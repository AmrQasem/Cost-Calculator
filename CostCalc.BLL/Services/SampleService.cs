using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using CostCalc.DAL.Repositories;
using CostCalc.Domain.Models;
using CostCalc.BLL.Validators;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.BLL.Services
{
    public class SampleService : BaseService
    {
        SampleRepository _Repository;
        SampleDM _Domain;

        public SampleService(GlobalErrors globalErrors): base(globalErrors)
        {
            _Repository = new SampleRepository(globalErrors);
            _Domain = new SampleDM(globalErrors);
        }
        public void EditSample(SampleDM sampleDM)
        {
            //Validate Service Domain Model
            SampleValidator sampleValidator = new SampleValidator(_GlobalErrors);
            sampleValidator.Validate(sampleDM);
            //Add to Global Errors if Validation Error exist
            if (_GlobalErrors.ErrorExist && !_GlobalErrors.ErrorHandled || !sampleDM.isValid)
            {
                _GlobalErrors.AddValidationError("Product addition Violation", "Violation Rule");
                return;
            }


            //Continue the process if no validation error exist
            //...
            //...

            try
            {
                _Repository.Add(_Domain);
            }catch(Exception e)
            {
                _GlobalErrors.AddSystemError("Error in Product Addition");
                _Logger.Error(e);
            }




        }
    }
}
