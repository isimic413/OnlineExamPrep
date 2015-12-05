using AutoMapper;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models.Mapping
{
    public static class AutoMapperMaps
    {
        public static void Initialize()
        {
            Mapper.CreateMap<AnswerChoice, AnswerChoiceEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerChoice, AnswerChoiceEntity>().ReverseMap();

            Mapper.CreateMap<AnswerChoicePicture, AnswerChoicePictureEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerChoicePicture, AnswerChoicePictureEntity>().ReverseMap();

            Mapper.CreateMap<AnswerStep, AnswerStepEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerStep, AnswerStepEntity>().ReverseMap();

            Mapper.CreateMap<AnswerStepPicture, AnswerStepPictureEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerStepPicture, AnswerStepPictureEntity>().ReverseMap();

            Mapper.CreateMap<Question, QuestionEntity>().ReverseMap();
            Mapper.CreateMap<IQuestion, QuestionEntity>().ReverseMap();

            Mapper.CreateMap<QuestionPicture, QuestionPictureEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionPicture, QuestionPictureEntity>().ReverseMap();

            Mapper.CreateMap<QuestionType, QuestionTypeEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionType, QuestionTypeEntity>().ReverseMap();

            Mapper.CreateMap<Role, RoleEntity>().ReverseMap();
            Mapper.CreateMap<IRole, RoleEntity>().ReverseMap();

            Mapper.CreateMap<TestingArea, TestingAreaEntity>().ReverseMap();
            Mapper.CreateMap<ITestingArea, TestingAreaEntity>().ReverseMap();

            Mapper.CreateMap<User, UserEntity>().ReverseMap();
            Mapper.CreateMap<IUser, UserEntity>().ReverseMap();

            Mapper.CreateMap<UserClaim, UserClaimEntity>().ReverseMap();
            Mapper.CreateMap<IUserClaim, UserClaimEntity>().ReverseMap();

            Mapper.CreateMap<UserLogin, UserLoginEntity>().ReverseMap();
            Mapper.CreateMap<IUserLogin, UserLoginEntity>().ReverseMap();
        }
    }
}
