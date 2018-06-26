using System;

namespace DAL
{
    //for simply notes
    public class Diary 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        //EF navigation property
        public virtual User User { get; set; } 
    }
}
