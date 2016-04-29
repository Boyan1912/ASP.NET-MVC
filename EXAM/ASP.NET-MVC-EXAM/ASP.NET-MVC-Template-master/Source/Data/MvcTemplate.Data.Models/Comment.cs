namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;

    public class Comment : BaseModel<int>
    {

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorIp { get; set; }

    }
}
