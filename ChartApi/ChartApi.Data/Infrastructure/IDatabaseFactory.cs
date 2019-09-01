using System;
using ChartApi.Data;

namespace ChartApi.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationEntities Get();
    }
}
