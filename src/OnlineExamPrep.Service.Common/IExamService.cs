﻿using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IExamService
    {
        Task<List<dynamic>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams);
        Task<List<IExam>> GetCollectionAsync(PagingParams pagingParams);
        Task<dynamic> GetExamDataForSimulationAsync(string examId);
        Task<IExamParams> GetExamForUpdateAsync(string examId);
        Task<dynamic> GetExamQuestionsAsync(string examId);
        Task<int> InsertAsync(IExam exam);
        Task<int> UpdateAsync(IExam exam);
        Task<int> DeleteAsync(string examId);
        Task<int> UpdateQuestionOrderAsync(string examId, IExamQuestion[] examQuestions);
    }
}
