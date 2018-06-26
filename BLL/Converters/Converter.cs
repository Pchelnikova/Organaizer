using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ConverterBLL
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
            foreach (Profit item in profits)
                profitsBLL.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description, Profit_Expance_Type = item.Profit_Type.Name });
            return profitsBLL;

        }
        public static List<Profit_ExpanceBLL> Expence_to_BLL_List(List<Expence> expence)
        {
            List<Profit_ExpanceBLL> expenceBLL = new List<Profit_ExpanceBLL>();
            foreach (Expence item in expence)
                expenceBLL.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description, Profit_Expance_Type = item.Expence_Type.Name });
            return expenceBLL;
        }
        public static List<Profit_ExpanceBLL>Plans_to_BLL_List(List<Plan> plan)
        {
            List<Profit_ExpanceBLL> planBLL = new List<Profit_ExpanceBLL>();
            foreach (Plan item in plan)
                planBLL.Add(new Profit_ExpanceBLL() { Date_ = item.Date_, Sum = item.Sum, Description = item.Description, Profit_Expance_Type = item.Expance_Type.Name });
            return planBLL;
        }
        public static Plan BLL_to_Plan(Profit_ExpanceBLL profit_ExpenceBLL)
        {
            Plan plan = new Plan
            {
                Date_ = profit_ExpenceBLL.Date_,
                Sum = profit_ExpenceBLL.Sum,
                Description = profit_ExpenceBLL.Description,
                User = new User(),
                Expance_Type = new Expence_Type() { Name = profit_ExpenceBLL.Profit_Expance_Type }
            };
            return plan;
        }
    }
}
