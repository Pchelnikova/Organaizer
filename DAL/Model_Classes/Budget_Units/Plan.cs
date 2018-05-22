using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    //finance plan for future month
    public class Plan : Budjet_Unit
    {
        //EF navigation properties
        public virtual Expence_Type Expance_Type { get; set; } 
    }
}
