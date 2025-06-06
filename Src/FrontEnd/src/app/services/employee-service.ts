import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeModel, EmployeeResponse } from '../Models/employee-model';
import { CreateModel } from '../Models/create-model';
import { API_URL } from '../../constant';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private baseUrl = 'https://localhost:7292/ALlEmployees';

  private url = API_URL;

  constructor(private http: HttpClient) {}

  getPagedEmployees(
    page: number,
    size: number,
    search?: string
  ): Observable<any> {
    let params: any = { page, size };
    if (search) {
      params.search = search;
    }

    return this.http.get<any>(
      `https://localhost:7292/ALlEmployees?pageNumber=${page}&pageSize=${size}`,
      { params }
    );
  }
  createEmployee(employee: CreateModel): Observable<any> {
    return this.http.post(this.url + '/Employee', employee);
  }

  getAllLocation() {
    return this.http.get<Location[]>(this.url + '/Location');
  }
}
export type Location = {
  locationId: number;
  locationName: string;
};
