using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.Domain.Models
{
    public class CategoryDM : BaseDM<int>
    {
        public CategoryDM(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int WorkRate { get; set; }

    }
}
