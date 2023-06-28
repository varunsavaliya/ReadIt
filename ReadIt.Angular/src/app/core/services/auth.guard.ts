import { CanActivateFn, Router } from '@angular/router';
import { UserAuthService } from './user-auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const userAuthService = new UserAuthService();
  const router = new Router();
  if (userAuthService.isLoggedIn()) {
    const currentRoute = window.location.href;
    const requestedRoute = state.url;
    if (requestedRoute.includes('login') || requestedRoute.includes('signup')) {
      if(currentRoute.includes('home')){
        return false;
      }
      router.navigate(['home']);
      return false;
    }
    return true;
  }
  else {
    const requestedRoute = state.url;
    if (requestedRoute.includes('login') || requestedRoute.includes('signup')) {
      return true;
    }
    router.navigate(['auth', 'login']);
    return false;
  }
};
