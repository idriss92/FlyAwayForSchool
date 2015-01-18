using System.Web;
using System.Web.Optimization;

namespace FlyAwayForSchool
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                     "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                      "~/Content/datepicker.css"));


            bundles.Add(new ScriptBundle("~/bundles/timepicker").Include(
                     "~/Scripts/bootstrap-timepicker.js"));

            bundles.Add(new StyleBundle("~/Content/timepicker").Include(
                    "~/Content/bootstrap-datepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                     "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/datetimepicker").Include(
                    "~/Content/bootstrap-datetimepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/clockpicker").Include(
                    "~/Scripts/bootstrap-clockpicker.js"));

            bundles.Add(new StyleBundle("~/Content/clockpicker").Include(
                    "~/Content/bootstrap-clockpicker.css"));

            // Définissez EnableOptimizations sur False pour le débogage. Pour plus d'informations,
            // visitez http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
