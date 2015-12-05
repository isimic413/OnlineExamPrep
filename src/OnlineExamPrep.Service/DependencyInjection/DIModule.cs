using OnlineExamPrep.Service.Common;

namespace OnlineExamPrep.Service.DependencyInjection
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IAnswerChoiceService>().To<AnswerChoiceService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<IQuestionTypeService>().To<QuestionTypeService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<ITestingAreaService>().To<TestingAreaService>();
        }
    }
}
