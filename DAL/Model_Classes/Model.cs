using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace DAL
{
    using DAL.Model_Classes;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WindowsFormsApp3.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public Model()
            : base("name=Model")
        {
            Database.SetInitializer<Model>(new MyInitializer<Model>());
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Diary> Diaries { get; set; }
        public virtual DbSet<Wish> Wish_Lists { get; set; }
        public virtual DbSet<Profit> Profits { get; set; }
        public virtual DbSet<Expence> Expences { get; set; }
        public virtual DbSet<Plan> Budjet_plans { get; set; }
        public virtual DbSet<Profit_Type> Profit_Types { get; set; }
        public virtual DbSet<Expence_Type> Expances_Types { get; set; }
        public virtual DbSet<Event_Type> Event_Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rang_of_User> Rangs_of_User { get; set; }

    }
}