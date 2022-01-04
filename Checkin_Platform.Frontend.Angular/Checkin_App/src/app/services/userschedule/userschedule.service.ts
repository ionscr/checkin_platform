import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
  UserSchedule,
  UserScheduleDto,
} from 'src/app/models/userschedule.model';

@Injectable({
  providedIn: 'root',
})
export class UserScheduleService {
  private apiServerUrl = `${environment.apiBaseUrl}userschedule`;
  constructor(private http: HttpClient) {}

  public GetUserSchedules(): Observable<UserSchedule[]> {
    return this.http.get<UserSchedule[]>(`${this.apiServerUrl}`);
  }

  public CreateUserSchedule(
    userSchedule: UserScheduleDto
  ): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiServerUrl}`, userSchedule);
  }

  public DeleteUserSchedule(
    userSchedule: UserScheduleDto
  ): Observable<boolean> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: userSchedule,
    };
    return this.http.delete<boolean>(`${this.apiServerUrl}`, options);
  }
}
