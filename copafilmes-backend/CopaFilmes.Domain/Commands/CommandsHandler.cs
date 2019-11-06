using CopaFilmes.Domain.Util;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Commands
{
	public class CommandsHandler
	{
		public CommandsHandler()
		{
		}

		public async Task<CommandResult> Handle(ICommand command)
		{
			var result = await command.GetErrorAsync(this);
			if (result != null && result.ErrorCode != ErrorCode.None)
				return result;

			result = await command.ExecuteAsync(this);
			if (result != null && result.ErrorCode != ErrorCode.None)
				return result;
			return result;
		}
	}
}
