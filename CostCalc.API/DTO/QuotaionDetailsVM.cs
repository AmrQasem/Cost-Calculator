using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostCalc.API.DTO
{
    public class QuotaionDetailsVM
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public int CategoryID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal NumberOfDays { get; set; }



        public QuotaionDetailsVM()
        {
        }
        public QuotaionDetailsVM(QuotaionDetailsDM  QuotaionDetails)
        {
            ID = QuotaionDetails.ID;
            JobID = QuotaionDetails.Quotaion.ID;
            CategoryID = QuotaionDetails.Category.ID;
            StartDate = QuotaionDetails.StartDate;
            EndDate = QuotaionDetails.EndDate;
            Price = QuotaionDetails.Price;
            NumberOfDays = QuotaionDetails.NumberOfDays;
        }

        public QuotaionDetailsDM MapVM_DM()
        {
            GlobalErrors globalErrors = new GlobalErrors();
            QuotaionDetailsDM obj = new QuotaionDetailsDM(globalErrors);
            obj.ID = ID;
            obj.Quotaion =new QuotationDM(globalErrors) {ID = JobID } ;
            obj.Category =new CategoryDM(globalErrors){ ID = CategoryID } ;
            obj.StartDate = StartDate;
            obj.EndDate = EndDate;
            obj.Price = Price;
            obj.NumberOfDays = NumberOfDays;
            return obj;
        }
    }
}