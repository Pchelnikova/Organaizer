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

        //public class FakeBreakeAwayContext : IBreakAwayContext
        //{
        //    public FakeBreakeAwayContext()
        //    {
        //        diary_fake = new Diary();
        //    }

        //    public IDbSet<Diary> Diary_Fake { get; private set; }

        //    public IDbSet<Profit> Profits_Fake { get; private set; }

        //    public IDbSet<Expence> Expenses_Fake { get; private set; }

        //    public IDbSet<Plan> Plans_Fake { get; private set; }

        //    public IDbSet<Wish> Wishes_Fake { get; private set; }

        //    public int SaveChanges()
        //    {
        //        return 0;
        //    }
        //}
        [TestMethod]
        public void Test_Add_Note()
        {
           
            //var set = new CustomDbSet<Diary>
            //{
            //    new Diary { Id = -1 }
            //};

            //var moqGenerator = new Mock<DbContext>();



            //moqGenerator
            //    .Setup(m => m.Set<Diary>())
            //    .Returns(new DbSet<FakeDbSet<Diary>>(){);
            //_dal = new DataDAL(moqGenerator.Object);
            //var all_notes = _dal.Get_All_Notes("1").Count;
            // _dal.Add_Note(_dal.Get_All_Notes("1")[0].Text,
            //    _dal.Get_All_Notes("1")[0].User.Login);
            //var all_notes_added = _dal.Get_All_Notes("1").Count;
            //Assert.AreEqual(1, all_notes_added - all_notes);                             
        }
    }
}
