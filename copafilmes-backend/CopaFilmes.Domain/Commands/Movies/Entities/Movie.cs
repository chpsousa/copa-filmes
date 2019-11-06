using Newtonsoft.Json;

namespace CopaFilmes.Domain.Commands.Movies.Entities
{
	public class Movie
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("titulo")]
		public string Title { get; set; }
		[JsonProperty("ano")]
		public int Year { get; set; }
		[JsonProperty("nota")]
		public decimal Score { get; set; }

		public Movie() { }

		public Movie(string id, string title, int year, decimal score)
		{
			this.Id = id;
			this.Title = title;
			this.Year = year;
			this.Score = score;
		}
	}
}
