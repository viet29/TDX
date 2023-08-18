import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddArticleModalComponent } from './add-article-modal.component';

describe('AddArticleModalComponent', () => {
  let component: AddArticleModalComponent;
  let fixture: ComponentFixture<AddArticleModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddArticleModalComponent]
    });
    fixture = TestBed.createComponent(AddArticleModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
