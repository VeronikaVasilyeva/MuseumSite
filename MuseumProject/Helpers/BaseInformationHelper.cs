using System.Linq;
using MuseumProject.Context;
using MuseumProject.Models.Enums;

namespace MuseumProject.Helpers
{
    public static class BaseInformationHelper
    {
        public static string GetPrices()
        {
            return GetInfoTextByTypeId((int)InformationTypes.Prices);
        }

        public static string GetBasement()
        {
            return GetInfoTextByTypeId((int)InformationTypes.Basement);
        }

        private static string GetInfoTextByTypeId(int typeId)
        {
            var _db = new MuseumContext();
            var info = _db.Informations.FirstOrDefault(i => i.InformationTypeId == typeId);
            return info != null ? info.Text : "";            
        }
    }
}