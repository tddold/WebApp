﻿using App.Data;
using App.Data.Common;
using App.Data.Common.Contracts;
using App.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Modules;
using System;
using System.Data.Entity;

namespace App.ConsoleClient
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IdentityDbContext<User>>().To<AppDbContext>().InSingletonScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}
