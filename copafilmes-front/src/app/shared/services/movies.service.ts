import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IMovie } from '../models/movie.interface';


@Injectable({providedIn: 'root'})
export class MoviesService {

  results: IMovie[] = [];

  constructor(
    private http: HttpClient
  ) { }

  getMovies(): Observable<IMovie[]> {
    const url = `https://copadefilmes.azurewebsites.net/api/movies`;
    return this.http.get<IMovie[]>(url)
      .pipe(
        map((data: IMovie[]) => {
          console.log(data);
          return data;
        })
      );
  }

  playChampionship(movies: IMovie[]): Observable<IMovie[]> {
    const url = `https://copadefilmes.azurewebsites.net/api/movies`;
    const data = { Movies: movies };
    return this.http.post<IMovie[]>(url, data);
  }
}
