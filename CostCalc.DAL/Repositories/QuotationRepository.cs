using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
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

        public object GetCategory(object iD)
        {
            
            throw new NotImplementedException();
        }

        public void AddCalculatedQuotation(QuotationDM domainModel)
        {
            throw new NotImplementedException();
        }
    }
}
