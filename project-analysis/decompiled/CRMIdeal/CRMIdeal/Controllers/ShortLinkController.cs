using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.GSD.Globalization;

namespace CRMIdeal.Controllers;

public class ShortLinkController : Controller
{
	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index(string key)
	{
		if (!string.IsNullOrEmpty(key))
		{
			DateTime now = DateTime.Now;
			string datePersian = now.ToString("yyyyMMdd", new PersianCulture());
			mct_Result_StrII mct_Result_StrII = Enumerable.FirstOrDefault<mct_Result_StrII>((IEnumerable<mct_Result_StrII>)_dbII.CRMspViewShortLink(key, now, datePersian));
			string value = string.Empty;
			if (!string.IsNullOrEmpty(mct_Result_StrII.Result.ToString()))
			{
				if (mct_Result_StrII.Result == "-1")
				{
					value = Messages.msgErrorShortLinkNotFound;
				}
				else if (mct_Result_StrII.Result == "-2")
				{
					value = Messages.msgErrorShortLinkInactive;
				}
				else if (mct_Result_StrII.Result == "-3")
				{
					value = Messages.msgErrorShortLinkExpired;
				}
				else if (mct_Result_StrII.Result == "-4")
				{
					value = Messages.msgErrorShortLinkViewLimitReached;
				}
				if (!string.IsNullOrEmpty(value))
				{
					base.TempData["Message"] = value;
					base.TempData["Type"] = "error";
					return RedirectToAction("ShowMessage", "Home");
				}
				return Redirect(mct_Result_StrII.Result);
			}
			return RedirectToAction("ShowMessage", "Home", (object)new
			{
				message = Messages.msgErrorShortLinkNotFound,
				type = "error"
			});
		}
		return HttpNotFound();
	}
}
