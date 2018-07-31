using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostCalc.DAL.Interfaces
{
    public interface IRepository<Domain>
    {
        void Add(Domain entity);
        void Update(Domain entity);
        void Delete(Domain entity);
        void Save();
    }
}
