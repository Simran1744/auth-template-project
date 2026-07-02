import { Component, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { CONST_ROUTES } from '../../../shared/constants/routes.constants';
import { AuthService } from '../../services/auth-services';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
    authService = inject(AuthService);
    readonly CONST_ROUTES = CONST_ROUTES;
}
