import { Component, HostListener, OnInit, TemplateRef } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  modelLogin: any = {};
  modelRegister: any = {};

  modalRegister?: BsModalRef | null;
  modalLogin?: BsModalRef | null;

  navbarFixed: boolean = false;

  constructor(protected accountService: AccountService,
    private modalService: BsModalService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {

  }

  // Account Management

  login() {
    this.accountService.login(this.modelLogin).subscribe({
      next: _ => {
        this.toastr.success("Đăng nhập thành công!")
        this.modalLogin?.hide();
      }
    })
  }

  register() {
    // console.log(this.modelRegister)
    this.accountService.register(this.modelRegister).subscribe({
      next: () => {
        // console.log(response);
        this.modalRegister?.hide();
      },
      error: err => {
        console.log(err);
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  // Modal Management

  openRegisterModal(template: TemplateRef<any>) {
    if (this.modalLogin) {
      this.closeModal(this.modalLogin);
    }
    this.modalRegister = this.modalService.show(template, { class: 'modal-lg' });
  }

  openLoginModal(template: TemplateRef<any>) {
    if (this.modalRegister) {
      this.closeModal(this.modalRegister);
    }
    this.modalLogin = this.modalService.show(template);
  }

  @HostListener('window:scroll', ['$event']) onScroll() {
    if (window.scrollY > 100)
      this.navbarFixed = true;
    else
      this.navbarFixed = false;
  }

  closeModal(modal: BsModalRef | null) {
    modal!.hide();
    modal = null;
  }

}
