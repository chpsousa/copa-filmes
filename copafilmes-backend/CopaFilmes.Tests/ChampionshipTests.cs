using CopaFilmes.Domain.Commands.Movies.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Tests
{
	[TestClass]
	public class ChampionshipTests
	{
		[TestMethod]
		public void AddMoviesTest()
		{
			var obj = new Championship();
			var movies = GetMovies();
			obj.AddMovies(movies);

			Assert.AreEqual(obj.AllMovies.Count(), 8);

			obj = new Championship();
			obj.AddMovie(movies.ElementAt(0));

			Assert.AreEqual(obj.AllMovies.Count(), 1);

			try
			{
				obj.AddMovies(movies);
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}
		}

		[TestMethod]
		public void GenerateQuarterFinalsTest()
		{
			var obj = new Championship();
			AddMovies(obj);

			obj.GenerateQuartersFinals();

			Assert.IsNotNull(obj.QuarterFinals);
			Assert.AreEqual(obj.QuarterFinals.Count(), 4);
			Assert.AreEqual(obj.QuarterFinals.ElementAt(0).Movie1.Id, "a");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(0).Movie2.Id, "h");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(1).Movie1.Id, "b");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(1).Movie2.Id, "g");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(2).Movie1.Id, "c");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(2).Movie2.Id, "f");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(3).Movie1.Id, "d");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(3).Movie2.Id, "e");
			Assert.IsNull(obj.QuarterFinals.ElementAt(0).Winner);
		}

		[TestMethod]
		public void GenerateSemiFinalsTest()
		{
			var obj = new Championship();
			AddMovies(obj);

			Assert.IsNotNull(obj.AllMovies);

			obj.GenerateQuartersFinals();

			Assert.IsNotNull(obj.QuarterFinals);
			Assert.AreEqual(obj.QuarterFinals.Count(), 4);

			try
			{
				obj.GenerateSemiFinals();
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}

			obj.PlayQuarterFinals();
			obj.GenerateSemiFinals();

			Assert.IsNotNull(obj.SemiFinals);
			Assert.AreEqual(obj.SemiFinals.Count(), 2);
			Assert.AreEqual(obj.SemiFinals.ElementAt(0).Movie1.Id, "h");
			Assert.AreEqual(obj.SemiFinals.ElementAt(0).Movie2.Id, "e");
			Assert.AreEqual(obj.SemiFinals.ElementAt(1).Movie1.Id, "g");
			Assert.AreEqual(obj.SemiFinals.ElementAt(1).Movie2.Id, "f");
		}

		[TestMethod]
		public void GenerateFinalsTest()
		{
			var obj = new Championship();
			AddMovies(obj);

			Assert.AreEqual(obj.AllMovies.Count(), 8);

			obj.GenerateQuartersFinals();

			Assert.AreEqual(obj.QuarterFinals.Count(), 4);

			obj.PlayQuarterFinals();
			obj.GenerateSemiFinals();

			try
			{
				obj.GenerateFinals();
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}

			obj.PlaySemiFinals();

			obj.GenerateFinals();

			Assert.IsNotNull(obj.Finals);
		}

		[TestMethod]
		public void PlayQuarterFinalsTest()
		{
			var obj = new Championship();
			AddMovies(obj);

			try
			{
				obj.PlayQuarterFinals();
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}

			Assert.AreEqual(obj.AllMovies.Count(), 8);

			obj.GenerateQuartersFinals();

			Assert.AreEqual(obj.QuarterFinals.Count(), 4);

			obj.PlayQuarterFinals();

			foreach (var match in obj.QuarterFinals)
			{
				Assert.IsNotNull(match.Winner);
				Assert.IsNotNull(match.Loser);
			}

			Assert.AreEqual(obj.QuarterFinals.ElementAt(0).Winner.Id, "h");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(0).Loser.Id, "a");

			Assert.AreEqual(obj.QuarterFinals.ElementAt(1).Winner.Id, "g");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(1).Loser.Id, "b");

			Assert.AreEqual(obj.QuarterFinals.ElementAt(2).Winner.Id, "f");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(2).Loser.Id, "c");

			Assert.AreEqual(obj.QuarterFinals.ElementAt(3).Winner.Id, "e");
			Assert.AreEqual(obj.QuarterFinals.ElementAt(3).Loser.Id, "d");

		}

		[TestMethod]
		public void PlaySemiFinalsTest()
		{
			var obj = new Championship();
			AddMovies(obj);

			try
			{
				obj.PlaySemiFinals();
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}

			Assert.AreEqual(obj.AllMovies.Count(), 8);

			obj.GenerateQuartersFinals();

			Assert.AreEqual(obj.QuarterFinals.Count(), 4);

			obj.PlayQuarterFinals();
			obj.GenerateSemiFinals();

			Assert.AreEqual(obj.SemiFinals.Count(), 2);

			obj.PlaySemiFinals();

			foreach (var match in obj.SemiFinals)
			{
				Assert.IsNotNull(match.Winner);
				Assert.IsNotNull(match.Loser);
			}

			Assert.AreEqual(obj.SemiFinals.ElementAt(0).Winner.Id, "h");
			Assert.AreEqual(obj.SemiFinals.ElementAt(0).Loser.Id, "e");

			Assert.AreEqual(obj.SemiFinals.ElementAt(1).Winner.Id, "g");
			Assert.AreEqual(obj.SemiFinals.ElementAt(1).Loser.Id, "f");
		}

		[TestMethod]
		public void PlayFinalsTest()
		{
			var obj = new Championship();
			AddMovies(obj);
			Assert.AreEqual(obj.AllMovies.Count(), 8);
			
			try
			{
				obj.PlayFinals();
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}

			obj.GenerateQuartersFinals();
			obj.PlayQuarterFinals();
			obj.GenerateSemiFinals();
			obj.PlaySemiFinals();
			obj.GenerateFinals();
			obj.PlayFinals();

			Assert.IsNotNull(obj.First);
			Assert.IsNotNull(obj.Second);
			Assert.AreEqual(obj.First.Id, "h");
			Assert.AreEqual(obj.Second.Id, "g");
		}

		public List<Movie> GetMovies()
		{
			var movies = new List<Movie>();
			movies.Add(new Movie("a", "movie1", 2018, 1));
			movies.Add(new Movie("b", "movie2", 2018, 2));
			movies.Add(new Movie("c", "movie3", 2018, 3));
			movies.Add(new Movie("d", "movie4", 2018, 4));
			movies.Add(new Movie("e", "movie5", 2018, 5));
			movies.Add(new Movie("f", "movie6", 2018, 6));
			movies.Add(new Movie("g", "movie7", 2018, 7));
			movies.Add(new Movie("h", "movie8", 2018, 8));

			return movies;
		}

		public void AddMovies(Championship obj)
		{
			obj.AddMovies(GetMovies());
		}
	}
}
