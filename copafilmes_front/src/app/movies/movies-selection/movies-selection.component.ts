import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/app/shared/models/movie.interface';
import { MoviesService } from '../../shared/services/movies.service';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-movies-selection',
  templateUrl: './movies-selection.component.html',
  styleUrls: ['./movies-selection.component.scss']
})
export class MoviesSelectionComponent implements OnInit {

  movies: IMovie[] = new Array<IMovie>();
  results: IMovie[];
  selectedMovies: IMovie[] = new Array<IMovie>();
  subscribe1: Subscription;
  subscribe2: Subscription;

  constructor(
    private snackBar: MatSnackBar,
    public moviesService: MoviesService,
    public router: Router
  ) { }

  ngOnInit() {
    this.subscribe1 = this.moviesService.getMovies().subscribe(data => this.movies = data);
  }

  addOrRemoveMovie(checked: boolean, movie: IMovie) {
    if (checked)
      this.selectedMovies.push(movie);
    else
      this.selectedMovies = this.selectedMovies.filter(m => m.id !== movie.id);
  }

  generate() {
    if (this.selectedMovies.length === 0) {
      this.snackBar.open('Selecione 8 filmes', 'OK', {
        duration: 5000,
      });
      return;
    }

    if (this.selectedMovies.length > 8) {
      this.snackBar.open('Selecione apenas 8 filmes', 'OK', {
        duration: 5000,
      });
      return;
    }

    if (this.selectedMovies.length < 8) {
      this.snackBar.open('Selecione mais ' + (8 - this.selectedMovies.length) + ' filmes', 'OK', {
        duration: 2000,
      });
      return;
    }

    this.subscribe2 = this.moviesService.playChampionship(this.selectedMovies)
      .subscribe(rs => {
          this.moviesService.results.push(rs[0]);
          this.moviesService.results.push(rs[1]);
          this.router.navigate(['result']);
        }
      );
  }
}
