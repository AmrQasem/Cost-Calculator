using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using NLog;
using CostCalc.BLL.Interfaces;
using CostCalc.Helper.ExceptionHandling; 

namespace CostCalc.BLL.Validators
{
    public abstract class BaseValidator<T> : IBaseValidator<T>
    {
        /// <summary>
        /// Used to Log Unhandled Exceptions
        /// </summary>
        protected Logger _Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Used to Get or Set All User Displayed Errors
        /// </summary>
        protected GlobalErrors _GlobalErrors;

        public BaseValidator(GlobalErrors globalErrors)
        {
            _GlobalErrors = globalErrors;
            _GlobalErrors.DefaultErrorLayer = ErrorLayer.BLL;
        }
        /// <summary>
        /// Validate any Object and add validation errors in _GlobalErrors List
        /// </summary>
        /// <param name="obj"></param>
        public abstract void Validate(T obj);
    }
}
