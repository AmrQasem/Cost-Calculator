using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using CostCalc.Domain.Interfaces;
using CostCalc.Helper.ExceptionHandling;
using NLog;

namespace CostCalc.Domain.Models
{
    /// <summary>
    /// Base Domain Model, all Domain Models must Inherit this Class
    /// </summary>
    public abstract class BaseDM<IdType> : IDomainModel
    {
        //public IdType Id { get; set; }
        /// <summary>
        /// Used to Log Unhandled Exceptions
        /// </summary>
        protected Logger _Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Used to Get or Set All User Displayed Errors
        /// </summary>
        protected GlobalErrors _GlobalErrors;

        public BaseDM(GlobalErrors globalErrors)
        {
            _GlobalErrors = globalErrors;
            _GlobalErrors.DefaultErrorLayer = ErrorLayer.Domain;
        }
    }
}
