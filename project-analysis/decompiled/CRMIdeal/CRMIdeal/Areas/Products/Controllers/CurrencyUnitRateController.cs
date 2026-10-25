using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Products.Controllers;

public class CurrencyUnitRateController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int currUnitRateId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public WSCurrencyUnitRateViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int currUnitRateId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineCurrencyUnitRate")]
	public ActionResult Index()
	{
		GetCurrencyUnits();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int currUnitRateId = 0)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.currUnitRateId = currUnitRateId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSCurrencyUnitRateViewModel wSCurrencyUnitRateViewModel = new WSCurrencyUnitRateViewModel();
		if (_003C_003Ec__DisplayClass3_.currUnitRateId > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSCurrencyUnitRate> wSCurrencyUnitRate = _dbTbl.WSCurrencyUnitRate;
			ParameterExpression val = Expression.Parameter(typeof(WSCurrencyUnitRate), "c");
			WSCurrencyUnitRate wSCurrencyUnitRate2 = Queryable.FirstOrDefault<WSCurrencyUnitRate>((IQueryable<WSCurrencyUnitRate>)wSCurrencyUnitRate, Expression.Lambda<Func<WSCurrencyUnitRate, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass3_, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSCurrencyUnitRate2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			WSCurrencyUnitRateViewModel obj = new WSCurrencyUnitRateViewModel
			{
				CurrencyUnitRateId = wSCurrencyUnitRate2.CurrencyUnitRateId,
				SrcCurrencyUnitId = wSCurrencyUnitRate2.SrcCurrencyUnitId,
				DestCurrencyUnitId = wSCurrencyUnitRate2.DestCurrencyUnitId,
				CurrencyRate = wSCurrencyUnitRate2.CurrencyRate
			};
			_ = wSCurrencyUnitRate2.RateDate;
			obj.RateDatePersian = wSCurrencyUnitRate2.RateDate.ToString("yyyy/MM/dd");
			wSCurrencyUnitRateViewModel = obj;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wSCurrencyUnitRateViewModel = new WSCurrencyUnitRateViewModel
			{
				RateDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
			};
		}
		GetCurrencyUnits();
		return View(wSCurrencyUnitRateViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSCurrencyUnitRateViewModel vm)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetCurrencyUnits();
		if (base.ModelState.IsValid)
		{
			try
			{
				DateTime dateTime = default(DateTime);
				string text2 = "";
				string text3 = _003C_003Ec__DisplayClass4_.vm.RateDatePersian;
				DateTime rateDate = default(DateTime);
				try
				{
					if (!string.IsNullOrEmpty(text3))
					{
						text2 = PersianDate.GetFormatetdDate(text3.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							text3 = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							text3 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							text3 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						rateDate = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return View(_003C_003Ec__DisplayClass4_.vm);
				}
				if (text3 != null)
				{
					text3 = text3.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				if (num == 0)
				{
					if (!base.ModelState.IsValid)
					{
						base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					else
					{
						WSCurrencyUnitRate wSCurrencyUnitRate = new WSCurrencyUnitRate();
						if (_003C_003Ec__DisplayClass4_.vm.CurrencyUnitRateId > 0)
						{
							DbSet<WSCurrencyUnitRate> wSCurrencyUnitRate2 = _dbTbl.WSCurrencyUnitRate;
							ParameterExpression val = Expression.Parameter(typeof(WSCurrencyUnitRate), "c");
							wSCurrencyUnitRate = Queryable.FirstOrDefault<WSCurrencyUnitRate>((IQueryable<WSCurrencyUnitRate>)wSCurrencyUnitRate2, Expression.Lambda<Func<WSCurrencyUnitRate, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						wSCurrencyUnitRate.UserId = UserLogin.CurrentUser.UserId;
						DateTime firstRegisterDate = (wSCurrencyUnitRate.RegisterDate = DateTime.Now);
						wSCurrencyUnitRate.RegisterDatePersian = firstRegisterDate.ToString("yyyyMMdd", new PersianCulture());
						wSCurrencyUnitRate.Month1 = short.Parse(firstRegisterDate.ToString("MM", new PersianCulture()));
						wSCurrencyUnitRate.AppType = Configuration.AppType;
						wSCurrencyUnitRate.FPId = Financial.Get().Id;
						wSCurrencyUnitRate.SrcCurrencyUnitId = _003C_003Ec__DisplayClass4_.vm.SrcCurrencyUnitId;
						wSCurrencyUnitRate.DestCurrencyUnitId = _003C_003Ec__DisplayClass4_.vm.DestCurrencyUnitId;
						wSCurrencyUnitRate.CurrencyRate = _003C_003Ec__DisplayClass4_.vm.CurrencyRate;
						wSCurrencyUnitRate.RateDatePersian = text3;
						wSCurrencyUnitRate.RateDate = rateDate;
						if (wSCurrencyUnitRate.CurrencyUnitRateId > 0)
						{
							_dbTbl.Entry(wSCurrencyUnitRate).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCurrencyUnitRate");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							wSCurrencyUnitRate.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							wSCurrencyUnitRate.FirstRegisterDate = firstRegisterDate;
							wSCurrencyUnitRate.FirstRegisterDatePersian = firstRegisterDate.ToString("yyyyMMdd", new PersianCulture());
							wSCurrencyUnitRate.LanguageID = result;
							wSCurrencyUnitRate.GUId = Guid.NewGuid();
							_dbTbl.WSCurrencyUnitRate.Add(wSCurrencyUnitRate);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCurrencyUnitRate");
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						_003C_003Ec__DisplayClass4_.vm.CurrencyUnitRateId = wSCurrencyUnitRate.CurrencyUnitRateId;
					}
				}
			}
			catch (DbEntityValidationException e2)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
				text = Messages.msgErrorRunFunction;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				text = Messages.msgErrorRunFunction + "<br/>" + ex.Message;
			}
		}
		base.ViewBag.Error = text;
		return View(_003C_003Ec__DisplayClass4_.vm);
	}

	[AjaxOnly]
	public JsonResult GetCurrencyUnits()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = (item.CurrencyUnit ?? ""),
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SrcCurrencyUnitList = list;
		base.ViewBag.DestCurrencyUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult CurrencyUnitRate_Read([DataSourceRequest] DataSourceRequest request, int currencyUnitId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCurrencyUnitRate_Result> list = new List<WSspSelectCurrencyUnitRate_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectCurrencyUnitRate_Result>((IEnumerable<WSspSelectCurrencyUnitRate_Result>)_db.WSspSelectCurrencyUnitRate(currencyUnitId, lCID, result));
			foreach (WSspSelectCurrencyUnitRate_Result item in list)
			{
				_ = item.RateDate;
				item.RateDatePersian = item.RateDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser += ((!string.IsNullOrEmpty(item.FirstRegisterDatePersian)) ? (" (" + item.FirstRegisterDatePersian + ")") : "");
				_ = item.RegisterDate;
				item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Labels.AppType + ": " + Configuration.GetAppType(item.AppType);
				item.EditUser = item.EditUser + " (" + item.AppType + ")" + ((!string.IsNullOrEmpty(item.RegisterDatePersian)) ? (" (" + item.RegisterDatePersian + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string CurrencyUnitRateDelete(int currUnitRateId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.currUnitRateId = currUnitRateId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass7_.currUnitRateId > 0)
			{
				DbSet<WSCurrencyUnitRate> wSCurrencyUnitRate = _dbTbl.WSCurrencyUnitRate;
				ParameterExpression val = Expression.Parameter(typeof(WSCurrencyUnitRate), "m");
				if (Queryable.FirstOrDefault<WSCurrencyUnitRate>((IQueryable<WSCurrencyUnitRate>)wSCurrencyUnitRate, Expression.Lambda<Func<WSCurrencyUnitRate, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCurrencyUnitRate(_003C_003Ec__DisplayClass7_.currUnitRateId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCurrencyUnitRate");
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
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.msgErrorRunFunction;
		}
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
		base.Dispose(disposing);
	}
}
