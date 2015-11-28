using OnlineExamPrep.Models.Mapping;

namespace OnlineExamPrep.WebAPI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapperMaps.Initialize();
        }
    }
}