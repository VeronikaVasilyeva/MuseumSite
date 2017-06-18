using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Helpers;
using MuseumProject.Models.Enums;
using MuseumProject.Models.Interfaces;
using WebGrease.Css.Extensions;

namespace MuseumProject.Models.Abstracts
{
    public abstract class AbstractInformationModel : IViewModel<Information>
    {
        public int Id { get; set; }

        private InformationTypes _informationType;
        public InformationTypes InformationType { get { return _informationType; } }

        [DisplayName("Заголовок")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина строки: не более 50 символов.")]
        public string Title { get; set; }

        [DisplayName("Дата создания")]
        [Required]
        public DateTime CreatedTime { get; set; }

        [DisplayName("Краткое описание")]
        [Required]
        [AllowHtml]
        [StringLength(100, ErrorMessage = "Длина строки: не более 100 символов.")]
        public string ShortDescription { get; set; }

        [DisplayName("Разрешено комментировать")]
        public bool IsCommented { get; set; }

        [DisplayName("Опубликовать")]
        public bool IsPublished { get; set; }

        [DisplayName("Фотографии")]
        public List<PhotoModel> Photos { get; set; }

        [DisplayName("Комментарии")]
        public List<CommentModel> Comments { get; set; }

        protected AbstractInformationModel(InformationTypes type)
        {
            CreatedTime = DateTime.Now;
            IsCommented = true;
            IsPublished = true;
            _informationType = type;
        }

        protected AbstractInformationModel(Information information)
        {
            Id = information.Id;
            _informationType = (InformationTypes) information.InformationTypeId;
            Title = information.Title;
            CreatedTime = information.CreatedTime;
            ShortDescription = information.ShortDescription;
            IsCommented = information.IsCommented;
            IsPublished = information.IsPublished;
            Photos = information.Photos.Select(i => new PhotoModel(i)).ToList();
            var isUserAnAdmin = HttpContext.Current.User.IsAdmin();
            Comments = information.Comments.Where(i => isUserAnAdmin || !i.Deleted).Select(i => new CommentModel(i)).ToList();
        }

        protected abstract void CustomApplyChange(Information information);

        public void ApplyChange(Information information)
        {
            CustomApplyChange(information);
            information.Title = Title;
            information.ShortDescription = ShortDescription;
            information.IsCommented = IsCommented;
            information.IsPublished = IsPublished;
            information.Photos = information.Photos ?? new List<Photo>();

            if (Photos != null && Photos.Any())
            {
                foreach (var photoModel in Photos)
                {
                    var photo = photoModel.Id == 0 ? null : information.Photos.FirstOrDefault(i => i.Id == photoModel.Id);
                    if (photo == null)
                    {
                        photo = new Photo();
                        information.Photos.Add(photo);
                    }
                    photoModel.ApplyChange(photo);
                }
            }

            // TODO: допилить удаление
            information.Photos.Where(i => !Photos.Select(e => e.Id).Contains(i.Id)).ForEach(i => i.Published = false);
        }
    }
}