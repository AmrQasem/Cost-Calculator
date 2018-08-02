using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CostCalc.API.DTO;
using CostCalc.BLL.Services;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.API.Controllers
{
    public class LanguageController : ApiController
    {
        GlobalErrors globalErrors = new GlobalErrors();
        LanguageService _LanguageService;

        public LanguageController()
        {
            _LanguageService = new LanguageService(globalErrors);
        }

        // GET: api/Language
        [HttpGet]
        public IEnumerable<LanguageDM> GetAllLanguages()
        {
            return _LanguageService.GetAllLanguages();
        }

        // GET: api/Language/5
        [HttpGet]
        public HttpResponseMessage GetLanguageByID(int id)
        {
            var LanguageDetails = _LanguageService.GetById(id);
            if (LanguageDetails != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, LanguageDetails);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Language with ID = " + id.ToString() + " is not found ");
            }
        }

        // POST: api/Language
        [HttpPost]
        public HttpResponseMessage AddLanguage([FromBody]LanguageVM domain)
        {
            try
            {
                _LanguageService.Add(domain.MapVM_DM());
                var msg = Request.CreateResponse(HttpStatusCode.Created, domain);
                msg.Headers.Location = new Uri(Request.RequestUri + "/" + domain.ID.ToString());
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // PUT: api/Language/5
        [HttpPut]
        public HttpResponseMessage EditLanguage(int id, [FromBody]LanguageVM domain)
        {
            try
            {
                domain.ID = id;
                _LanguageService.Update(domain.MapVM_DM());
                var msg = Request.CreateResponse(HttpStatusCode.Created, domain);
                msg.Headers.Location = new Uri(Request.RequestUri + "/" + domain.ID.ToString());
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Language/5
        [HttpDelete]
        public HttpResponseMessage DeleteLanguage(int id)
        {
            try
            {
                _LanguageService.Delete(new LanguageDM(globalErrors) { ID = id });
                var msg = Request.CreateResponse(HttpStatusCode.OK, id);
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
