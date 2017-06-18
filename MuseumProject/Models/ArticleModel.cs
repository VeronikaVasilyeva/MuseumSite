﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Models.Abstracts;
using MuseumProject.Models.Enums;

namespace MuseumProject.Models
{
    public class ArticleModel : AbstractInformationModel
    {
        [DisplayName("Текст")]
        [Required]
        [AllowHtml]
        [StringLength(1000, ErrorMessage = "Длина строки: не более 1000 символов.")]
        public string Text { get; set; }

        [DisplayName("Количество просмотров")]
        public int Counter { get; set; }

        public ArticleModel() : base(InformationTypes.Article) {}

        public ArticleModel(Information information) : base(information)
        {
            Text = information.Text;
            Counter = information.Counter;
        }

        protected override void CustomApplyChange(Information information)
        {
            information.Text = Text;
        }
    }
}