using App.Data.Models;
using Ninject;
using System.Reflection;

namespace App.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            var ctx = kernel.Get<MyDataProvider>();

            //using ( var unitOfWork = ctx.UnitOfWork())
            //{
            //    ctx.Articles.Add(new Article
            //    {
            //        Title = "Какво е Lorem Ipsum?",
            //        Context = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове."
            //    });

            //    ctx.Articles.Add(new Article               
            //   {
            //       Title = "Защо го използваме?",
            //       Context = @"Известен факт е, че читателя обръща внимание на съдържанието, което чете, а не на оформлението му. Свойството на Lorem Ipsum е, че до голяма степен има нормално разпределение на буквите и се чете по-лесно, за разлика от нормален текст на английски език като ""Това е съдържание,
            //        това е съдържание"". "
            //   });

            //    unitOfWork.Commit();
            //}
        }
    }
}
