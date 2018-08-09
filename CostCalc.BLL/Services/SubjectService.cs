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
    public class SubjectService : BaseService
    {
        SubjectRepository _SubjectRepo;
        SubjectDM _SubjectnDM;

        public SubjectService(GlobalErrors globalErrors) : base(globalErrors)
        {
            _SubjectRepo = new SubjectRepository(globalErrors);
            _SubjectnDM = new SubjectDM(globalErrors);
        }
        public List<SubjectDM> GetAllSubjects()
        {
            try
            {
                return _SubjectRepo.GetAllSubjects();
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

        public SubjectDM GetById(int id)
        {
            try
            {
                return _SubjectRepo.GetById(id);
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
        public void Add(SubjectDM domain)
        {
            try
            {
                _SubjectRepo.Add(domain);
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

        public void Delete(SubjectDM domain)
        {
            try
            {
                _SubjectRepo.Delete(domain);
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

        public void Update(SubjectDM domain)
        {
            try
            {
                _SubjectRepo.Update(domain);
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