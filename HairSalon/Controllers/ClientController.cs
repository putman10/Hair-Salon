using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> model = Client.GetAll();
            return View(model);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult ClientByStylist(int stylistId, int clientId)
        {
            Dictionary<object, object> model = new Dictionary<object, object>();
            Stylist selectedStylist = Stylist.Find(stylistId);
            Client selectedClient = Client.Find(clientId);
            model.Add("stylist", selectedStylist);
            model.Add("client", selectedClient);
            return View("Details", model);
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<object, object> model = new Dictionary<object, object>();
            Client selectedClient = Client.Find(id);
            int stylistId = selectedClient.GetStylistId();
            Stylist selectedStylist = Stylist.Find(stylistId);
            model.Add("stylist", selectedStylist);
            model.Add("client", selectedClient);
            return View(model);
        }

        [HttpPost("/clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
            Client.DeleteClient(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/clients/new")]
        public ActionResult CreateClientForm(int id)
        {
            Client model = Client.Find(id);
            return View(model);
        }

        [HttpGet("/clients/new")]
        public ActionResult AddForm()
        {
            List<Stylist> results = Stylist.GetAll();
            return View(results);;
        }

        [HttpPost("/clients/new")]
        public ActionResult AddClient(int stylist, string name)
        {
            int id = 0;
            Client newClient = new Client(id, stylist, name);
            newClient.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/Clients/{id}/edit")]
        public ActionResult EditForm(int id)
        {
            Dictionary<object, object> model = new Dictionary<object, object>();
            List<Stylist> allStylists = Stylist.GetAll();
            Client thisClient = Client.Find(id);
            model.Add("stylists", allStylists);
            model.Add("client", thisClient);
            return View(model);
        }

        [HttpPost("/Clients/{id}/edit")]
        public ActionResult EditClient(int id, string newName, int stylist)
        {
            Client thisClient = Client.Find(id);
            thisClient.Edit(newName, stylist);
            return RedirectToAction("Details");
        }


    }
}
