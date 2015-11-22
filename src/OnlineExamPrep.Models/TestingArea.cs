using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class TestingArea : ITestingArea
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
    }
}
