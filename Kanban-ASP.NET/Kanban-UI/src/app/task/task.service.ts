import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Task} from '../models/task.model';
import {catchError, retry, map} from 'rxjs/operators';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  // Base url
  baseurl = 'https://localhost:44301/api';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // GET EMPLOYEES
  GetEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseurl + '/employees/')
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  //
  // POST
  CreateTask(data): Observable<Task> {
    return this.http.post<Task>(this.baseurl + '/tasks', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // GET TASKS
  GetTask(id): Observable<Task> {
    return this.http.get<Task>(this.baseurl + '/tasks/ ' + id)
      .pipe(map(data => data));
  }

  // DELETE
  DeleteTask(id) {
    return this.http.delete<Task>(this.baseurl + '/tasks/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // Error handling
  errorHandl(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
