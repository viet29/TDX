import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {

  baseUrl = 'https://localhost:5001/api/';
  validationErrors: string[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

  }

  get404Error() {
    this.http.get(this.baseUrl + 'error/notfound').subscribe({
      next: response => {
        console.log(response);
      },
      error: err => console.log(err)
    })
  }

  get400Error() {
    this.http.get(this.baseUrl + 'error/badrequest').subscribe({
      next: response => {
        console.log(response);
      },
      error: err => console.log(err)
    })
  }

  get500Error() {
    this.http.get(this.baseUrl + 'error/servererror').subscribe({
      next: response => {
        console.log(response);
      },
      error: err => console.log(err)
    })
  }

  get401Error() {
    this.http.get(this.baseUrl + 'error/auth').subscribe({
      next: response => {
        console.log(response);
      },
      error: err => console.log(err)
    })
  }

  get400ValidationError() {
    this.http.post(this.baseUrl + 'account/register', {}).subscribe({
      next: response => {
        console.log(response);
      },
      error: err => {
        console.log(err);
        this.validationErrors = err;
      }
    })
  }

}
