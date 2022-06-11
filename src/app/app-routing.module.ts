import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './home-page';
import { ViewMovieDetailComponent } from './view-movie-detail';


const routes: Routes = [
  { path:'', component: HomepageComponent },
  { path: 'home', component: HomepageComponent },
  { path: 'view/:id', component: ViewMovieDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
