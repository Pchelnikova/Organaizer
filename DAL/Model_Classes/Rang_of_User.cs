using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model_Classes
{
   public  class Rang_of_User
    {
        public int Id { get; set; }
        public string Rang { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
