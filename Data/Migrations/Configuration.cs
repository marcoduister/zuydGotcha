namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.GotchaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.GotchaContext context)
        {
            var User = new List<User>
            {
            new User{Email="Marcoduister@hotmail.com", Password="Qwerty", User_Rol= Enums.Rolen.Admin, UserActive =true},
            new User{Email="Eva@hotmail.com", Password="Qwerty",User_Rol= Enums.Rolen.Gamemaster, UserActive =true},
            new User{Email="Julean@hotmail.com", Password="Qwerty",User_Rol= Enums.Rolen.Gamemaster, UserActive =true},
            new User{Email="Rick@hotmail.com", Password="Qwerty",User_Rol= Enums.Rolen.Player, UserActive =true},
            new User{Email="Broertje@hotmail.com",Password="Qwerty",User_Rol= Enums.Rolen.Player, UserActive =true},
            };
            var account = new List<Account>
            {
                new Account{ User_Id =1, FirstName="marco",LastName="duister", Alias="mark", Group="A1B1", Residence="kerkrade", Birthdate=DateTime.Parse("1996-05-25") },
                new Account{ User_Id =2, FirstName="eva",LastName="wittekatis", Alias="tiktok", Group="A1B1", Residence="kerkrade", Birthdate=DateTime.Parse("1994-08-15") },
                new Account{ User_Id =3, FirstName="julean",LastName="hommel", Alias="julan", Group="A1B1", Residence="maastricht", Birthdate=DateTime.Parse("1999-02-12") },
                new Account{ User_Id =4, FirstName="Rick",LastName="hooi", Alias="Rickert", Group="A1B1", Residence="simpeveld", Birthdate=DateTime.Parse("1999-05-25") },
                new Account{ User_Id =5, FirstName="broertje",LastName="hooi", Alias="liveanjiolo", Group="A1B1", Residence="heerlen", Birthdate=DateTime.Parse("1990-05-25") },
            };
            var worden = new List<Word>
            {
                new Word{ Word_Name="code",Word_public=false, Maker_Id=1 },
                new Word{ Word_Name="sharp",Word_public=false, Maker_Id=1 },
                new Word{ Word_Name="computer",Word_public=false, Maker_Id=1 },
                new Word{ Word_Name="website",Word_public=false, Maker_Id=1 }
            };
            var Wordenset = new List<WordSet>
            {
                 new WordSet{ Maker_Id =1, WordSet_Name="ICT worden",WordSet_public= false, Word= worden }
            };
            var Rules = new List<Rule>
            {
                new Rule{ Rule_Name="Rule1",Rule_public=false, Maker_Id=1 },
                new Rule{ Rule_Name="Rule2",Rule_public=false, Maker_Id=1 },
                new Rule{ Rule_Name="Rule3",Rule_public=false, Maker_Id=1 },
                new Rule{ Rule_Name="Rule4",Rule_public=false, Maker_Id=1 }
            };
            var RuleSets = new List<RuleSet>
            {
                 new RuleSet{ Maker_Id =1, RuleSet_Name="ICT worden",RuleSet_public= false, Rule= Rules }
            };
            var Gametype = new List<GameType>
            {
                new GameType{ GameType_Name="GameType1", GameType_Description="dit is een beschijving van gameType 1" , Maker_Id=1 },
                new GameType{ GameType_Name="GameType2",GameType_Description="dit is een beschijving van gameType 2" , Maker_Id=1 },
                new GameType{ GameType_Name="GameType3",GameType_Description="dit is een beschijving van gameType 3" , Maker_Id=1 },
                new GameType{ GameType_Name="GameType4",GameType_Description="dit is een beschijving van gameType 4" , Maker_Id=1 }
            };
            var Game = new List<Game>
            {
                new Game{  Game_Name="Game1",  Game_Start=DateTime.Parse("2021-09-20"),Game_Eind=DateTime.Parse("2021-09-30") , GameType_Id=1, Location="kerkrade", RuleSet_Id=1, WordSet_Id=1, Archived=false, Maker_Id=1 },
            };
            var gameplayers = new List<GamePlayer>
            {
                new GamePlayer{ User_Id =1, Active= false, Game_Id=1 },
                new GamePlayer{ User_Id =2, Active= false, Game_Id=1 },
                new GamePlayer{ User_Id =3, Active= false, Game_Id=1 },
                new GamePlayer{ User_Id =4, Active= false, Game_Id=1 }
            };


            User.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            account.ForEach(s => context.Account.Add(s));
            context.SaveChanges();
            worden.ForEach(s => context.Words.Add(s));
            context.SaveChanges();
            Wordenset.ForEach(s => context.WordSets.Add(s));
            context.SaveChanges();
            Rules.ForEach(s => context.Rules.Add(s));
            context.SaveChanges();
            RuleSets.ForEach(s => context.RuleSets.Add(s));
            context.SaveChanges();
            Gametype.ForEach(s => context.GameTypes.Add(s));
            context.SaveChanges();
            Game.ForEach(s => context.Games.Add(s));
            context.SaveChanges();
            gameplayers.ForEach(s => context.GamePlayers.Add(s));
            context.SaveChanges();
        }
    }
}
