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

        public override LanguageDM GetById(int id)
        {
            var Language = _DbContext.Languages.FirstOrDefault(s => s.ID == id);
            if (Language != null)
            {

                LanguageDM LangDM = new LanguageDM(_GlobalErrors);
                LangDM.ID = Language.ID;
                LangDM.Name = Language.Name;
                return LangDM;
            }
            else
                return null;

        }

        public override void Add(LanguageDM domain)
        {
            Language obj = new Language();
            obj.ID = domain.ID;
            obj.Name = domain.Name;

            _DbContext.Languages.Add(obj);
            _DbContext.SaveChanges();
            domain.ID = obj.ID;
        }

        public override void Delete(LanguageDM domain)
        {
            var Language = _DbContext.Languages.FirstOrDefault(s => s.ID == domain.ID);
            if (Language != null)
            {
                _DbContext.Languages.Remove(Language);
                _DbContext.SaveChanges();
            }
        }

        public override void Update(LanguageDM domain)
        {
            var Language = _DbContext.Languages.FirstOrDefault(s => s.ID == domain.ID);
            if (Language != null)
            {
                Language.ID = domain.ID;
                Language.Name = domain.Name;

                _DbContext.SaveChanges();
            }
        }
    }
}
