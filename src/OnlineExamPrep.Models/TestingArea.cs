﻿using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models
{
    public class TestingArea : ITestingArea
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
    }
}
