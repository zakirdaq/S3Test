using ChartApi.ClientModel;
using ChartApi.Model;
using ChartApi.Service;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace ChartApi.Web.Controllers
{
    public class ChartValueController : ApiController
    {
        public readonly IChartValueService ChartValueService;

        public ChartValueController(IChartValueService chartValueService)
        {
            this.ChartValueService = chartValueService;
        }

        // GET api/ChartValue
        public JsonResult<List<ChartValueModel>> GetAll()
        {
            var ChartValueListObj = this.ChartValueService.GetAllChartValue();
            List<ChartValueModel> ChartValueVMList = new List<ChartValueModel>();

            foreach (var ChartValue in ChartValueListObj)
            {
                ChartValueModel ChartValueTemp = new ChartValueModel();
                ChartValueTemp.Id = ChartValue.Id;
                ChartValueTemp.Time = ChartValue.Time.ToString(@"hh\:mm");
                ChartValueTemp.Value = ChartValue.Value.Value.ToString();

                ChartValueVMList.Add(ChartValueTemp);
            }
            return Json(ChartValueVMList);
        }

        // GET api/ChartValue/5
        public JsonResult<ChartValueModel> Get(int id)
        {
            var ChartValue = this.ChartValueService.GetChartValue(id);
            ChartValueModel ChartValueTemp = new ChartValueModel();
            ChartValueTemp.Id = ChartValue.Id;
            ChartValueTemp.Time = ChartValue.Time.ToString(@"hh\:mm");
            ChartValueTemp.Value = ChartValue.Value.Value.ToString();

            return Json(ChartValueTemp);
        }

        // POST api/ChartValue
        [HttpPost()]
        public string Post(ChartValue chartValue)
        {
            //var isSuccess = false;
            var message = string.Empty;
            var isNew = ChartValueService.GetChartValue(chartValue.Id);

            return message;
        }

        // DELETE api/ChartValue/5
        [HttpDelete()]
        public string Delete(int id)
        {
            var isSuccess = true;
            var message = string.Empty;

            isSuccess = this.ChartValueService.DeleteChartValue(id);
            if (isSuccess)
            {
                message = "ChartValue deleted successfully!";

            }
            else
            {
                message = "ChartValue can't be deleted!";
            }

            return message;
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}