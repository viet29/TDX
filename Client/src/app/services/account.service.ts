import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, of } from 'rxjs';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';
import { Photo } from '../models/photo';
import { UserAuth } from '../models/userAuth';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl: string = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<UserAuth | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {

  }

  login(model: any) {
    return this.http.post<UserAuth>(this.baseUrl + 'account/login', model).pipe(
      map((response: UserAuth) => {
        const userAuth = response;
        if (userAuth) {
          this.setCurrentUser(userAuth);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post<UserAuth>(this.baseUrl + 'account/register', model).pipe(
      map(userAuth => {
        if (userAuth) {
          this.setCurrentUser(userAuth);
        }
      })
    )
  }

  setCurrentUser(userAuth: UserAuth) {
    userAuth.roles = []
    const roles = this.getDecodedToken(userAuth.token).role;

    Array.isArray(roles) ? userAuth.roles = roles : userAuth.roles.push(roles);

    localStorage.setItem('user', JSON.stringify(userAuth));
    this.currentUserSource.next(userAuth);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  getUserInfo(username: string) {
    return this.http.get<User>(this.baseUrl + 'users/' + username);
  }

  updateUser(user: User) {
    return this.http.put(this.baseUrl + 'account/edit', user);
  }

  changeAvatarImg(photo: FormData) {
    return this.http.post<Photo>(this.baseUrl + 'account/updateAvatar', photo);
  }

  changePassword(model: any) {
    return this.http.post(this.baseUrl + 'account/changePassword', model);
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }
}
