using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostCalc.API.DTO
{
    public class QuotaionVM
    {
        public int ID { get; set; }
        public int FromLangID { get; set; }
        public int ToLangID { get; set; }
        public decimal WordCount { get; set; }
        public string IP_Address { get; set; }
        public bool? IsRush { get; set; }
        public DateTime RushDate { get; set; }
        public int SubjectID { get; set; }


        public QuotaionVM()
        {
        }
        public QuotaionVM(QuotationDM Quotaion)
        {
            GlobalErrors globalErros = new GlobalErrors();
            ID = Quotaion.ID;
            FromLangID = Quotaion.FromLangID;
            ToLangID = Quotaion.ToLangID;
            WordCount = Quotaion.WordCount;
            IP_Address = Quotaion.IP_Address;
            IsRush = Quotaion.IsRush;
            RushDate = Quotaion.RushDate;
            SubjectID = Quotaion.Subject.ID;
        }

        public QuotationDM MapVM_DM()
        {
            GlobalErrors globalErrors = new GlobalErrors();
            QuotationDM obj = new QuotationDM(globalErrors);
            obj.ID = ID;
            obj.FromLangID = FromLangID;
            obj.ToLangID = ToLangID;
            obj.WordCount = WordCount;
            //obj.IP_Address = IP_Address;
            obj.IsRush = IsRush;
            obj.RushDate = RushDate;
            obj.Subject = new SubjectDM(globalErrors) { ID = SubjectID };

            return obj;
        }
}
}