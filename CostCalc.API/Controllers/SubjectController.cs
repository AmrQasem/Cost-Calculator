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
    public class SubjectController : ApiController
    {
        GlobalErrors globalErrors = new GlobalErrors();
        SubjectService _SubjectService;

        public SubjectController()
        {
            _SubjectService = new SubjectService(globalErrors);
        }

        // GET: api/Subject
        [HttpGet]
        public IEnumerable<SubjectDM> GetAllSubjects()
        {
            try
            {
                return _SubjectService.GetAllSubjects();
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Database Error: Cannot Get All Subjects!");
                    globalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        // GET: api/Subject/5
        [HttpGet]
        public HttpResponseMessage GetSubjectByID(int id)
        {
            try
            {
                var SubjectDetails = _SubjectService.GetById(id);
                if (SubjectDetails != null)
                    return Request.CreateResponse(HttpStatusCode.OK, SubjectDetails);
                else
                    return null;
                
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Database Error: Cannot Get Specific Subjects!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Subject with ID = " + id.ToString() + " is not found ");
                }
                throw;
            }
        }

        // POST: api/Subject
        [HttpPost]
        public HttpResponseMessage AddSubject([FromBody]SubjectVM domain)
        {
            try
            {
                _SubjectService.Add(domain.MapVM_DM());
                var msg = Request.CreateResponse(HttpStatusCode.Created, domain);
                msg.Headers.Location = new Uri(Request.RequestUri + "/" + domain.ID.ToString());
                return msg;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Database Error: Cannot Add Subjects!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                throw;
            }

        }

        // PUT: api/Subject/5
        [HttpPut]
        public HttpResponseMessage EditSubject(int id, [FromBody]SubjectVM domain)
        {
            try
            {
                domain.ID = id;
                _SubjectService.Update(domain.MapVM_DM());
                var msg = Request.CreateResponse(HttpStatusCode.Created, domain);
                msg.Headers.Location = new Uri(Request.RequestUri + "/" + domain.ID.ToString());
                return msg;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Database Error: Cannot Update Subjects!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                throw;
            }
        }

        // DELETE: api/Subject/5
        [HttpDelete]
        public HttpResponseMessage DeleteSubject(int id)
        {
            try
            {
                _SubjectService.Delete(new SubjectDM(globalErrors) { ID = id });
                var msg = Request.CreateResponse(HttpStatusCode.OK, id);
                return msg;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Database Error: Cannot Delete Subjects!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                throw;
            }
        }
    }
}
