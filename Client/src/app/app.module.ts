import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselComponent } from './components/carousel/carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { NavComponent } from './components/nav/nav.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/user/home/home.component';
import { ArticleListComponent } from './pages/user/article-list/article-list.component';
import { ArticleDetailsComponent } from './pages/user/article-details/article-details.component';
import { AboutsComponent } from './pages/user/abouts/abouts.component';
import { ErrorComponent } from './pages/errors/error/error.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { AdminPanelComponent } from './pages/admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './directives/has-role.directive';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { UserManagementComponent } from './components/admin/user-management/user-management.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { EditUserModalComponent } from './components/admin/modals/edit-user-modal/edit-user-modal.component';
import { UserProfileComponent } from './pages/user/user-profile/user-profile.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { MyCkEditorComponent } from './components/my-ck-editor/my-ck-editor.component';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { AddArticleModalComponent } from './components/modals/add-article-modal/add-article-modal.component';
import { ArticleCardComponent } from './components/article-card/article-card.component';
import { ArticleManagementComponent } from './components/admin/article-management/article-management.component';
import { ArticlePreviewModalComponent } from './components/admin/modals/article-preview-modal/article-preview-modal.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { FaqManagementComponent } from './components/admin/faq-management/faq-management.component';
import { AddFaqModalComponent } from './components/admin/modals/add-faq-modal/add-faq-modal.component';
import { FaqComponent } from './pages/user/faq/faq.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    CarouselComponent,
    HomeComponent,
    ArticleListComponent,
    ArticleDetailsComponent,
    AboutsComponent,
    ErrorComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    EditUserModalComponent,
    UserProfileComponent,
    MyCkEditorComponent,
    AddArticleModalComponent,
    ArticleCardComponent,
    ArticleManagementComponent,
    ArticlePreviewModalComponent,
    ChangePasswordComponent,
    FaqManagementComponent,
    AddFaqModalComponent,
    FaqComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgbModule,
    CKEditorModule,
    NgxSpinnerModule.forRoot({
      type: 'line-scale-party'
    }),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    AccordionModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),
    AccordionModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },


  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
