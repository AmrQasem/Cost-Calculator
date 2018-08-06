using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;
using System.Net;

namespace CostCalc.Domain.Models
{
    public class QuotaionDetailsDM : BaseDM<int>
    {
        public QuotaionDetailsDM(GlobalErrors globalErrors) : base(globalErrors)
        {
            Ratio = 0.02;
            IsRush = false;
            RushRatio = 0.1;
            SubjectRatio = 0.1;
        }

        public int ID { get; set; }
        public QuotationDM Quotaion { get; set; }
        public CategoryDM Category { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal NumberOfDays { get; set; }
        public double Ratio { get; set; }
        public bool? IsRush { get; set; }
        public double RushRatio { get; set; }
        public double SubjectRatio { get; set; }
        public decimal NumberOfRushDays { get; set; }
        public DateTime RushDate { get; set; }



        public void AddCalculatedQuotation()
        {
            //StartDate = DateTime.Today;


            if (Quotaion.IsRush == false || Quotaion.IsRush == null)
            {
                NumberOfDays = (Quotaion.WordCount / Category.WorkRate);
                NumberOfDays = Math.Round(NumberOfDays, 0, MidpointRounding.AwayFromZero);
                //EndDate = StartDate.AddDays((double)NumberOfDays - 1);

                CalcPrice(Quotaion.WordCount, Quotaion.ToLangID);
            }
            else if (IsRush == true)
            {
                NumberOfDays = Quotaion.WordCount / Category.WorkRate;
                //EndDate = StartDate.AddDays((double)NumberOfDays - 1);

                NumberOfRushDays = EndDate.Day - RushDate.Day;
                NumberOfDays = NumberOfDays - NumberOfRushDays;
                NumberOfDays = Math.Round(NumberOfDays, 0, MidpointRounding.AwayFromZero);
                //EndDate = StartDate.AddDays((double)NumberOfDays - 1);

                CalcPriceRush(Quotaion.WordCount, Quotaion.ToLangID, NumberOfRushDays);
            }
        }



        public void CalcPrice(decimal WordCount, int ToLang)
        {
            decimal price = 0;
            if (Quotaion.Subject.ID == 1)
            {

                if (ToLang == 1)
                {
                    price = Convert.ToDecimal((double)(WordCount) * ((double)Category.UnitPrice + Ratio));
                }
                else
                    price = Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice);
            }
            else
            {
                if (ToLang == 1)
                {
                    price = Convert.ToDecimal((double)(WordCount) * ((double)Category.UnitPrice + Ratio));
                    price += price * (decimal)SubjectRatio;
                }
                else
                {
                    price = Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice);
                    price += price * (decimal)SubjectRatio;
                    //+SubjectRatio
                }
            }
            Price = price;
        }

        public void CalcPriceRush(decimal WordCount, int ToLang, decimal NumberOfDays)
        {
            decimal price = 0;
            if (Quotaion.Subject.ID == 1)
            {
                if (ToLang == 1)
                {

                    price = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * ((double)Category.UnitPrice + Ratio))) +
                        Convert.ToDecimal((double)(WordCount) * ((double)Category.UnitPrice + Ratio));
                }
                else
                {
                    decimal x, y = 0;
                    x = Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice);
                    y = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice));
                    price = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice)) +
                      Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice);
                }
            }
            else
            {
                if (ToLang == 1)
                {

                    price = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * ((double)Category.UnitPrice + Ratio)) + (decimal)SubjectRatio) +
                        Convert.ToDecimal((double)(WordCount) * ((double)Category.UnitPrice + Ratio)) + (decimal)SubjectRatio;
                }
                else
                {
                    price = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice) + (decimal)SubjectRatio) +
                      Convert.ToDecimal((double)(WordCount) * (double)Category.UnitPrice) + (decimal)SubjectRatio;
                }
            }

            Price = price;

        }
    }
}
