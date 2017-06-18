using System;
using System.Linq;
using System.Web.Mvc;
using MuseumProject.Context;
using MuseumProject.Helpers;

namespace MuseumProject.Controllers
{
    public abstract class AbstractInformationController : Controller
    {
        protected readonly MuseumContext _db = new MuseumContext();

        protected void UpdateCounter(int informationId)
        {
            var userIp = Request.UserHostAddress;
            var lastVisit = _db.Counters.OrderByDescending(i => i.Id).FirstOrDefault(i => i.Ip == userIp && i.InformationId == informationId);
            if (lastVisit == null || (DateTime.Now - lastVisit.Date).TotalSeconds > 24 * 60 * 60)
            {
                var counter = new Counter
                {
                    Date = DateTime.Now,
                    Ip = Request.UserHostAddress,
                    InformationId = informationId
                };
                _db.Counters.Add(counter);
                _db.SaveChanges();
            }
        }

        protected IQueryable<Information> GetInformations(int typeId)
        {
            var isAdmin = User.IsAdmin();
            return _db.Informations
                .Where(i => i.InformationTypeId == typeId)
                .Where(i => isAdmin || i.IsPublished)
                .OrderByDescending(i => i.CreatedTime);
        }

        protected void DeteleInformation(Information information)
        {
            foreach (var comment in information.Comments.ToList())
            {
                _db.Comments.Remove(comment);
            }
            foreach (var photo in information.Photos.ToList())
            {
                _db.Photos.Remove(photo);
            }
            _db.Informations.Remove(information);
        }
    }
}
