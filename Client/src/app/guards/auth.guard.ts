import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Observable, map } from 'rxjs';

export const authGuard: CanActivateFn = (): Observable<boolean> => {

  const accountService: AccountService = inject(AccountService)
  const toastr: ToastrService = inject(ToastrService)

  return accountService.currentUser$.pipe(
    map(user => {
      if (user) {
        return true;
      } else {
        toastr.error("Vui lòng đăng nhập trước");
        return false;
      }
    })
  )

};
