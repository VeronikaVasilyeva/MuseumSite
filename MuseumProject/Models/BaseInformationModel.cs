using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Models.Abstracts;
using MuseumProject.Models.Enums;

namespace MuseumProject.Models
{
    public class BaseInformationModel : AbstractInformationModel
    {
        public BaseInformationModel() : base(InformationTypes.BaseInformation) { }

        public BaseInformationModel(Information information) : base(information)
        {
            Text = information.Text;
        }

        [DisplayName("Текст")]
        [Required]
        [AllowHtml]
        [StringLength(1000, ErrorMessage = "Длина строки: не более 1000 символов.")]
        public string Text { get; set; }

        protected override void CustomApplyChange(Information information)
        {
            information.Text = Text;
        }
    }
}