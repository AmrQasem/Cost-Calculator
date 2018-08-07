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
            try
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
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get All Subjects!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get All Subjects!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override SubjectDM GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return null;
                var Subject = _DbContext.Subjects.FirstOrDefault(s => s.ID == id);
                if (Subject != null)
                {

                    SubjectDM SubjectDM = new SubjectDM(_GlobalErrors);
                    SubjectDM.ID = Subject.ID;
                    SubjectDM.SubjectTitle = Subject.SubjectTitle;
                    return SubjectDM;
                }

                return null;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get Specific Subject!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get Specific Subject!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override void Add(SubjectDM domain)
        {
            try
            {
                if (domain == null || string.IsNullOrWhiteSpace(domain.SubjectTitle))
                    return;
                Subject obj = new Subject();
                obj.ID = domain.ID;
                obj.SubjectTitle = domain.SubjectTitle;

                _DbContext.Subjects.Add(obj);
                _DbContext.SaveChanges();
                domain.ID = obj.ID;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Add Subject!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Add Subject!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override void Delete(SubjectDM domain)
        {
            try
            {
                if (domain == null || domain.ID <= 0)
                    return;
                var Subject = _DbContext.Subjects.FirstOrDefault(s => s.ID == domain.ID);
                if (Subject != null)
                {
                    _DbContext.Subjects.Remove(Subject);
                    _DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Delete Subject!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Delete Subject!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public override void Update(SubjectDM domain)
        {
            try
            {
                if (domain == null || domain.ID <= 0 || string.IsNullOrWhiteSpace(domain.SubjectTitle))
                    return;
                var Subject = _DbContext.Subjects.FirstOrDefault(s => s.ID == domain.ID);
                if (Subject != null)
                {
                    Subject.ID = domain.ID;
                    Subject.SubjectTitle = domain.SubjectTitle;

                    _DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Update Subject!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Update Subject!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }
    }
}
