import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';
import { ArticlePreviewModalComponent } from '../modals/article-preview-modal/article-preview-modal.component';

@Component({
  selector: 'app-article-management',
  templateUrl: './article-management.component.html',
  styleUrls: ['./article-management.component.css']
})
export class ArticleManagementComponent implements OnInit {

  articles: Article[] = []
  bsModalRef: BsModalRef<ArticlePreviewModalComponent> = new BsModalRef<ArticlePreviewModalComponent>();

  constructor(private articleService: ArticleService, private toastr: ToastrService, private modalService: BsModalService) {

  }

  ngOnInit(): void {
    this.getArticles();
  }

  getArticles() {
    this.articleService.getArticlesAdmin().subscribe({
      next: articles => {
        this.articles = articles;
      }
    })
  }

  openViewModal(a: Article) {
    const config: ModalOptions = {
      class: 'modal-dialog-centered modal-xl',
      backdrop: true,
      ignoreBackdropClick: true,
      initialState: {
        article: a
      }
    }

    this.bsModalRef = this.modalService.show(ArticlePreviewModalComponent, config);
  }

  changeState(a: Article) {
    this.articleService.changeState(a).subscribe({
      next: _ => {
        this.toastr.success("Thay đổi thành công.");
        this.getArticles();
      }
    });
  }

  deleteArticle(a: Article) {
    this.articleService.deleteAticle(a).subscribe({
      next: _ => {
        this.toastr.success("Thay đổi thành công.");
        this.getArticles();
      }
    })
  }
}
