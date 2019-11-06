using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Domain.Commands.Movies.Entities;
using CopaFilmes.Domain.Util;

namespace CopaFilmes.Domain.Commands.Movies
{
	public class PlayChampionshipCommand : ICommand
	{
		public List<Movie> Movies { get; set; }
		public async Task<CommandResult> GetErrorAsync(CommandsHandler handler)
		{
			if (Movies.Count() < 8)
				return await Task.FromResult(new CommandResult(ErrorCode.InvalidParameters, "Movies list should have 8 movies"));
			return null;
		}
		public async Task<CommandResult> ExecuteAsync(CommandsHandler handler)
		{
			var obj = new Championship();
			obj.AddMovies(Movies);

			obj.GenerateQuartersFinals();
			obj.PlayQuarterFinals();

			obj.GenerateSemiFinals();
			obj.PlaySemiFinals();

			obj.GenerateFinals();
			obj.PlayFinals();

			var rs = new List<Movie>();
			rs.Add(obj.First);
			rs.Add(obj.Second);

			return await Task.FromResult(new CommandResult(rs));
		}

	}
}
