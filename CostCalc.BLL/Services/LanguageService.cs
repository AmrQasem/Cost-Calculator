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
    public class LanguageService : BaseService
    {
        LanguageRepository _LanguageRepo;
        LanguageDM _LanguagenDM;

        public LanguageService(GlobalErrors globalErrors) : base(globalErrors)
        {
            _LanguageRepo = new LanguageRepository(globalErrors);
            _LanguagenDM = new LanguageDM(globalErrors);
        }
        public List<LanguageDM> GetAllLanguages()
        {
            return _LanguageRepo.GetAllLangues();
        }

        public LanguageDM GetById(int id)
        {
            return _LanguageRepo.GetById(id);
        }
        public void Add(LanguageDM domain)
        {
            _LanguageRepo.Add(domain);
        }

        public void Delete(LanguageDM domain)
        {
            _LanguageRepo.Delete(domain);
        }

        public void Update(LanguageDM domain)
        {
            _LanguageRepo.Update(domain);
        }
    }
}