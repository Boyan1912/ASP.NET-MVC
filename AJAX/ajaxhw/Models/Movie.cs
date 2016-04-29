namespace ajaxhw.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
        
        public string Director { get; set; }

        public string LeadingMaleRole { get; set; }

        public int LeadingMaleActorAge { get; set; }

        public string LeadingFemaleRole { get; set; }

        public int LeadingFemaleActorAge { get; set; }

    }
}