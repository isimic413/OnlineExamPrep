namespace OnlineExamPrep.Common
{
    public static class ExamTerms
    {
        public const int Summer = 1;
        public const int Autumn = 2;

        public static string GetExamTermName(int term)
        {
            if (term == Summer)
            {
                return "Ljeto"; // Summer
            }
            else if (term == Autumn)
            {
                return "Jesen"; // Autumn
            }
            return "";
        }
    }
}
