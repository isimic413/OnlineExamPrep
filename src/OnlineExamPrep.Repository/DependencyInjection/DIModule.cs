﻿using Ninject.Extensions.Factory;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Repository.Common;

namespace OnlineExamPrep.Repository.DependencyInjection
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IOnlineExamContext>().To<OnlineExamContext>();
            Bind<IUnitOfWorkFactory>().ToFactory();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRepository>().To<Repository>();

            Bind<ITestingAreaRepository>().To<TestingAreaRepository>();
        }
    }
}
