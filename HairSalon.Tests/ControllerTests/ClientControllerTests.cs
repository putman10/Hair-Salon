using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class ClientControllerTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }
        public ClientControllerTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_putman_test;";
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult allView = controller.Index();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_List()
        {
            ViewResult resultsView = new ClientController().Index() as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Client>));
        }

        [TestMethod]
        public void ClientByStylist_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult allView = controller.Index();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void ClientByStylist_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new ClientController().ClientByStylist(1, 2) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<object, object>));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult allView = controller.Details(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new ClientController().Details(1) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<object, object>));
        }

        [TestMethod]
        public void CreateClientForm_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult allView = controller.CreateClientForm(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateClientForm_HasCorrectModelType_Object()
        {
            ViewResult resultsView = new ClientController().CreateClientForm(1) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(object));
        }

        [TestMethod]
        public void AddForm_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult allView = controller.AddForm();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void AddForm_HasCorrectModelType_List()
        {
            ViewResult resultsView = new ClientController().AddForm() as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void EditForm_ReturnsCorrectView_True()
        {
            ClientController controller = new ClientController();
            ActionResult allView = controller.EditForm(1);
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void EditForm_HasCorrectModelType_Dictionary()
        {
            ViewResult resultsView = new ClientController().EditForm(1) as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<object, object>));
        }
    }
}