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
            List<Stylist> model = Stylist.GetAll();
            return View(model);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            return View(stylistClients);
        }

        [HttpPost("/stylists/{id}/delete")]
        public ActionResult DeleteStylist(int id)
        {
            Stylist.DeleteStylist(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/new")]
        public ActionResult AddForm()
        {
            return View();
        }

        [HttpPost("/stylists/new")]
        public ActionResult AddStylist(string name, int id)
        {
            id = 0;
            Stylist newStylist = new Stylist(name, id);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult EditForm(int id)
        {
            Stylist thisStylist = Stylist.Find(id);
            return View(thisStylist);
        }

        [HttpPost("/stylists/{id}/edit")]
        public ActionResult EditStylist(int id, string newname)
        {
            Stylist thisStylist = Stylist.Find(id);
            thisStylist.Edit(newname);
            return RedirectToAction("Index");
        }


    }
}
