using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.Helper.ExceptionHandling;
using CostCalc.Domain.Models;
using CostCalc.DAL.Repositories;

namespace CostCalc.BLL.Services
{
    public class QuotationService : BaseService
    {
        QuotationRepository _QuotationRepo;
        QuotationDM _QuotationDM;
        public QuotationService(GlobalErrors globalErrors) : base(globalErrors)
        {
            _QuotationRepo = new QuotationRepository(globalErrors);
            _QuotationDM = new QuotationDM(globalErrors);
        }

        public QuotationDM GetQuotationForCategory(QuotationDM domainModel)
        {
            //Load Data needed for calculations
            domainModel.CategoryDMList = _QuotationRepo.GetCategory(domainModel.ID);
            //Calculate quotation in Domain
            domainModel.AddCalculatedQuotation();
            //Store calculations
            _QuotationRepo.Add(domainModel);
            //return calculated domain
            return domainModel;
        }
    }
}
