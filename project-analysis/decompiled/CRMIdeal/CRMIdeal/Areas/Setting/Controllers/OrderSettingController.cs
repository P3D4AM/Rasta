using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class OrderSettingController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSOrderSettingViewModel wSOrderSettingViewModel = new WSOrderSettingViewModel();
		_ = DateTime.Now;
		try
		{
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFoundSetting;
			}
			else
			{
				string text = crmsysSetting.OrderSetting ?? "";
				if (string.IsNullOrWhiteSpace(text))
				{
					base.ViewBag.Error = Messages.ErrorNotFoundSetting;
				}
				else
				{
					List<WSOrderSettingViewModel> list = new JavaScriptSerializer().Deserialize<List<WSOrderSettingViewModel>>(text);
					if (list != null && Enumerable.Any<WSOrderSettingViewModel>((IEnumerable<WSOrderSettingViewModel>)list))
					{
						wSOrderSettingViewModel = Enumerable.FirstOrDefault<WSOrderSettingViewModel>((IEnumerable<WSOrderSettingViewModel>)list);
					}
					if (wSOrderSettingViewModel == null)
					{
						wSOrderSettingViewModel = new WSOrderSettingViewModel();
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSOrderSettingViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult Index(WSOrderSettingViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<WSOrderSettingViewModel> list = new List<WSOrderSettingViewModel>();
			if (model == null)
			{
				num++;
				text = Messages.ErrorNotFoundSetting;
			}
			else
			{
				list.Add(model);
			}
			if (num == 0)
			{
				_ = DateTime.Now;
				try
				{
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
					if (crmsysSetting != null)
					{
						DateTime now = DateTime.Now;
						DateTime value = now;
						now.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
						short value3 = short.Parse(Financial.Get().Id.ToString());
						string appType = Configuration.AppType;
						_ = Financial.Get().Id;
						int userId = UserLogin.CurrentUser.UserId;
						string orderSetting = JsonConvert.SerializeObject(Enumerable.ToList<WSOrderSettingViewModel>((IEnumerable<WSOrderSettingViewModel>)list));
						crmsysSetting.UserId = userId;
						crmsysSetting.RegisterDate = value;
						crmsysSetting.Month1 = value2;
						crmsysSetting.Year1 = value3;
						crmsysSetting.AppType = appType;
						crmsysSetting.OrderSetting = orderSetting;
						_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
						SysSeting.Update();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						text = Messages.ErrorNotFoundSetting;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
