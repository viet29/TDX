import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserAuth } from 'src/app/models/userAuth';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  @ViewChild('editForm') editForm: NgForm | undefined;
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm?.dirty) {
      $event.returnValue = true;
    }
  }
  userAuth: UserAuth | null = null;
  user: User | undefined;

  constructor(private accountService: AccountService, private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: userAuth => {
        if (userAuth) {
          this.userAuth = userAuth;
        }
      }
    });
  }

  openChangeAvatarFileChooser() {
    document.querySelector<HTMLInputElement>("#changeAvaUrl")!.click()
  }

  changeAvatar($event) {
    const file = <File>$event.target.files[0];
    const formData = new FormData();
    formData.append('file', file);

    this.accountService.changeAvatarImg(formData).subscribe({
      next: photo => {
        if (this.userAuth) {
          this.userAuth.avatarUrl = photo.url;
          this.accountService.setCurrentUser(this.userAuth);
          this.toastr.success("Đổi ảnh đại diện thành công!");
        }
        window.location.reload();
      },
      error: _ => {
        this.toastr.error("Đã xảy ra lỗi, xin thử lại sau!");
      }
    })
  }

  ngOnInit(): void {
    this.loadUserInfo();
  }

  loadUserInfo() {
    if (!this.userAuth)
      return;
    this.accountService.getUserInfo(this.userAuth.userName).subscribe({
      next: user => {
        this.user = user;
        console.log(user);
      }
    });
  }

  updateUser() {
    this.accountService.updateUser(this.editForm?.value).subscribe({
      next: () => {
        this.toastr.success('Thay đổi thành công!');
        this.userAuth!.fullName = this.editForm?.value.fullName;
        this.accountService.setCurrentUser(this.userAuth!);
        this.editForm?.reset(this.user);
        window.location.reload();
      }
    })
  }
}
