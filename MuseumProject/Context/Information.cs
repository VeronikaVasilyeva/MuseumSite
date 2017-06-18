using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumProject.Context
{
    public class Information
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        [Required]
        public bool IsCommented { get; set; }

        [Required]
        public int Counter { get; set; }

        [Required]
        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [ForeignKey("InformationType")]
        public int InformationTypeId { get; set; }
        
        public virtual InformationType InformationType { get; set; }

        public virtual List<Photo> Photos { get; set; }

        public virtual List<Comments> Comments { get; set; } 

    }
}