using System.Collections.Generic;
using MuseumProject.Context;

namespace MuseumProject.Models
{
    public class HomeModel      //модель для главной страницы
    {
        public List<Information> Informations { get; set; }       
    }
}