using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    //for dreams, goals, wishes of all family members
    public class Wish_List 
    {
        public int Id { get; set; }

        public DateTime Date_ { get; set; }
        public string Text { get; set; }
        public decimal Sum_plan { get; set; }
        //harmonization childes wishes with parents and adding to Budjet_plan
        public bool Agreement { get; set; } 

        //EF navigaion properties
        public virtual Event_Type Event { get; set; }
        public virtual User User { get; set; } 

    }
}
