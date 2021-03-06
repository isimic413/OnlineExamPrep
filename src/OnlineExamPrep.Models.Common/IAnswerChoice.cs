﻿using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IAnswerChoice
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        string Text { get; set; }
        byte Points { get; set; }
    }
}
