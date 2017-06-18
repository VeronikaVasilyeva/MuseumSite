using System.Web.Optimization;

namespace MuseumProject
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                        .Include("~/Scripts/jquery-{version}.js")
                        .Include("~/Scripts/tinymce/tiny_mce.js")
                        .Include("~/Scripts/bootstrap-image-gallery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                        .Include("~/Scripts/jquery.unobtrusive*")
                        .Include("~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap*")
                .Include("~/Content/bootstrap-image-gallery.css")
                .Include("~/Content/carousel.css"));
        }
    }
}