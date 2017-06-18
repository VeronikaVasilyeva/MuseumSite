using System;
using System.ComponentModel.DataAnnotations;

namespace MuseumProject.Context
{
    public class Event
    {
        public int Id { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Finish { get; set; }

        // [ForeignKey("Information")]
        // public int InformationId { get; set; }

        // public virtual Information Information { get; set; }
    }
}