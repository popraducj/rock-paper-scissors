// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Microsoft">
//   Copyright © 2016 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.RockPaperScissors.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include(
                "~/content/app.css",
                "~/content/main.css",
                "~/content/loading-bar.css",
                "~/content/responsive.css"
                ));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(


                "~/scripts/vendor/angular-ui-router.js",
                "~/scripts/filters.js",
                "~/scripts/services.js",
                "~/scripts/vendor/angular-local-storage.min.js",
                "~/scripts/directives.js",
                "~/scripts/controllers.js",
                "~/scripts/loading-bar.js",
                "~/scripts/app.js",

                //Services
                "~/scripts/Services/AuthInterceptorService.js",
                "~/scripts/Services/AuthService.js",
                "~/scripts/Services/GameService.js",
                "~/scripts/Services/AdvancedGameService.js",

                //Controllers
                "~/scripts/Controllers/IndexController.js",
                "~/scripts/Controllers/AboutController.js",
                "~/scripts/Controllers/LoginController.js",
                "~/scripts/Controllers/SignupController.js",
                "~/scripts/Controllers/RockPaperScissorsInverseController.js",
                "~/scripts/Controllers/AdvancedGameController.js",
                "~/scripts/Controllers/HomeController.js"));
        }
    }
}
