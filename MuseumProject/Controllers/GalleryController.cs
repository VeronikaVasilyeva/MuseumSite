using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Filters;
using MuseumProject.Helpers;
using MuseumProject.Models;
using MuseumProject.Models.Abstracts;
using MuseumProject.Models.Enums;

namespace MuseumProject.Controllers
{
    [InitializeSimpleMembership]
    public class GalleryController : AbstractInformationController
    {
        private const int GallaryTypeId = (int) InformationTypes.Gallary;

        public ActionResult Index(int page = 1)
        {
            var itemCount = GetInformations(GallaryTypeId).Count();
            var pageCount = itemCount / ConstsHelper.PageSize + Math.Min(1, itemCount % ConstsHelper.PageSize);
            page = Math.Max(1, page);
            page = Math.Min(page, pageCount);
            var model = new AbstractInformationIndexModel
            {
                Items = GetInformations(GallaryTypeId)
                    .Skip((page - 1) * ConstsHelper.PageSize)
                    .Take(ConstsHelper.PageSize)
                    .ToList()
                    .Select(i => (AbstractInformationModel)new GalleryModel(i))
                    .ToList(),
                Page = page,
                PageCount = pageCount,
                Action = "Index"
            };

            return View(model);
        }

        public ActionResult Details(int id = 0)
        {
            var information = _db.Informations.Where(i => i.InformationTypeId == GallaryTypeId).FirstOrDefault(i => i.Id == id);
            if (information == null)
            {
                return HttpNotFound();
            }

            var model = new GalleryModel(information);
            model.Photos = model.Photos.Where(i => i.Published).ToList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = ConstsHelper.AdministratorRole)]
        public ActionResult Create()
        {
            var model = new GalleryModel();
            ViewBag.ActionName = "Create";
            ViewBag.Title = "Создание галереи";
            return View("Create", model);
        }


        [HttpPost]
        [Authorize(Roles = ConstsHelper.AdministratorRole)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryModel model)
        {
            if (ModelState.IsValid)
            {
                var information = new Information
                {
                    InformationTypeId = (int) InformationTypes.Gallary,
                    CreatedTime = DateTime.Now,
                    Counter = 0
                };
                model.ApplyChange(information);

                _db.Informations.Add(information);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = information.Id });
            }
            ViewBag.ActionName = "Create";
            ViewBag.Title = "Создание галереи";
            return View("Create", model);
        }

        [HttpGet]
        [Authorize(Roles = ConstsHelper.AdministratorRole)]
        public ActionResult Edit(int id = 0)
        {
            var information = _db.Informations.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformationTypeId = new SelectList(_db.InformationType, "Id", "Category",
                information.InformationTypeId);
            var model = new GalleryModel(information);
            ViewBag.ActionName = "Edit";
            ViewBag.Title = "Изменение галереи";
            return View("Create", model);
        }

        [HttpPost]
        [Authorize(Roles = ConstsHelper.AdministratorRole)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalleryModel model)
        {
            if (ModelState.IsValid)
            {
                var information = _db.Informations.Find(model.Id);
                model.ApplyChange(information);
                _db.Entry(information).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = information.Id });
            }
            ViewBag.ActionName = "Edit";
            ViewBag.Title = "Изменение галереи";
            return View("Create", model);
        }

        [HttpPost]
        [Authorize(Roles = ConstsHelper.AdministratorRole)]
        public JsonResult Delete(int id)
        {
            var article = _db.Informations.Find(id);
            if (article == null || article.InformationTypeId != (int) InformationTypes.Gallary)
            {
                return Json(new { IsSuccess = false, Message = "Галерея не найдена." });
            }

            DeteleInformation(article);
            _db.SaveChanges();

            return Json(new { IsSuccess = true, Message = "Галерея успешно удалена." });
        }
    }
}