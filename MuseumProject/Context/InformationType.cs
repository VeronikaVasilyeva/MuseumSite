using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuseumProject.Context
{
    public class InformationType
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        public virtual List<Information> Informations { get; set; }
    }
}