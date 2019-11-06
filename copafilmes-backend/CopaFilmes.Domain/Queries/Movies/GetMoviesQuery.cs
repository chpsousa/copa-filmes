using CopaFilmes.Domain.Queries.Movies.ViewModels;
using CopaFilmes.Domain.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Queries.Movies
{
	public class GetMoviesQuery : IQuery
	{
		public async Task<IViewModel[]> ExecuteAsync(QueriesHandler queriesHandler)
		{
			var result = null as IEnumerable<Movie>;
			using (HttpClient client = new HttpClient())

			using (HttpResponseMessage res = await client.GetAsync("http://copafilmes.azurewebsites.net/api/filmes"))
			using (HttpContent content = res.Content)
			{
				string data = await content.ReadAsStringAsync();
				if (data != null)
					result = JsonConvert.DeserializeObject<IEnumerable<Movie>>(data);
			}

			return result.ToArray();
		}
		public bool IsValid()
		{
			return true;
		}
	}
}
