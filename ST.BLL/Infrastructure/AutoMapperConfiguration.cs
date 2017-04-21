using AutoMapper;

namespace ST.BLL.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MyMappings>();
            });
        }
    }

    public class MyMappings : Profile
    {
        
    }
}
