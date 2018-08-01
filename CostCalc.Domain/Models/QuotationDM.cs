using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;
using System.Net;

namespace CostCalc.Domain.Models
{
    public class QuotationDM : BaseDM<int>
    {

        public QuotationDM(GlobalErrors globalErrors) : base(globalErrors)
        {
            Ratio = 0.02;
            IsRush = false;
            RushRatio = 0.1;
        }

        public int ID { get; set; }
        public int FromLangID { get; set; }
        public int ToLangID { get; set; }
        public decimal WordCount { get; set; }
        public decimal Price { get; set; }
        public string IP_Address { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal NumberOfDays { get; set; }
        public double Ratio { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal PremiumPrice { get; set; }
        public List<CategoryDM> CategoryDMList { get; set; }
        public bool? IsRush { get; set; }
        public DateTime RushDate { get; set; }
        public decimal NumberOfRushDays { get; set; }
        public double RushRatio { get; set; }



        public void CalculateQuotation()
        {
            throw new NotImplementedException();
        }

        public void AddCalculatedQuotation()
        {
            IP_Address = Get_IP();
            StartDate = DateTime.Today;

            foreach (var item in CategoryDMList)
            {
                if(IsRush == false)
                {
                    NumberOfDays = WordCount / item.WorkRate;
                    NumberOfDays = Math.Round(NumberOfDays, 0, MidpointRounding.AwayFromZero);
                    EndDate = StartDate.AddDays((double)NumberOfDays - 1);

                    CalcPrice(item, WordCount, ToLangID);
                }
                else if(IsRush == true)
                {
                    NumberOfDays = WordCount / item.WorkRate;
                    EndDate = StartDate.AddDays((double)NumberOfDays - 1 );

                    NumberOfRushDays = EndDate.Day - RushDate.Day;
                    NumberOfDays = NumberOfDays - NumberOfRushDays;
                    NumberOfDays = Math.Round(NumberOfDays, 0, MidpointRounding.AwayFromZero);
                    EndDate = StartDate.AddDays((double)NumberOfDays - 1);

                    CalcPriceRush(item, WordCount, ToLangID, NumberOfRushDays);
                }
            }
        }

        public string Get_IP()
        {
            string ip = "";
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            ip = addr[1].ToString();
            return ip;
        }

        public void CalcPrice(CategoryDM CatDM, decimal WordCount, int ToLang)
        {
            decimal price = 0;
            if (ToLang == 1)
            {
                price = Convert.ToDecimal((double)(WordCount) * ((double)CatDM.UnitPrice + Ratio));
            }
            else
                price = Convert.ToDecimal((double)(WordCount) * (double)CatDM.UnitPrice);

            if (CatDM.ID == 1)
            {
                StandardPrice = price;
            }
            else
                PremiumPrice = price;
        }

        public void CalcPriceRush(CategoryDM CatDM, decimal WordCount, int ToLang, decimal NumberOfDays)
        {
            decimal price = 0;
            

            if (ToLang == 1)
            {
                
                price = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * ((double)CatDM.UnitPrice + Ratio)) ) +
                    Convert.ToDecimal((double)(WordCount) * ((double)CatDM.UnitPrice + Ratio));
            }
            else
            {
                decimal x,y = 0;
                x = Convert.ToDecimal((double)(WordCount) * (double)CatDM.UnitPrice);
                y = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * (double)CatDM.UnitPrice));
                price = (NumberOfDays * (decimal)RushRatio * Convert.ToDecimal((double)(WordCount) * (double)CatDM.UnitPrice)) +
                  Convert.ToDecimal((double)(WordCount) * (double)CatDM.UnitPrice);

            }

            if (CatDM.ID == 1)
            {
                StandardPrice = price;
            }
            else
                PremiumPrice = price;
        }
    }
}
