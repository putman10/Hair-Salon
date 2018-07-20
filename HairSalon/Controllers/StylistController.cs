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
            return View(model);
        }

        [HttpPost("/stylists/{id}/delete")]
        public ActionResult DeleteStylist(int id)
        {
            Stylist.DeleteStylist(id);
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/all/delete")]
        public ActionResult DeleteStylist()
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/new")]
        public ActionResult AddForm()
        {
            return View();
        }

        [HttpPost("/stylists/new")]
        public ActionResult AddStylist(string name, int id, string description)
        {
            id = 0;
            Stylist newStylist = new Stylist(name, description, id);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult EditForm(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist thisStylist = Stylist.Find(id);
            List<Client> stylistClients = thisStylist.GetClients();
            model.Add("stylist", thisStylist);
            model.Add("clients", stylistClients);
            return View(model);
        }

        [HttpPost("/stylists/{id}/edit")]
        public ActionResult EditStylist(int id, string newName, string newDescription)
        {
            Stylist thisStylist = Stylist.Find(id);
            thisStylist.Edit(newName, newDescription);
            return RedirectToAction("Index");
        }
    }
}
