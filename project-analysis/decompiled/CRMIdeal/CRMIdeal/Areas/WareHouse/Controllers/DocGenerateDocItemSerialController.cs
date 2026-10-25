using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class DocGenerateDocItemSerialController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmDoc", ActionName = "actGenerateDocItemSerial")]
	public ActionResult Index(int docItemId, int whId, int docId = 0)
	{
		DocGenerateDocItemSerialViewModel model = new DocGenerateDocItemSerialViewModel
		{
			ItemId = docItemId,
			WHId = whId,
			ExpDate_Text = "",
			DocId = docId
		};
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmGenerateDocItemSerial", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(DocGenerateDocItemSerialViewModel model)
	{
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string expDate_Text = model.ExpDate_Text;
		if (Doc.IsSentToLinkAccByAction(model.DocId))
		{
			string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			return View(model);
		}
		if (!VersionBuyer.WareHouseUserPermission)
		{
			int num = 1000;
			List<WSspSelectDocItemSerials_Result> list = Enumerable.ToList<WSspSelectDocItemSerials_Result>((IEnumerable<WSspSelectDocItemSerials_Result>)_db.WSspSelectDocItemSerials(model.ItemId, lCID, defLangID));
			int num2 = 0;
			if (list != null && Enumerable.Any<WSspSelectDocItemSerials_Result>((IEnumerable<WSspSelectDocItemSerials_Result>)list))
			{
				num2 = Enumerable.Count<WSspSelectDocItemSerials_Result>((IEnumerable<WSspSelectDocItemSerials_Result>)list);
			}
			int count = model.Count;
			if (num2 + count > num)
			{
				base.ViewBag.Error = string.Format(Messages.msgErrorInsertSeiralMoreThanNumberInDoc, num);
				return View(model);
			}
		}
		DateTime dateTime = default(DateTime);
		string text = "";
		if (!string.IsNullOrEmpty(model.ExpDatePersian))
		{
			try
			{
				if (!string.IsNullOrEmpty(expDate_Text))
				{
					text = PersianDate.GetFormatetdDate(model.ExpDatePersian.Replace("/", ""));
					if (lCID == 1065)
					{
						dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
						model.ExpDatePersian = dateTime.ToString("yyyyMMdd");
					}
					else
					{
						dateTime = DateTime.Parse(PersianDate.GetShamsi2Miladi(text.Replace("/", "")));
						model.ExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					}
					model.ExpDate = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.ErrorFormatDatePersian;
				return View(model);
			}
		}
		else if (!string.IsNullOrEmpty(expDate_Text))
		{
			text = PersianDate.GetFormatetdDate(expDate_Text.Replace("/", ""));
			dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
			model.ExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
			model.ExpDate = dateTime;
		}
		if (model.ExpDatePersian != null)
		{
			model.ExpDatePersian = model.ExpDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
				.Replace(".", "")
				.Replace(",", "")
				.Replace("\\", "");
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				model.Description = ((model.Description == "") ? null : model.Description);
				if (!string.IsNullOrEmpty(model.Description_Lang))
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.Description_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Description_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = model.Description,
						LanguageId = lCID
					});
					model.Description_Lang = "";
					model.Description_Lang = Enumerable.Aggregate<CommonMultiLanguageViewModel, string>((IEnumerable<CommonMultiLanguageViewModel>)list2, model.Description_Lang, (Func<string, CommonMultiLanguageViewModel, string>)((string current, CommonMultiLanguageViewModel item) => current + "@LangID=" + item.LanguageId + ",%," + item.Value + "|"));
					model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				}
				DateTime now = DateTime.Now;
				if (_db.WSspGenerateDocItemSerial(model.Count, model.ItemId, model.PreFixSerial, model.Serial, model.IncSerial, model.Description, model.WHId, UserLogin.CurrentUser.UserId, int.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, now.ToString(), now.ToString("yyyyMMdd", new PersianCulture()), model.ExpDate, model.ExpDatePersian, Configuration.AppType, model.PreFixInfoI, model.InfoI, model.IncInfoI, model.PreFixInfoII, model.InfoII, model.IncInfoII, model.PreFixInfoIII, model.InfoIII, model.IncInfoIII, model.PreFixInfoIV, model.InfoIV, model.IncInfoIV, model.PreFixInfoV, model.InfoV, model.IncInfoV, model.PreFixInfoVI, model.InfoVI, model.IncInfoVI, defLangID, model.Description_Lang) <= 0)
				{
					base.ViewBag.Error = Messages.msgNotCompeleteSuccessAction + "<br>" + Messages.msgErrorDupSerialInGenerateSerialInDoc;
				}
				else
				{
					base.ViewBag.Successfull = Messages.msgOperationCompleted;
				}
			}
			catch (DbEntityValidationException ex)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
			}
			catch (Exception ex2)
			{
				ErrorSignal.FromCurrentContext().Raise(ex2);
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
			}
		}
		model.ExpDate_Text = expDate_Text;
		return View(model);
	}

	[AjaxOnly]
	public string ConvertDate(string dt, string typ)
	{
		string result = "-1";
		try
		{
			if (typ == "fa")
			{
				result = DateTime.Parse(dt + " 00:00:00", new CultureInfo("en-US")).ToString("yyyy/MM/dd", new PersianCulture());
			}
			else if (typ == "en")
			{
				result = DateTime.Parse(PersianDate.GetShamsi2Miladi(dt.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
