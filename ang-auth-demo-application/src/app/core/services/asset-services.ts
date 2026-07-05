// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Asset } from '../../shared/models/asset.model';

@Injectable({ providedIn: 'root' })
export class AssetService {
  private apiUrl = 'http://localhost:5009/api/assets';

  constructor(private http: HttpClient) {}

  getAllAssets() {
    return this.http.get<Asset[]>(`${this.apiUrl}/getAssets`);
  }


 /*TODO: Implement Logout*/
  /*logout() { 
    return this.http.post(`${this.apiUrl}/logout`, {});
  }*/
}