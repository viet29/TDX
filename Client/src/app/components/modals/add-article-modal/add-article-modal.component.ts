import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-add-article-modal',
  templateUrl: './add-article-modal.component.html',
  styleUrls: ['./add-article-modal.component.css']
})
export class AddArticleModalComponent implements OnInit {

  article: any = {}
  addArticleForm;

  constructor(protected bsModalRef: BsModalRef, private articleService: ArticleService, private toastr: ToastrService) { }

  ngOnInit(): void {

  }

  addArticle() {
    console.log(this.article.title, this.article.body)
    this.articleService.addArticle(this.article).subscribe({
      next: _ => {
        console.log("Success");
        this.toastr.success("Thêm thành công");
        window.location.reload();
      }
    })
  }
}
