using ChartApi.Data.Repository;
using ChartApi.Data.Infrastructure;
using ChartApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartApi.Core.Common;

namespace ChartApi.Service
{
    public interface IChartValueService
    {
        bool CreateChartValue(ChartValue chartValue);
        bool UpdateChartValue(ChartValue chartValue);
        bool DeleteChartValue(int id);
        ChartValue GetChartValue(int id);
        
        IEnumerable<ChartValue> GetAllChartValue();
        void SaveRecord();
    }

    public class ChartValueService : IChartValueService
    {
        private readonly IChartValueRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChartValueService()
        {
        }
                
        public ChartValueService(IChartValueRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool CreateChartValue(ChartValue chartValue)
        {
            bool isSuccess = true;
            try
            {
                countryRepository.Add(chartValue);                
                this.SaveRecord();
            }
            catch(Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool UpdateChartValue(ChartValue chartValue)
        {
            bool isSuccess = true;
            try
            {
                countryRepository.Update(chartValue);
                this.SaveRecord();
            }
            catch(Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool DeleteChartValue(int id)
        {
            bool isSuccess = true;
            var chartValue = countryRepository.GetById(id);
            try
            {
                countryRepository.Delete(chartValue);
                SaveRecord();
            }
            catch(Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public ChartValue GetChartValue(int id)
        {
            return countryRepository.GetById(id);
        }
               
        public IEnumerable<ChartValue> GetAllChartValue()
        {
            IEnumerable<ChartValue> countryList = countryRepository.GetAll();
            return countryList;
        }

        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}
