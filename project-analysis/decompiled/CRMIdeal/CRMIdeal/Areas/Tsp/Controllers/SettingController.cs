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
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.Classes.Helper.Tsp;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Tsp.Controllers;

public class SettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int tspSettingId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public TspSettingLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__21;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public TspSetting tspSetting;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		int result = 1;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.TspPrdSendMethod.ToString(), out result);
		}
		base.ViewBag.TspPrdSendMethod = result;
		return View();
	}

	public List<TSPspSelectSetting_Result> ListTspSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TSPspSelectSetting_Result> list = new List<TSPspSelectSetting_Result>();
		try
		{
			list = Enumerable.ToList<TSPspSelectSetting_Result>((IEnumerable<TSPspSelectSetting_Result>)_dbI.TSPspSelectSetting(lCID, result));
			foreach (TSPspSelectSetting_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				int result2 = 0;
				int.TryParse(item.TspTob.ToString(), out result2);
				switch (result2)
				{
				case 1:
					item.AppType = Labels.cmpTspCmpTobI;
					break;
				case 2:
					item.AppType = Labels.cmpTspCmpTobII;
					break;
				case 3:
					item.AppType = Labels.cmpTspCmpTobIII;
					break;
				case 4:
					item.AppType = Labels.cmpTspCmpTobIV;
					break;
				case 5:
					item.AppType = Labels.cmpTspCmpTobV;
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult TspSetting_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListTspSetting()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListTspSetting()
	{
		return Json(ListTspSetting(), JsonRequestBehavior.AllowGet);
	}

	public ActionResult InsertEdit(int tspSettingId = 0)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.tspSettingId = tspSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		TspSettingLanguageViewModel tspSettingLanguageViewModel = new TspSettingLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			GetTspTob();
			base.ViewBag.CountriesListJs = GetCountryJs();
			if (!UserLogin.IsUserAccess("frmMain", "actSetting", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<TspSetting_Lang> tspSetting_Lang = _dbTbl.TspSetting_Lang;
			ParameterExpression val = Expression.Parameter(typeof(TspSetting_Lang), "c");
			List<TspSetting_Lang> list = Enumerable.ToList<TspSetting_Lang>((IEnumerable<TspSetting_Lang>)Queryable.Where<TspSetting_Lang>((IQueryable<TspSetting_Lang>)tspSetting_Lang, Expression.Lambda<Func<TspSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			TspSetting tspSetting = new TspSetting();
			if (CS_0024_003C_003E8__locals0.tspSettingId == 0)
			{
				tspSetting = new TspSetting();
				tspSetting.TspSettingId = 0;
			}
			else
			{
				DbSet<TspSetting> tspSetting2 = _dbTbl.TspSetting;
				val = Expression.Parameter(typeof(TspSetting), "m");
				tspSetting = Queryable.FirstOrDefault<TspSetting>((IQueryable<TspSetting>)tspSetting2, Expression.Lambda<Func<TspSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (tspSetting == null)
				{
					tspSetting = new TspSetting();
					tspSetting.TspSettingId = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<TspSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<TspSetting_Lang>)list, (Func<TspSetting_Lang, CommonMultiLanguageViewModel>)((TspSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TspSettingTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = tspSetting.TspSettingTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<TspSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<TspSetting_Lang>)list, (Func<TspSetting_Lang, CommonMultiLanguageViewModel>)((TspSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TspCoName,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = tspSetting.TspCoName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<TspSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<TspSetting_Lang>)list, (Func<TspSetting_Lang, CommonMultiLanguageViewModel>)((TspSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.TspAddress,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = tspSetting.TspAddress,
				LanguageId = result
			});
			tspSettingLanguageViewModel = new TspSettingLanguageViewModel
			{
				TspSettingId = tspSetting.TspSettingId,
				TspSettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				TspSettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				TspIdentify = tspSetting.TspIdentify,
				TspPrivateKey = tspSetting.TspPrivateKey,
				TspSbc = tspSetting.TspSbc,
				TspScln = tspSetting.TspScln,
				TspScc = tspSetting.TspScc,
				TspCrn = tspSetting.TspCrn,
				TspBsrn = tspSetting.TspBsrn,
				TspTob = tspSetting.TspTob,
				TspRegistrationNumber = tspSetting.TspRegistrationNumber,
				TspEconomicCode = tspSetting.TspEconomicCode,
				TspNationalCode = tspSetting.TspNationalCode,
				TspTel = tspSetting.TspTel,
				TspCityId = tspSetting.TspCityId,
				TspZipCode = tspSetting.TspZipCode,
				TspCoName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				TspCoName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				TspAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				TspAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				TspSendDateType = tspSetting.TspSendDateType,
				TspSendPay = tspSetting.TspSendPay
			};
			if (tspSettingLanguageViewModel != null)
			{
				int result2 = 0;
				int.TryParse(tspSettingLanguageViewModel.TspCityId.ToString(), out result2);
				if (result2 != 0)
				{
					CRMspSelectCountryProvinceCityByCityId_Result cRMspSelectCountryProvinceCityByCityId_Result = Enumerable.FirstOrDefault<CRMspSelectCountryProvinceCityByCityId_Result>((IEnumerable<CRMspSelectCountryProvinceCityByCityId_Result>)_dbI.CRMspSelectCountryProvinceCityByCityId(result2, CS_0024_003C_003E8__locals0.currLangID, result));
					if (cRMspSelectCountryProvinceCityByCityId_Result != null)
					{
						tspSettingLanguageViewModel.TspCountryId = cRMspSelectCountryProvinceCityByCityId_Result.CountryId;
						tspSettingLanguageViewModel.TspProvinceId = cRMspSelectCountryProvinceCityByCityId_Result.ProvinceId;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(tspSettingLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult InsertEdit(TspSettingLanguageViewModel model)
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetTspTob();
		base.ViewBag.CountriesListJs = GetCountryJs();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TspSettingTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.TspSettingTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.TspSettingTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TspCoName_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.TspCoName_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.TspCoName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.TspAddress_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.TspAddress_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.TspAddress,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.model.TspSettingId == 0)
			{
				List<TSPspSelectSetting_Result> list4 = ListTspSetting();
				if (list4 != null && Enumerable.Any<TSPspSelectSetting_Result>((IEnumerable<TSPspSelectSetting_Result>)list4) && list4.Count >= 1)
				{
					text = text + Messages.msgErrorNotsaveMoreTahnOneTspSetting + "<br/>";
					num++;
				}
			}
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.TspSettingTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.TspSettingTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.TspSettingTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.TspSettingTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
					_003C_003Ec__DisplayClass8_.tspSetting = new TspSetting();
					if (CS_0024_003C_003E8__locals0.model.TspSettingId > 0)
					{
						DbSet<TspSetting> tspSetting = _dbTbl.TspSetting;
						ParameterExpression val = Expression.Parameter(typeof(TspSetting), "m");
						_003C_003Ec__DisplayClass8_.tspSetting = Queryable.FirstOrDefault<TspSetting>((IQueryable<TspSetting>)tspSetting, Expression.Lambda<Func<TspSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime dateTime = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now2.ToString("MM", new PersianCulture()));
					short year = short.Parse(Financial.Get().Id.ToString());
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass8_.tspSetting.UserId = userId;
					_003C_003Ec__DisplayClass8_.tspSetting.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass8_.tspSetting.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass8_.tspSetting.Month1 = month;
					_003C_003Ec__DisplayClass8_.tspSetting.Year1 = year;
					_003C_003Ec__DisplayClass8_.tspSetting.AppType = appType;
					_003C_003Ec__DisplayClass8_.tspSetting.TspSettingTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass8_.tspSetting.TspIdentify = CS_0024_003C_003E8__locals0.model.TspIdentify;
					_003C_003Ec__DisplayClass8_.tspSetting.TspPrivateKey = CS_0024_003C_003E8__locals0.model.TspPrivateKey;
					_003C_003Ec__DisplayClass8_.tspSetting.TspSbc = CS_0024_003C_003E8__locals0.model.TspSbc;
					_003C_003Ec__DisplayClass8_.tspSetting.TspScln = CS_0024_003C_003E8__locals0.model.TspScln;
					_003C_003Ec__DisplayClass8_.tspSetting.TspScc = CS_0024_003C_003E8__locals0.model.TspScc;
					_003C_003Ec__DisplayClass8_.tspSetting.TspCrn = CS_0024_003C_003E8__locals0.model.TspCrn;
					_003C_003Ec__DisplayClass8_.tspSetting.TspBsrn = CS_0024_003C_003E8__locals0.model.TspBsrn;
					_003C_003Ec__DisplayClass8_.tspSetting.TspTob = CS_0024_003C_003E8__locals0.model.TspTob;
					_003C_003Ec__DisplayClass8_.tspSetting.TspCoName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass8_.tspSetting.TspRegistrationNumber = CS_0024_003C_003E8__locals0.model.TspRegistrationNumber;
					_003C_003Ec__DisplayClass8_.tspSetting.TspEconomicCode = CS_0024_003C_003E8__locals0.model.TspEconomicCode;
					_003C_003Ec__DisplayClass8_.tspSetting.TspNationalCode = CS_0024_003C_003E8__locals0.model.TspNationalCode;
					_003C_003Ec__DisplayClass8_.tspSetting.TspTel = CS_0024_003C_003E8__locals0.model.TspTel;
					_003C_003Ec__DisplayClass8_.tspSetting.TspCityId = CS_0024_003C_003E8__locals0.model.TspCityId;
					_003C_003Ec__DisplayClass8_.tspSetting.TspAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass8_.tspSetting.TspZipCode = CS_0024_003C_003E8__locals0.model.TspZipCode;
					_003C_003Ec__DisplayClass8_.tspSetting.TspSendDateType = CS_0024_003C_003E8__locals0.model.TspSendDateType;
					_003C_003Ec__DisplayClass8_.tspSetting.TspSendPay = CS_0024_003C_003E8__locals0.model.TspSendPay;
					if (CS_0024_003C_003E8__locals0.model.TspSettingId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass8_.tspSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass8_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<TspSetting_Lang> tspSetting_Lang = _dbTbl.TspSetting_Lang;
								ParameterExpression val = Expression.Parameter(typeof(TspSetting_Lang), "c");
								TspSetting_Lang tspSetting_Lang2 = Queryable.FirstOrDefault<TspSetting_Lang>((IQueryable<TspSetting_Lang>)tspSetting_Lang, Expression.Lambda<Func<TspSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (tspSetting_Lang2 != null)
								{
									tspSetting_Lang2.TspSettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									tspSetting_Lang2.TspCoName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									tspSetting_Lang2.TspAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(tspSetting_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								tspSetting_Lang2 = new TspSetting_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									TspSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.tspSetting.TspSettingId,
									TspSettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									TspCoName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									TspAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.TspSetting_Lang.Add(tspSetting_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("TspSetting");
						_dbI.TSPspUpdateOrderSettingId(0, CS_0024_003C_003E8__locals0.model.TspSettingId, userId, dateTime, registerDatePersian, appType);
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass8_.tspSetting.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass8_.tspSetting.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass8_.tspSetting.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass8_.tspSetting.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass8_.tspSetting.GUId = Guid.NewGuid();
						_dbTbl.TspSetting.Add(_003C_003Ec__DisplayClass8_.tspSetting);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass8_.tspSetting.TspSettingId > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								TspSetting_Lang entity = new TspSetting_Lang
								{
									LanguageID = lang.LanguageID,
									TspSettingId = _003C_003Ec__DisplayClass8_.tspSetting.TspSettingId,
									TspSettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.TspSetting_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
							_dbI.TSPspUpdateOrderSettingId(0, _003C_003Ec__DisplayClass8_.tspSetting.TspSettingId, userId, dateTime, registerDatePersian, appType);
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
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
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public string ActDelete(int tspSettingId)
	{
		string text = "";
		try
		{
			if (tspSettingId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.TSPspDeleteSetting(tspSettingId));
					int result = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result);
					}
					if (result == 1)
					{
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.msgErrorRunFunction;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string ActUpdateTspPrdSendMethod(int tspPrdSendMethod)
	{
		string text = "";
		try
		{
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting != null)
			{
				DateTime now = DateTime.Now;
				crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
				crmsysSetting.RegisterDate = now;
				crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmsysSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				crmsysSetting.AppType = Configuration.AppType;
				crmsysSetting.TspPrdSendMethod = ((tspPrdSendMethod != 0) ? new int?(tspPrdSendMethod) : null);
				_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				if (!SysSeting.Update())
				{
					return Messages.ErrorInCacheUpdate;
				}
				return "1";
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public JsonResult GetTspTob()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobIII,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobIV,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobV,
				Value = "5",
				Selected = false
			});
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspTobList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCountryJs()
	{
		return JsonConvert.SerializeObject(Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCountry_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCountry_Result>)Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID)), (Func<CRMspSelectCountry_Result, CrmDroupDownItem>)((CRMspSelectCountry_Result country) => new CrmDroupDownItem
		{
			text = country.Country,
			value = country.CountryID.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProvinceJs(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCompanyProvince_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCompanyProvince_Result>)Enumerable.ToList<CRMspSelectCompanyProvince_Result>((IEnumerable<CRMspSelectCompanyProvince_Result>)_db.CRMspSelectCompanyProvince(UserLogin.CurrentUser.UserId, id, lCID, result, result2)), (Func<CRMspSelectCompanyProvince_Result, CrmDroupDownItem>)((CRMspSelectCompanyProvince_Result province) => new CrmDroupDownItem
		{
			text = province.Province,
			value = province.ProvinceID.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCityJs(int id)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCompanyCity_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCompanyCity_Result>)Enumerable.ToList<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)_db.CRMspSelectCompanyCity(UserLogin.CurrentUser.UserId, id, lCID, result, result2)), (Func<CRMspSelectCompanyCity_Result, CrmDroupDownItem>)((CRMspSelectCompanyCity_Result city) => new CrmDroupDownItem
		{
			text = city.City,
			value = city.CityID.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string SearchCityJs(string val = "")
	{
		List<CRMspSearchCity_Result> value = new List<CRMspSearchCity_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			_ = Configuration.AppType;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSearchCity_Result> list = Enumerable.ToList<CRMspSearchCity_Result>((IEnumerable<CRMspSearchCity_Result>)_db.CRMspSearchCity(userId, val, 0, lCID, result, result2));
			if (list != null)
			{
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[AjaxOnly]
	public JsonResult TestToken(int tspSettingId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			CommonResultViewModel<int> commonResultViewModel = TspTax.TestToken(tspSettingId);
			if (commonResultViewModel != null)
			{
				data2 = commonResultViewModel;
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			text = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
