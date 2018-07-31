//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CostCalc.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
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
    
        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }
        public virtual Language Language1 { get; set; }
    }
}
