using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.API.DTO
{
    public class SubjectVM
    {
        public int ID { get; set; }
        public string SubjectTitle { get; set; }


        public SubjectVM()
        {
        }
        public SubjectVM(SubjectDM Sub)
        {
            ID = Sub.ID;
            SubjectTitle = Sub.SubjectTitle;
           
        }

        public SubjectDM MapVM_DM()
        {
            GlobalErrors globalErrors = new GlobalErrors();
            SubjectDM obj = new SubjectDM(globalErrors);
            obj.ID = ID;
            obj.SubjectTitle = SubjectTitle;
            return obj;
        }
    }
}