using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostCalc.DAL.Interfaces
{
    /// <summary>
    /// Base Repository Interface, should be implemented by any other Interface or Concrete Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IBaseRepository<Domain, IdType> : IRepository<Domain>
    {
        Domain GetById(IdType id);

    }
}
