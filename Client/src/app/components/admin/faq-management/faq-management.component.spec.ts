import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FaqManagementComponent } from './faq-management.component';

describe('FaqManagementComponent', () => {
  let component: FaqManagementComponent;
  let fixture: ComponentFixture<FaqManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FaqManagementComponent]
    });
    fixture = TestBed.createComponent(FaqManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
