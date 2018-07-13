using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult AllStylists()
        {
            List<Stylist> model = Stylist.GetAll();
            return View("Index", model);
        }

        [HttpGet("/stylists/new")]
        public ActionResult AddForm()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult AddStylist(string stylistName)
        {
            Stylist newStylist = new Stylist(stylistName);
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }


    }
}
