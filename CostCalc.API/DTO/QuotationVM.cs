using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.API.DTO
{
    public class QuotationVM
    {
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


        public QuotationVM()
        {
        }
        public QuotationVM(QuotationDM job)
        {
            ID = job.ID;
            FromLangID = job.FromLangID;
            ToLangID = job.ToLangID;
            WordCount = job.WordCount;
            CategoryID = job.CategoryID;
            Price = job.Price;
            IP_Address = job.IP_Address;
            StartDate = job.StartDate;
            EndDate = job.EndDate;
            NumberOfDays = job.NumberOfDays;
        }

        public QuotationDM MapVM_DM()
        {
            GlobalErrors globalErrors = new GlobalErrors();
            QuotationDM obj = new QuotationDM(globalErrors);
            obj.ID = ID;
            obj.FromLangID = FromLangID;
            obj.ToLangID = ToLangID;
            obj.WordCount = WordCount;
            obj.CategoryID = CategoryID;
            obj.Price = Price;
            obj.IP_Address = IP_Address;
            obj.StartDate = StartDate;
            obj.EndDate = EndDate;
            obj.NumberOfDays = NumberOfDays;

            return obj;
        }

    }


}