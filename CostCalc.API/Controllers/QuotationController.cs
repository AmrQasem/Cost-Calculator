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
        [HttpPost]
        // POST api/quotation
        public HttpResponseMessage RequestQuotation([FromBody]QuotationVM dataModel)
        {
            try
            {
                QuotationDM domainModel = dataModel.MapVM_DM();
                domainModel = _QuotationService.GetQuotationForCategory(domainModel);

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