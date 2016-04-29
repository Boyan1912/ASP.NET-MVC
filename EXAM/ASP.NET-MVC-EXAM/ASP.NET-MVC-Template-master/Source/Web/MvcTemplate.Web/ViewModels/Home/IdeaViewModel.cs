namespace MvcTemplate.Web.ViewModels.Home
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using MvcTemplate.Data.Models;

    public class IdeaViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int VotesCount { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.VotesCount, opt => opt.MapFrom(x => x.Votes.Count));
            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}