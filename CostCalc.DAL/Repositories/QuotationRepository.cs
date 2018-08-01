using CostCalc.DAL.EF;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostCalc.DAL.Repositories
{
    public class QuotationRepository : BaseRepository<QuotationDM, int>
    {
        public QuotationRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }
        public override void Add(QuotationDM domain)
        {
            Job obj = new Job();

            obj.FromLangID = domain.FromLangID;
            obj.ToLangID = domain.ToLangID;
            obj.WordCount = domain.WordCount;
            obj.IP_Address = domain.IP_Address;
            obj.StartDate = domain.StartDate;
            obj.NumberOfDays = domain.NumberOfDays;
            obj.Price = domain.Price;
            obj.EndDate = domain.EndDate;
            obj.StandardPrice = domain.StandardPrice;
            obj.PremiumPrice = domain.PremiumPrice;
            obj.IsRush = domain.IsRush;

            _DbContext.Jobs.Add(obj);
            _DbContext.SaveChanges();
        }

        public override void Delete(QuotationDM domain)
        {
            throw new NotImplementedException();
        }

        public override QuotationDM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(QuotationDM domain)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDM> GetCategory(int? ID)
        {
            var CategoryDetails = ID == 0? _DbContext.Categories : _DbContext.Categories.Where(s=>s.ID == ID);
            List<CategoryDM> CategoryDMList = new List<CategoryDM>();
            foreach (var item in CategoryDetails)
            {
                CategoryDM CatDM = new CategoryDM(_GlobalErrors);
                CatDM.ID = item.ID;
                CatDM.CategoryName = item.CategoryName;
                CatDM.UnitPrice = item.UnitPrice;
                CatDM.WorkRate = item.WorkRate;
                CategoryDMList.Add(CatDM);
            }
            return CategoryDMList;
        }
    }
}
