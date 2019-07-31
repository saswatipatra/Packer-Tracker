using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackerTracker.Models;
using System.Collections.Generic;
using System;

namespace PackerTracker.Tests
{
    [TestClass]
    public class PackerTest: IDisposable
    {
        public void Dispose()
        {
            Packer.ClearAll();
        }

        [TestMethod]
        public void AddPackerList_CreatesInstanceOfTheTrip_ListOfItems()
        {
            Packer instanceName = new Packer("sunscream", 5, true, false);
            Assert.AreEqual(typeof(Packer), instanceName.GetType());
        }
        [TestMethod]
        public void DisplayPackerList_ShowsAllList_ListsOfItems()
        {
            Packer newPacker01= new Packer("sunscream", 5, true, false);
            Packer newPacker02= new Packer("Towel", 20, false, false);
            List<Packer> newList = new List<Packer>{newPacker01,newPacker02};
            List<Packer> result= Packer.GetAll();
            CollectionAssert.AreEqual(newList,result);
        }

        [TestMethod]
        public void FindingPacker_SearchPackerById_SearchPacker()
        {
            Packer newPacker01= new Packer("sunscream", 5, true, false);
            Packer newPacker02= new Packer("Towel", 20, false, false);
            Packer result= Packer.Search(2);
            Assert.AreEqual(newPacker02, result);
        }
    }
}