using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BundlingMinificationExample
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Add bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/customscripts").Include(
                        "~/Scripts/JavaScript1.js",
                        "~/Scripts/JavaScript2.js",
                        "~/Scripts/JavaScript3.js",
                        "~/Scripts/JavaScript4.js",
                        "~/Scripts/JavaScript5.js",
                        "~/Scripts/JavaScript6.js",
                        "~/Scripts/JavaScript7.js",
                        "~/Scripts/JavaScript8.js",
                        "~/Scripts/JavaScript9.js",
                        "~/Scripts/JavaScript10.js"));

            bundles.Add(new StyleBundle("~/bundles/customstyles").Include(
                        "~/Content/StyleSheet*"));
        }
    }
}