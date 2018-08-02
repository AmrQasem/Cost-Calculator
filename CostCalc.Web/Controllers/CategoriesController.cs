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
    public class CategoriesController : Controller
    {
        HttpClient client = new HttpClient();
        public CategoriesController()
        {
            client.BaseAddress = new Uri("http://localhost:54218/api/");
            client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryVM> Category = new List<CategoryVM>();
            HttpResponseMessage response = client.GetAsync("category").Result;
            if (response.IsSuccessStatusCode)
            {
                Category = response.Content.ReadAsAsync<List<CategoryVM>>().Result;
            }
            return View(Category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryVM Cat)
        {
            client.PostAsJsonAsync<CategoryVM>("category", Cat).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var EmployeeDetails = client.GetAsync("category/" + id.ToString()).Result;
            return View(EmployeeDetails.Content.ReadAsAsync<CategoryVM>().Result);
        }

        [HttpPost]
        public ActionResult Edit(CategoryVM Cat)
        {
            var editedEmployee = client.PutAsJsonAsync<CategoryVM>("category/" + Cat.ID, Cat).Result;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            var EmployeeDetails = client.DeleteAsync("category/" + ID.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}