﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> model = Specialty.GetAll();
            return View(model);
        }

        [HttpGet("/stylists/{id}/specialties/new")]
        public ActionResult CreateSpecialtyForm(int id)
        {
            Specialty model = Specialty.Find(id);
            return View(model);
        }

        [HttpGet("/specialties/new")]
        public ActionResult AddForm()
        {
            List<Specialty> results = Specialty.GetAll();
            return View(results); ;
        }

        [HttpPost("/specialties/new")]
        public ActionResult AddSpecialty(string name)
        {
            int id = 0;
            Specialty newSpecialty = new Specialty(name, id);
            newSpecialty.Save();
            return RedirectToAction("Index");
        }
    }
}