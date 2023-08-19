import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlePreviewModalComponent } from './article-preview-modal.component';

describe('ArticlePreviewModalComponent', () => {
  let component: ArticlePreviewModalComponent;
  let fixture: ComponentFixture<ArticlePreviewModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArticlePreviewModalComponent]
    });
    fixture = TestBed.createComponent(ArticlePreviewModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
