using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostCalc.Helper.ExceptionHandling
{
    /// <summary>
    /// Select the Architectural Layer that generated the Error
    /// </summary>
    public enum ErrorLayer
    {
        /// <summary>
        /// Global Error that is common between layers, or doesn't belong to specific layer
        /// </summary>
        Global,
        /// <summary>
        /// Error generated in Data Access Layer
        /// </summary>
        DAL,
        /// <summary>
        /// Error generated in Business Logic Layer
        /// </summary>
        BLL,
        /// <summary>
        /// Error generated in Domain Layer
        /// </summary>
        Domain,
        /// <summary>
        /// Error generated in Web Layer (Presentation Layer)
        /// </summary>
        Web
    }
    /// <summary>
    /// Classifies Error to Validation or System Errors
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Validation error that violates business validation rule
        /// </summary>
        Validation,
        /// <summary>
        /// Unhandled Exception that will lead to system crash
        /// </summary>
        System
    }
    public class ErrorItem
    {
        /// <summary>
        /// Architectural Layer where the error exist
        /// </summary>
        public ErrorLayer Layer;
        public ErrorType Type;
        /// <summary>
        /// [Optional] Error Source Name, Example: property, class, method, object, etc...
        /// </summary>
        public string Source;
        /// <summary>
        /// High-Level error message displayed to High-Level User
        /// </summary>
        public string FriendlyMessage;

        public ErrorItem(string source, string friendlyMessage, ErrorType type, ErrorLayer layer)
        {
            Layer = layer;
            Type = type;
            Source = source;
            FriendlyMessage = friendlyMessage;
        }
    }
    public class GlobalErrors
    {
        /// <summary>
        /// Default value is ErrorLayer.Global if not Set
        /// </summary>
        public ErrorLayer DefaultErrorLayer;
        public List<ErrorItem> ErrorList { get; private set; }

        public bool ErrorHandled { get; set; }
        public bool ErrorExist { get; private set; }

        public GlobalErrors()
        {
            ErrorList = new List<ErrorItem>();
            DefaultErrorLayer = ErrorLayer.Global;
            ErrorHandled = false;
            ErrorExist = false;
        }

        public GlobalErrors(ErrorLayer defaultErrorLayer)
        {
            ErrorList = new List<ErrorItem>();
            DefaultErrorLayer = defaultErrorLayer;
            ErrorHandled = false;
            ErrorExist = false;
        }



        public void AddValidationError(string source, string message)
        {
            ErrorList.Add(new ErrorItem(source, message, ErrorType.Validation, DefaultErrorLayer));
            ErrorExist = true;
        }

        public void AddSystemError(string friendlyMessage)
        {
            ErrorList.Add(new ErrorItem(String.Empty, friendlyMessage, ErrorType.System, DefaultErrorLayer));
            ErrorExist = true;
        }

        public void Clear()
        {
            ErrorList.Clear();
            ErrorHandled = false;
            ErrorExist = false;
        }
    }
}
