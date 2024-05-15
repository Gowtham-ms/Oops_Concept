import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './services/employee.service';
import { Employee } from './models/employee';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  // form group is return type & EmployeeFormGroup is my variable name
  EmployeeFG: FormGroup;
  isVisible: boolean = false;
  isFlag: boolean = false;
  constructor(private EmployeeService: EmployeeService, private FormsBuilder: FormBuilder) {
    // here creating object for this formsbuilder to assign our values
    this.EmployeeFG = this.FormsBuilder.group({
      employeeId: ["00000000-0000-0000-0000-000000000000"],
      employeeName: [""],
      mobileNumber: [],
      emailID: [""]
    })
  }
  // string values = "";
  EmpArray: Employee[] = [];

  // title = 'CRUD_UI';
  // page loading
  ngOnInit(): void {
    this.getEmployee()
  }
  getEmployee() {
    this.EmployeeService.GetEmployee().subscribe(response => {
      this.EmpArray = response;
    });
  }
  OnSubmit() {
    if (!this.isFlag) {
      this.EmployeeService.CreateEmployee(this.EmployeeFG.value).subscribe(
        response => {
          this.getEmployee();
        }
      );
    }
    else {
      console.log(this.EmployeeFG.value);
      this.EmployeeService.UpdateEmployee(this.EmployeeFG.value).subscribe(
        response => {
          this.getEmployee();
        });
    }

  }
  FillForm(emp: Employee) {
    this.isVisible = true;
    this.isFlag = true;
    this.EmployeeFG.setValue({
      employeeId: emp.employeeId,
      employeeName: emp.employeeName,
      mobileNumber: emp.mobileNumber,
      emailID: emp.emailID
    })
  }
}
