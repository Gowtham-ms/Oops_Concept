import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  // dependency injection
  constructor(private _HttpClient: HttpClient) {
  }
  // call our api so I set it as global variable
  api_Url = "http://localhost:5112/api/Employee"

  // get employee details
  GetEmployee(): Observable<Employee[]> {
    return this._HttpClient.get<Employee[]>(this.api_Url)
  }

  // creating employee details
  CreateEmployee(emp: Employee): Observable<Employee> {
    return this._HttpClient.post<Employee>(this.api_Url, emp)
  }
  UpdateEmployee(emp: Employee): Observable<Employee> {
    return this._HttpClient.put<Employee>(this.api_Url + '/' + emp.employeeId, emp)
  }
}
