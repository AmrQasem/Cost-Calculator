using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostCalc.API.DTO
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        //unit price
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// work rate per day
        /// </summary>
        public int WorkRate { get; set; }


        public CategoryVM()
        {
        }
        public CategoryVM(CategoryDM Cat)
        {
            ID = Cat.ID;
            CategoryName = Cat.CategoryName;
            UnitPrice = Cat.UnitPrice;
            WorkRate = Cat.WorkRate;
        }

        public CategoryDM MapVM_DM()
        {
            GlobalErrors globalErrors = new GlobalErrors();
            CategoryDM obj = new CategoryDM(globalErrors);
            obj.ID = ID;
            obj.CategoryName = CategoryName;
            obj.UnitPrice = UnitPrice;
            obj.WorkRate = WorkRate;

            return obj;
        }
    }
}