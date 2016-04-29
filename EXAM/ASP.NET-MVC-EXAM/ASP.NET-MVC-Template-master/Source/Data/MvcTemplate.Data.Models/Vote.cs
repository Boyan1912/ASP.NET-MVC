namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public string VoterIpAddress { get; set; }

        public int Points { get; set; }
    }
}
