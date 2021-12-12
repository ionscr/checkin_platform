import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Schedule } from '../models/Schedule';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  private apiServerUrl = `${environment.apiBaseUrl}/schedule`;
  constructor(private http: HttpClient) { }

  public GetSchedules(): Observable<Schedule[]>{
    return this.http.get<Schedule[]>(`${this.apiServerUrl}`);
  }

  public CreateSchedule(schedule: Schedule): Observable<boolean>{
    return this.http.post<boolean>(`${this.apiServerUrl}`,schedule);
  }

  public UpdateSchedule(schedule: Schedule): Observable<boolean>{
    return this.http.put<boolean>(`${this.apiServerUrl}`,schedule);
  }

  public DeleteSchedule(id: number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }
}
