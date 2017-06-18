using System;
using System.Linq;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Filters;
using MuseumProject.Helpers;

namespace MuseumProject.Controllers
{
    [InitializeSimpleMembership]
    public class CommentsController : Controller
    {
        private readonly MuseumContext _db = new MuseumContext();

        [HttpPost]
        public JsonResult AddComment(int id, string text)
        {
            if (!Request.IsAuthenticated)
            {
                return Json(new { IsSuccess = false, Message = "Нужно авторизоваться." });
            }
            var comment = new Comments
            {
                UserName = User.GetLogin(),
                Comment = text,
                CreatedDate = DateTime.Now,
                Deleted = false,
                UserProfileId = _db.UserProfiles.FirstOrDefault(x => x.UserName == User.Identity.Name).UserId,
                InformationId = id
            };
            _db.Comments.Add(comment);
            _db.SaveChanges();

            return Json(new { IsSuccess = true, Message = "Комментарий успешно добавлен." });
        }

        [HttpPost]
        public JsonResult DeleteComment(int id)
        {
            var comment = _db.Comments.Find(id);

            if (!Request.IsAuthenticated)
            {
                return Json(new { IsSuccess = false, Message = "Нужно авторизоваться." });
            }
            if (comment == null)
            {
                return Json(new { IsSuccess = false, Message = "Данный комментарий не найден." });
            }
            if (!User.HasLogin(comment.UserName) && !User.IsAdmin())
            {
                return Json(new { IsSuccess = false, Message = "У вас нет прав на удалние данного комментария." });
            }

            comment.Deleted = true;
            _db.SaveChanges();

            return Json(new { IsSuccess = true, Message = "Комментарий успешно удалён." });
        }

    }
}