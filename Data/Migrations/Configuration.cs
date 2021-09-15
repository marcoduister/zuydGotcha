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
            new User{Email="Marcoduister@hotmail.com", Password="Qwerty", Rol= Enums.Rolen.Admin, UserActive =true},
            new User{Email="Meredith@hotmail.com", Password="Qwerty",Rol= Enums.Rolen.Gamemaster, UserActive =true},
            new User{Email="Arturo@hotmail.com", Password="Qwerty",Rol= Enums.Rolen.Gamemaster, UserActive =true},
            new User{Email="Gytis@hotmail.com", Password="Qwerty",Rol= Enums.Rolen.Player, UserActive =true},
            new User{Email="Yan@hotmail.com",Password="Qwerty",Rol= Enums.Rolen.Player, UserActive =true},
            new User{Email="Peggy@hotmail.com",Password="Qwerty",Rol= Enums.Rolen.Player, UserActive =true},
            new User{Email="Laura@hotmail.com",Password="Qwerty",Rol= Enums.Rolen.Player, UserActive =true},
            new User{Email="Nino@hotmail.com",Password="Qwerty",Rol= Enums.Rolen.Player, UserActive =true }
            };

            User.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}
