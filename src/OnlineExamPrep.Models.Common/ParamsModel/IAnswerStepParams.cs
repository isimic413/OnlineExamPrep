﻿using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IAnswerStepParams
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        string Text { get; set; }
        byte Number { get; set; }
        byte Points { get; set; }
        IQuestion Question { get; set; }
        ICollection<IAnswerStepPicture> AnswerStepPictures { get; set; }
    }
}
