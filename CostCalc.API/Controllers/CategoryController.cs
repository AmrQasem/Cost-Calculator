using CostCalc.BLL.Services;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CostCalc.Domain.Models;
using CostCalc.API.DTO;

namespace CostCalc.API.Controllers
{
    public class CategoryController : BaseApiController
    {

        GlobalErrors globalErrors = new GlobalErrors();
        CategoryService _CategoryService;

        public CategoryController()
        {
            _CategoryService = new CategoryService(globalErrors);
        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<CategoryDM> GetAllCategories()
        {
            try
            {
                return _CategoryService.GetAllCategories();
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Get All Categories!");
                    globalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        // GET: api/Category/5
        [HttpGet]
        public HttpResponseMessage GetCategoryByID(int id)
        {
            try
            {
                var CategoryDetails = _CategoryService.GetById(id);
                if (CategoryDetails != null)
                    return Request.CreateResponse(HttpStatusCode.OK, CategoryDetails);
                else
                    return null;

            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    _Logger.Error("");
                    globalErrors.AddSystemError("Service Error: Cannot Get Speceific Categories!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category with ID = " + id.ToString() + " is not found ");
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category with ID = " + id.ToString() + " is not found ");

                throw;
            }
        }

        // POST: api/Category
        [HttpPost]
        public HttpResponseMessage AddCategory([FromBody]CategoryVM domain)
        {
            try
            {
                //if (ModelState.IsValid) { }
                _CategoryService.Add(domain.MapVM_DM());
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
                    globalErrors.AddSystemError("Service Error: Cannot Get Add Category!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

                }
                throw;
            }

        }

        // PUT: api/Category/5
        [HttpPut]
        public HttpResponseMessage EditCategory(int id, [FromBody]CategoryVM domain)
        {
            try
            {
                domain.ID = id;
                _CategoryService.Update(domain.MapVM_DM());
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
                    globalErrors.AddSystemError("Service Error: Cannot Edit Category!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                throw;
            }
        }

        // DELETE: api/Category/5
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int id)
        {
            try
            {
                _CategoryService.Delete(new CategoryDM(globalErrors) { ID = id });
                var msg = Request.CreateResponse(HttpStatusCode.OK, id);
                return msg;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!globalErrors.ErrorHandled)
                {
                    globalErrors.AddSystemError("Service Error: Cannot Delete Category!");
                    globalErrors.ErrorHandled = true;
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                throw;
            }
        }
    }
}
