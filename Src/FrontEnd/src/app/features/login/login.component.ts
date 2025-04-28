import { CommonModule } from '@angular/common';
import { Component, OnInit, NgZone } from '@angular/core'; // <-- Added NgZone
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthResponseModel, Login } from '../../Models/login';
import { UserService } from '../../services/user.service';
declare var bootstrap: any;

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  UserName = '';
  login: Login = new Login('', '', false);
  otpDigits: string[] = ['', '', '', ''];
  isVerifying = false;
  errorMessage = '';
  formSubmitted = false;

  constructor(
    private router: Router,
    private userService: UserService,
    private ngZone: NgZone   // <-- Injected NgZone
  ) {}

  ngOnInit() { }

  loginUser(loginForm: NgForm) {
    this.login = loginForm.value;
    this.formSubmitted = true;
    if (loginForm.invalid) {
      return;
    }
    this.login = loginForm.value;

    this.userService.login(this.login).subscribe({
      next: (response: AuthResponseModel) => {
        localStorage.setItem('otp', response.otp);
        localStorage.setItem('email', response.email);
        loginForm.reset();

        const modalElement = document.getElementById('otpModal');
        const otpModal = new bootstrap.Modal(modalElement);
        otpModal.show();
      },
      error: (error) => {
        console.error('Login failed!', error);
        alert("Invalid email or password. Please try again");
      }
    });
  }

  verifyOtp() {
    this.isVerifying = true;

    setTimeout(() => {
      const enteredOtp = this.otpDigits.join('');
      const storedOtp = localStorage.getItem('otp');

      if (enteredOtp === storedOtp) {
        alert('OTP Verified Successfully!');
        const modalElement = document.getElementById('otpModal');
        const otpModal = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
        otpModal.hide();
        localStorage.setItem('isAuthenticated', 'true');
        this.router.navigate(['/dashboard']);

      } else {
        alert('Incorrect OTP. Please try again.');
      }

      this.isVerifying = false;
    }, 1500);
  }

  moveToNext(event: any, index: number) {
    const input = event.target;
    if (input.value.length === 1 && index < 3) {
      const nextInput = input.parentElement.children[index + 1];
      nextInput.focus();
    }
  }

  moveToPrev(event: any, index: number) {
    const input = event.target;
    if (input.value.length === 0 && index > 0) {
      const prevInput = input.parentElement.children[index - 1];
      prevInput.focus();
    }
  }

  resendOtp() {
    alert('OTP Resent Successfully!');
  }
}
