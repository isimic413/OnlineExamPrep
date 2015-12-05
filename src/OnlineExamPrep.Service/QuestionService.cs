using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class QuestionService : IQuestionService
    {
        protected IQuestionRepository questionRepository { get; private set; }
        protected IAnswerChoiceRepository answerChoiceRepository { get; private set; }

        public QuestionService(IQuestionRepository questionRepository, IAnswerChoiceRepository answerChoiceRepository)
        {
            this.questionRepository = questionRepository;
            this.answerChoiceRepository = answerChoiceRepository;
        }

        public Task<IQuestion> GetSingleAsync(string questionId)
        {
            return questionRepository.GetSingleAsync(questionId);
        }

        public Task<IQuestion> GetSingleWithPicturesAsync(string questionId)
        {
            return questionRepository.GetSingleWithPicturesAsync(questionId);
        }

        public Task<IQuestion> GetSingleWithAnswerChoicesAsync(string questionId)
        {
            return questionRepository.GetSingleWithAnswerChoicesAsync(questionId);
        }

        public Task<IQuestion> GetSingleWithStepsAsync(string questionId)
        {
            return questionRepository.GetSingleWithStepsAsync(questionId);
        }

        public Task<List<IQuestion>> GetCollectionAsync(PagingParams pagingParams)
        {
            return questionRepository.GetCollectionAsync(pagingParams);
        }

        public Task<List<IQuestion>> GetCollectionByTypeAsync(PagingParams pagingParams, string questionTypeId)
        {
            return questionRepository.GetCollectionByTypeAsync(pagingParams, questionTypeId);
        }

        public Task<List<IQuestion>> GetCollectionByTestingAreaAsync(PagingParams pagingParams, string testingAreaId)
        {
            return questionRepository.GetCollectionByTestingAreaAsync(pagingParams, testingAreaId);
        }

        public async Task<int> InsertAsync(IQuestion question, List<IAnswerChoice> answerChoiceList)
        {
            if (answerChoiceList == null || answerChoiceList.Count == 0)
            {
                throw new ArgumentException("Empty list of choices.");
            }
            bool containsCorrectAnswer = false;
            foreach(var choice in answerChoiceList)
            {
                if (choice.IsCorrectAnswer)
                {
                    containsCorrectAnswer = true;
                    break;
                }
            }
            if (!containsCorrectAnswer)
            {
                throw new ArgumentException("List must contain at least one correct answer.");
            }
            IUnitOfWork unitOfWork = questionRepository.CreateUnitOfWork();
            await questionRepository.AddToUowForInsertAsync(unitOfWork, question);
            foreach(var choice in answerChoiceList)
            {
                await answerChoiceRepository.AddToUowForInsertAsync(unitOfWork, choice);
            }
            return await unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateAsync(IQuestion question, List<IAnswerChoice> answerChoiceList)
        {
            var existingQuestion = await questionRepository.GetSingleWithAnswerChoicesAsync(question.Id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found.");
            }

            var choicesForUpdateIdList = answerChoiceList.Select(choice => choice.Id);
            var newChoiceList = answerChoiceList.Union(existingQuestion.AnswerChoices.Where(choice => !choicesForUpdateIdList.Contains(choice.Id)));
            var containsCorrectAnswer = false;
            foreach (var choice in newChoiceList)
            {
                if (choice.IsCorrectAnswer)
                {
                    containsCorrectAnswer = true;
                    break;
                }
            }
            if (!containsCorrectAnswer)
            {
                throw new ArgumentException("List must contain at least one correct answer.");
            }

            var unitOfWork = questionRepository.CreateUnitOfWork();

            foreach (var picture in existingQuestion.QuestionPictures)
            {
                await questionRepository.AddPictureToUowForDeleteAsync(unitOfWork, picture.Id);
            }
            foreach (var picture in question.QuestionPictures)
            {
                await questionRepository.AddPictureToUowForInsertAsync(unitOfWork, picture);
            }
            await questionRepository.AddToUowForUpdateAsync(unitOfWork, question);
            foreach (var choice in answerChoiceList)
            {
                var pictures = existingQuestion.AnswerChoices.Where(c => c.Id == choice.Id);
                foreach (var picture in pictures)
                {
                    await answerChoiceRepository.AddPictureToUowForDeleteAsync(unitOfWork, picture.Id);
                }
                foreach (var picture in choice.AnswerChoicePictures)
                {
                    await answerChoiceRepository.AddPictureToUowForInsertAsync(unitOfWork, picture);
                }
                await answerChoiceRepository.AddToUowForUpdateAsync(unitOfWork, choice);
            }

            return await unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateAsync(IQuestion question)
        {
            var existingQuestion = await questionRepository.GetSingleWithPicturesAsync(question.Id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found.");
            }
            var unitOfWork = questionRepository.CreateUnitOfWork();

            foreach (var picture in existingQuestion.QuestionPictures)
            {
                await questionRepository.AddPictureToUowForDeleteAsync(unitOfWork, picture.Id);
            }
            foreach (var picture in question.QuestionPictures)
            {
                await questionRepository.AddPictureToUowForInsertAsync(unitOfWork, picture);
            }
            await questionRepository.AddToUowForUpdateAsync(unitOfWork, question);

            return await unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(string questionId)
        {
            IUnitOfWork unitOfWork = questionRepository.CreateUnitOfWork();
            await questionRepository.AddToUowForDeleteAsync(unitOfWork, questionId);

            var choices = await answerChoiceRepository.GetChoicesByQuestionIdAsync(questionId);
            foreach (var choice in choices)
            {
                var choicePictures = choice.AnswerChoicePictures;
                foreach(var picture in choicePictures)
                {
                    await answerChoiceRepository.AddPictureToUowForDeleteAsync(unitOfWork, picture.Id);
                }
                await answerChoiceRepository.AddToUowForDeleteAsync(unitOfWork, choice.Id);
            }
            return await unitOfWork.CommitAsync();
        }

        public Task<int> InsertPictureAsync(IQuestionPicture questionPicture)
        {
            return questionRepository.InsertPictureAsync(questionPicture);
        }

        public Task<int> UpdatePictureAsync(IQuestionPicture questionPicture)
        {
            return questionRepository.UpdatePictureAsync(questionPicture);
        }

        public Task<int> DeletePictureAsync(string questionPictureId)
        {
            return questionRepository.DeletePictureAsync(questionPictureId);
        }
    }
}
