using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumProject.Context
{
    public class Comments
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public bool Deleted { get; set; }

        [ForeignKey("Information")]
        public int InformationId { get; set; }

        public virtual Information Information { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}