using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests.ModelsTests
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public void Dispose()
        {
            Specialty.DeleteAll();
        }
        public void SpecialtyDBTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_putman_test;";
        }

        [TestMethod]
        public void GetSetName_SetsGetsName_String()
        {
            Specialty newSpecialty = new Specialty("Buzz Cuts", 1);

            Assert.AreEqual("Buzz Cuts", newSpecialty.name);
        }

        [TestMethod]
        public void GetSetId_SetsGetsId_Int()
        {
            Specialty newSpecialty = new Specialty("Buzz Cuts", 1);

            Assert.AreEqual(1, newSpecialty.id);
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Specialty.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfSameIds_Bool()
        {
            Specialty firstSpecialty = new Specialty("Buzz Cuts", 2);
            Specialty secondSpecialty = new Specialty("Buzz Cuts", 2);

            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void Save_SaveSpecialtyToDatabase_SpecialtyList()
        {
            Specialty testSpecialty = new Specialty("Buzz Cuts", 1);

            testSpecialty.Save();
            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty> { testSpecialty };

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Specialty testSpecialty = new Specialty("Buzz Cuts", 1);

            testSpecialty.Save();
            Specialty savedSpecialty = Specialty.GetAll()[0];

            int result = savedSpecialty.id;
            int testId = testSpecialty.id;

            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsIdOfObject_Id()
        {
            Specialty testSpecialty = new Specialty("Buzz Cuts", 1);

            testSpecialty.Save();
            Specialty savedSpecialty = Specialty.Find(testSpecialty.id);

            int result = savedSpecialty.id;
            int testId = testSpecialty.id;

            Assert.AreEqual(testId, result);
        }

    }
}
