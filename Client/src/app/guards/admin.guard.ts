import { CanActivateFn } from '@angular/router';
import { AccountService } from '../services/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable, map } from 'rxjs';

export const adminGuard: CanActivateFn = (): Observable<boolean> => {

  const accountService: AccountService = inject(AccountService);
  const toastr: ToastrService = inject(ToastrService)

  return accountService.currentUser$.pipe(
    map(user => {
      if (!user) return false;
      if (user.roles.includes('Admin') || user.roles.includes('Manager') || user.roles.includes('Teacher')) {
        return true;
      } else {
        toastr.error('Không thể truy cập!');
        return false;
      }
    })
  )
};
