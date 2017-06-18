using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumProject.Context
{
    public class Photo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDiscription { get; set; }

        [Required]
        public string FileName { get; set; }

        public bool Published { get; set; }

        [ForeignKey("Information")]
        public int InformationId { get; set; }

        public virtual Information Information { get; set; }
    }   
}