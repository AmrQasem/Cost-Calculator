using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CostCalc.BLL.Services;
using CostCalc.Helper.ExceptionHandling;
using CostCalc.API.DTO;
using CostCalc.Domain.Models;

namespace CostCalc.API.Controllers
{
    public class QuotationController : ApiController
    {
        GlobalErrors globalErrors = new GlobalErrors();
        QuotationService _QuotationService;

        public QuotationController()
        {
            _QuotationService = new QuotationService(globalErrors);
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage RequestQuotation(QuotationVM dataModel)
        {
            QuotationDM domainModel = dataModel.MapVM_DM();
            domainModel = _QuotationService.GetQuotationForCategory(domainModel);

            var response = Request.CreateResponse(HttpStatusCode.OK, domainModel);
            return response;
        }
    }
}