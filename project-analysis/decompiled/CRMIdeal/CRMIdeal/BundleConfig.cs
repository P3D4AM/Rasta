using System.Web.Optimization;

namespace CRMIdeal;

public class BundleConfig
{
	public static void RegisterBundles(BundleCollection bundles)
	{
		bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", "~/Scripts/js/jsToast.js"));
		bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));
		bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.validate*"));
		bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
		bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
		bundles.Add(new StyleBundle("~/Content/themes/base/css").Include("~/Content/themes/base/jquery.ui.core.css", "~/Content/themes/base/jquery.ui.resizable.css", "~/Content/themes/base/jquery.ui.selectable.css", "~/Content/themes/base/jquery.ui.accordion.css", "~/Content/themes/base/jquery.ui.autocomplete.css", "~/Content/themes/base/jquery.ui.SubmitButton.css", "~/Content/themes/base/jquery.ui.dialog.css", "~/Content/themes/base/jquery.ui.slider.css", "~/Content/themes/base/jquery.ui.tabs.css", "~/Content/themes/base/jquery.ui.datepicker.css", "~/Content/themes/base/jquery.ui.progressbar.css", "~/Content/themes/base/jquery.ui.theme.css"));
		bundles.Add(new StyleBundle("~/Content/style").Include("~/Content/StySetting-old.css", "~/Content/StyPublic-old.css", "~/Content/Menu/Inner-Menu.css", "~/Content/Responsive/RepPublic.css", "~/Content/Menu/Main-Menu.css", "~/Content/Menu/Cartable-Menu.css"));
		bundles.Add(new StyleBundle("~/Content/styleIndex").Include("~/Content/StySetting-old.css", "~/Content/Responsive/RepPublic.css"));
		bundles.Add(new ScriptBundle("~/bundles/KendoUI/js").Include("~/Scripts/kendo/2013.2.918/kendo.all.min.js", "~/Scripts/kendo/2013.2.918/kendo.aspnetmvc.min.js", "~/Scripts/kendo.modernizr.custom.js"));
		bundles.Add(new StyleBundle("~/bundles/KendoUI/Css").Include("~/Content/kendo.compatibility.css", "~/Content/kendo/2014.2.1008/kendo.common-bootstrap.min.css", "~/Content/kendo/2013.2.918/kendo.dataviz.min.css", "~/Content/kendo/2014.2.1008/kendo.bootstrap.min.css", "~/Content/kendo/2014.1.318/kendo.dataviz.bootstrap.min.css"));
		bundles.Add(new ScriptBundle("~/bundles/KendoUI2022/js").Include("~/Scripts/Kendo_2022/kendo.all.min.js", "~/Scripts/Kendo_2022/kendo.aspnetmvc.min.js", "~/Scripts/kendo.modernizr.custom.js"));
		bundles.Add(new StyleBundle("~/bundles/KendoUI2022/Css").Include("~/Content/kendo.compatibility.css", "~/Content/Kendo_2022/kendo.common-bootstrap.min.css", "~/Content/Kendo_2022/kendo.dataviz.min.css", "~/Content/Kendo_2022/kendo.bootstrap.min.css", "~/Content/Kendo_2022/kendo.dataviz.bootstrap.min.css"));
		bundles.Add(new StyleBundle("~/Content/NewStyle").Include("~/Content/fonts.css", "~/Content/icofont.css", "~/Content/flag-icon.css", "~/Content/bootstrap-4-1.css", "~/Content/MainStyle.css", "~/Content/Responsive/RepMainStyle.css", "~/Content/StySetting.css", "~/Content/StyPublic.css"));
		bundles.IgnoreList.Clear();
		bundles.IgnoreList.Ignore("*.intellisense.js");
		bundles.IgnoreList.Ignore("*-vsdoc.js");
		bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
		BundleTable.EnableOptimizations = false;
	}
}
