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
        public static Profit BLL_to_Profit(Profit_ExpanceBLL profit_ExpenceBLL)
        {
            Profit profit = new Profit
            {
                Date_ = profit_ExpenceBLL.Date_,
                Sum = profit_ExpenceBLL.Sum,
                Description = profit_ExpenceBLL.Description,
                Profit_Type = new Profit_Type()
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
                Expence_Type = new Expence_Type()
            };
            return expence;
        }
    }
}
