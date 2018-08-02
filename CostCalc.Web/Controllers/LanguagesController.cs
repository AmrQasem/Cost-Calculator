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

namespace CostCalc.Web.Controllers
{
    public class LanguagesController : Controller
    {
        HttpClient client = new HttpClient();
        public LanguagesController()
        {
            client.BaseAddress = new Uri("http://localhost:54218/api/");
            client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Language
        public ActionResult Index()
        {
            List<LanguageVM> Language = new List<LanguageVM>();
            HttpResponseMessage response = client.GetAsync("language").Result;
            if (response.IsSuccessStatusCode)
            {
                Language = response.Content.ReadAsAsync<List<LanguageVM>>().Result;
            }
            return View(Language);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LanguageVM Lang)
        {
            client.PostAsJsonAsync<LanguageVM>("language", Lang).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var EmployeeDetails = client.GetAsync("language/" + id.ToString()).Result;
            return View(EmployeeDetails.Content.ReadAsAsync<LanguageVM>().Result);
        }

        [HttpPost]
        public ActionResult Edit(LanguageVM Lang)
        {
            var editedEmployee = client.PutAsJsonAsync<LanguageVM>("language/" + Lang.ID, Lang).Result;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            var EmployeeDetails = client.DeleteAsync("language/" + ID.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}