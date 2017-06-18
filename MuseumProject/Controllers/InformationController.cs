using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Models;

namespace MuseumProject.Controllers
{
    public class InformationController : Controller
    {
        private readonly MuseumContext _db = new MuseumContext();

        public ActionResult Index()
        {
            // TODO: удалить метод

            var informations = _db.Informations.Include(i => i.InformationType);
            return View(informations.ToList());
        }

        public ActionResult DetailsArticle(int id = 0)
        {
            //Request.UserHostAddress; - взять ip

            var information = _db.Informations.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
        
            var model = new InformationModel(information);
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateArticle()
        {
            var model = new InformationModel();
            return View("CreateArticle", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(InformationModel model)
        {
            if (ModelState.IsValid)
            {
                var information = new Information();
                model.ApplyChange(information);

                _db.Informations.Add(information);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CreateArticle", model);
        }

        [HttpGet]
        public ActionResult EditArticle(int id = 0)
        {
            var information = _db.Informations.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformationTypeId = new SelectList(_db.InformationType, "Id", "Category", information.InformationTypeId);
            var model = new InformationModel(information);
            return View("CreateArticle", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArticle(InformationModel model)
        {
            if (ModelState.IsValid)
            {
                var information = _db.Informations.Find(model.Id);
                model.ApplyChange(information);
                _db.Entry(information).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CreateArticle", model);
        }

        /*
        public ActionResult Delete(int id = 0)
        {
            // todo: сделать удаление
            //Information information = db.Informations.Find(id);
            //if (information == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(information);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // todo: сделать удаление
            //Information information = db.Informations.Find(id);
            //db.Informations.Remove(information);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
        */


        public ActionResult DetailsNews(int id = 0)
        {
            //Request.UserHostAddress; - взять ip

            var information = _db.Informations.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }

            var model = new InformationModel(information);
            return View("DetailsArticle", model);
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            var model = new InformationModel();
            return View("CreateArticle", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNews(InformationModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    //do whatever you want with the file
                }

                var information = new Information();
                model.ApplyChange(information);

                _db.Informations.Add(information);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CreateArticle", model);
        }

        [HttpGet]
        public ActionResult EditNews(int id = 0)
        {
            var information = _db.Informations.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformationTypeId = new SelectList(_db.InformationType, "Id", "Category", information.InformationTypeId);
            var model = new InformationModel(information);
            return View("CreateArticle", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNews(InformationModel model)
        {
            if (ModelState.IsValid)
            {
                var information = _db.Informations.Find(model.Id);
                model.ApplyChange(information);
                _db.Entry(information).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CreateArticle", model);
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}