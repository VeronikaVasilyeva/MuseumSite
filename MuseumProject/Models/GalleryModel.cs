using MuseumProject.Context;
using MuseumProject.Models.Abstracts;
using MuseumProject.Models.Enums;

namespace MuseumProject.Models
{
    public class GalleryModel : AbstractInformationModel
    {
        public GalleryModel() : base(InformationTypes.Gallary) { }

        public GalleryModel(Information information) : base(information) { }

        protected override void CustomApplyChange(Information information)
        {
            information.Text = "text";
        }
    }
}