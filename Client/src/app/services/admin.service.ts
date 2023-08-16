import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<User[]>(this.baseUrl + 'admin/users');
  }

  updateUserRoles(username: string, roles: string[]) {
    return this.http.get<string[]>(this.baseUrl + 'admin/edit/'
      + username + '?roles=' + roles, {});
  }
}
