import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddArticleModalComponent } from 'src/app/components/modals/add-article-modal/add-article-modal.component';
import { Article } from 'src/app/models/article';
import { AccountService } from 'src/app/services/account.service';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {

  articles: Article[] = [];
  bsModalRef: BsModalRef<AddArticleModalComponent> = new BsModalRef<AddArticleModalComponent>();

  public htmlData: string = "hello"
  public readonly: boolean = true;

  constructor(private articleService: ArticleService, private modalService: BsModalService,
    protected accountService: AccountService) {

  }

  ngOnInit(): void {
    this.loadArticles();
  }

  loadArticles() {
    this.articleService.getArticles().subscribe({
      next: articles => {
        this.articles = articles
        console.log(articles);
      }
    })
  }

  openAddArticleModal() {
    const config: ModalOptions = {
      class: 'modal-xl',
      backdrop: true,
      ignoreBackdropClick: true
    }

    this.bsModalRef = this.modalService.show(AddArticleModalComponent, config);
  }

}
