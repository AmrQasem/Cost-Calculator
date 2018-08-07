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
            try
            {
                if (domain == null || domain.FromLangID <= 0 || domain.ToLangID <= 0)
                    return;
                Quotation obj = new Quotation();

                obj.FromLangID = domain.FromLangID;
                obj.ToLangID = domain.ToLangID;
                obj.WordCount = domain.WordCount;
                obj.IP_Address = domain.IP_Address;
                obj.IsRush = domain.IsRush;
                obj.SubjectID = domain.Subject.ID;
                obj.StartDate = domain.StartDate;

                _DbContext.Quotations.Add(obj);
                _DbContext.SaveChanges();

                domain.ID = obj.ID;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Add Quotation!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Add Quotation!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }

        }

        public void AddDetails(QuotaionDetailsDM domain)
        {
            try
            {
                if (domain == null)
                    return;
                QuotationDetail obj = new QuotationDetail();

                obj.NumberOfDays = domain.NumberOfDays;
                obj.CategoryID = domain.Category.ID;
                obj.Price = domain.Price;
                obj.QuotationID = domain.Quotaion.ID;

                _DbContext.QuotationDetails.Add(obj);
                _DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Add QuotationDetails!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Add QuotationDetails!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
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
            try
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
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get SubjectDetails!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get SubjectDetails!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }

        public List<QuotaionDetailsDM> GetAllQuotationDetails(int ID)
        {

            var QuotationDetails = _DbContext.QuotationDetails.Where(s => s.QuotationID == ID);
            List<QuotaionDetailsDM> QuotaionDetailsDMList = new List<QuotaionDetailsDM>();

            if (QuotationDetails != null)
            {
                foreach (var item in QuotationDetails)
                {
                    QuotaionDetailsDM QuotDetailsDM = new QuotaionDetailsDM(_GlobalErrors);
                    QuotDetailsDM.ID = item.ID;
                    QuotDetailsDM.NumberOfDays = item.NumberOfDays;
                    QuotDetailsDM.Price = item.Price;
                    QuotDetailsDM.Quotaion = new QuotationDM(_GlobalErrors) { ID = item.QuotationID };
                    QuotDetailsDM.Category = new CategoryDM(_GlobalErrors) { ID = item.CategoryID , CategoryName = item.Category.CategoryName };


                    QuotaionDetailsDMList.Add(QuotDetailsDM);
                }
            }
            return QuotaionDetailsDMList;
        }

        public QuotationDM GetQuotationStartDate(int ID)
        {
            try
            {
                if (ID <= 0)
                    return null;

                var QuotationDate = _DbContext.Quotations.FirstOrDefault(s => s.ID == ID);
                if (QuotationDate != null)
                {
                    QuotationDM QuotDM = new QuotationDM(_GlobalErrors);
                    QuotDM.ID = QuotationDate.ID;
                    QuotDM.StartDate = QuotationDate.StartDate;

                    return QuotDM;
                }
                return null;
            }
            catch (Exception ex)
            {
                //Errors in this scope indicates system error (not validation errors)
                //If error not handled, log it and add system error
                if (!_GlobalErrors.ErrorHandled)
                {
                    _Logger.Error(ex, "Database Error: Cannot Get Specific Category!");
                    _GlobalErrors.AddSystemError("Database Error: Cannot Get Specific Category!");
                    _GlobalErrors.ErrorHandled = true;
                }
                throw;
            }
        }
    }
}
