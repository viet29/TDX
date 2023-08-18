import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { take } from 'rxjs';
import { UserAuth } from '../models/userAuth';

@Directive({
  selector: '[appHasRole]' // *appHasRole='["Admin", "..."]'
})
export class HasRoleDirective implements OnInit {

  @Input() appHasRole: string[] = [];
  userAuth: UserAuth = {} as UserAuth;

  constructor(private viewContainerRef: ViewContainerRef,
    private templateRef: TemplateRef<any>,
    private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: userAuth => {
        if (userAuth)
          this.userAuth = userAuth
      }
    })
  }

  ngOnInit(): void {
    if (this.userAuth.roles.some(r => this.appHasRole.includes(r))) {
      this.viewContainerRef.createEmbeddedView(this.templateRef);
    } else {
      this.viewContainerRef.clear();
    }
  }

}
