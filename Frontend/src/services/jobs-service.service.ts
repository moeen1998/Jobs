import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseObject } from '../Interfaces/ResponseObject';
import { JobApplication } from '../Interfaces/JobApplication';

@Injectable({
  providedIn: 'root'
})
export class JobsServiceService {


  apiUrl = 'https://localhost:7161/api/jobs';

  constructor(private http: HttpClient) { }

  getAllPositions(): Observable<ResponseObject> {
    return this.http.get<ResponseObject>(`${this.apiUrl}/ListJobs`);
  }
  getJobById(id: number): Observable<ResponseObject> {
    console.log(id);
    return this.http.get<ResponseObject>(`${this.apiUrl}/ViewDetails?ID=${id}`);
  }

  submitApplication(application: JobApplication): Observable<ResponseObject> {
    console.log(application);
    return this.http.post<ResponseObject>(`${this.apiUrl}/Apply`, application);
  }

}
