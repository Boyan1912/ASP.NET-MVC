namespace TwitterLikeApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        private ICollection<Twit> twits;
        
        public Tag()
        {
            this.Twits = new HashSet<Twit>();
        }
        

        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^#{1}\w+", ErrorMessage = "A tag name should start with the symbol '#'")]
        public string Name { get; set; }

        public virtual ICollection<Twit> Twits { get { return this.twits; } set { this.twits = value; } }


    }
}