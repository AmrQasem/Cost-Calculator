using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;
using CostCalc.DAL.Repositories;
using CostCalc.Domain.Models;

namespace CostCalc.BLL.Services
{
    public class QuotaionService : BaseService
    {

        QuotaionRepository _QuotaionRepo;
        QuotationDM _QuotaionDM;
        public QuotaionService(GlobalErrors globalErrors) : base(globalErrors)
        {
            _QuotaionRepo = new QuotaionRepository(globalErrors);
            _QuotaionDM = new QuotationDM(globalErrors);
        }

        public QuotationDM GetQuotationForCategory(QuotationDM domainModel)
        {
            CategoryService _CategorySer = new CategoryService(_GlobalErrors);
            _QuotaionRepo.Add(domainModel);
           
            domainModel.CategoryDMList = _CategorySer.GetAllCategories();

            foreach (var item in domainModel.CategoryDMList)
            {
                QuotaionDetailsDM obj = new QuotaionDetailsDM(_GlobalErrors);

                obj.Category = item;
                obj.Quotaion = domainModel;
                obj.AddCalculatedQuotation();
                _QuotaionRepo.AddDetails(obj);
            }

            return domainModel;
        }


    }
}
