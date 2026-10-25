using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class FinancialPeriodController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineFinancialPeriod")]
	public ActionResult Index()
	{
		return View();
	}

	public List<WSFinancialPeriodViewModel> ListFinancialPeriod()
	{
		List<WSFinancialPeriodViewModel> list = new List<WSFinancialPeriodViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSFinancialPeriod> list2 = Enumerable.ToList<WSFinancialPeriod>((IEnumerable<WSFinancialPeriod>)_dbTbl.WSFinancialPeriod);
			List<CRMspSelectUsers_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
			foreach (WSFinancialPeriod item in list2)
			{
				WSFinancialPeriodViewModel wSFinancialPeriodViewModel = new WSFinancialPeriodViewModel();
				wSFinancialPeriodViewModel.Name = item.Name;
				wSFinancialPeriodViewModel.ID = item.ID;
				switch (lCID)
				{
				case 1065:
					wSFinancialPeriodViewModel.FDate = DateTimeClass.ConvertDateWOSlashToSlash(item.FDate);
					wSFinancialPeriodViewModel.TDate = DateTimeClass.ConvertDateWOSlashToSlash(item.TDate);
					break;
				case 1025:
					if (!string.IsNullOrEmpty(item.FDate))
					{
						wSFinancialPeriodViewModel.FDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.FDate.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
					}
					else
					{
						wSFinancialPeriodViewModel.FDate = "";
					}
					if (!string.IsNullOrEmpty(item.TDate))
					{
						wSFinancialPeriodViewModel.TDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.TDate.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
					}
					else
					{
						item.TDate = "";
					}
					break;
				default:
					if (!string.IsNullOrEmpty(item.FDate))
					{
						wSFinancialPeriodViewModel.FDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.FDate.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					}
					else
					{
						wSFinancialPeriodViewModel.FDate = "";
					}
					if (!string.IsNullOrEmpty(item.TDate))
					{
						wSFinancialPeriodViewModel.TDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.TDate.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
					}
					else
					{
						item.TDate = "";
					}
					break;
				}
				wSFinancialPeriodViewModel.Year1 = item.Year1;
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				wSFinancialPeriodViewModel.AppType = Configuration.GetAppType(item.AppType);
				CRMspSelectUsers_Result cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == item.FirstRegisterUserId));
				string text = ((cRMspSelectUsers_Result != null) ? (cRMspSelectUsers_Result.LName + ((cRMspSelectUsers_Result.FName != null) ? (" " + cRMspSelectUsers_Result.FName) : "")) : "");
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				wSFinancialPeriodViewModel.FirstRegisterDatePersian = text + " (" + text2 + ")";
				CRMspSelectUsers_Result cRMspSelectUsers_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == item.UserId));
				string text3 = ((cRMspSelectUsers_Result2 != null) ? (cRMspSelectUsers_Result2.LName + ((cRMspSelectUsers_Result2.FName != null) ? (" " + cRMspSelectUsers_Result2.FName) : "")) : "");
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				wSFinancialPeriodViewModel.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + wSFinancialPeriodViewModel.AppType + ")  (" + text4 + ")";
				list.Add(wSFinancialPeriodViewModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult FinancialPeriod_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListFinancialPeriod()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult FinancialPeriodList()
	{
		return Json(ListFinancialPeriod(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineFinancialPeriod", ActionName = "actDelete")]
	public string FinancialPeriodDelete(int financialId)
	{
		string text = "";
		try
		{
			if (financialId > 0)
			{
				WSFinancialPeriod wSFinancialPeriod = _dbTbl.WSFinancialPeriod.Find(financialId);
				if (wSFinancialPeriod != null)
				{
					try
					{
						_dbTbl.WSFinancialPeriod.Remove(wSFinancialPeriod);
						_dbTbl.SaveChanges();
						text = "1";
						Financial.Update();
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						text = Messages.RedundancyMessage;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						text = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmDefineFinancialPeriod", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int financialId = 0)
	{
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSFinancialPeriod wSFinancialPeriod = new WSFinancialPeriod();
		if (financialId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineFinancialPeriod", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			wSFinancialPeriod = new WSFinancialPeriod
			{
				ID = 0
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineFinancialPeriod", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			wSFinancialPeriod = _dbTbl.WSFinancialPeriod.Find(financialId) ?? new WSFinancialPeriod
			{
				ID = 0
			};
			if (wSFinancialPeriod != null)
			{
				switch (lCID)
				{
				case 1025:
					if (!string.IsNullOrEmpty(wSFinancialPeriod.FDate))
					{
						wSFinancialPeriod.FDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(wSFinancialPeriod.FDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA"));
					}
					else
					{
						wSFinancialPeriod.FDate = "";
					}
					if (!string.IsNullOrEmpty(wSFinancialPeriod.TDate))
					{
						wSFinancialPeriod.TDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(wSFinancialPeriod.TDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA"));
					}
					else
					{
						wSFinancialPeriod.TDate = "";
					}
					break;
				default:
					if (!string.IsNullOrEmpty(wSFinancialPeriod.FDate))
					{
						wSFinancialPeriod.FDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(wSFinancialPeriod.FDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"));
					}
					else
					{
						wSFinancialPeriod.FDate = "";
					}
					if (!string.IsNullOrEmpty(wSFinancialPeriod.TDate))
					{
						wSFinancialPeriod.TDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(wSFinancialPeriod.TDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"));
					}
					else
					{
						wSFinancialPeriod.TDate = "";
					}
					break;
				case 1065:
					break;
				}
			}
		}
		return View(wSFinancialPeriod);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineFinancialPeriod", ActionName = "actPost")]
	public ActionResult InsertEdit(WSFinancialPeriod model)
	{
		string text = "";
		try
		{
			if (model.FDate != null)
			{
				model.FDate = model.FDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (model.TDate != null)
			{
				model.TDate = model.TDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			DateTime dateTime = default(DateTime);
			string text2 = "";
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			try
			{
				if (!string.IsNullOrEmpty(model.FDate))
				{
					text2 = PersianDate.GetFormatetdDate(model.FDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						model.FDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						model.FDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						model.FDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(model);
			}
			try
			{
				if (!string.IsNullOrEmpty(model.TDate))
				{
					text2 = PersianDate.GetFormatetdDate(model.TDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						model.TDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						model.TDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						model.TDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(model);
			}
			bool flag = true;
			if (model.ID > 0)
			{
				WSspSelectFinancialPeriod_Result wSspSelectFinancialPeriod_Result = Enumerable.FirstOrDefault<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)_db.WSspSelectFinancialPeriod(), (Func<WSspSelectFinancialPeriod_Result, bool>)((WSspSelectFinancialPeriod_Result m) => m.ID == model.ID));
				if (wSspSelectFinancialPeriod_Result != null)
				{
					long result = 0L;
					long.TryParse(wSspSelectFinancialPeriod_Result.FDate ?? "", out result);
					long result2 = 0L;
					long.TryParse(wSspSelectFinancialPeriod_Result.TDate ?? "", out result2);
					long result3 = 0L;
					long.TryParse(model.FDate, out result3);
					long result4 = 0L;
					long.TryParse(model.TDate, out result4);
					if (result == result3 && result2 == result4)
					{
						flag = false;
					}
				}
			}
			int fpId = Financial.Get().Id;
			WSspSelectFinancialPeriod_Result wSspSelectFinancialPeriod_Result2 = Enumerable.FirstOrDefault<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)_db.WSspSelectFinancialPeriod(), (Func<WSspSelectFinancialPeriod_Result, bool>)((WSspSelectFinancialPeriod_Result m) => m.ID == fpId));
			if (wSspSelectFinancialPeriod_Result2 != null && flag)
			{
				string fDate = wSspSelectFinancialPeriod_Result2.FDate;
				string tDate = wSspSelectFinancialPeriod_Result2.TDate;
				if (model.ID != fpId && !string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
				{
					long result5 = 0L;
					long.TryParse(fDate, out result5);
					long result6 = 0L;
					long.TryParse(tDate, out result6);
					long result7 = 0L;
					long.TryParse(model.FDate, out result7);
					long result8 = 0L;
					long.TryParse(model.TDate, out result8);
					if (result5 > result7 && result6 > result8)
					{
						base.ViewBag.Error = string.Format(Messages.msgErrorNotRegFPBeforeCurrentFPByName, wSspSelectFinancialPeriod_Result2.Name ?? "");
						return View(model);
					}
				}
			}
			if (base.ModelState.IsValid)
			{
				try
				{
					if (model.ID > 0)
					{
						DateTime now = DateTime.Now;
						model.UserId = UserLogin.CurrentUser.UserId;
						model.RegisterDate = now;
						model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						model.AppType = Configuration.AppType;
						model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_dbTbl.Entry(model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						DateTime now2 = DateTime.Now;
						model.UserId = UserLogin.CurrentUser.UserId;
						model.RegisterDate = now2;
						model.RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						model.AppType = Configuration.AppType;
						model.Month1 = short.Parse(now2.ToString("MM", new PersianCulture()));
						model.GUId = Guid.NewGuid();
						int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result9);
						if (result9 <= 0)
						{
							result9 = 1065;
						}
						model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						model.FirstRegisterDate = now2;
						model.FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						model.LanguageID = result9;
						_dbTbl.WSFinancialPeriod.Add(model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					text = Messages.msgErrorRunFunction + "<br/>" + ex.Message;
				}
				Financial.Update();
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
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
