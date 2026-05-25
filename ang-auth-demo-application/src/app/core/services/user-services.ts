// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserProfile } from '../../shared/models/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private apiUrl = 'http://localhost:5009/api/users';

  constructor(private http: HttpClient) {}

  getProfile() {
    return this.http.get<UserProfile>(`${this.apiUrl}/me`);
  }

  updateProfile(username: string, bio: string, avatarUrl: string) {
    return this.http.put(`${this.apiUrl}/updateProfile`, {username, bio, avatarUrl});
  }

 /*TODO: Implement Logout*/
  /*logout() { 
    return this.http.post(`${this.apiUrl}/logout`, {});
  }*/
}