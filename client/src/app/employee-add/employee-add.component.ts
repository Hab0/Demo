import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent {
  employee: Employee = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    position: '',
    department: ''
  };

  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  addEmployee(): void {
    this.employeeService.addEmployee(this.employee).subscribe(() => {
      this.router.navigate(['/employee-list']);
    });
  }
}
