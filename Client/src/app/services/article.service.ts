import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getArticles() {
    return this.http.get<Article[]>(this.baseUrl + 'articles');
  }

  addArticle(article: Article) {
    return this.http.post<Article>(this.baseUrl + 'articles', article);
  }


}
