using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.DAL.EF;
using System.Web.ModelBinding;

namespace CostCalc.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryDM, int>
    {
        public CategoryRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public List<CategoryDM> GetAllCategories()
        {
            try
            {
                var CategoryDetails = _DbContext.Categories;
                List<CategoryDM> CategoryDMList = new List<CategoryDM>();
                foreach (var item in CategoryDetails)
                {
                    CategoryDM CatDM = new CategoryDM(_GlobalErrors);
                    CatDM.ID = item.ID;
                    CatDM.CategoryName = item.CategoryName;
                    CatDM.UnitPrice = item.UnitPrice;
                    CatDM.WorkRate = item.WorkRate;
                    CategoryDMList.Add(CatDM);
                }
                return CategoryDMList;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get All Categories!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get All Categories!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override CategoryDM GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return null;

                var Category = _DbContext.Categories.FirstOrDefault(s => s.ID == id);
                CategoryDM CatDM = null;
                if (Category != null)
                {
                    CatDM = new CategoryDM(_GlobalErrors);
                    CatDM.ID = Category.ID;
                    CatDM.CategoryName = Category.CategoryName;
                    CatDM.UnitPrice = Category.UnitPrice;
                    CatDM.WorkRate = Category.WorkRate;
                }
                else
                {
                    _GlobalErrors.AddValidationError("", "Can't Get Category");
                    _GlobalErrors.ErrorHandled = true;
                    throw new Exception();
                }
                return CatDM;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get Specific Category!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get Specific Category!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override void Add(CategoryDM domain)
        {
            try
            {
                if (domain == null || string.IsNullOrWhiteSpace(domain.CategoryName))
                    return;
                Category obj = new Category();
                obj.ID = domain.ID;
                obj.CategoryName = domain.CategoryName;
                obj.UnitPrice = domain.UnitPrice;
                obj.WorkRate = domain.WorkRate;

                _DbContext.Categories.Add(obj);
                _DbContext.SaveChanges();
                domain.ID = obj.ID;
            }

            catch (Exception ex)
            {
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Create New Category!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Create New Category!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }

        }

        public override void Delete(CategoryDM domain)
        {
            try
            {
                if (domain == null || domain.ID <= 0)
                    return;
                var Category = _DbContext.Categories.FirstOrDefault(s => s.ID == domain.ID);
                if (Category != null)
                {
                    _DbContext.Categories.Remove(Category);
                    _DbContext.SaveChanges();
                }
                else
                {
                    _GlobalErrors.AddValidationError("", "Can't Delete Category");
                    _GlobalErrors.ErrorHandled = true;
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Delete Category!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Delete Category!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }

        }

        public override void Update(CategoryDM domain)
        {
            try
            {
                if (domain == null || domain.ID <= 0 || string.IsNullOrWhiteSpace(domain.CategoryName))
                    return;
                var Category = _DbContext.Categories.FirstOrDefault(s => s.ID == domain.ID);
                if (Category != null)
                {
                    Category.ID = domain.ID;
                    Category.CategoryName = domain.CategoryName;
                    Category.UnitPrice = domain.UnitPrice;
                    Category.WorkRate = domain.WorkRate;

                    _DbContext.SaveChanges();
                }
                else
                {
                    _GlobalErrors.AddValidationError("", "Can't Update Category");
                    _GlobalErrors.ErrorHandled = true;
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Update Category!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Update Category!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }

        }
    }
}
