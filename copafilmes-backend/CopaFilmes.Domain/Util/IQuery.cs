using CopaFilmes.Domain.Queries;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Util
{
	public interface IQuery
	{
		bool IsValid();
		Task<IViewModel[]> ExecuteAsync(QueriesHandler queriesHandler);
	}
}
