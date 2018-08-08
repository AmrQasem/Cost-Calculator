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
                if (domainModel.FromLangID == domainModel.ToLangID)
                {
                    _GlobalErrors.AddValidationError("", "From language equla Tatrget language");
                    _GlobalErrors.ErrorHandled = true;
                    throw new Exception();
                }
                CategoryService _CategorySer = new CategoryService(_GlobalErrors);
                domainModel.StartDate = DateTime.Now;
                _QuotaionRepo.Add(domainModel);

                if (domainModel.CategoryID == null)
                {
                    domainModel.CategoryDMList = _CategorySer.GetAllCategories();

                    // to load Quotation details in the MVC project 
                    //domainModel.QuotaionDetailsList = new List<QuotaionDetailsDM>();

                    foreach (var item in domainModel.CategoryDMList)
                    {
                        QuotaionDetailsDM obj = new QuotaionDetailsDM(_GlobalErrors);

                        obj.Category = item;
                        obj.Quotaion = domainModel;
                        obj.AddCalculatedQuotation();
                        _QuotaionRepo.AddDetails(obj);

                        // To load Quotation details in the MVC project 
                        //domainModel.QuotaionDetailsList.Add(obj);
                    }
                }

                else
                {
                    CategoryDM CatObj = _CategorySer.GetById(domainModel.CategoryID);

                    // To load Quotation details in the MVC project 
                    //domainModel.QuotaionDetailsList = new List<QuotaionDetailsDM>();

                    QuotaionDetailsDM obj = new QuotaionDetailsDM(_GlobalErrors);

                    obj.Category = CatObj;
                    obj.Quotaion = domainModel;
                    obj.AddCalculatedQuotation();
                    _QuotaionRepo.AddDetails(obj);

                    // To load Quotation details in the MVC project 
                    //domainModel.QuotaionDetailsList.Add(obj);
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

        public List<QuotaionDetailsDM> GetQuotationDetails(int ID)
        {
            try
            {
                return _QuotaionRepo.GetAllQuotationDetails(ID);
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

        public QuotationDM QuotationStartDate(int ID)
        {
            try
            {
                return _QuotaionRepo.GetQuotationStartDate(ID);
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

    }
}
