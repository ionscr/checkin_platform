import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiServerUrl = `${environment.apiBaseUrl}/user`;
  constructor(private http: HttpClient) { }

  public GetUsers(): Observable<User[]>{
    return this.http.get<User[]>(`${this.apiServerUrl}`);
  }

  public CreateUser(user: User): Observable<boolean>{
    return this.http.post<boolean>(`${this.apiServerUrl}`,user);
  }

  public UpdateUser(user: User): Observable<boolean>{
    return this.http.put<boolean>(`${this.apiServerUrl}`,user);
  }

  public DeleteUser(id: number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }
}
