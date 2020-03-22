import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Task} from '../models/task.model';
import {TaskService} from './task.service';
import {Service} from '../app.service';

const input = Input;

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  // tslint:disable-next-line:variable-name
  private _visible: boolean;
  employees: any[] = [];
  visibleWarring = false;
  withShadingOptionsVisible = false;
  visibleChangeChecklistAction = false;

  @Input()
  get visible(): boolean {
    return this._visible;
  }

  set visible(value: boolean) {
    this._visible = value;
    this.visibleChange.emit(value);
  }

  @Input() task: Task;

  // tslint:disable-next-line:no-output-on-prefix
  @Output() onTaskChange = new EventEmitter();

  @Output() visibleChange = new EventEmitter<boolean>();

  allowEditing = true;

  today: Date = new Date();

  constructor(public taskService: TaskService, public service: Service) {
    taskService.GetEmployees().subscribe((employees) =>
      employees.forEach(employee => this.employees.push(employee))
    );
  }

  ngOnInit() {
    this.task.assignedEmployeeId = 2;
    this.task.ownerId = 1;
  }

  close() {
    this.visible = false;
  }

  saveTask() {
    if (this.task.id) {
      this.service.UpdateTask(this.task.id, this.task).subscribe((data) => {
        this.onTaskChange.emit();
      });
    } else {
      this.taskService.CreateTask(this.task).subscribe((data) => {
        this.onTaskChange.emit();
        this.visible = false;
      });
    }
  }

  deleteTask() {
    this.taskService.DeleteTask(this.task.id).subscribe((data) => {
      this.onTaskChange.emit();
      this.visibleWarring = false;
      this.visible = false;
    });
  }

  showWarring() {
    this.visibleWarring = true;
  }

  closeWarring() {
    this.visibleWarring = false;
  }

  toggleWithShadingOptions() {
    this.withShadingOptionsVisible = !this.withShadingOptionsVisible;
  }

  withShadingOptionsVisibleChecklistAction() {
    this.visibleChangeChecklistAction = !this.visibleChangeChecklistAction;
  }


  valueTextArea: string;

  editChecklist(e) {

  }
}
