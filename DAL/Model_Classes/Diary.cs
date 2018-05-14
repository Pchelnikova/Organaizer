using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
    //for simply notes
    public class Diary 
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public string Text { get; set; }
        //EF navigation property
        public virtual User User { get; set; } 
    }
}
