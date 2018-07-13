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

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult ClientByStylist(int stylistId, int clientId)
        {
            return View();
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client model = Client.Find(id);
            return View(model);
        }

        [HttpGet("/stylists/{id}/clients/new")]
        public ActionResult CreateClientForm(int id)
        {
            Client model = Client.Find(id);
            return View(model);
        }

        [HttpPost("/clients")]
        public ActionResult AddClient()
        {
            return View();
        }


    }
}
