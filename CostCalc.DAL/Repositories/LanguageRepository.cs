using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostCalc.DAL.EF;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.DAL.Repositories
{
    public class LanguageRepository : BaseRepository<LanguageDM, int>
    {
        public LanguageRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public List<LanguageDM> GetAllLangues()
        {
            try
            {
                var LangDetails = _DbContext.Languages;
                List<LanguageDM> LanguageDMList = new List<LanguageDM>();
                foreach (var item in LangDetails)
                {
                    LanguageDM LangDM = new LanguageDM(_GlobalErrors);
                    LangDM.ID = item.ID;
                    LangDM.Name = item.Name;
                    LanguageDMList.Add(LangDM);
                }
                return LanguageDMList;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get All Languages!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get All Languages!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override LanguageDM GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return null;
                var Language = _DbContext.Languages.FirstOrDefault(s => s.ID == id);
                if (Language != null)
                {

                    LanguageDM LangDM = new LanguageDM(_GlobalErrors);
                    LangDM.ID = Language.ID;
                    LangDM.Name = Language.Name;
                    return LangDM;
                }
                return null;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get Specific Language!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get Specific Language!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override void Add(LanguageDM domain)
        {
            try
            {
                if (domain == null || string.IsNullOrWhiteSpace(domain.Name))
                    return;
                Language obj = new Language();
                obj.ID = domain.ID;
                obj.Name = domain.Name;

                _DbContext.Languages.Add(obj);
                _DbContext.SaveChanges();
                domain.ID = obj.ID;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Add Language!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Add Language!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }

        }

        public override void Delete(LanguageDM domain)
        {
            try
            {
                if (domain == null || domain.ID <= 0 )
                    return;
                var Language = _DbContext.Languages.FirstOrDefault(s => s.ID == domain.ID);
                if (Language != null)
                {
                    if(Language.ID != 1)
                    {
                        _DbContext.Languages.Remove(Language);
                        _DbContext.SaveChanges();
                    }
                    else
                    {
                        _GlobalErrors.AddValidationError("", "You Can't Update English ");
                        _GlobalErrors.ErrorHandled = true;
                        throw new Exception();
                    }

                }
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Delete Language!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Delete Language!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override void Update(LanguageDM domain)
        {
            try
            {
                if (domain == null || domain.ID <= 0 || string.IsNullOrWhiteSpace(domain.Name))
                    return;
                var Language = _DbContext.Languages.FirstOrDefault(s => s.ID == domain.ID);
                if (Language != null)
                {
                    if (Language.ID != 1)
                    {
                        Language.ID = domain.ID;
                        Language.Name = domain.Name;

                        _DbContext.SaveChanges();
                    }
                    else
                    {
                        _GlobalErrors.AddValidationError("", "You Can't Update English ");
                        _GlobalErrors.ErrorHandled = true;
                        throw new Exception();
                    }

                }
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Update Language!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Update Language!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }

        }
    }
}
