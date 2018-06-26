using System.Collections.Generic;

namespace DAL
{
    public  class Rang_of_User
    {
        public int Id { get; set; }
        public string Rang { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
