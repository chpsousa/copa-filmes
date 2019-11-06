using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopaFilmes.Domain.Commands.Movies.Entities
{
	public class Match
	{
		public Movie Movie1 { get; set; }
		public Movie Movie2 { get; set; }
		public Movie Winner { get; set; }
		public Movie Loser { get; set; }

		public Match() { }

		public Match(Movie movie1, Movie movie2)
		{
			this.Movie1 = movie1;
			this.Movie2 = movie2;
		}

		public void PlayMatch()
		{
			if (this.Movie1 == null || this.Movie2 == null)
				throw new InvalidOperationException("Movie1 or Movie2 cannot be null");

			if (this.Movie1.Score == this.Movie2.Score)
			{
				var _movies = new List<Movie>();
				_movies.Add(this.Movie1);
				_movies.Add(this.Movie2);

				_movies = _movies.OrderBy(m => m.Title).ToList();
				this.Winner = _movies.ElementAt(0);
				this.Loser = _movies.ElementAt(1);
				return;
			}

			this.Winner = this.Movie1.Score > this.Movie2.Score ? this.Movie1 : this.Movie2;
			this.Loser = this.Movie1.Score > this.Movie2.Score ? this.Movie2 : this.Movie1;
		}
	}
}
