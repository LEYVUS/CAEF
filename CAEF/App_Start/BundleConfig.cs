﻿using System.Web;
using System.Web.Optimization;

namespace CAEF
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/jquery").Include(
                         "~/Content/node_modules/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/Content/Bootstrap/js").Include(
                        "~/Content/node_modules/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/Bootstrap/css").Include(
                        "~/Content/node_modules/bootstrap/dist/css/bootstrap.css",
                        "~/Content/css/estilos.css"));

            bundles.Add(new ScriptBundle("~/Content/Angular").Include(
                        "~/Content/node_modules/angular/angular.min.js",
                        "~/Content/node_modules/angular-route/angular-route.min.js",
                         "~/Content/node_modules/angular-crypto/angular-crypto.min.js",
                        "~/Content/node_modules/angular-modal-service/dst/angular-modal-service.min.js",
                        "~/Content/node_modules/angular-local-storage/dist/angular-local-storage.min.js"));

            bundles.Add(new ScriptBundle("~/Content/Angular/app").Include(
                       "~/Content/src/app-controller.js", "~/Content/src/app.js",
                       "~/Content/src/Directiva/TempleteDirectiva.js"));

            bundles.Add(new ScriptBundle("~/Content/Angular/Inicio").Include(
                       "~/Content/src/Controller/LoginControlador.js",
                       "~/Content/src/Controller/TiempoControlador.js"));

            bundles.Add(new ScriptBundle("~/Content/Angular/Usuario").Include(
                       "~/Content/src/Controller/UsuarioControlador.js",
                       "~/Content/src/Servicio/ServicioUtileria.js"));
        }
    }
}
