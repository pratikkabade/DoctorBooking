using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using frontend.Models;

namespace frontend.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult CreateMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult EditMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult DeleteMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult SentMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult MedicineMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult DoctorMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult OrderMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult DrugMessage()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

    }
}
