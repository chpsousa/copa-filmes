using CopaFilmes.Domain.Util;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Queries
{
	public class QueriesHandler
	{
		public QueriesHandler()
		{
		}

		public async Task<IViewModel[]> RunQuery(IQuery query)
		{
			if (!query.IsValid())
				return null;
			return await query.ExecuteAsync(this);
		}
	}
}
