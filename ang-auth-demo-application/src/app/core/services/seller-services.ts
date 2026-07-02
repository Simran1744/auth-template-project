// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SellerProfile } from '../../shared/models/seller.model';

@Injectable({ providedIn: 'root' })
export class SellerService {
  private apiUrl = 'http://localhost:5009/api/seller';

  constructor(private http: HttpClient) {}

  getSellerProfile() {
    return this.http.get<SellerProfile>(`${this.apiUrl}/me`);
  }

  applyAsSeller(displayname: string, bio: string, avatarUrl: string, nexusModsProfileUrl: string, 
    githubProfileUrl: string, websiteUrl: string) {
    return this.http.post(`${this.apiUrl}/apply`, {displayname, bio, avatarUrl,
        nexusModsProfileUrl, githubProfileUrl, websiteUrl});
  }

  updateProfile(displayname: string, bio: string, avatarUrl: string, nexusModsProfileUrl: string, 
    githubProfileUrl: string, websiteUrl: string) {
    return this.http.put(`${this.apiUrl}/updateProfile`, {displayname, bio, avatarUrl,
        nexusModsProfileUrl, githubProfileUrl, websiteUrl});
  }

 /*TODO: Implement Logout*/
  /*logout() { 
    return this.http.post(`${this.apiUrl}/logout`, {});
  }*/
}