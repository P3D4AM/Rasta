using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Mobile.Classes;

namespace CRMIdeal.Areas.Company.Controllers;

public class LogoController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult Index()
	{
		CrmCompanyLoGoViewModel model = new CrmCompanyLoGoViewModel();
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Index(CrmCompanyLoGoViewModel logo, HttpPostedFileBase CompanyLogoUrlUpload)
	{
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		if (CompanyLogoUrlUpload != null)
		{
			string text = CompanyLogoUrlUpload.ContentType.ToLower();
			string text2 = Path.GetExtension(CompanyLogoUrlUpload.FileName).ToLower();
			if ((text != "image/jpg" && text != "image/jpeg" && text != "image/pjpeg" && text != "image/gif" && text != "image/x-png" && text != "image/png") || (text2 != ".jpg" && text2 != ".png" && text2 != ".gif" && text2 != ".jpeg"))
			{
				base.ModelState.AddModelError("error", "Not Image");
				return View(logo);
			}
		}
		CrmCompanyLoGo crmCompanyLoGo = new CrmCompanyLoGo();
		crmCompanyLoGo.CompanyId = 2242;
		crmCompanyLoGo.LogoDesc = "";
		crmCompanyLoGo.Month1 = 3;
		crmCompanyLoGo.RegisterDate = DateTime.Now;
		crmCompanyLoGo.RegisterDatePersian = "13940320";
		crmCompanyLoGo.Year1 = 1;
		crmCompanyLoGo.UserId = UserLogin.CurrentUser.UserId;
		_ = string.Empty;
		_ = string.Empty;
		if (CompanyLogoUrlUpload != null)
		{
			Bitmap val = new Bitmap(CompanyLogoUrlUpload.InputStream);
			MemoryStream memoryStream = new MemoryStream();
			((Image)val).Save((Stream)memoryStream, ImageFormat.Png);
			crmCompanyLoGo.CompanyLogo = memoryStream.GetBuffer();
		}
		else
		{
			crmCompanyLoGo.CompanyLogo = null;
		}
		crmCompanyLoGo.AppType = CRMIdeal.Classes.Common.Configuration.AppType;
		_dbTbl.CrmCompanyLoGo.Add(crmCompanyLoGo);
		_dbTbl.SaveChanges();
		return View(logo);
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
