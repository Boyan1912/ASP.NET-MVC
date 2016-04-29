namespace TwitterLikeApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Twit
    {
        private ICollection<Tag> tags;

        public Twit()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 150, MinimumLength = 5, ErrorMessage ="A twit must be between 5 and 150 characters long")]
        public string Text { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags { get { return this.tags; } set { this.tags = value; } }

    }
}
