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
    public class SubjectRepository : BaseRepository<SubjectDM, int>
    {
        public SubjectRepository(GlobalErrors globalErrors) : base(globalErrors)
        {
        }

        public List<SubjectDM> GetAllSubjects()
        {
            var SubjectDetails = _DbContext.Subjects;
            List<SubjectDM> SubjectDMList = new List<SubjectDM>();
            foreach (var item in SubjectDetails)
            {
                SubjectDM SubjectDM = new SubjectDM(_GlobalErrors);
                SubjectDM.ID = item.ID;
                SubjectDM.SubjectTitle = item.SubjectTitle;
                SubjectDMList.Add(SubjectDM);
            }
            return SubjectDMList;
        }

        public override SubjectDM GetById(int id)
        {
            var Subject = _DbContext.Subjects.FirstOrDefault(s => s.ID == id);
            if (Subject != null)
            {

                SubjectDM SubjectDM = new SubjectDM(_GlobalErrors);
                SubjectDM.ID = Subject.ID;
                SubjectDM.SubjectTitle = Subject.SubjectTitle;
                return SubjectDM;
            }
            else
                return null;

        }

        public override void Add(SubjectDM domain)
        {
            Subject obj = new Subject();
            obj.ID = domain.ID;
            obj.SubjectTitle = domain.SubjectTitle;

            _DbContext.Subjects.Add(obj);
            _DbContext.SaveChanges();
            domain.ID = obj.ID;
        }

        public override void Delete(SubjectDM domain)
        {
            var Subject = _DbContext.Subjects.FirstOrDefault(s => s.ID == domain.ID);
            if (Subject != null)
            {
                _DbContext.Subjects.Remove(Subject);
                _DbContext.SaveChanges();
            }
        }

        public override void Update(SubjectDM domain)
        {
            var Subject = _DbContext.Subjects.FirstOrDefault(s => s.ID == domain.ID);
            if (Subject != null)
            {
                Subject.ID = domain.ID;
                Subject.SubjectTitle = domain.SubjectTitle;

                _DbContext.SaveChanges();
            }
        }
    }
}
