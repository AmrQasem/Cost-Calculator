using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CostCalc.API.DTO
{
    public class QuotaionVM
    {
        public int ID { get; set; }
        [Display(Name = "From Language")]
        public int FromLangID { get; set; }
        [Display(Name = "To Language")]
        public int ToLangID { get; set; }
        [Display(Name = "Word Count")]
        public decimal WordCount { get; set; }
        public string IP_Address { get; set; }
        public bool? IsRush { get; set; }
        public DateTime RushDate { get; set; }
        [Display(Name = "Subject")]
        public int SubjectID { get; set; }
        public List<SubjectVM> SubjectVMList { get; set; }
        public List<LanguageVM> LanguageVMList { get; set; }
        public List<CategoryVM> CategoryVMList { get; set; }
        public List<QuotaionDetailsVM> QuotaionDetailsVMList { get; set; }
        public DateTime StartDate { get; set; }



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
            StartDate = Quotaion.StartDate;
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
            obj.StartDate = StartDate;

            return obj;
        }
}
}