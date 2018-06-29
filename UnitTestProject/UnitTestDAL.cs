using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestDAL
    {
        private DataDAL _dal = null;

        [TestInitialize]
        public void InitTest()
        {
            _dal = new DataDAL(new Model());
        }

        [TestCleanup]
        public void MethodAfter()
        {
            _dal = null;
        }

        [TestMethod]
        public void Test_Add_Note()
        {
            var moqGenerator = new Mock<IServiceDAL>();
            moqGenerator.Setup(m =>
                m.Get_All_Notes(It.IsIn<string>("1"))).Returns(new List<Diary>() { new Diary(), new Diary() }) ;
            var all_notes = _dal.Get_All_Notes("1").Count;
            _dal.Add_Note(moqGenerator.Object.Get_All_Notes("1").ToString(),  moqGenerator.Object.Get_All_Notes("1").ToString());
            var all_notes_added = _dal.Get_All_Notes("1").Count;
            Assert.AreEqual(1, all_notes_added - all_notes);                             
        }
    }
}
