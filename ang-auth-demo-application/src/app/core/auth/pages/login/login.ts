import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth-services';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  email: string = '';
  password: string=  '';
  constructor(private authService: AuthService) {}

  onSubmit() {
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        console.log('Login successful', response);
        this.authService.isLoggedIn.set(true);
        // redirect to home page
      },
      error: (err) => {
        console.error('Login failed', err);
      }
    });
  }
}
