import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth-services';
import { FormsModule } from '@angular/forms';
import { NgClass } from '@angular/common';
import { Router } from '@angular/router';
import { inject } from '@angular/core';


@Component({
  selector: 'app-register',
  imports: [FormsModule, NgClass],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
    username: string = '';
    email: string = '';
    password1: string =  '';
    password2: string =  ''; 
    passwordError: boolean = false;
    passwordHint: string = 'Re-enter password to confirm';

    private router = inject(Router);

    constructor(private authService: AuthService) {}
  
    onSubmit() {
      if (this.password1 != this.password2) {
        this.passwordError = true;
        this.passwordHint = "Passwords don't match!";
        return;
      }

      this.authService.register(this.username, this.email, this.password1, this.password2).subscribe({
        next: (response) => {
          console.log('Registration successful', response);
          // redirect to home page
          this.router.navigate(['']);
        },
        error: (err) => {
          console.error('Registration failed', err);
        }
      });
    }
}
