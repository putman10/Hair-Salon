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
        public void Index_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            ActionResult allView = controller.Index();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_List()
        {
            ViewResult resultsView = new StylistController().Index() as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            ActionResult allView = controller.Details(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new StylistController().Details(3) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void AddForm_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            ActionResult allView = controller.AddForm();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void EditForm_ReturnsCorrectView_True()
        {
            StylistController controller = new StylistController();
            ActionResult allView = controller.EditForm(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void EditForm_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new StylistController().EditForm(3) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

    }
}
