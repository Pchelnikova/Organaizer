using System.Collections.Generic;

namespace DAL
{
    public class User 
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password_ { get; set; }

        public virtual Rang_of_User Rang_of_User { get; set; }

        public virtual ICollection<Wish> Wish_List { get; set; } 
        public virtual ICollection<Diary> Dairy { get; set; }
        public virtual ICollection<Profit> Profit { get; set; }
        public virtual ICollection<Expense> Expance { get; set; }
        public virtual ICollection<Plan> Budjet_Plan { get; set; }
    }
}
