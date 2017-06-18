using System;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Filters;
using MuseumProject.Helpers;

namespace MuseumProject.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles = ConstsHelper.AdministratorRole)]
    public class AdministrationController : Controller
    {
        private readonly MuseumContext _db = new MuseumContext();

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult SetBaseInformation(int id, string text)
        //{
        //    var info = _db.BaseInformations.Find(id);
        //    if (info == null)
        //    {
        //        return Json(new { IsSuccess = false, Message = "Информация не найдена." });
        //    }
        //    if (String.IsNullOrEmpty(text))
        //    {
        //        return Json(new { IsSuccess = false, Message = "Задаваемый текст не может быть пустым." });
        //    }
        //
        //    info.Text = HtmlTagHelper.ReplaceTags(text);
        //    _db.SaveChanges();
        //    return Json(new { IsSuccess = false, Message = "Текст успешно изменён." });
        //}

    }
}
