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
            try
            {
                return _LanguageService.GetAllLanguages();
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Get All Languages!");
                    globalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        // GET: api/Language/5
        [HttpGet]
        public HttpResponseMessage GetLanguageByID(int id)
        {
            try
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
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Get Specific Languages!");
                    globalErrors.ErrorHandled = true;
                }
                throw;
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
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Add Languages!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

                }
                throw;
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
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Update Languages!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                throw;
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
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Delete Languages!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                throw;
            }
        }
    }
}
