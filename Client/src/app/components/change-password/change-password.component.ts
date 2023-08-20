import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  model: any = {}

  constructor(private accountService: AccountService, private toastr: ToastrService) {

  }

  ngOnInit(): void {

  }

  changePassword() {
    this.accountService.changePassword(this.model).subscribe({
      next: _ => {
        this.toastr.success("Đổi mật khẩu thành công!");
        window.location.reload();
      }
    })
  }
}
