using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using CostCalc.Domain.Models;
using CostCalc.BLL.Services;
using CostCalc.API.DTO;
using CostCalc.Helper.ExceptionHandling;

namespace CostCalc.Web.Controllers
{
    public class QuotationsController : Controller
    {
        QuotaionService _QuotationService ;

        GlobalErrors _GlobalErrors;

        HttpClient client = new HttpClient();
        public QuotationsController()
        {
            client.BaseAddress = new Uri("http://localhost:54218/api/");
            client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue("application/json"));
            _GlobalErrors = new GlobalErrors();
            _QuotationService  = new QuotaionService(_GlobalErrors);
        }
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            CategoryService _CategoryService = new CategoryService(_GlobalErrors);
            SubjectService _SubjectService = new SubjectService(_GlobalErrors);
            LanguageService _LanguageService = new LanguageService(_GlobalErrors);
            QuotaionVM obj = new QuotaionVM();

            obj.CategoryVMList = _CategoryService.GetAllCategories()?.Select(s=> new CategoryVM(s)).ToList();
            obj.SubjectVMList  = _SubjectService.GetAllSubjects()?.Select(s => new SubjectVM(s)).ToList();
            obj.LanguageVMList = _LanguageService.GetAllLanguages()?.Select(s => new LanguageVM(s)).ToList();

            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(QuotaionVM Quot)
        {
            CategoryService _CategoryService = new CategoryService(_GlobalErrors);
            SubjectService _SubjectService = new SubjectService(_GlobalErrors);
            LanguageService _LanguageService = new LanguageService(_GlobalErrors);
            QuotaionVM obj = new QuotaionVM();

            //client.PostAsJsonAsync<QuotaionVM>("Quotaion", Quot).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));

            var x = _QuotationService.GetQuotationForCategory(Quot.MapVM_DM());
            //obj.QuotaionDetailsVMList = x.QuotaionDetailsList?.Select(s => new QuotaionDetailsVM(s)).ToList();
            //foreach (var item in obj.QuotaionDetailsVMList)
            //{
            //    item.EndDate = x.StartDate.AddDays((double)item.NumberOfDays - 1);
            //}
            obj.CategoryVMList = _CategoryService.GetAllCategories()?.Select(s => new CategoryVM(s)).ToList();
            obj.SubjectVMList = _SubjectService.GetAllSubjects()?.Select(s => new SubjectVM(s)).ToList();
            obj.LanguageVMList = _LanguageService.GetAllLanguages()?.Select(s => new LanguageVM(s)).ToList();


            return RedirectToAction("Details" , new { ID = x.ID });
        }

        public ActionResult Details(int ID)
        {
            CategoryService _CategoryService = new CategoryService(_GlobalErrors);
            SubjectService _SubjectService = new SubjectService(_GlobalErrors);
            LanguageService _LanguageService = new LanguageService(_GlobalErrors);
            QuotaionVM obj = new QuotaionVM();

            var QuotationDate = _QuotationService.QuotationStartDate(ID);
            
            obj.QuotaionDetailsVMList = _QuotationService.GetQuotationDetails(ID)?.Select(s => new QuotaionDetailsVM(s)).ToList();
            foreach (var item in obj.QuotaionDetailsVMList)
            {
                item.StartDate = QuotationDate.StartDate;
                item.EndDate = item.StartDate.AddDays((double)item.NumberOfDays - 1);
            }
            obj.CategoryVMList = _CategoryService.GetAllCategories()?.Select(s => new CategoryVM(s)).ToList();
            obj.SubjectVMList = _SubjectService.GetAllSubjects()?.Select(s => new SubjectVM(s)).ToList();
            obj.LanguageVMList = _LanguageService.GetAllLanguages()?.Select(s => new LanguageVM(s)).ToList();

            return View(obj);
        }


        public ActionResult Edit(int id)
        {
            var EmployeeDetails = client.GetAsync("Quotation/" + id.ToString()).Result;
            return View(EmployeeDetails.Content.ReadAsAsync<QuotaionVM>().Result);
        }

        [HttpPost]
        public ActionResult Edit(QuotaionVM Quot)
        {
            var editedEmployee = client.PutAsJsonAsync<QuotaionVM>("Quotation/" + Quot.ID, Quot).Result;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            var EmployeeDetails = client.DeleteAsync("Quotation/" + ID.ToString()).Result;
            return RedirectToAction("Index");
        }


        public ActionResult CreateRushRequest()
        {
            CategoryService _CategoryService = new CategoryService(_GlobalErrors);
            SubjectService _SubjectService = new SubjectService(_GlobalErrors);
            LanguageService _LanguageService = new LanguageService(_GlobalErrors);
            QuotaionVM obj = new QuotaionVM();

            obj.CategoryVMList = _CategoryService.GetAllCategories()?.Select(s => new CategoryVM(s)).ToList();
            obj.SubjectVMList = _SubjectService.GetAllSubjects()?.Select(s => new SubjectVM(s)).ToList();
            obj.LanguageVMList = _LanguageService.GetAllLanguages()?.Select(s => new LanguageVM(s)).ToList();

            return View(obj);
        }

        [HttpPost]
        public ActionResult CreateRushRequest(QuotaionVM Quot)
        {
            CategoryService _CategoryService = new CategoryService(_GlobalErrors);
            SubjectService _SubjectService = new SubjectService(_GlobalErrors);
            LanguageService _LanguageService = new LanguageService(_GlobalErrors);
            QuotaionVM obj = new QuotaionVM();

            //client.PostAsJsonAsync<QuotaionVM>("Quotaion", Quot).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));

            var x = _QuotationService.GetQuotationForCategory(Quot.MapVM_DM());

            obj.CategoryVMList = _CategoryService.GetAllCategories()?.Select(s => new CategoryVM(s)).ToList();
            obj.SubjectVMList = _SubjectService.GetAllSubjects()?.Select(s => new SubjectVM(s)).ToList();
            obj.LanguageVMList = _LanguageService.GetAllLanguages()?.Select(s => new LanguageVM(s)).ToList();


            return RedirectToAction("Details", new { ID = x.ID });
        }


    }
}