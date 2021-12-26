import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Class } from 'src/app/models/class.model';

@Injectable({
  providedIn: 'root',
})
export class ClassService {
  private apiServerUrl = `${environment.apiBaseUrl}class`;
  constructor(private http: HttpClient) {}

  public GetClasses(): Observable<Class[]> {
    return this.http.get<Class[]>(`${this.apiServerUrl}`);
  }

  public CreateClass(class_to_add: Class): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiServerUrl}`, class_to_add);
  }

  public UpdateClass(class_to_update: Class): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiServerUrl}`, class_to_update);
  }

  public DeleteClass(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }
}
