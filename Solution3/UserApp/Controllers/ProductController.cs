using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UserApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProducts()
        {
            List<UserAPI.Models.Product> api = new List<UserAPI.Models.Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60762/");
                var response = client.GetAsync("Product/GetProducts");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var GetData = result.Content.ReadAsAsync<List<UserAPI.Models.Product>>();
                    api = GetData.Result;
                }
                return View(api);
            }
        }
    }
}