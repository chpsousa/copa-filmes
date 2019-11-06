using CopaFilmes.Domain.Commands.Movies.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Tests
{
	[TestClass]
	public class MatchTests
	{
		[TestMethod]
		public void MatchTest()
		{
			var obj = new Match();

			try
			{
				obj.PlayMatch();
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is InvalidOperationException);
			}

			var movie1 = new Movie("a", "movie1", 2019, 9);
			var movie2 = new Movie("b", "movie2", 2010, 7);
			obj = new Match(movie1, movie2);

			Assert.IsNotNull(obj.Movie1);
			Assert.IsNotNull(obj.Movie2);
			Assert.AreEqual(obj.Movie1.Id, movie1.Id);
			Assert.AreEqual(obj.Movie1.Id, movie1.Id);
		}

		[TestMethod]
		public void PlayMatchTest()
		{
			var movie1 = new Movie("a", "movie1", 2019, 9);
			var movie2 = new Movie("b", "movie2", 2010, 7);
			var obj = new Match(movie1, movie2);

			obj.PlayMatch();

			Assert.IsNotNull(obj.Winner);
			Assert.IsNotNull(obj.Loser);
			Assert.AreEqual(obj.Winner.Id, obj.Movie1.Id);
			Assert.AreEqual(obj.Loser.Id, obj.Movie2.Id);
		}

		[TestMethod]
		public void PlayMatchEqualScoreTest()
		{
			var movie1 = new Movie("b", "b", 2010, 9);
			var movie2 = new Movie("a", "a", 2019, 9);
			var obj = new Match(movie1, movie2);

			obj.PlayMatch();

			Assert.IsNotNull(obj.Winner);
			Assert.IsNotNull(obj.Loser);
			Assert.AreEqual(obj.Winner.Id, obj.Movie2.Id);
			Assert.AreEqual(obj.Loser.Id, obj.Movie1.Id);
		}
	}
}
