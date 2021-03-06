﻿using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IExamRepository
    {
        Task<List<IExamParams>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams);
        Task<List<IExam>> GetCollectionAsync(PagingParams pagingParams);
        Task<IExamParams> GetExamForUpdateAsync(string examId);
        Task<List<IExamQuestionParams>> GetExamQuestionsAsync(string examId);
        Task<dynamic> GetExamDataForSimulationAsync(string examId);
        Task<int> InsertAsync(IExam exam);
        Task<int> UpdateAsync(IExam exam);
        Task<int> DeleteAsync(string examId);
        Task<int> AddExamQuestionForInsert(IUnitOfWork unitOfWork, IExamQuestion examQuestion);
        Task<int> AddExamQuestionForUpdateAsync(IUnitOfWork unitOfWork, IExamQuestion examQuestion);
        Task<int> AddExamQuestionForDeleteAsync(IUnitOfWork unitOfWork, IExamQuestion examQuestion);
        Task<int> AddExamQuestionForDeleteAsync(IUnitOfWork unitOfWork, string examQuestionId);
        Task<int> GetNumberOfQuestionsAsync(string examId);
    }
}
