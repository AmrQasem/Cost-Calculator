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
    public class CategoryService : BaseService
    {
        CategoryRepository _CategoryRepo;
        CategoryDM _CategorynDM;

        public CategoryService(GlobalErrors globalErrors) : base(globalErrors)
        {
            _CategoryRepo = new CategoryRepository(globalErrors);
            _CategorynDM = new CategoryDM(globalErrors);
        }
        public List<CategoryDM> GetAllCategories()
        {
            try
            {
                return _CategoryRepo.GetAllCategories();
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Get All Categories!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Get All Categories!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public CategoryDM GetById(int? id)
        {
            try
            {
                return _CategoryRepo.GetById(id.Value);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Get Speceific Categories!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Get Speceific Categories!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }
        public void Add(CategoryDM domain)
        {
            try
            {
                _CategoryRepo.Add(domain);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Add Categories!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Add Categories!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public void Delete(CategoryDM domain)
        {
            try
            {
                _CategoryRepo.Delete(domain);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Delete Categories!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Delete Categories!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public void Update(CategoryDM domain)
        {
            try
            {
                _CategoryRepo.Update(domain);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Update Categories!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Update Categories!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }
    }
}
