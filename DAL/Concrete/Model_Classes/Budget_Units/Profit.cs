using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Profit : Budjet_Unit
    {
        //EF navigation properties
        public virtual Profit_Type Profit_Type { get; set; } 
    }
}
