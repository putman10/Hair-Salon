using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class SpecialtyControllerTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }
        public SpecialtyControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_putman_test;";
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult allView = controller.Index();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_List()
        {
            ViewResult resultsView = new SpecialtyController().Index() as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Specialty>));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult allView = controller.Details(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new SpecialtyController().Details(1) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void AddForm_ReturnsCorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult allView = controller.AddForm();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void AddForm_HasCorrectModelType_Object()
        {
            ViewResult resultsView = new SpecialtyController().AddForm() as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Specialty>));
        }

        [TestMethod]
        public void EditForm_ReturnsCorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult allView = controller.EditForm(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void EditForm_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new SpecialtyController().EditForm(1) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Specialty));
        }
    }
}