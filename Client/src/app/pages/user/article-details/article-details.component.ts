import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ArticleDetailsComponent implements OnInit {

  article!: Article

  safeHtmlContent!: SafeHtml;

  constructor(private route: ActivatedRoute, private articleService: ArticleService, private sanitizer: DomSanitizer) {

  }

  ngOnInit(): void {
    this.getArticleDetail();
  }

  getArticleDetail() {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      this.articleService.getArticleById(parseInt(id!)).subscribe({
        next: article => {
          this.article = article;
          this.safeHtmlContent = this.sanitizer.bypassSecurityTrustHtml(this.article.body);
        }
      });
    })
  }
}
