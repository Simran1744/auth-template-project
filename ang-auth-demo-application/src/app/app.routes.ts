import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { CONST_ROUTES } from './shared/constants/routes.constants'
import { Register } from './core/auth/pages/register/register';
import { Login } from './core/auth/pages/login/login';

export const routes: Routes = [
    {
        path: CONST_ROUTES.HOME,
        title: 'App Home Page',
        component: Home,
    },
    {
        path: CONST_ROUTES.AUTH.REGISTER,
        title: 'Sign Up',
        component: Register,
    },
    {
        path: CONST_ROUTES.AUTH.LOGIN,
        title: 'Login',
        component: Login,
    },


];
