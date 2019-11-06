import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutMainComponent } from './shared/layout/layout-main/layout-main.component';
import { MoviesSelectionComponent } from './movies/movies-selection/movies-selection.component';
import { MoviesResultComponent } from './movies/movies-result/movies-result.component';
import { IMovie } from './shared/models/movie.interface';

const routes: Routes = [
  {
    path: '', component: LayoutMainComponent, children: [
       { path: '', redirectTo: 'movies', pathMatch: 'full' },
       { path: 'movies', component: MoviesSelectionComponent },
       { path: 'result', component: MoviesResultComponent }
    ]
  }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
