// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5009/api/auth';

  constructor(private http: HttpClient) {}

  login(email: string, password: string) {
    return this.http.post(`${this.apiUrl}/login`, { email, password });
  }

  register(username: string, email: string, password: string, confirmPassword: string) {
    return this.http.post(`${this.apiUrl}/register`, {username, email, password, confirmPassword });
  }

 /*TODO: Implement Logout*/
  /*logout() { 
    return this.http.post(`${this.apiUrl}/logout`, {});
  }*/
}