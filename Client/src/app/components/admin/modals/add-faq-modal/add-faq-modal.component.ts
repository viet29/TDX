import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Faq } from 'src/app/models/faq';
import { FaqService } from 'src/app/services/faq.service';

@Component({
  selector: 'app-add-faq-modal',
  templateUrl: './add-faq-modal.component.html',
  styleUrls: ['./add-faq-modal.component.css']
})
export class AddFaqModalComponent implements OnInit {

  faqModel: Faq | any = {}

  constructor(private faqService: FaqService, private toastr: ToastrService, protected bsModalRef: BsModalRef) {

  }


  ngOnInit(): void {

  }

  addFaq() {
    this.faqService.addFaq(this.faqModel).subscribe({
      next: _ => {
        this.toastr.success("Thêm thành công");
      }
    })
  }
}
