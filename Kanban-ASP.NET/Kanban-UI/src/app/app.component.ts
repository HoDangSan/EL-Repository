import { NgModule, Component, ViewChild, AfterViewInit, enableProdMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import {AssignedEmployee, Owner, Task} from '../app/models/task.model';

import { Service } from './app.service';
import { DxScrollViewModule, DxSortableModule } from 'devextreme-angular';
import {TaskService} from './task/task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  preserveWhitespaces: true
})

export class AppComponent {
  lists: any[] = [];
  statuses: string[] = [];
  task: Task;
  popupVisible = false;
  //
  constructor(public service: Service, public taskService: TaskService) {
    service.GetTaskList().subscribe((lists) => {
      lists.forEach(list => {
        this.statuses.push(list.name);
        this.lists.push(list.tasks);
      });
      // this.lists.forEach(list => {
      //   list.push(this.taskEmpty);
      // });
    });
  }

  onListReorder(e) {
    const list = this.lists.splice(e.fromIndex, 1)[0];
    this.lists.splice(e.toIndex, 0, list);

    const status = this.statuses.splice(e.fromIndex, 1)[0];
    this.statuses.splice(e.toIndex, 0, status);
  }

  onTaskDragStart(e) {
    e.itemData = e.fromData[e.fromIndex];
  }

  onTaskDrop(e) {
    e.fromData.splice(e.fromIndex, 1);
    e.toData.splice(e.toIndex, 0, e.itemData);
    // tslint:disable-next-line:no-unused-expression
    e.toIndex;
    // tslint:disable-next-line:no-unused-expression
    const listId = e.toComponent._$element[0].id;
    // get index before and after
    const beforeIndex = (e.toData[e.toIndex - 1] == null) ? 0 : e.toData[e.toIndex - 1].indexTask;
    const afterIndex = (e.toData[e.toIndex + 1] == null) ? 0 : e.toData[e.toIndex + 1].indexTask;
    // change index
    let Index;
    if (beforeIndex === 0 && afterIndex === 0) {
      Index = 1;
    } else if (beforeIndex === 0) {
      Index = afterIndex / 2;
    } else if (afterIndex === 0) {
      Index  = beforeIndex + 1;
    } else {
      Index = (beforeIndex + afterIndex) / 2;
    }
    // api update
    const obj = e.itemData;
    obj.listId = Number(listId) + 1;
    obj.indexTask = Index;
    this.service.UpdateTask(obj.id, obj).subscribe();
  }

  // onTaskA(e) {
  //   e.fromData;
  //   e.toData;
  //   debugger;
  // }

  showFormCreate(e) {
    this.popupVisible = true;
    this.task = new Task();
    const listId = Number(e.toElement.id);
    this.task.indexTask = this.lists[listId][this.lists[listId].length - 1].indexTask + 1;
    this.task.listId = listId + 1;
  }

  showFormEdit(e) {
    this.taskService.GetTask(e.id).subscribe((task) => {
      this.task = task;

      this.popupVisible = true;
    });
  }

  onTaskChange() {
    this.lists = [];
    this.service.GetTaskList().subscribe((lists) => {
      lists.forEach(list => {
        this.lists.push(list.tasks);
      });
    });
  }
}
