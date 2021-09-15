using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class GotchaContext :DbContext
    {
        public GotchaContext() : base("GotchaContext")
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleSet> RuleSets { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordSet> WordSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasOptional(s => s.Account)
                .WithRequired(ad => ad.User);
        }
    }
}