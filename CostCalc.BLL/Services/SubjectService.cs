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
            return _SubjectRepo.GetAllSubjects();
        }

        public SubjectDM GetById(int id)
        {
            return _SubjectRepo.GetById(id);
        }
        public void Add(SubjectDM domain)
        {
            _SubjectRepo.Add(domain);
        }

        public void Delete(SubjectDM domain)
        {
            _SubjectRepo.Delete(domain);
        }

        public void Update(SubjectDM domain)
        {
            _SubjectRepo.Update(domain);
        }
    }
}