import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselComponent } from './components/carousel/carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
