using CostCalc.DAL.EF;
using CostCalc.Domain.Models;
using CostCalc.Helper.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostCalc.DAL.Repositories
{
    public class QuotaionRepository : BaseRepository<QuotationDM, int>
    {
        public QuotaionRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }
        public override void Add(QuotationDM domain)
        {
            Job obj = new Job();

            obj.FromLangID = domain.FromLangID;
            obj.ToLangID = domain.ToLangID;
            obj.WordCount = domain.WordCount;
            obj.IP_Address = domain.IP_Address;
            obj.IsRush = domain.IsRush;
            obj.SubjectID = domain.Subject.ID;

            _DbContext.Jobs.Add(obj);
            _DbContext.SaveChanges();

            domain.ID = obj.ID;
        }

        public  void AddDetails(QuotaionDetailsDM domain)
        {
            JobDetail obj = new JobDetail();

            obj.NumberOfDays = domain.NumberOfDays;
            obj.CategoryID = domain.Category.ID;
            obj.Price = domain.Price;
            obj.StartDate = domain.StartDate;
            obj.EndDate = domain.EndDate;
            obj.JobID = domain.Quotaion.ID;


            _DbContext.JobDetails.Add(obj);
            _DbContext.SaveChanges();
        }

        public override void Delete(QuotationDM domain)
        {
            throw new NotImplementedException();
        }

        public override QuotationDM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(QuotationDM domain)
        {
            throw new NotImplementedException();
        }

        public List<SubjectDM> GetSubjects(int? ID)
        {
            var SubjectDetails = ID == 0 ? _DbContext.Subjects : _DbContext.Subjects.Where(s => s.ID == ID);
            List<SubjectDM> SubjectDMList = new List<SubjectDM>();
            foreach (var item in SubjectDetails)
            {
                SubjectDM SubDM = new SubjectDM(_GlobalErrors);
                SubDM.ID = item.ID;
                SubDM.SubjectTitle = item.SubjectTitle;

                SubjectDMList.Add(SubDM);
            }
            return SubjectDMList;
        }
    }
}
