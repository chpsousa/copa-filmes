using CopaFilmes.Domain.Commands;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Util
{
	public interface ICommand
	{
		Task<CommandResult> GetErrorAsync(CommandsHandler handler);
		Task<CommandResult> ExecuteAsync(CommandsHandler handler);
	}
}
