using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using Elmah;

namespace CRMIdeal.Areas.Sms.Controllers;

public class TelegramController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	public ActionResult Index()
	{
		CrmTelegramContactViewModel model = new CrmTelegramContactViewModel();
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Index(CrmTelegramContactViewModel model)
	{
		string text = "";
		try
		{
			if (!base.ModelState.IsValid)
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
