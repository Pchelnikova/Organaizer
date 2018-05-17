using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using WcfService.DataContracts;
using WcfService.Converters;

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

        public List<Diary_WCF> Get_All_Notes(string login)
        {
            var diary_list = _bll.Show_All_Notes(login);
            var diaries = new List<Diary_WCF>();
            foreach (BLL.Diary_BLL item in diary_list)
            {
                diaries.Add(new Diary_WCF() { Date_ = item.Date_, Text = item.Text });
            }
            return diaries;
        }

        public void Add_Note(string note, string login)
        {
            _bll.Add_Note(note, login);
        }
        public void Delete_Note(string note)
        {
            if (note != null)
                _bll.Delete_Note(note);
        }
        public List<Profit_ExpanceWCF> Get_All_Profits(string login)
        {
            return Converter.BLL_to_WCF_List(_bll.Get_All_Profits(login));
        }
        public void Save_New_Profit(Profit_ExpanceWCF new_profit, string Type, string login)
        {
            _bll.Save_New_Profit(Converter.WCF_to_BLL(new_profit), Type, login);
        }
        public void Delete_Profit(Profit_ExpanceWCF profit_ExpanceWCF, string login)
        {
            _bll.Delete_Profit(Converter.WCF_to_BLL(profit_ExpanceWCF), login);
        }
        public void Save_New_Expance(Profit_ExpanceWCF new_expance, string Type, string login)
        {            
            _bll.Save_New_Expence(Converter.WCF_to_BLL(new_expance), Type, login);
        }
        public List<Profit_ExpanceWCF> Get_All_Expance(string login)
        {          
           return Converter.BLL_to_WCF_List(_bll.Get_All_Expance(login));                       
        }
        public void Delete_Expence(Profit_ExpanceWCF profit_ExpanceWCF, string login)
        {
            _bll.Delete_Expence(Converter.WCF_to_BLL(profit_ExpanceWCF), login);
        }
        



        public List<string> GetProfitsTypes()
        {
            return _bll.GetProfitsTypes();
        }
        public List<string> GetExpanceTypes()
        {
            return _bll.GetExpanceTypes();
        }        
    }
}
