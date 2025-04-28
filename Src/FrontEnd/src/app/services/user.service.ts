import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponseModel, Login } from '../Models/login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl:string = "https://localhost:7292/api/Login/login";
  constructor(private http:HttpClient) { }
  login(loginUser:Login):Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(`${this.apiUrl}`, loginUser);
  }

  resendOtp(loginUser: Login): Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(`${this.apiUrl}/resend-otp`, loginUser);
  }

}
