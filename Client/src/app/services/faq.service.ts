import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Faq } from '../models/faq';

@Injectable({
  providedIn: 'root'
})
export class FaqService {

  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllFaqs() {
    return this.http.get<Faq[]>(this.baseUrl + 'faqs');
  }

  addFaq(a: Faq) {
    return this.http.post<Faq>(this.baseUrl + 'faqs', a);
  }

  deleteFaq(a: Faq) {
    return this.http.delete(this.baseUrl + 'faqs/' + a.id);
  }

  updateFaq(a: Faq) {
    return this.http.put(this.baseUrl + 'faqs', a);
  }
}
