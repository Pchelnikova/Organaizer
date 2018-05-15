using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using WcfService.DataContracts;

namespace WcfOrganizer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly DataBLL _bll = new DataBLL();

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public List<Diary_WCF> Show_All_Notes(string login)
        {
            var diary_list = _bll.Show_All_Notes(login);
            List<Diary_WCF> diaries = new List<Diary_WCF>();
            foreach (BLL.Diary_BLL item in diary_list)
                diaries.Add(new Diary_WCF() { Date_ = item.Date_, Text = item.Text });
            return diaries;
        }

        public void Add_Note(string note, string login)
        {
            _bll.Add_Note(note, login);
        }

        public void Delete_Note (string note)
        {
            if (note!=null)
            _bll.Delete_Note(note);
        }
         //Budget CRUD
         public List<Profit_WCF> Show_All_Profits (string login)
        {
            var profit_list = _bll.Show_All_Profits(login);
            List<Profit_WCF> profits = new List<Profit_WCF>();
            foreach (BLL.Profit_BLL item in profit_list)
                profits.Add(new Profit_WCF() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description  });
            return profits;           
        }

        public List<string> GetProfitsTypes()
        {
          return   _bll.GetProfitsTypes();
        }




        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
