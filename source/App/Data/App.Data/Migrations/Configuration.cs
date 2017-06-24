namespace App.Data.Migrations
{
    using App.Data.Models;
    using App.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System;
    using System.Data;

    public sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            const string AdministratorUserName = "admin@site.com";
            const string AdministratorPassword = AdministratorUserName;

            var users = new List<User>();

            if (!context.Roles.Any(r => r.Name == AdministratorUserName))
            {
                // Create administrator role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole
                {
                    Name = GlobalConstants.AdministratorRoleName
                };

                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == AdministratorUserName))
            {
                // Create administrator user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName
                };

                userManager.Create(user, AdministratorPassword);

                // Assign user to administrator role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            if (!context.Users.Any(u => u.UserName != AdministratorUserName))
            {
                // Create user role
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 4,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false
                };

                // Create users
                for (int i = 1; i <= 5; i++)
                {
                    string name = "user" + i;
                    var newUser = new User
                    {
                        UserName = name + "@site.com",
                        Email = name + "@site.com"
                    };

                    // Assign user to role
                    manager.Create(newUser, name);
                    users.Add(newUser);
                }
            }

            context.SaveChanges();

            if (!context.Articles.Any())
            {
                context.Articles.Add(new Article
                {
                    Title = "Откъде произлиза?",
                    Context = @"Противно на всеобщото вярване, Lorem Ipsum не е просто случаен текст. Неговите корени са в класическата Латинска литература от 45г.пр.Хр., което прави преди повече от 2000 години. Richard McClintock, професор по Латински от колежа Hampden-Sydney College във Вирджиния, изучавайки една от най-неясните латински думи ""consectetur"" в един от пасажите на Lorem Ipsum, и търсейки цитати на думата в класическата литература, открива точния източник. Lorem Ipsum е намерен в секции 1.10.32 и 1.10.33 от ""de Finibus Bonorum et Malorum""(Крайностите на Доброто и Злото) от Цицерон, написан през 45г.пр.Хр. Тази книга е трактат по теория на етиката, много популярна през Ренесанса. Първият ред на Lorem Ipsum идва от ред, намерен в секция 1.10.32."
                });

                context.Articles.Add(new Article
                {
                    Title = "Откъде мога да го взема?",
                    Context = @"Съществуват много вариации на пасажа Lorem Ipsum, но повечето от тях са променени по един или друг начин чрез добавяне на смешни думи или разбъркване на думите, което не изглежда много достоверно. Ако искате да използвате пасаж от Lorem Ipsum, трябва да сте сигурни, че в него няма смущаващи или нецензурни думи. Всички Lorem Ipsum генератори в Интернет използват предефинирани пасажи, който се повтарят, което прави този този генератор първия истински такъв. Той използва речник от над 200 латински думи, комбинирани по подходящ начин като изречения, за да генерират истински Lorem Ipsum пасажи. Оттук следва, че генерираният Lorem Ipsum пасаж не съдържа повторения, смущаващи, нецензурни и всякакви неподходящи думи. "
                });

                context.SaveChanges();
            }

            //if (!context.Categories.Any())
            //{
            //    context.Categories.Add(new Category
            //    {
            //        ArticleId = 1
            //    });

            //    context.HomeArticles.Add(new HomeArticle
            //    {
            //        ArticleId = 2
            //    });

            //    context.SaveChanges();
            //}
        }
    }
}
