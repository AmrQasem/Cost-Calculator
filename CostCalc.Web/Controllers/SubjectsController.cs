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
    public class SubjectsController : Controller
    {
        HttpClient client = new HttpClient();
        public SubjectsController()
        {
            client.BaseAddress = new Uri("http://localhost:54218/api/");
            client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue("appliSubion/json"));
        }
        // GET: Subject
        public ActionResult Index()
        {
            List<SubjectVM> Subject = new List<SubjectVM>();
            HttpResponseMessage response = client.GetAsync("subject").Result;
            if (response.IsSuccessStatusCode)
            {
                Subject = response.Content.ReadAsAsync<List<SubjectVM>>().Result;
            }
            return View(Subject);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SubjectVM Sub)
        {
            client.PostAsJsonAsync<SubjectVM>("subject", Sub).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var EmployeeDetails = client.GetAsync("subject/" + id.ToString()).Result;
            return View(EmployeeDetails.Content.ReadAsAsync<SubjectVM>().Result);
        }

        [HttpPost]
        public ActionResult Edit(SubjectVM Sub)
        {
            var editedEmployee = client.PutAsJsonAsync<SubjectVM>("subject/" + Sub.ID, Sub).Result;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            var EmployeeDetails = client.DeleteAsync("subject/" + ID.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}