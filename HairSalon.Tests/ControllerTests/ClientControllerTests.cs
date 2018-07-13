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
            Client.DeleteAll();
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
    }
}