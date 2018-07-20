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
            return View(Specialty.GetAll());
        }

        [HttpPost("/stylists/new")]
        public ActionResult AddStylist(string name, int id, string description, string[] specialtyFields, int[] specialties)
        {
            id = 0;
            Stylist newStylist = new Stylist(name, description, id);
            newStylist.Save();
            int stylistId = Stylist.FindLastAdded();
            Specialty.CreateSpecialtyStylistPairing(stylistId, specialties);

            if (!(specialtyFields[0] == null))
            {
                int[] listOfNewSpecialtiesIds = Specialty.SaveListOfSpecialties(specialtyFields);
                Specialty.CreateSpecialtyStylistPairing(stylistId, listOfNewSpecialtiesIds);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult EditForm(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist thisStylist = Stylist.Find(id);
            List<Specialty> allSpecialties = Specialty.GetAll();
            List<Client> stylistClients = thisStylist.GetClients();
            model.Add("stylist", thisStylist);
            model.Add("clients", stylistClients);
            model.Add("specialties", allSpecialties);

            return View(model);
        }

        [HttpPost("/stylists/{id}/edit")]
        public ActionResult EditStylist(int id, string newName, string newDescription, string[] specialtyFields, int[] specialties)
        {
            Stylist thisStylist = Stylist.Find(id);
            thisStylist.Edit(newName, newDescription);

            Specialty.CreateSpecialtyStylistPairing(id, specialties);

            if (!(specialtyFields[0] == null))
            {
                int[] listOfNewSpecialtiesIds = Specialty.SaveListOfSpecialties(specialtyFields);
                Specialty.CreateSpecialtyStylistPairing(id, listOfNewSpecialtiesIds);
            }

            return RedirectToAction("Index");
        }
    }
}
