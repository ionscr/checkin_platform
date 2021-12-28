import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
  ClassroomFeature,
  ClassroomFeatureDto,
} from 'src/app/models/classroomfeature.model';

@Injectable({
  providedIn: 'root',
})
export class ClassroomFeatureService {
  private apiServerUrl = `${environment.apiBaseUrl}classroomfeature`;
  constructor(private http: HttpClient) {}

  public GetClassroomFeatures(): Observable<ClassroomFeature[]> {
    return this.http.get<ClassroomFeature[]>(`${this.apiServerUrl}`);
  }

  public CreateClassroomFeature(
    classroomFeature: ClassroomFeatureDto
  ): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiServerUrl}`, classroomFeature);
  }

  public DeleteClassroomFeature(
    classroomFeature: ClassroomFeatureDto
  ): Observable<boolean> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: classroomFeature,
    };
    return this.http.delete<boolean>(`${this.apiServerUrl}`, options);
  }
}
