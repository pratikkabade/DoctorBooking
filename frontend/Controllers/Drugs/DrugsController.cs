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

    public class DrugsController : Controller
    {
        private static HttpClient httpDrugClient = new HttpClient();
        public DrugsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }



        //CREATE
        [HttpGet]
        public async Task<IActionResult> Drugs()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            await Task.Delay(1000);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Drugs(Drugs drugReq)
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpDrugClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var serializedProductToCreate = JsonConvert.SerializeObject(drugReq);
            var request = new HttpRequestMessage(HttpMethod.Post, Configuration.GetValue<string>("WebAPIBaseUrl") + "/drugs");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedProductToCreate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpDrugClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("DrugMessage", "Messages");
            }
            else
            {
                return RedirectToAction("Load1", "Error");
            }
        }



        //INDEX
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpDrugClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/drugs/");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var drugReq = new List<Drugs>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    drugReq = JsonConvert.DeserializeObject<List<Drugs>>(content);
                }
                return View(drugReq);
            }
            else
            {
                return RedirectToAction("Load1", "Error");
            }
        }


        //DrugSearch
        [HttpGet]
        public async Task<IActionResult> DrugSearch()
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/no-auth");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var drugReq = new List<Drugs>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    drugReq = JsonConvert.DeserializeObject<List<Drugs>>(content);
                }
                return View(drugReq);
            }
            else
            {
                return RedirectToAction("Load1", "Error");
            }
        }



        //DrugById
        [HttpGet]
        public async Task<IActionResult> DrugById(int id)
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/id/{id}");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var drugReq = new List<Drugs>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    drugReq = JsonConvert.DeserializeObject<List<Drugs>>(content);
                }
                return View(drugReq);
            }
            else
            {
                return RedirectToAction("Load1", "Error");
            }
        }








        //DrugByName
        [HttpGet]
        public async Task<IActionResult> DrugByName(string name)
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/name/{name}");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var drugReq = new List<Drugs>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    drugReq = JsonConvert.DeserializeObject<List<Drugs>>(content);
                }
                return View(drugReq);
            }
            else
            {
                return RedirectToAction("Load4", "Error");
            }
        }



        //DrugByLocation
        [HttpGet]
        public async Task<IActionResult> DrugByLocation(string location)
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/location/{location}");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var drugReq = new List<Drugs>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    drugReq = JsonConvert.DeserializeObject<List<Drugs>>(content);
                }
                return View(drugReq);
            }
            else
            {
                return RedirectToAction("Load4", "Error");
            }
        }



        //DrugByEMAIL
        [HttpGet]
        public async Task<IActionResult> MyDrugs(string email)
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/email/admin@gmail.com");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var drugReq = new List<Drugs>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    drugReq = JsonConvert.DeserializeObject<List<Drugs>>(content);
                }
                return View(drugReq);
            }
            else
            {
                return RedirectToAction("Load4", "Error");
            }
        }

    }
}
