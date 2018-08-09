using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.Domain.Models
{
    public class SubjectDM : BaseDM<int>
    {
        public SubjectDM(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public int ID { get; set; }
        public string SubjectTitle { get; set; }
    }
}
