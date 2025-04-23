import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ActivateEmployeeService } from '../../../../services/activate-employee-service';
import { ActivateEmployeeModel } from '../../../../Models/activate-employee-model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-activate-employee',
  standalone: true,
  imports: [CommonModule, MatDialogModule, FormsModule],
  templateUrl: './activate-employee.component.html',
  styleUrl: './activate-employee.component.css'
})
export class ActivateEmployeeComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<ActivateEmployeeComponent>,
    private activateemployeecomponentservice :ActivateEmployeeService
  ) {}

  activate(): void {
    this.activateemployeecomponentservice.activateEmployee(this.data.employeeCode).subscribe({
          next: (res: ActivateEmployeeModel) => {
            alert(res.message); 
            this.dialogRef.close(true);
          },
          error: (err) => {
            console.error(err);
            alert('Failed to Activate employee');
          }
        });

  }

  close(): void {
    this.dialogRef.close();
  }
}