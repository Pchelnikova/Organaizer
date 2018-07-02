using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
            //var moqGenerator = new Mock<DbContext>();
            var moqGenerator = new Mock<DbContext>();
            moqGenerator
                .Setup(m => m.Set<Diary>())
                .Returns(  (new FakeDbSet<Diary>() { new Diary { Id = -1 } })     );
            _dal = new DataDAL(moqGenerator.Object);
            var all_notes = _dal.Get_All_Notes("1").Count;
             _dal.Add_Note(_dal.Get_All_Notes("1")[0].Text,
                _dal.Get_All_Notes("1")[0].User.Login);
            var all_notes_added = _dal.Get_All_Notes("1").Count;
            Assert.AreEqual(1, all_notes_added - all_notes);                             
        }
    }
}
