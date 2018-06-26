using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Expence : Budjet_Unit
    {
        //EF navigation property
        public virtual Expence_Type Expence_Type { get; set; } 
    }
}
