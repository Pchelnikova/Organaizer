﻿
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Model_Classes
{
    internal class MyInitializer<T> :DropCreateDatabaseAlways<Model>
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
            Expance_Type Food = new Expance_Type()
            {
                Name = "FOOD",
                Description = "Products, drinks"
            };
            Expance_Type Shopping = new Expance_Type()
            {
                Name = "SHOPPING",
                Description = "Clothes, shoes, accessories"
            };
            Expance_Type Household = new Expance_Type()
            {
                Name = "HOUSEHOLD",
                Description = "Everyday expances for house: washing powder, dishers itc"
            };
            Expance_Type Apartment = new Expance_Type()
            {
                Name = "APARTMENT",
                Description = "Rest, communal payment"
            };
            Expance_Type Transport = new Expance_Type()
            {
                Name = "TRANSPORT",
                Description = "Petrol, fuel, repair of car"
            };
            Expance_Type Holiday = new Expance_Type()
            {
                Name = "HOLIDAY",
                Description = "Presents, cinema, HoReCa, vacation"
            };
            Expance_Type Connection = new Expance_Type()
            {
                Name = "CONNECTION",
                Description = "Telephone, internet, post"
            };
            context.Expances_Types.AddRange(new List<Expance_Type> { Food, Shopping, Household, Apartment, Transport, Connection });
            context.SaveChanges();
            Rang_of_User Senior = new Rang_of_User()
            {
                Rang = "Senior"
            };
            Rang_of_User Middle = new Rang_of_User()
            {
                Rang = "Middle"
            };
            Rang_of_User Junior = new Rang_of_User()
            {
                Rang = "Junior"
            };
            User First = new User()
            {
                Login = "1",// "Senior",
                Password_ = "1",
                Rang_of_User = Senior
            };
            User Second = new User()
            {
                Login = "1",
                Password_ = "1"
            };
      
            context.Users.Add(First);
            context.Users.Add(Second);
            context.SaveChanges();

            Budjet_plan Budjet = new Budjet_plan()
            {
                Date_ = new System.DateTime(2018, 03, 14),
                Expance_Type = Holiday,
                Sum = 1000,
                Description = "Masha's Birthday",
                User = First
            };
            context.Budjet_plans.Add(Budjet);
            context.SaveChanges();
            Wish_List Vacation = new Wish_List
            {
                Date_ = new System.DateTime(2018, 7, 1),
                Text = "Trip to the seaside",
                Sum_plan = 10000,
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
            context.Expences.AddRange(new List<Expance>
                                   { new Expance {Date_ = new System.DateTime(2018, 1, 2),  Sum = 500, Description = "Supermarket", Expance_Type = Food, User = First },
                                     new Expance {Date_ = new System.DateTime(2018, 1, 5),  Sum = 980, Description = "Petrol", Expance_Type = Transport, User = First },
                                     new Expance {Date_ = new System.DateTime(2018, 1, 15),  Sum = 400, Description = "Market", Expance_Type = Food, User = First },
                                     new Expance {Date_ = new System.DateTime(2018, 1, 20), Sum = 500, Description = "Bedlinen", Expance_Type = Household, User = First },
                                     new Expance {Date_ = new System.DateTime(2018, 1, 22), Sum = 1500, Description = "Jeans and top", Expance_Type = Shopping, User = First },
                                     new Expance {Date_ = new System.DateTime(2018, 2, 2),  Sum = 5000, Description = "Pay the bills", Expance_Type = Apartment, User = First } });
            context.SaveChanges();
           
             
            
            
        }
    }

}