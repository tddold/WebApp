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
                    Title = "������ ���������?",
                    Context = @"�������� �� ��������� �������, Lorem Ipsum �� � ������ ������� �����. �������� ������ �� � ������������ �������� ���������� �� 45�.��.��., ����� ����� ����� ������ �� 2000 ������. Richard McClintock, �������� �� �������� �� ������ Hampden-Sydney College ��� ���������, ���������� ���� �� ���-�������� �������� ���� ""consectetur"" � ���� �� �������� �� Lorem Ipsum, � �������� ������ �� ������ � ������������ ����������, ������� ������ ��������. Lorem Ipsum � ������� � ������ 1.10.32 � 1.10.33 �� ""de Finibus Bonorum et Malorum""(����������� �� ������� � �����) �� �������, ������� ���� 45�.��.��. ���� ����� � ������� �� ������ �� �������, ����� ��������� ���� ���������. ������� ��� �� Lorem Ipsum ���� �� ���, ������� � ������ 1.10.32."
                });

                context.Articles.Add(new Article
                {
                    Title = "������ ���� �� �� �����?",
                    Context = @"����������� ����� �������� �� ������ Lorem Ipsum, �� �������� �� ��� �� ��������� �� ���� ��� ���� ����� ���� �������� �� ������ ���� ��� ����������� �� ������, ����� �� �������� ����� ����������. ��� ������ �� ���������� ����� �� Lorem Ipsum, ������ �� ��� �������, �� � ���� ���� ��������� ��� ���������� ����. ������ Lorem Ipsum ���������� � �������� ��������� ������������� ������, ����� �� ��������, ����� ����� ���� ���� ��������� ������ �������� �����. ��� �������� ������ �� ��� 200 �������� ����, ����������� �� �������� ����� ���� ���������, �� �� ��������� �������� Lorem Ipsum ������. ����� ������, �� ������������ Lorem Ipsum ����� �� ������� ����������, ���������, ���������� � �������� ����������� ����. "
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
