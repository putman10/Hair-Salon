using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests.ModelsTests
{
    [TestClass]
    public class ClientTests : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }
        public void ClientDBTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_putman_test;";
        }

        [TestMethod]
        public void GetSetName_SetsGetsName_String()
        {
            Client newClient = new Client(1, 2, "Janet Jackson");

            Assert.AreEqual("Janet Jackson", newClient.GetName());
        }

        [TestMethod]
        public void GetSetId_SetsGetsId_Int()
        {
            Client newClient = new Client(1, 2, "Janet Jackson");

            Assert.AreEqual(1, newClient.GetId());
        }

        [TestMethod]
        public void GetSetStylistId_SetsGetsStylistId_Id()
        {
            Client newClient = new Client(1, 2, "Janet Jackson");

            Assert.AreEqual(2, newClient.GetStylistId());

        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Client.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfSameIds_Bool()
        {
            Client firstClient = new Client(1, 2, "Janet Jackson");
            Client secondClient = new Client(1, 2, "Janet Jackson");

            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SaveClientToDatabase_ClientList()
        {
            Client testClient = new Client(1, 2, "Janet Jackson");

            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { testClient };

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Client testClient = new Client(1, 2, "Janet Jackson");

            testClient.Save();
            Client savedClient = Client.GetAll()[0];

            int result = savedClient.GetId();
            int testId = testClient.GetId();

            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FinsIdOfObject_Id()
        {
            Client testClient = new Client(1, 2, "Janet Jackson");

            testClient.Save();
            Client savedClient = Client.Find(1);

            int result = savedClient.GetId();
            int testId = testClient.GetId();

            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Edit_UpdatesClientInDatabase_String()
        {
            //Arrange
            string firstName = "Janet Jackson";
            Client testClient = new Client(1, 2, firstName);
            testClient.Save();
            string secondName = "Jennifer Lopez";

            //Act
            testClient.Edit(secondName, 1);

            string result = Client.Find(testClient.GetId()).GetName();

            Assert.AreEqual(secondName, result);
        }

    }
}
