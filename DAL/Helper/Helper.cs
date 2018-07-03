using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class Helper
    {
        public static T Single<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, T value)
        {
            return source.Single(item => comparer.Equals(item, value));
        }

        public class ProfitComparator: IEqualityComparer<Profit>
        {

            public bool Equals(Profit x, Profit y)
            {
                bool result = false;

                //Date_ = profit_ExpenceBLL.Date_,
                //Sum = profit_ExpenceBLL.Sum,
                //Description = profit_ExpenceBLL.Description,
                //Profit_Type = new Profit_Type() { Name = profit_ExpenceBLL.Profit_Expance_Type },
                //User = new User() { Login = login }

                bool date = x.Date_ == y.Date_;
                bool sum = x.Sum == y.Sum;
                bool desc = x.Description == y.Description;
                bool profit_type = x.Profit_Type == y.Profit_Type;
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


    }
}
