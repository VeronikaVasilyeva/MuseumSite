using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumProject.Context
{
    public class Counter
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Ip { get; set; }

        [ForeignKey("Information")]
        public int InformationId { get; set; }
        
        public virtual Information Information { get; set; }
    }
}