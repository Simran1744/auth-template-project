// src/app/services/auth.service.ts
import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5009/api/auth';

  isLoggedIn = signal<boolean>(false);

  constructor(private http: HttpClient) {
    this.checkAuthStatus();
  }

  private checkAuthStatus() {
    this.http.get(`${this.apiUrl}/me`).subscribe({
      next: () => this.isLoggedIn.set(true),
      error: () => this.isLoggedIn.set(false)
    });
  }

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