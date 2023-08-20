import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-article-preview-modal',
  templateUrl: './article-preview-modal.component.html',
  styleUrls: ['./article-preview-modal.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ArticlePreviewModalComponent implements OnInit {

  article!: Article

  constructor(protected bsModalRef: BsModalRef, private articleService: ArticleService) {

  }

  ngOnInit(): void {
    this.articleService.getArticleById(this.article.id).subscribe({
      next: article => {
        this.article = article;
      }
    })
  }


}
