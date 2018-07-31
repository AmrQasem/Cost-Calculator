using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using CostCalc.DAL.Interfaces;

namespace CostCalc.DAL.Repositories
{
    public class SampleRepository : BaseRepository<SampleDM, int>
    {
        public SampleRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public override void Add(SampleDM domain)
        {
            throw new NotImplementedException();
        }

        public override void Delete(SampleDM domain)
        {
            throw new NotImplementedException();
        }

        public override SampleDM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(SampleDM domain)
        {
            throw new NotImplementedException();
        }
    }
}
