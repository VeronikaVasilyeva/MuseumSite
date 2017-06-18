using System.Linq;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Filters;
using MuseumProject.Helpers;
using MuseumProject.Models;
using MuseumProject.Models.Enums;

namespace MuseumProject.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private readonly MuseumContext _db = new MuseumContext();

        public ActionResult Index()
        {
            var model = new HomeModel
            {
                Informations = _db.Informations
                    .Where(i => i.IsPublished)
                    .Where(i => i.InformationTypeId == (int) InformationTypes.News)
                    .OrderByDescending(i => i.CreatedTime)
                    .Take(ConstsHelper.HomePageNewsCount)
                    .ToList()
            };
            model.Informations.ForEach(i => i.Counter = _db.Counters.Count(e => e.InformationId == i.Id));
            return View(model);
        }

        public ActionResult About()
        {
            var about = _db.Informations.FirstOrDefault(i => i.InformationTypeId == (int)InformationTypes.About);
            var model = new BaseInformationModel(about);
            return View(model);
        }
        
        public ActionResult EditAbout()
        {
            var about = _db.Informations.FirstOrDefault(i => i.InformationTypeId == (int)InformationTypes.About);
            var model = new BaseInformationModel(about);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditAbout(BaseInformationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var about = _db.Informations.FirstOrDefault(i => i.InformationTypeId == (int)InformationTypes.About);
            model.ApplyChange(about);
            _db.SaveChanges();
            return RedirectToAction("About");
        }

        public ActionResult Contact()
        {
            var contact = _db.Informations.FirstOrDefault(i => i.InformationTypeId == (int)InformationTypes.Contacts);
            var model = new BaseInformationModel(contact);
            return View(model);
        }

        public ActionResult EditContact()
        {
            var contact = _db.Informations.FirstOrDefault(i => i.InformationTypeId == (int)InformationTypes.Contacts);
            var model = new BaseInformationModel(contact);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditContact(BaseInformationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = _db.Informations.FirstOrDefault(i => i.InformationTypeId == (int)InformationTypes.Contacts);
            model.ApplyChange(contact);
            _db.SaveChanges();
            return RedirectToAction("Contact");
        }
    }
}