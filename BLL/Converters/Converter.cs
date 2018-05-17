using DAL.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public static class Converter
    {
        public static Profit BLL_to_Profit(Profit_ExpanceBLL profit_ExpenceBLL, string login)
        {
            Profit profit = new Profit
            {
                Date_ = profit_ExpenceBLL.Date_,
                Sum = profit_ExpenceBLL.Sum,
                Description = profit_ExpenceBLL.Description,
                Profit_Type = new Profit_Type() { Name = profit_ExpenceBLL.Profit_Expance_Type },
                User = new User() {Login = login }
            };
            return profit;
        }

        public static Expence BLL_to_Expence(Profit_ExpanceBLL profit_ExpenceBLL)
        {
            Expence expence = new Expence
            {
                Date_ = profit_ExpenceBLL.Date_,
                Sum = profit_ExpenceBLL.Sum,
                Description = profit_ExpenceBLL.Description,
                User = new User(),
                Expence_Type = new Expence_Type() { Name = profit_ExpenceBLL.Profit_Expance_Type}
            };
            return expence;
        }
        public static List <Profit_ExpanceBLL> Profit_to_BLL_List (List<Profit> profits)
        {
            List<Profit_ExpanceBLL> profitsBLL = new List<Profit_ExpanceBLL>();
            foreach (DAL.Model_Classes.Profit item in profits)
                profitsBLL.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description, Profit_Expance_Type = item.Profit_Type.Name });
            return profitsBLL;

        }
    }
}
