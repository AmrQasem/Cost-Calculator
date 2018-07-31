using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.Domain.Models
{
    public class SampleDM : BaseDM<int>
    {
        public bool isValid { get; set; }

        public SampleDM(int id, GlobalErrors globalErrors) : base(globalErrors)
        {
            Id = id;
        }

        public SampleDM(GlobalErrors globalErrors) : base(globalErrors)
        {
        }




    }
}
