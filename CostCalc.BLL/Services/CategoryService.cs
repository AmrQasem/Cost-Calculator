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
            return _CategoryRepo.GetAllCategories();
        }

        public CategoryDM GetById(int id)
        {
            return _CategoryRepo.GetById(id); 
        }
        public  void Add(CategoryDM domain)
        {
            _CategoryRepo.Add(domain);
        }

        public void Delete(CategoryDM domain)
        {
            _CategoryRepo.Delete(domain);
        }

        public  void Update(CategoryDM domain)
        {
            _CategoryRepo.Update(domain);
        }
    }
}
