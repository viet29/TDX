import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Faq } from 'src/app/models/faq';
import { AddFaqModalComponent } from '../modals/add-faq-modal/add-faq-modal.component';
import { FaqService } from 'src/app/services/faq.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-faq-management',
  templateUrl: './faq-management.component.html',
  styleUrls: ['./faq-management.component.css']
})
export class FaqManagementComponent implements OnInit {

  faqs: Faq[] = []
  bsModalRef: BsModalRef<AddFaqModalComponent> = new BsModalRef<AddFaqModalComponent>();

  constructor(private faqService: FaqService, private modalService: BsModalService, private toastr: ToastrService) {

  }

  ngOnInit(): void {
    this.getAllFaqs();
  }

  getAllFaqs() {
    this.faqService.getAllFaqs().subscribe({
      next: faqs => {
        this.faqs = faqs
      }
    })
  }

  deleteFaq(f: Faq) {
    this.faqService.deleteFaq(f).subscribe({
      next: _ => {
        this.toastr.success("Xoá thành công!");
        this.getAllFaqs();
      }
    })
  }

  addNewFaq() {
    const config: ModalOptions = {
      class: 'modal-dialog-centered modal-lg',
      backdrop: true,
      ignoreBackdropClick: true,
    }

    this.bsModalRef = this.modalService.show(AddFaqModalComponent, config);
  }

  editFaq(f: Faq) {

  }
}
