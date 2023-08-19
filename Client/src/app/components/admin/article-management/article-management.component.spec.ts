import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleManagementComponent } from './article-management.component';

describe('ArticleManagementComponent', () => {
  let component: ArticleManagementComponent;
  let fixture: ComponentFixture<ArticleManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArticleManagementComponent]
    });
    fixture = TestBed.createComponent(ArticleManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
