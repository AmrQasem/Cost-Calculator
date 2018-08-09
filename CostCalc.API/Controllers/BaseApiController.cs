using CostCalc.Helper.ExceptionHandling;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CostCalc.API.Controllers
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// Used to Log Unhandled Exceptions
        /// </summary>
        protected Logger _Logger;
        /// <summary>
        /// Used to Get or Set All User Displayed Errors
        /// </summary>
        protected GlobalErrors _GlobalErrors;

        public BaseApiController()
        {
            _Logger = LogManager.GetCurrentClassLogger();
            _GlobalErrors = new GlobalErrors(ErrorLayer.Web);
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    //Log the error!!
        //    _Logger.Error(filterContext.Exception);

        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/Shared/Error.cshtml"
        //    };
        //}
    }
}