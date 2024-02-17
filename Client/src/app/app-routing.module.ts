import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/user/home/home.component';
import { ArticleListComponent } from './pages/user/article-list/article-list.component';
import { ArticleDetailsComponent } from './pages/user/article-details/article-details.component';
import { AboutsComponent } from './pages/user/abouts/abouts.component';
import { authGuard } from './guards/auth.guard';
import { ErrorComponent } from './pages/errors/error/error.component';
import { AdminPanelComponent } from './pages/admin/admin-panel/admin-panel.component';
import { adminGuard } from './guards/admin.guard';
import { UserProfileComponent } from './pages/user/user-profile/user-profile.component';
import { FaqComponent } from './pages/user/faq/faq.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'articles', component: ArticleListComponent },
  { path: 'articles/:id', component: ArticleDetailsComponent },
  { path: 'about-us', component: AboutsComponent },
  { path: 'faq', component: FaqComponent },
  {
    path: '', runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'profile', component: UserProfileComponent },
      { path: 'admin', component: AdminPanelComponent, canActivate: [adminGuard] },
    ]
  },
  { path: 'errors', component: ErrorComponent },
  // { path: 'error'},
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
