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
            try
            {
                CategoryService _CategorySer = new CategoryService(_GlobalErrors);
                domainModel.StartDate = DateTime.Now;
                _QuotaionRepo.Add(domainModel);

                domainModel.CategoryDMList = _CategorySer.GetAllCategories();
                domainModel.QuotaionDetailsList = new List<QuotaionDetailsDM>();

                foreach (var item in domainModel.CategoryDMList)
                {
                    QuotaionDetailsDM obj = new QuotaionDetailsDM(_GlobalErrors);

                    obj.Category = item;
                    obj.Quotaion = domainModel;
                    obj.AddCalculatedQuotation();
                    _QuotaionRepo.AddDetails(obj);
                    domainModel.QuotaionDetailsList.Add(obj);
                }

                return domainModel;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Request Quotation!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Request Quotation!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        //public List<QuotaionDetailsDM> GetQuotationDetails()
        //{
        //    return _QuotaionRepo.GetAllQuotationDetails();
        //}

    }
}
