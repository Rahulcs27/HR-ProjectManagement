import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DivisionService {
  private apiurl :"";

  constructor(private http:HttpClient) { }
  getAllDivisions(): Observable<GetDivisionDto[]> {
      return this.http.get<GetDivisionDto[]>(this.apiUrl);
    }
  
    createDivisions(dto: CreateDivisionDto): Observable<any> {
      return this.http.post(this.apiUrl, dto);
    }
  
    updateDivisions(dto: UpdateDivisionDto): Observable<any> {
      return this.http.put(this.apiUrl, dto);
    }
    softDeleteDivisions(id: number, newStatus: number): Observable<any> {
      return this.http.delete(`${this.apiUrl}/${id}`);
    }
}
