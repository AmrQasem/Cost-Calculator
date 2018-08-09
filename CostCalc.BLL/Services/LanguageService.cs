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
            try
            {
            return _LanguageRepo.GetAllLangues();
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Get All Languages!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Get All Languages!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public LanguageDM GetById(int id)
        {
            try
            {
                return _LanguageRepo.GetById(id);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Get Specific Languages!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Get Specific Languages!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }
        public void Add(LanguageDM domain)
        {
            try
            {
            _LanguageRepo.Add(domain);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Add Languages!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Add Languages!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public void Delete(LanguageDM domain)
        {
            try
            {
            _LanguageRepo.Delete(domain);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot Delete Languages!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot Delete Languages!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public void Update(LanguageDM domain)
        {
            try
            {
            _LanguageRepo.Update(domain);
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error exist but not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Service Error: Cannot update Languages!");
                    _GlobalErrors.AddSystemError("Service Error: Cannot update Languages!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }
    }
}