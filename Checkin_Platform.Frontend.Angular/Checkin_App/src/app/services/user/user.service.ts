import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User, UserLoginData } from '../../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiServerUrl = `${environment.apiBaseUrl}user`;
  constructor(private http: HttpClient) {}

  public GetUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiServerUrl}`);
  }
  public GetUsersByRole(role: String): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiServerUrl}/role/${role}`);
  }
  public GetUsersBySchedule(scheduleId: number): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiServerUrl}/${scheduleId}`);
  }
  public GetOtherUsersBySchedule(scheduleId: number): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiServerUrl}/other/${scheduleId}`);
  }
  public GetRoles(): Observable<String[]> {
    return this.http.get<String[]>(`${this.apiServerUrl}/roles`);
  }
  public CreateUser(user: User): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiServerUrl}`, user);
  }

  public UpdateUser(user: User): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiServerUrl}`, user);
  }

  public DeleteUser(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }

  public LoginUser(userLoginData: UserLoginData) {
    return this.http.post<User>(`${this.apiServerUrl}/login`, userLoginData);
  }
}
