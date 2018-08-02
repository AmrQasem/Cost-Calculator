using CostCalc.API.DTO;
using CostCalc.BLL.Services;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CostCalc.API.Controllers
{
    public class QuotaionController : ApiController
    {
        GlobalErrors globalErrors = new GlobalErrors();
        QuotaionService _QuotaionService;

        public QuotaionController()
        {
            _QuotaionService = new QuotaionService(globalErrors);
        }
        [HttpPost]
        // POST api/quotation
        public HttpResponseMessage RequestQuotation([FromBody]QuotaionVM dataModel)
        {
            try
            {
                QuotationDM domainModel = dataModel.MapVM_DM();
                domainModel = _QuotaionService.GetQuotationForCategory(domainModel);

                var msg = Request.CreateResponse(HttpStatusCode.Created, domainModel);
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
