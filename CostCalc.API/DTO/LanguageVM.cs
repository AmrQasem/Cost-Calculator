using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostCalc.API.DTO
{
    public class LanguageVM
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public LanguageVM()
        {
        }
        public LanguageVM(LanguageDM Sub)
        {
            ID = Sub.ID;
            Name = Sub.Name;

        }

        public LanguageDM MapVM_DM()
        {
            GlobalErrors globalErrors = new GlobalErrors();
            LanguageDM obj = new LanguageDM(globalErrors);
            obj.ID = ID;
            obj.Name = Name;
            return obj;
        }
    }
}