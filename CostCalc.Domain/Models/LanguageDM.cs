using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.Domain.Models
{
    public class LanguageDM : BaseDM<int>
    {
        public LanguageDM(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }

    }
}
