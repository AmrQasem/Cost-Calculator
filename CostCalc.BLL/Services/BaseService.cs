using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using NLog;
using CostCalc.Helper.ExceptionHandling;
using CostCalc.DAL.Repositories;
using CostCalc.Domain.Models;
using CostCalc.Domain.Interfaces;

namespace CostCalc.BLL.Services
{
    /// <summary>
    /// Base Service Class, all services must Inherit this Class
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Used to Log Unhandled Exceptions
        /// </summary>
        protected Logger _Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Used to Get or Set All User Displayed Errors
        /// </summary>
        protected GlobalErrors _GlobalErrors;

        public BaseService(GlobalErrors globalErrors)
        {
            _GlobalErrors = globalErrors;
            _GlobalErrors.DefaultErrorLayer = ErrorLayer.BLL;

        }
    }
}
