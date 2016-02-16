using AutoMapper;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using OnlineExamPrep.Models.ParamsModel;

namespace OnlineExamPrep.Models.Mapping
{
    public static class AutoMapperMaps
    {
        public static void Initialize()
        {
            Mapper.CreateMap<AnswerChoice, AnswerChoiceEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerChoice, AnswerChoiceEntity>().ReverseMap();
            Mapper.CreateMap<AnswerChoiceParams, AnswerChoiceEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerChoiceParams, AnswerChoiceEntity>().ReverseMap();

            Mapper.CreateMap<AnswerChoicePicture, AnswerChoicePictureEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerChoicePicture, AnswerChoicePictureEntity>().ReverseMap();
            Mapper.CreateMap<AnswerChoicePicture, AnswerChoicePictureEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerChoicePicture, AnswerChoicePictureEntity>().ReverseMap();

            Mapper.CreateMap<AnswerStep, AnswerStepEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerStep, AnswerStepEntity>().ReverseMap();
            Mapper.CreateMap<AnswerStepParams, AnswerStepEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerStepParams, AnswerStepEntity>().ReverseMap();

            Mapper.CreateMap<AnswerStepPicture, AnswerStepPictureEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerStepPicture, AnswerStepPictureEntity>().ReverseMap();
            Mapper.CreateMap<AnswerStepPictureParams, AnswerStepPictureEntity>().ReverseMap();
            Mapper.CreateMap<IAnswerStepPictureParams, AnswerStepPictureEntity>().ReverseMap();

            Mapper.CreateMap<Exam, ExamEntity>().ReverseMap();
            Mapper.CreateMap<IExam, ExamEntity>().ReverseMap();
            Mapper.CreateMap<ExamParams, ExamEntity>().ReverseMap();
            Mapper.CreateMap<IExamParams, ExamEntity>().ReverseMap();

            Mapper.CreateMap<ExamQuestion, ExamQuestionEntity>().ReverseMap();
            Mapper.CreateMap<IExamQuestion, ExamQuestionEntity>().ReverseMap();
            Mapper.CreateMap<ExamQuestionParams, ExamQuestionEntity>().ReverseMap();
            Mapper.CreateMap<IExamQuestionParams, ExamQuestionEntity>().ReverseMap();
            Mapper.CreateMap<IExamQuestionParams, ExamQuestion>().ReverseMap();
            Mapper.CreateMap<ExamQuestionParams, ExamQuestion>().ReverseMap();
            Mapper.CreateMap<IExamQuestionParams, IExamQuestion>().ReverseMap();
            Mapper.CreateMap<ExamQuestionEntity, ExamQuestionParams>()
                .ForMember(dest => dest.TestingArea, opts => opts.MapFrom(src => src.Exam.TestingArea));
            Mapper.CreateMap<ExamQuestionEntity, IExamQuestionParams>()
                .ForMember(dest => dest.TestingArea, opts => opts.MapFrom(src => src.Exam.TestingArea));

            Mapper.CreateMap<Question, QuestionEntity>().ReverseMap();
            Mapper.CreateMap<IQuestion, QuestionEntity>().ReverseMap();
            Mapper.CreateMap<QuestionParams, QuestionEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionParams, QuestionEntity>().ReverseMap();

            Mapper.CreateMap<QuestionPicture, QuestionPictureEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionPicture, QuestionPictureEntity>().ReverseMap();
            Mapper.CreateMap<QuestionPictureParams, QuestionPictureEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionPictureParams, QuestionPictureEntity>().ReverseMap();

            Mapper.CreateMap<QuestionType, QuestionTypeEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionType, QuestionTypeEntity>().ReverseMap();
            Mapper.CreateMap<QuestionTypeParams, QuestionTypeEntity>().ReverseMap();
            Mapper.CreateMap<IQuestionTypeParams, QuestionTypeEntity>().ReverseMap();

            Mapper.CreateMap<Role, RoleEntity>().ReverseMap();
            Mapper.CreateMap<IRole, RoleEntity>().ReverseMap();
            Mapper.CreateMap<RoleParams, RoleEntity>().ReverseMap();
            Mapper.CreateMap<IRoleParams, RoleEntity>().ReverseMap();

            Mapper.CreateMap<TestingArea, TestingAreaEntity>().ReverseMap();
            Mapper.CreateMap<ITestingArea, TestingAreaEntity>().ReverseMap();
            Mapper.CreateMap<TestingAreaParams, TestingAreaEntity>().ReverseMap();
            Mapper.CreateMap<ITestingAreaParams, TestingAreaEntity>().ReverseMap();

            Mapper.CreateMap<User, UserEntity>().ReverseMap();
            Mapper.CreateMap<IUser, UserEntity>().ReverseMap();
            Mapper.CreateMap<UserParams, UserEntity>().ReverseMap();
            Mapper.CreateMap<IUserParams, UserEntity>().ReverseMap();

            Mapper.CreateMap<UserClaim, UserClaimEntity>().ReverseMap();
            Mapper.CreateMap<IUserClaim, UserClaimEntity>().ReverseMap();
            Mapper.CreateMap<UserClaimParams, UserClaimEntity>().ReverseMap();
            Mapper.CreateMap<IUserClaimParams, UserClaimEntity>().ReverseMap();

            Mapper.CreateMap<UserExamResult, UserExamResultEntity>().ReverseMap();
            Mapper.CreateMap<IUserExamResult, UserExamResultEntity>().ReverseMap();
            Mapper.CreateMap<UserExamResultParams, UserExamResultEntity>().ReverseMap();
            Mapper.CreateMap<IUserExamResultParams, UserExamResultEntity>().ReverseMap();

            Mapper.CreateMap<UserLogin, UserLoginEntity>().ReverseMap();
            Mapper.CreateMap<IUserLogin, UserLoginEntity>().ReverseMap();
            Mapper.CreateMap<UserLoginParams, UserLoginEntity>().ReverseMap();
            Mapper.CreateMap<IUserLoginParams, UserLoginEntity>().ReverseMap();
        }
    }
}
