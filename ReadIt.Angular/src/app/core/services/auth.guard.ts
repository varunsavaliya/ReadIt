import { CanActivateFn, Router } from '@angular/router';
import { UserAuthService } from './user-auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const userAuthService = new UserAuthService();
  const router = new Router();
  if (userAuthService.isLoggedIn()) {
    return true;
  }
  else {
    router.navigate(['']);
    return false;
  }
};
