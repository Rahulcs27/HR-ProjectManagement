import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthResponseModel, Login } from '../../Models/login';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  UserName='';
  login: Login = new Login('', '',false);
  errorMessage='';
  formSubmitted = false;

  constructor(private router:Router,private userService: UserService) {}
  ngonInit() { }

  loginUser(loginForm: NgForm) {
    this.login = loginForm.value;
    console.log(this.login);
    // this.router.navigate(['/otp'])
    this.formSubmitted=true;
    if (loginForm.invalid) {
      return;
    }   
    this.login = loginForm.value;
    console.log(this.login);


    this.userService.login(this.login).subscribe({
      next: (response: AuthResponseModel) => {
        console.log(response)
        localStorage.setItem('otp', response.otp);
        localStorage.setItem('email', response.email);  
        loginForm.reset();
        this.router.navigate(['/otp']);
      }, error: (error) => {
        console.error('Login failed!', error);
        alert("Invalid email or password. Please try again");
        console.log(error.error.message);
      }
    });
  }

  
}
