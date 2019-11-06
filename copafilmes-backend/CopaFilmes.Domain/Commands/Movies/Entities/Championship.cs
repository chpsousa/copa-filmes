using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Commands.Movies.Entities
{
	public class Championship
	{
		public Movie First { get; set; }
		public Movie Second { get; set; }
		private List<Movie> _allMovies { get; set; }
		public IReadOnlyCollection<Movie> AllMovies { get => _allMovies.OrderBy(m => m.Title).ToList().AsReadOnly(); }

		private List<Match> _quarterFinals { get; set; }
		public IReadOnlyCollection<Match> QuarterFinals { get => _quarterFinals.AsReadOnly(); }

		private List<Match> _semiFinals { get; set; }
		public IReadOnlyCollection<Match> SemiFinals { get => _semiFinals.AsReadOnly(); }

		public Match Finals { get; set; }

		public Championship()
		{
			this._allMovies = new List<Movie>();
			this._quarterFinals = new List<Match>();
			this._semiFinals = new List<Match>();
		}

		public void AddMovie(Movie movie)
		{
			if (AllMovies.Count < 8)
				this._allMovies.Add(movie);
			else
				throw new InvalidOperationException("movies list cannot be greater than 8");
		}

		public void AddMovies(List<Movie> movies)
		{
			foreach (var movie in movies)
				AddMovie(movie);
		}

		public void GenerateQuartersFinals()
		{
			if (this.AllMovies == null || this.AllMovies.Count() < 8 || this.AllMovies.Count() > 8)
				throw new InvalidOperationException("AllMovies should have 8 movies");

			this._quarterFinals.Add(new Match(this.AllMovies.ElementAt(0), this.AllMovies.ElementAt(7)));
			this._quarterFinals.Add(new Match(this.AllMovies.ElementAt(1), this.AllMovies.ElementAt(6)));
			this._quarterFinals.Add(new Match(this.AllMovies.ElementAt(2), this.AllMovies.ElementAt(5)));
			this._quarterFinals.Add(new Match(this.AllMovies.ElementAt(3), this.AllMovies.ElementAt(4)));
		}

		public void GenerateSemiFinals()
		{
			if (this.QuarterFinals == null || this.QuarterFinals.Count() == 0 || this.QuarterFinals.Any(m => m.Winner == null))
				throw new InvalidOperationException("Quarterfinals must be finished");

			this._semiFinals.Add(new Match(this.QuarterFinals.ElementAt(0).Winner, this.QuarterFinals.ElementAt(3).Winner));
			this._semiFinals.Add(new Match(this.QuarterFinals.ElementAt(1).Winner, this.QuarterFinals.ElementAt(2).Winner));
		}

		public void GenerateFinals()
		{
			if (this.SemiFinals == null || this.SemiFinals.Count() == 0 || this.SemiFinals.Any(m => m.Winner == null))
				throw new InvalidOperationException("Semifinals must be finished");

			this.Finals = new Match(this.SemiFinals.ElementAt(0).Winner, this.SemiFinals.ElementAt(1).Winner);
		}

		public void PlayQuarterFinals()
		{
			if (this.QuarterFinals == null || this.QuarterFinals.Count() == 0)
				throw new InvalidOperationException("Quarterfinals must be generated");

			foreach (var match in this.QuarterFinals)
				match.PlayMatch();
		}

		public void PlaySemiFinals()
		{
			if (this.SemiFinals == null || this.SemiFinals.Count() == 0)
				throw new InvalidOperationException("Semifinals must be generated");

			foreach (var match in this.SemiFinals)
				match.PlayMatch();
		}

		public void PlayFinals()
		{
			if (this.Finals == null)
				throw new InvalidOperationException("Finals must be generated");

			this.Finals.PlayMatch();

			this.First = this.Finals.Winner;
			this.Second = this.Finals.Loser;
		}
	}
}
