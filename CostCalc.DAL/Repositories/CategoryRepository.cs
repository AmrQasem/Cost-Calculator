using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.DAL.EF;

namespace CostCalc.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryDM, int>
    {
        public CategoryRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public List<CategoryDM> GetAllCategories()
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

        public override CategoryDM GetById(int id)
        {
            var Category = _DbContext.Categories.FirstOrDefault(s => s.ID == id);
            if (Category != null)
            {

                CategoryDM CatDM = new CategoryDM(_GlobalErrors);
                CatDM.ID = Category.ID;
                CatDM.CategoryName = Category.CategoryName;
                CatDM.UnitPrice = Category.UnitPrice;
                CatDM.WorkRate = Category.WorkRate;
                return CatDM;
            }
            else
                return null;
           
        }

        public override void Add(CategoryDM domain)
        {
            Category obj = new Category();
            obj.ID = domain.ID;
            obj.CategoryName = domain.CategoryName;
            obj.UnitPrice = domain.UnitPrice;
            obj.WorkRate = domain.WorkRate;

            _DbContext.Categories.Add(obj);
            _DbContext.SaveChanges();
            domain.ID = obj.ID;
        }

        public override void Delete(CategoryDM domain)
        {
            var Category = _DbContext.Categories.FirstOrDefault(s => s.ID == domain.ID);
            if (Category != null)
            {
                _DbContext.Categories.Remove(Category);
                _DbContext.SaveChanges();
            }
        }

        public override void Update(CategoryDM domain)
        {
            var Category = _DbContext.Categories.FirstOrDefault(s => s.ID == domain.ID);
            if (Category != null)
            {
                Category.ID = domain.ID;
                Category.CategoryName = domain.CategoryName;
                Category.UnitPrice = domain.UnitPrice;
                Category.WorkRate = domain.WorkRate;

                _DbContext.SaveChanges();
            }
        }
    }
}
