using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.BLL.Validators
{
    class SampleValidator : BaseValidator<SampleDM>
    {
        public SampleValidator(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public override void Validate(SampleDM obj)
        {
            throw new NotImplementedException();
        }
    }
}
