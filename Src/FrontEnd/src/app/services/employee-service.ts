
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeResponse } from '../Models/employee-model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl = 'https://localhost:7292/ALlEmployees';

  constructor(private http: HttpClient) {}


  getPagedEmployees(page: number, size: number, search?: string): Observable<any> {
    let params: any = { page, size };
    if (search) {
      params.search = search;
    }
  
    return this.http.get<any>(`${this.baseUrl}?pageNumber=${page}&pageSize=${size}`, { params });
  }
  
}
