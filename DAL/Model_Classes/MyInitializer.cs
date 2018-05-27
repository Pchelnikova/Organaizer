
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Model_Classes
{
    internal class MyInitializer<T> :DropCreateDatabaseIfModelChanges<Model>
    {
        protected override void Seed(Model context)
        {
            #region
            Event_Type Event_Task = new Event_Type()
            {
                Name = "TASK",
                Description = "What are you planing to do?"
            };
            Event_Type Event_Dream = new Event_Type()
            {
                Name = "DREAM",
                Description = "What about are you dreaming, honey?",

            };
            context.Event_Types.AddRange(new List<Event_Type> { Event_Dream, Event_Task });
            context.SaveChanges();
            Profit_Type Salary = new Profit_Type()
            {
                Name = "SALARY",
                Description = "CASH"
            };
            Profit_Type Dividents = new Profit_Type()
            {
                Name = "DIVIDENTS",
                Description = "Bank and other"
            };
            Profit_Type Present = new Profit_Type()
            {
                Name = "PRESENT",
                Description = "All presents"
            };
            context.Profit_Types.AddRange(new List<Profit_Type> { Salary, Dividents, Present });
            context.SaveChanges();
            Expence_Type None = new Expence_Type()
            {
                Name = "NONE!",
                Description = "Need for EDIT!"
            };
            Expence_Type Food = new Expence_Type()
            {
                Name = "FOOD",
                Description = "Products, drinks"
            };
            Expence_Type Shopping = new Expence_Type()
            {
                Name = "SHOPPING",
                Description = "Clothes, shoes, accessories"
            };
            Expence_Type Household = new Expence_Type()
            {
                Name = "HOUSEHOLD",
                Description = "Everyday expances for house: washing powder, dishers itc"
            };
            Expence_Type Apartment = new Expence_Type()
            {
                Name = "APARTMENT",
                Description = "Rest, communal payment"
            };
            Expence_Type Transport = new Expence_Type()
            {
                Name = "TRANSPORT",
                Description = "Petrol, fuel, repair of car"
            };
            Expence_Type Holiday = new Expence_Type()
            {
                Name = "HOLIDAY",
                Description = "Presents, cinema, HoReCa, vacation"
            };
            Expence_Type Connection = new Expence_Type()
            {
                Name = "CONNECTION",
                Description = "Telephone, internet, post"
            };
            context.Expances_Types.AddRange(new List<Expence_Type> { Food, Shopping, Household, Apartment, Transport, Connection });
            context.SaveChanges();
            Rang_of_User Senior = new Rang_of_User()
            {
                Rang = "Senior"
            };
          
            Rang_of_User Junior = new Rang_of_User()
            {
                Rang = "Junior"
            };
            context.Rangs_of_User.Add(Junior);
            context.Rangs_of_User.Add(Senior);
            context.SaveChanges();
            User First = new User()
            {
                Login = "1",// "Senior",
                Password_ = "1",
                Rang_of_User = Senior
            };
            User Second = new User()
            {
                Login = "2",
                Password_ = "2",
                Rang_of_User = Junior
            };
      
            context.Users.Add(First);
            context.Users.Add(Second);
            context.SaveChanges();

            Plan Budjet = new Plan()
            {
                Date_ = new System.DateTime(2018, 03, 14),
                Expance_Type = Holiday,
                Sum = 30000,
                Description = "Summer vacation!",
                User = First
            };
            context.Plans.Add(Budjet);
            context.SaveChanges();
            Wish Vacation = new Wish
            {
                Date_ = new System.DateTime(2019, 7, 1),
                Description = "Trip to the seaside",
                Sum = 50000,
                Agreement = false,
                Event = Event_Dream,
                User = First
            };
            context.Wish_Lists.Add(Vacation);
            context.SaveChanges();            
            #endregion

            context.Profits.AddRange(new List<Profit>
                                   { new Profit { Date_ = new System.DateTime(2018, 1, 1), Sum = 50000, Description = "January", Profit_Type = Salary, User = First  },
                                     new Profit { Date_ = new System.DateTime(2018, 2, 1), Sum = 50000, Description = "February", Profit_Type = Salary, User = First },
                                     new Profit { Date_ = new System.DateTime(2018, 1, 19), Sum = 2000, Description = "HappyBirthday!!!", Profit_Type = Present, User = First },
                                     new Profit { Date_ = new System.DateTime(2018, 2, 15), Sum = 5000, Description = "Insurance, PRIVATBANK", Profit_Type = Dividents, User = First} });
            context.SaveChanges();
            context.Expences.AddRange(new List<Expence>
                                   { new Expence {Date_ = new System.DateTime(2018, 1, 2),  Sum = 500, Description = "Supermarket", Expence_Type = Food, User = First },
                                     new Expence {Date_ = new System.DateTime(2018, 1, 5),  Sum = 980, Description = "Petrol", Expence_Type = Transport, User = First },
                                     new Expence {Date_ = new System.DateTime(2018, 1, 15),  Sum = 400, Description = "Market", Expence_Type = Food, User = First },
                                     new Expence {Date_ = new System.DateTime(2018, 1, 20), Sum = 500, Description = "Bedlinen", Expence_Type = Household, User = First },
                                     new Expence {Date_ = new System.DateTime(2018, 1, 22), Sum = 1500, Description = "Jeans and top", Expence_Type = Shopping, User = First },
                                     new Expence {Date_ = new System.DateTime(2018, 2, 2),  Sum = 5000, Description = "Pay the bills", Expence_Type = Apartment, User = First } });
            context.SaveChanges();
           
             
            
            
        }
    }

}