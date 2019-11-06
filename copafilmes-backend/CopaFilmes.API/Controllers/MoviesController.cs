using CopaFilmes.Domain.Commands;
using CopaFilmes.Domain.Commands.Movies;
using CopaFilmes.Domain.Queries;
using CopaFilmes.Domain.Queries.Movies;
using CopaFilmes.Domain.Util;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CopaFilmes.API.v1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly CommandsHandler _commandsHandler;
		private readonly QueriesHandler _queriesHandler;

		public MoviesController(CommandsHandler commandsHandler, QueriesHandler queriesHandler)
		{
			_commandsHandler = commandsHandler;
			_queriesHandler = queriesHandler;
		}

		[HttpGet]
		public async Task<object> Get([FromQuery] GetMoviesQuery query)
		{
			var data = await _queriesHandler.RunQuery(query);
			return data;
		}

		public async Task<ActionResult<string>> Post([FromBody] PlayChampionshipCommand command)
		{
			var result = await _commandsHandler.Handle(command);
			return Ok(result.ResultData);
		}
	}
}