using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using MuseumProject.Context;
using MuseumProject.Helpers;

namespace MuseumProject.Models
{
    public class PhotoModel : IValidatableObject
    {
        public int Id { get; set; }

        [DisplayName("Заголовок")]
        [MaxLength(50)]
        public string PhotoTitle { get; set; }

        [DisplayName("Краткое описание")]
        [MaxLength(100)]
        public string PhotoShortDescription { get; set; }

        [DisplayName("Файл")]
        public HttpPostedFileBase File { get; set; }

        public string FileName { get; set; }

        [DisplayName("Разрешить к публикации")]
        public bool Published { get; set; }

        public PhotoModel() { }

        public PhotoModel(Photo photo)
        {
            Id = photo.Id;
            PhotoTitle = photo.Title;
            PhotoShortDescription = photo.ShortDiscription;
            Published = photo.Published;
            FileName = photo.FileName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == 0 && File == null)
            {
                yield return new ValidationResult("Необходимо выбрать файл", new[] { "File" });
            }
        }

        public void ApplyChange(Photo photo)
        {
            if (photo.Id == 0)
            {
                var newFileName = RandomHelper.GeneratePhotoName(File.FileName);
                File.SaveAs(ConstsHelper.ProjectPhotosFolder + newFileName);
                photo.FileName = newFileName;
            }

            photo.Title = PhotoTitle ?? "";
            photo.ShortDiscription = PhotoShortDescription ?? "";
            photo.Published = Published;
        }
    }
}