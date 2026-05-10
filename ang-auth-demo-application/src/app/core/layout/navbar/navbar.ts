import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CONST_ROUTES } from '../../../shared/constants/routes.constants';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
    readonly CONST_ROUTES = CONST_ROUTES;
}
