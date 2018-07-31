using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.Domain.Models
{
    public class QuotationDM : BaseDM<int>
    {

        public QuotationDM(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public int ID { get; set; }
        public int FromLangID { get; set; }
        public int ToLangID { get; set; }
        public decimal WordCount { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string IP_Address { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal NumberOfDays { get; set; }

        public void CalculateQuotation()
        {
            throw new NotImplementedException();
        }
    }
}
