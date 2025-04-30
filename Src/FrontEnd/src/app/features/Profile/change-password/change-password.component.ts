import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-change-password',
  imports: [ FormsModule,CommonModule],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
// change-password.component.ts
 
export class ChangePasswordComponent {
  passwordModel = {
    oldPassword: '',
    newPassword: '',
    confirmPassword: ''
  };

  showPassword = false;

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  onChangePassword() {
    const { oldPassword, newPassword, confirmPassword } = this.passwordModel;

    if (!oldPassword || !newPassword || !confirmPassword) {
      alert("Please fill in all fields.");
      return;
    }

    if (newPassword !== confirmPassword) {
      alert("New password and confirm password do not match.");
      return;
    }

    // Call your password change service or logic here
    console.log('Password changed:', this.passwordModel);
  }
}


