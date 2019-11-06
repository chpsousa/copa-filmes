import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MoviesService } from 'src/app/shared/services/movies.service';
import { IMovie } from 'src/app/shared/models/movie.interface';

@Component({
  selector: 'app-movies-result',
  templateUrl: './movies-result.component.html',
  styleUrls: ['./movies-result.component.scss']
})
export class MoviesResultComponent implements OnInit {

  results: IMovie[] = [];

  constructor(
    private moviesService: MoviesService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.results = this.moviesService.results;
  }

  reset() {
    this.moviesService.results = [];
    this.results = [];
    this.router.navigate(['movies']);
  }

}
