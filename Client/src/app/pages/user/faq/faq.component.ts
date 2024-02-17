import { Component, OnInit } from '@angular/core';
import { Faq } from 'src/app/models/faq';
import { FaqService } from 'src/app/services/faq.service';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css'],
})
export class FaqComponent implements OnInit {

  faqs: Faq[] = []

  constructor(private faqService: FaqService) {

  }

  ngOnInit(): void {
    this.loadFaqs();
  }

  loadFaqs() {
    this.faqService.getAllFaqs().subscribe({
      next: faqs => {
        this.faqs = faqs;
      }
    });
  }
}
