import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Feature } from 'src/app/models/feature.model';

@Injectable({
  providedIn: 'root',
})
export class FeatureService {
  private apiServerUrl = `${environment.apiBaseUrl}feature`;
  constructor(private http: HttpClient) {}

  public GetFeatures(): Observable<Feature[]> {
    return this.http.get<Feature[]>(`${this.apiServerUrl}`);
  }

  public GetFeaturesByClassroom(id: number): Observable<Feature[]> {
    return this.http.get<Feature[]>(`${this.apiServerUrl}/${id}`);
  }
  public GetOtherFeaturesByClassroom(id: number): Observable<Feature[]> {
    return this.http.get<Feature[]>(`${this.apiServerUrl}/other/${id}`);
  }
  public CreateFeature(feature: Feature): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiServerUrl}`, feature);
  }

  public UpdateFeature(feature: Feature): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiServerUrl}`, feature);
  }

  public DeleteFeature(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiServerUrl}/${id}`);
  }
}
