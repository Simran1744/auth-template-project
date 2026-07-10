// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Asset } from '../../shared/models/asset.model';
import { PagedResult } from '../../shared/models/pagedResult.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AssetService {
  private apiUrl = 'http://localhost:5009/api/assets';

  constructor(private http: HttpClient) {}

  getAllAssets() {
    return this.http.get<Asset[]>(`${this.apiUrl}/getAssets`);
  }

  getPagedAssets(page: number, pageSize: number): Observable<PagedResult<Asset>> {
    const parms = new HttpParams()
      .set('pageNumber', page.toString())
      .set('pageSize', pageSize.toString());
    return this.http.get<PagedResult<Asset>>(`${this.apiUrl}/getPagedAssets`, { params: parms });
  }

  getMostDownloadedAssets() {
    return this.http.get<Asset[]>(`${this.apiUrl}/getMostDownloadedAssets`);
  }

  getFeaturedAssets() {
    return this.http.get<Asset[]>(`${this.apiUrl}/getFeaturedAssets`);
  }


 /*TODO: Implement Logout*/
  /*logout() { 
    return this.http.post(`${this.apiUrl}/logout`, {});
  }*/
}