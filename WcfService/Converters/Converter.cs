using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.DataContracts;

namespace WcfService.Converters
{
    public static class Converter
    {
        public static Profit_ExpanceBLL WCF_to_BLL(Profit_ExpanceWCF profit_ExpenceWCF)
        {
            Profit_ExpanceBLL profit_ExpenceBLL = new Profit_ExpanceBLL()
            {
                Date_ = profit_ExpenceWCF.Date_,
                Sum = profit_ExpenceWCF.Sum,
                Description = profit_ExpenceWCF.Description,
                Profit_Expance_Type = profit_ExpenceWCF.Profit_Expance_Type
            };
            return profit_ExpenceBLL;
        }

        public static List<Profit_ExpanceBLL> WCF_to_BLL_List(Profit_ExpanceWCF[] profit_ExpenceWCF)
        {
            List<Profit_ExpanceBLL> profit_expance = new List<Profit_ExpanceBLL>();
            foreach (Profit_ExpanceWCF item in profit_ExpenceWCF)
            {
                profit_expance.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description, Profit_Expance_Type = item.Profit_Expance_Type });
            }
            return profit_expance;
        }
        public static List<Profit_ExpanceWCF> BLL_to_WCF_List(List<Profit_ExpanceBLL> profit_ExpenceBLL)
        {
            List<Profit_ExpanceWCF> profit_expance = new List<Profit_ExpanceWCF>();
            foreach (Profit_ExpanceBLL item in profit_ExpenceBLL)
            {
                profit_expance.Add(new Profit_ExpanceWCF() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description,Profit_Expance_Type = item.Profit_Expance_Type });
            }
            return profit_expance;
        }

    }
}