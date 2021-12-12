import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ClassroomFeature } from '../models/ClassroomFeature';

@Injectable({
  providedIn: 'root'
})
export class ClassroomFeatureService {
  private apiServerUrl = `${environment.apiBaseUrl}/classroomfeature`;
  constructor(private http: HttpClient) { }

  public GetClassroomFeatures(): Observable<ClassroomFeature[]>{
    return this.http.get<ClassroomFeature[]>(`${this.apiServerUrl}`);
  }

  public CreateClassroomFeature(classroomFeature: ClassroomFeature): Observable<boolean>{
    return this.http.post<boolean>(`${this.apiServerUrl}`,classroomFeature);
  }

  public DeleteClassroomFeature(id: number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }
}
