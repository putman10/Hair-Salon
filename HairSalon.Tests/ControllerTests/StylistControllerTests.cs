using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class StylistControllerTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        [TestMethod]
        public void All_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            ActionResult allView = controller.Index();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Results_HasCorrectModelType_Stylist()
        {
            ViewResult resultsView = new StylistController().AllStylists(1) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void Add_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            ActionResult addView = controller.AddForm("apple", 1);
            Assert.IsInstanceOfType(addView, typeof(RedirectToActionResult));
        }
    }
}
