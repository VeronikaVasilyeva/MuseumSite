using System.Collections.Generic;
using MuseumProject.Models.Abstracts;
using MuseumProject.Models.Interfaces;

namespace MuseumProject.Models
{
    public class AbstractInformationIndexModel : IPageable
    {
        public List<AbstractInformationModel> Items { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public string Action { get; set; }
    }
}

