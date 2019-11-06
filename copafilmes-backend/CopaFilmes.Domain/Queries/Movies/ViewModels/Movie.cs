using CopaFilmes.Domain.Util;
using Newtonsoft.Json;

namespace CopaFilmes.Domain.Queries.Movies.ViewModels
{
	public class Movie : IViewModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("titulo")]
		public string Title { get; set; }
		[JsonProperty("ano")]
		public int Year { get; set; }
		[JsonProperty("nota")]
		public decimal Score { get; set; }
	}
}
