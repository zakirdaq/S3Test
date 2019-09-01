using ChartApi.Data.Infrastructure;
using ChartApi.Model;

namespace ChartApi.Data.Repository
{
    public class ChartValueRepository : RepositoryBase<ChartValue>, IChartValueRepository
    {
        public ChartValueRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IChartValueRepository : IRepository<ChartValue>
    {
    }

}
