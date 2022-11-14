using ASP.NET_WebAPI_With_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_WebAPI_With_Db.Controllers
{
    public class ConsumeController : Controller
    {  
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<student> list = new List<student>();
            client.BaseAddress = new Uri("https://localhost:44321/api/NewApi");
            var response = client.GetAsync("NewApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<student>>();
                display.Wait();
                list = display.Result;
            }

            return View(list);
        }
        
        [HttpPost]
        public ActionResult Create(student std)
        {
            client.BaseAddress = new Uri("https://localhost:44321/api/NewApi");
            var response = client.PostAsJsonAsync<student>("NewApi", std);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        public ActionResult Details(int id)
        {
            student e = null;
            client.BaseAddress = new Uri("https://localhost:44321/api/NewApi");
            var response = client.GetAsync("NewApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            student e = null;
            client.BaseAddress = new Uri("https://localhost:44321/api/NewApi");
            var response = client.GetAsync("NewApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(student e)
        {
            client.BaseAddress = new Uri("https://localhost:44321/api/NewApi");
            var response = client.PutAsJsonAsync<student>("NewApi", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

    }
}