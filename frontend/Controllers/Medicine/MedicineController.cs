using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using frontend.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace frontend.Controllers
{

    public class MedicineController : Controller
    {
        private static HttpClient httpMsgClient = new HttpClient();
        public MedicineController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }



        //CREATE
        [HttpGet]
        public async Task<IActionResult> Medicine()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            await Task.Delay(1000);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Medicine(Medicine medicineReq)
        {
            if (ModelState.IsValid)
            {
                var serializedProductToCreate = JsonConvert.SerializeObject(medicineReq);
                var request = new HttpRequestMessage(HttpMethod.Post, Configuration.GetValue<string>("WebAPIBaseUrl") + "/medicine");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToCreate);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpMsgClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("MedicineMessage", "Messages");
                }
                else
                {
                    return RedirectToAction("Error401", "Error");
                }
            }
            else
                return RedirectToAction("Error404", "Error");
        }



        //INDEX
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            httpMsgClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpMsgClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpMsgClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/medicine");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var medicineReq = new List<Medicine>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    medicineReq = JsonConvert.DeserializeObject<List<Medicine>>(content);
                }
                return View(medicineReq);
            }
            else
            {
                return RedirectToAction("Error401", "Error");
            }
        }

    }
}
