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

        [HttpPost]
        public async Task<IActionResult> DrugSearch()
        {
            await Task.Delay(1000);
            HttpContext.Session.SetString("DrugId", Request.Form["DrugId"]);
            HttpContext.Session.SetString("DrugName", Request.Form["DrugName"]);
            return RedirectToAction("DrugSearch", "Drugs");
        }



        //DrugById_dd
        [HttpGet]
        public async Task<IActionResult> DrugById(int DrugId)
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // httpDrugClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/id/{DrugId}");
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
        // //DrugById
        // [HttpGet]
        // public async Task<IActionResult> DrugById(int id)
        // {
        //     var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/drugs/id/{id}");
        //     response.EnsureSuccessStatusCode();
        //     var content = await response.Content.ReadAsStringAsync();

        //     ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

        //     var drugReq = new Drugs();
        //     if (response.Content.Headers.ContentType.MediaType == "application/json")
        //     {
        //         drugReq = JsonConvert.DeserializeObject<Drugs>(content);
        //     }
        //     return View(drugReq);
        // }








        //DrugByName
        [HttpGet]
        public async Task<IActionResult> DrugByName()
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // httpDrugClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/drugs/name/sinarest");
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



        //DrugByLocation
        [HttpGet]
        public async Task<IActionResult> DrugByLocation()
        {
            httpDrugClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // httpDrugClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpDrugClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/drugs/id/1");
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

    }
}
