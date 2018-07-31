using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using CostCalc.BLL.Validators;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.BLL.Interfaces
{
    public interface IBaseValidator<T>
    {
        void Validate(T obj);
    }
}
