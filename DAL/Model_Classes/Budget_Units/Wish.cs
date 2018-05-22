using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    //for dreams, goals, wishes of all family members
    public class Wish : Budjet_Unit
    {      
        //harmonization childes wishes with parents possibility and adding to Budjet_plan
        public bool Agreement { get; set; } 

        //EF navigaion properties
        public virtual Event_Type Event { get; set; }
    }
}
