using OnlineExamPrep.Service.Common;

namespace OnlineExamPrep.Service.DependencyInjection
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ITestingAreaService>().To<TestingAreaService>();
        }
    }
}
