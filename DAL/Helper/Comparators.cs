using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class Comparators
    {
        public static T Single<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, T value)
        {
            return source.Single(item => comparer.Equals(item, value));
        }

        public class ProfitComparator : IEqualityComparer<Profit>
        {

            public bool Equals(Profit x, Profit y)
            {
                bool result = false;

                bool date = x.Date_ == y.Date_;
                bool sum = x.Sum == y.Sum;
                bool desc = x.Description == y.Description;
                bool profit_type = x.Profit_Type.Name == y.Profit_Type.Name;
                bool user = x.User.Login == y.User.Login;

                if (date && sum && desc && profit_type && user)
                {
                    result = true;
                }
                return result;
            }
            public int GetHashCode(Profit obj)
            {
                return obj.GetHashCode();
            }
        }
        public class ExpenseComparator : IEqualityComparer<Expense>
        {
            public bool Equals(Expense x, Expense y)
            {
                bool result = false;

                bool date = x.Date_ == y.Date_;
                bool sum = x.Sum == y.Sum;
                bool desc = x.Description == y.Description;
                bool expense_type = x.Expence_Type.Name == y.Expence_Type.Name;
                bool user = x.User.Login == y.User.Login;

                if (date && sum && desc && expense_type && user)
                {
                    result = true;
                }
                return result;
            }
            public int GetHashCode(Expense obj)
            {
                return obj.GetHashCode();
            }
        }

        public class PlanComparator : IEqualityComparer<Plan>
        {
            public bool Equals(Plan x, Plan y)
            {
                bool result = false;

                bool date = x.Date_ == y.Date_;
                bool sum = x.Sum == y.Sum;
                bool desc = x.Description == y.Description;
                bool expense_type = x.Expense_Type.Name == y.Expense_Type.Name;
                bool user = x.User.Login == y.User.Login;

                if (date && sum && desc && expense_type && user)
                {
                    result = true;
                }
                return result;
            }

            public int GetHashCode(Plan obj)
            {
                return obj.GetHashCode();
            }
        }


    }
}
