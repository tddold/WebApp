﻿using App.Data.Models;
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

            using (var unitOfWork = ctx.UnitOfWork())
            {
                ctx.Articles.Add(new Article
                {
                    Title = "Откъде произлиза?",
                    Context = @"Противно на всеобщото вярване, Lorem Ipsum не е просто случаен текст. Неговите корени са в класическата Латинска литература от 45г.пр.Хр., което прави преди повече от 2000 години. Richard McClintock, професор по Латински от колежа Hampden-Sydney College във Вирджиния, изучавайки една от най-неясните латински думи ""consectetur"" в един от пасажите на Lorem Ipsum, и търсейки цитати на думата в класическата литература, открива точния източник. Lorem Ipsum е намерен в секции 1.10.32 и 1.10.33 от ""de Finibus Bonorum et Malorum""(Крайностите на Доброто и Злото) от Цицерон, написан през 45г.пр.Хр. Тази книга е трактат по теория на етиката, много популярна през Ренесанса. Първият ред на Lorem Ipsum идва от ред, намерен в секция 1.10.32."
                });

                ctx.Articles.Add(new Article
                {
                    Title = "Откъде мога да го взема?",
                    Context = @"Съществуват много вариации на пасажа Lorem Ipsum, но повечето от тях са променени по един или друг начин чрез добавяне на смешни думи или разбъркване на думите, което не изглежда много достоверно. Ако искате да използвате пасаж от Lorem Ipsum, трябва да сте сигурни, че в него няма смущаващи или нецензурни думи. Всички Lorem Ipsum генератори в Интернет използват предефинирани пасажи, който се повтарят, което прави този този генератор първия истински такъв. Той използва речник от над 200 латински думи, комбинирани по подходящ начин като изречения, за да генерират истински Lorem Ipsum пасажи. Оттук следва, че генерираният Lorem Ipsum пасаж не съдържа повторения, смущаващи, нецензурни и всякакви неподходящи думи. "
                });

                unitOfWork.Commit();

            }
            using (var unitOfWork = ctx.UnitOfWork())
            {
                //ctx.HomeArticles.Add(new HomeArticle
                //{
                //    ArticleId = 1
                //});

                //ctx.HomeArticles.Add(new HomeArticle
                //{
                //    ArticleId = 2
                //});

                //ctx.ItemArticles.Add(new ItemArticle
                //{
                //    ArticleId = 3
                //});
                //
                //ctx.ItemArticles.Add(new ItemArticle
                //{
                //    ArticleId = 4
                //});

                unitOfWork.Commit();
            }
        }
    }
}
