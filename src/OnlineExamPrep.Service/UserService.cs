using OnlineExamPrep.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class UserService : IUserService
    {
        protected IRoleRepository roleRepository { get; private set; }
        protected IQuestionTypeRepository questionTypeRepository { get; private set; }
        protected ITestingAreaRepository testingAreaRepository { get; private set; }

        public UserService(
            IRoleRepository roleRepository,
            IQuestionTypeRepository questionTypeRepository,
            ITestingAreaRepository testingAreaRepository
            )
        {
            this.roleRepository = roleRepository;
            this.questionTypeRepository = questionTypeRepository;
            this.testingAreaRepository = testingAreaRepository;
        }


        public async Task<dynamic> GetApplicationData(string userId)
        {
            var pagingParams = new PagingParams();
            var role = await roleRepository.GetByUserId(userId);
            var testingAreas = await testingAreaRepository.GetCollectionAsync(pagingParams);
            var questionTypes = await questionTypeRepository.GetCollectionAsync(pagingParams);

            return (dynamic)new
            {
                Role = role.Name,
                TestingAreas = testingAreas,
                QuestionTypes = questionTypes
            };
        }
    }
}
