import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Classroom } from './classroom.model';


@Injectable({
  providedIn: 'root'
})
export class ClassroomService {
  private apiServerUrl = `${environment.apiBaseUrl}/classroom`;
  constructor(private http: HttpClient) { }

  public GetClassrooms(): Observable<Classroom[]>{
    return this.http.get<Classroom[]>(`${this.apiServerUrl}`);
  }

  public CreateClassroom(classroom: Classroom): Observable<boolean>{
    return this.http.post<boolean>(`${this.apiServerUrl}`,classroom);
  }

  public UpdateClassroom(classroom: Classroom): Observable<boolean>{
    return this.http.put<boolean>(`${this.apiServerUrl}`,classroom);
  }

  public DeleteClassroom(id: number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }
}
