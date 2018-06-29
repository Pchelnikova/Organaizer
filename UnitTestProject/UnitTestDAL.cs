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
                m.Get_All_Notes("1")).Returns(new List<Diary>() { new Diary()
                    {
                        Date = DateTime.Now,
                        Id = 0,
                        Text = "drrrr",
                        User = new User(){Login = "1", Password_ = "1" }
                    },
                    new Diary()
                 {
                        Date = DateTime.Now,
                        Id = 1,
                        Text = "trrrr",
                        User = new User(){Login = "1", Password_ = "1" }
                 }
                }) ;
            var all_notes = moqGenerator.Object.Get_All_Notes("1").Count;
             moqGenerator.Object.Add_Note(moqGenerator.Object.Get_All_Notes("1")[0].Text,
                 moqGenerator.Object.Get_All_Notes("1")[0].User.Login);
            var all_notes_added = moqGenerator.Object.Get_All_Notes("1").Count;
            Assert.AreEqual(1, all_notes_added - all_notes);                             
        }
    }
}
