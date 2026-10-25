using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
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

namespace CRMIdeal.Areas.Sms.Controllers;

public class GSMSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int? gsmId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int gsmId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsGSMSetting")]
	public ActionResult Index()
	{
		return View();
	}

	public void SetRegisterInfo(SmsGSMModemSetting model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds((model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId) + "," + (model.UserId ?? UserLogin.CurrentUser.UserId));
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				model.UserId = model.UserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text5 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			string text6 = (model.RegisterDate.HasValue ? model.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text7 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text5 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text7 + ") (" + text6 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsGSMSetting")]
	public ActionResult InsertEdit(int? gsmId = null)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.gsmId = gsmId;
		SmsGSMModemSetting smsGSMModemSetting = null;
		DateTime now = DateTime.Now;
		if (!_003C_003Ec__DisplayClass4_.gsmId.HasValue || _003C_003Ec__DisplayClass4_.gsmId == 0)
		{
			smsGSMModemSetting = new SmsGSMModemSetting
			{
				RegisterDate = now,
				RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				AppType = Configuration.AppType
			};
		}
		else
		{
			DbSet<SmsGSMModemSetting> smsGSMModemSetting2 = _dbTbl.SmsGSMModemSetting;
			ParameterExpression val = Expression.Parameter(typeof(SmsGSMModemSetting), "c");
			smsGSMModemSetting = Queryable.FirstOrDefault<SmsGSMModemSetting>((IQueryable<SmsGSMModemSetting>)smsGSMModemSetting2, Expression.Lambda<Func<SmsGSMModemSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		}
		SetRegisterInfo(smsGSMModemSetting);
		return View(smsGSMModemSetting);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsGSMSetting")]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(SmsGSMModemSetting model)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (base.ModelState.IsValid)
			{
				model.UserId = UserLogin.CurrentUser.UserId;
				model.RegisterDate = now;
				model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				model.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				model.AppType = Configuration.AppType;
				if (model.ID > 0)
				{
					_dbTbl.Entry(model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					model.GUId = Guid.NewGuid();
					model.LanguageID = result;
					model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					model.FirstRegisterDate = now;
					model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_dbTbl.SmsGSMModemSetting.Add(model);
					_dbTbl.SaveChanges();
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		SetRegisterInfo(model);
		return View(model);
	}

	public List<SmsspSelectGSMModemSetting_Result> ListGsmSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SmsspSelectGSMModemSetting_Result> list = new List<SmsspSelectGSMModemSetting_Result>();
		try
		{
			list = Enumerable.ToList<SmsspSelectGSMModemSetting_Result>((IEnumerable<SmsspSelectGSMModemSetting_Result>)_db.SmsspSelectGSMModemSetting());
			foreach (SmsspSelectGSMModemSetting_Result item in list)
			{
				item.RegisterDatePersian = ((item.RegisterDate.HasValue && lCID != 1065) ? item.RegisterDate.Value.ToString("yyyyMMdd") : item.RegisterDatePersian);
				item.FirstRegisterDatePersian = ((item.FirstRegisterDate.HasValue && lCID != 1065) ? item.FirstRegisterDate.Value.ToString("yyyyMMdd") : item.FirstRegisterDatePersian);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult GsmSetting_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListGsmSetting()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GsmSettingList()
	{
		return Json(ListGsmSetting(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string GsmSettingDelete(int gsmId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.gsmId = gsmId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass9_.gsmId > 0)
			{
				DbSet<SmsGSMModemSetting> smsGSMModemSetting = _dbTbl.SmsGSMModemSetting;
				ParameterExpression val = Expression.Parameter(typeof(SmsGSMModemSetting), "c");
				SmsGSMModemSetting smsGSMModemSetting2 = Queryable.FirstOrDefault<SmsGSMModemSetting>((IQueryable<SmsGSMModemSetting>)smsGSMModemSetting, Expression.Lambda<Func<SmsGSMModemSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (smsGSMModemSetting2 != null)
				{
					_dbTbl.SmsGSMModemSetting.Remove(smsGSMModemSetting2);
					_dbTbl.SaveChanges();
					DbSet<SmsGSMModemSetting> smsGSMModemSetting3 = _dbTbl.SmsGSMModemSetting;
					val = Expression.Parameter(typeof(SmsGSMModemSetting), "c");
					if (Queryable.Any<SmsGSMModemSetting>((IQueryable<SmsGSMModemSetting>)smsGSMModemSetting3, Expression.Lambda<Func<SmsGSMModemSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						result = Messages.frmErrorMessage;
					}
				}
				else
				{
					result = Messages.ErrorNotFound;
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
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
