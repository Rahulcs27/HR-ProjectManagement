import { Component } from '@angular/core';
// import { NgForm } from '@angular/forms';
import { UserService } from '../../../services/user.service';  
// import {   } from '@angular/forms';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css'],
  imports: [FormsModule, CommonModule, RouterModule],
})
export class ChangePasswordComponent {
  passwordModel = {
    oldPassword: '',
    newPassword: '',
    confirmPassword: ''
  };

  showPassword = false;

  constructor(private userService: UserService) {}

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  onChangePassword(form: NgForm) {
    if (!form.valid) {
      alert('Please fill in all fields.');
      return;
    }

    if (this.passwordModel.newPassword !== this.passwordModel.confirmPassword) {
      alert('New passwords do not match.');
      return;
    }

    const requestData = {
      userName: String(localStorage.getItem('userName')),
      oldPassword: this.passwordModel.oldPassword,
      newPassword: this.passwordModel.newPassword,
      confirmPassword: this.passwordModel.confirmPassword
    };
    console.log(requestData);
    
    this.userService.updatePasswords(requestData).subscribe({
      next:(res:string) => {
        alert('Password updated successfully!');
        form.resetForm();
      },
      error: (err) => {
        console.error(err);
        if(err.status == 200)
        {
          alert('Password Updated Successfully.');
        }
        else
        {
          alert('Error updating password.');
        }
      }
    });
  }
}
