import { Component, OnInit, TemplateRef } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  modelLogin: any = {};
  modelRegister: any = {};

  modalRegister?: BsModalRef;
  modalLogin?: BsModalRef;

  constructor(protected accountService: AccountService, private modalService: BsModalService) { }

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.modelLogin).subscribe({
      next: response => {
        this.modalLogin?.hide();

      },
      error: err => {
        console.log(err);
      }
    })
  }

  register() {
    // console.log(this.modelRegister)
    this.accountService.register(this.modelRegister).subscribe({
      next: response => {
        console.log(response);
        this.modalRegister?.hide();
      },
      error: err => console.log(err)
    })
  }

  logout() {
    this.accountService.logout();
  }

  openRegisterModal(template: TemplateRef<any>) {
    if (this.modalLogin) {
      this.modalLogin.hide();
    }
    this.modalRegister = this.modalService.show(template);
  }

  openLoginModal(template: TemplateRef<any>) {
    if (this.modalRegister) {
      this.modalRegister.hide();
    }
    this.modalLogin = this.modalService.show(template);
  }

}
