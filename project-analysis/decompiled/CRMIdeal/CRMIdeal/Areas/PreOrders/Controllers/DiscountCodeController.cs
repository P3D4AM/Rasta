using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class DiscountCodeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int discountCodeId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public WSDiscountCodeLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__6;

		public Func<Languages, bool> _003C_003E9__12;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public WSDiscountCode model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int discountCodeId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineDiscountCode")]
	public ActionResult Index(int dicountCodeId = 0)
	{
		base.ViewBag.SelectedDicountCodeId = dicountCodeId;
		return View();
	}

	[AjaxOnly]
	public ActionResult DiscountCode_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<WSspSelectDiscountCode_Result> list = new List<WSspSelectDiscountCode_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectDiscountCode_Result>((IEnumerable<WSspSelectDiscountCode_Result>)_db.WSspSelectDiscountCode(lCID, result));
			foreach (WSspSelectDiscountCode_Result item in list)
			{
				_ = item.DisExpDate;
				item.DisExpDatePersian = item.DisExpDate.ToString("yyyy/MM/dd");
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

	public void SetDisCodeRegisterInfo(WSDiscountCodeLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.LName)) ? cRMspSelectUsersById_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FName)) ? (" " + cRMspSelectUsersById_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.LName)) ? cRMspSelectUsersById_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.FName)) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmDefineDiscountCode", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int discountCodeId = 0, int? cmpId = 0, int mode = 0)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.discountCodeId = discountCodeId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		if (cmpId == 0)
		{
			cmpId = null;
		}
		WSDiscountCodeLanguageViewModel wSDiscountCodeLanguageViewModel = new WSDiscountCodeLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.discountCodeId > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineDiscountCode", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSDiscountCode_Lang> wSDiscountCode_Lang = _dbTbl.WSDiscountCode_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSDiscountCode_Lang), "c");
			List<WSDiscountCode_Lang> list = Enumerable.ToList<WSDiscountCode_Lang>((IEnumerable<WSDiscountCode_Lang>)Queryable.Where<WSDiscountCode_Lang>((IQueryable<WSDiscountCode_Lang>)wSDiscountCode_Lang, Expression.Lambda<Func<WSDiscountCode_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSDiscountCode> wSDiscountCode = _dbTbl.WSDiscountCode;
			val = Expression.Parameter(typeof(WSDiscountCode), "c");
			WSDiscountCode wSDiscountCode2 = Queryable.FirstOrDefault<WSDiscountCode>((IQueryable<WSDiscountCode>)wSDiscountCode, Expression.Lambda<Func<WSDiscountCode, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSDiscountCode2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDiscountCode_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDiscountCode_Lang>)list, (Func<WSDiscountCode_Lang, CommonMultiLanguageViewModel>)((WSDiscountCode_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.DisTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDiscountCode2.DisTitle,
				LanguageId = result
			});
			WSDiscountCodeLanguageViewModel obj = new WSDiscountCodeLanguageViewModel
			{
				DiscountCodeId = wSDiscountCode2.DiscountCodeId,
				DisTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				DisTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				DisCode = wSDiscountCode2.DisCode,
				DisAmount = wSDiscountCode2.DisAmount.GetValueOrDefault(),
				DisAmountPercent = wSDiscountCode2.DisAmountPercent.GetValueOrDefault(),
				DisExpDate = wSDiscountCode2.DisExpDate
			};
			_ = wSDiscountCode2.DisExpDate;
			obj.DisExpDatePersian = wSDiscountCode2.DisExpDate.ToString("yyyy/MM/dd");
			obj.DisCmpId = wSDiscountCode2.DisCmpId.GetValueOrDefault();
			obj.DisPrdId = wSDiscountCode2.DisPrdId.GetValueOrDefault();
			obj.DisUseCnt = wSDiscountCode2.DisUseCnt;
			obj.FirstRegisterUserId = wSDiscountCode2.FirstRegisterUserId;
			obj.FirstRegisterDate = wSDiscountCode2.FirstRegisterDate;
			obj.FirstRegisterDatePersian = wSDiscountCode2.FirstRegisterDatePersian;
			obj.UserId = wSDiscountCode2.UserId;
			obj.FPId = wSDiscountCode2.FPId;
			obj.Month1 = wSDiscountCode2.Month1;
			obj.RegisterDate = wSDiscountCode2.RegisterDate;
			obj.RegisterDatePersian = wSDiscountCode2.RegisterDatePersian;
			obj.GUId = wSDiscountCode2.GUId;
			obj.AppType = wSDiscountCode2.AppType;
			obj.LanguageID = wSDiscountCode2.LanguageID;
			obj.Mode = mode;
			obj.ScoreRate = wSDiscountCode2.ScoreRate;
			obj.DisCanChangeToScore = wSDiscountCode2.DisCanChangeToScore;
			obj.DisUseCntPerCmp = wSDiscountCode2.DisUseCntPerCmp;
			wSDiscountCodeLanguageViewModel = obj;
			if (wSDiscountCodeLanguageViewModel.DisCmpId.HasValue)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSDiscountCodeLanguageViewModel.DisCmpId.GetValueOrDefault());
				if (companyById != null)
				{
					wSDiscountCodeLanguageViewModel.DisCmpName = companyById.CompanyName ?? "";
				}
			}
			if (wSDiscountCodeLanguageViewModel.DisPrdId.HasValue)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSDiscountCodeLanguageViewModel.DisPrdId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					wSDiscountCodeLanguageViewModel.DisPrdName = wSspSelectProductsWithId_Result.PrdName ?? "";
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineDiscountCode", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wSDiscountCodeLanguageViewModel = new WSDiscountCodeLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				FPId = int.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = Configuration.AppType,
				LanguageID = result,
				DisExpDate = now,
				DisExpDatePersian = now.ToString("yyyy/MM/dd"),
				DisUseCnt = 1,
				DisCmpId = cmpId,
				Mode = mode
			};
			base.ViewBag.IsBuying = VersionBuyer.DiscountCode;
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetDisCodeRegisterInfo(wSDiscountCodeLanguageViewModel, ref firstRegInfo, ref regInfo);
		wSDiscountCodeLanguageViewModel.FirstRegisterUser = firstRegInfo;
		wSDiscountCodeLanguageViewModel.EditUser = regInfo;
		return View(wSDiscountCodeLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineDiscountCodeDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSDiscountCodeLanguageViewModel vm)
	{
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			if (CS_0024_003C_003E8__locals0.vm.DiscountCodeId <= 0 && !VersionBuyer.DiscountCode)
			{
				DbSet<WSDiscountCode> wSDiscountCode = _dbTbl.WSDiscountCode;
				ParameterExpression val = Expression.Parameter(typeof(WSDiscountCode), "c");
				if (Queryable.Any<WSDiscountCode>((IQueryable<WSDiscountCode>)wSDiscountCode, Expression.Lambda<Func<WSDiscountCode, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DisTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DisTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.DisTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DisTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.DisCodeTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.DisTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.DisCodeTitle) + "<br>";
				num++;
			}
			try
			{
				if (num == 0)
				{
					if (!base.ModelState.IsValid)
					{
						base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					else
					{
						_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
						_003C_003Ec__DisplayClass8_.model = new WSDiscountCode();
						if (CS_0024_003C_003E8__locals0.vm.DiscountCodeId > 0)
						{
							DbSet<WSDiscountCode> wSDiscountCode2 = _dbTbl.WSDiscountCode;
							ParameterExpression val = Expression.Parameter(typeof(WSDiscountCode), "c");
							_003C_003Ec__DisplayClass8_.model = Queryable.FirstOrDefault<WSDiscountCode>((IQueryable<WSDiscountCode>)wSDiscountCode2, Expression.Lambda<Func<WSDiscountCode, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						_003C_003Ec__DisplayClass8_.model.UserId = UserLogin.CurrentUser.UserId;
						DateTime now = DateTime.Now;
						_003C_003Ec__DisplayClass8_.model.RegisterDate = now;
						_003C_003Ec__DisplayClass8_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass8_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass8_.model.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass8_.model.DisTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_003C_003Ec__DisplayClass8_.model.DisTitle = CS_0024_003C_003E8__locals0.vm.DisTitle;
						_003C_003Ec__DisplayClass8_.model.DisCode = CS_0024_003C_003E8__locals0.vm.DisCode;
						_003C_003Ec__DisplayClass8_.model.DisAmount = CS_0024_003C_003E8__locals0.vm.DisAmount;
						_003C_003Ec__DisplayClass8_.model.DisAmountPercent = CS_0024_003C_003E8__locals0.vm.DisAmountPercent;
						_003C_003Ec__DisplayClass8_.model.ScoreRate = CS_0024_003C_003E8__locals0.vm.ScoreRate;
						_003C_003Ec__DisplayClass8_.model.DisCanChangeToScore = CS_0024_003C_003E8__locals0.vm.DisCanChangeToScore;
						_003C_003Ec__DisplayClass8_.model.DisUseCntPerCmp = CS_0024_003C_003E8__locals0.vm.DisUseCntPerCmp;
						DateTime dateTime = default(DateTime);
						string text2 = "";
						try
						{
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DisExpDatePersian))
							{
								text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.DisExpDatePersian.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
									_003C_003Ec__DisplayClass8_.model.DisExpDatePersian = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
									_003C_003Ec__DisplayClass8_.model.DisExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
									_003C_003Ec__DisplayClass8_.model.DisExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								CS_0024_003C_003E8__locals0.vm.DisExpDate = dateTime;
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							base.ViewBag.Error = Messages.WrongDateTime;
							return View(CS_0024_003C_003E8__locals0.vm);
						}
						if (_003C_003Ec__DisplayClass8_.model.DisExpDatePersian != null)
						{
							_003C_003Ec__DisplayClass8_.model.DisExpDatePersian = _003C_003Ec__DisplayClass8_.model.DisExpDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						_003C_003Ec__DisplayClass8_.model.DisExpDate = CS_0024_003C_003E8__locals0.vm.DisExpDate;
						if (CS_0024_003C_003E8__locals0.vm.DisCmpId > 0)
						{
							_003C_003Ec__DisplayClass8_.model.DisCmpId = CS_0024_003C_003E8__locals0.vm.DisCmpId;
						}
						else
						{
							_003C_003Ec__DisplayClass8_.model.DisCmpId = null;
						}
						if (CS_0024_003C_003E8__locals0.vm.DisPrdId > 0)
						{
							_003C_003Ec__DisplayClass8_.model.DisPrdId = CS_0024_003C_003E8__locals0.vm.DisPrdId;
						}
						else
						{
							_003C_003Ec__DisplayClass8_.model.DisPrdId = null;
						}
						_003C_003Ec__DisplayClass8_.model.DisUseCnt = CS_0024_003C_003E8__locals0.vm.DisUseCnt;
						if (_003C_003Ec__DisplayClass8_.model.DiscountCodeId > 0)
						{
							if (Enumerable.FirstOrDefault<WSspCheckDuplicateDiscountCode_Result>((IEnumerable<WSspCheckDuplicateDiscountCode_Result>)_db.WSspCheckDuplicateDiscountCode(_003C_003Ec__DisplayClass8_.model.DiscountCodeId, _003C_003Ec__DisplayClass8_.model.DisCode, lCID, CS_0024_003C_003E8__locals0.defLangID)) != null)
							{
								base.ViewBag.Error = Messages.msgErrorDupDisCode;
								return View(CS_0024_003C_003E8__locals0.vm);
							}
							_dbTbl.Entry(_003C_003Ec__DisplayClass8_.model).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass8_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<WSDiscountCode_Lang> wSDiscountCode_Lang = _dbTbl.WSDiscountCode_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSDiscountCode_Lang), "c");
									WSDiscountCode_Lang wSDiscountCode_Lang2 = Queryable.FirstOrDefault<WSDiscountCode_Lang>((IQueryable<WSDiscountCode_Lang>)wSDiscountCode_Lang, Expression.Lambda<Func<WSDiscountCode_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSDiscountCode_Lang2 != null)
									{
										wSDiscountCode_Lang2.DisTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSDiscountCode_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSDiscountCode_Lang2 = new WSDiscountCode_Lang();
									wSDiscountCode_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									wSDiscountCode_Lang2.DiscountCodeId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DiscountCodeId;
									wSDiscountCode_Lang2.DisTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.WSDiscountCode_Lang.Add(wSDiscountCode_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountCode");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							_003C_003Ec__DisplayClass8_.model.FPId = int.Parse(Financial.Get().Id.ToString());
							if (Enumerable.FirstOrDefault<WSspCheckDuplicateDiscountCode_Result>((IEnumerable<WSspCheckDuplicateDiscountCode_Result>)_db.WSspCheckDuplicateDiscountCode(0, _003C_003Ec__DisplayClass8_.model.DisCode, lCID, CS_0024_003C_003E8__locals0.defLangID)) != null)
							{
								base.ViewBag.Error = Messages.msgErrorDupDisCode;
								return View(CS_0024_003C_003E8__locals0.vm);
							}
							_003C_003Ec__DisplayClass8_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass8_.model.FirstRegisterDate = now;
							_003C_003Ec__DisplayClass8_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass8_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							_003C_003Ec__DisplayClass8_.model.GUId = Guid.NewGuid();
							_dbTbl.WSDiscountCode.Add(_003C_003Ec__DisplayClass8_.model);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSDiscountCode_Lang wSDiscountCode_Lang3 = new WSDiscountCode_Lang();
								wSDiscountCode_Lang3.LanguageID = lang.LanguageID;
								wSDiscountCode_Lang3.DiscountCodeId = _003C_003Ec__DisplayClass8_.model.DiscountCodeId;
								wSDiscountCode_Lang3.DisTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								_dbTbl.WSDiscountCode_Lang.Add(wSDiscountCode_Lang3);
								_dbTbl.SaveChanges();
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountCode");
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						CS_0024_003C_003E8__locals0.vm.DiscountCodeId = _003C_003Ec__DisplayClass8_.model.DiscountCodeId;
						CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass8_.model.UserId;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass8_.model.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass8_.model.RegisterDate;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass8_.model.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass8_.model.AppType;
						string firstRegInfo = "";
						string regInfo = "";
						SetDisCodeRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
						CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
						if (CS_0024_003C_003E8__locals0.vm.DisCmpId.HasValue)
						{
							CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals0.vm.DisCmpId.GetValueOrDefault());
							if (companyById != null)
							{
								CS_0024_003C_003E8__locals0.vm.DisCmpName = companyById.CompanyName ?? "";
							}
						}
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
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineDiscountCode", ActionName = "actDelete")]
	public string Delete(int discountCodeId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.discountCodeId = discountCodeId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass9_.discountCodeId > 0)
			{
				DbSet<WSDiscountCode> wSDiscountCode = _dbTbl.WSDiscountCode;
				ParameterExpression val = Expression.Parameter(typeof(WSDiscountCode), "m");
				if (Queryable.FirstOrDefault<WSDiscountCode>((IQueryable<WSDiscountCode>)wSDiscountCode, Expression.Lambda<Func<WSDiscountCode, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteDiscountCode(_003C_003Ec__DisplayClass9_.discountCodeId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDiscountCode");
							result = "";
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						result = Messages.msgErrorRunFunction;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult SearchCompany(string value = "")
	{
		List<CRMspMainSearchWeb_Result> data = new List<CRMspMainSearchWeb_Result>();
		try
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
			data = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(value, UserLogin.CurrentUser.UserId, 4, lCID, result, "", result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSetDiscountCode")]
	public ActionResult SetDiscountCodeForCompany(int cmpId)
	{
		base.ViewBag.CompanyId = cmpId;
		return View();
	}

	[AjaxOnly]
	public ActionResult SetDiscountCodeForCompany_Read([DataSourceRequest] DataSourceRequest request, int cmpId)
	{
		List<WSspSelectDiscountCodeWithCmpId_Result> list = new List<WSspSelectDiscountCodeWithCmpId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectDiscountCodeWithCmpId_Result>((IEnumerable<WSspSelectDiscountCodeWithCmpId_Result>)_db.WSspSelectDiscountCodeWithCmpId(cmpId, lCID, result));
			foreach (WSspSelectDiscountCodeWithCmpId_Result item in list)
			{
				_ = item.DisExpDate;
				item.DisExpDatePersian = item.DisExpDate.ToString("yyyy/MM/dd");
				item.FirstRegisterUser = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
				item.EditUser = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text2 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(item.AppType);
				WSspSelectDiscountCodeWithCmpId_Result wSspSelectDiscountCodeWithCmpId_Result = item;
				wSspSelectDiscountCodeWithCmpId_Result.EditUser = wSspSelectDiscountCodeWithCmpId_Result.EditUser + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
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
	public ActionResult SetDiscountCodeHistoryForCompany_Read([DataSourceRequest] DataSourceRequest request, int cmpId)
	{
		List<WSspSelectDiscountCodeHistoryWithCmpId_Result> list = new List<WSspSelectDiscountCodeHistoryWithCmpId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectDiscountCodeHistoryWithCmpId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithCmpId_Result>)_db.WSspSelectDiscountCodeHistoryWithCmpId(cmpId, lCID, result));
			foreach (WSspSelectDiscountCodeHistoryWithCmpId_Result item in list)
			{
				_ = item.FirstRegisterDate;
				item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
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

	[DynamicAuthorize(ControllerName = "frmCompanyReport", ActionName = "actSetDiscountCode")]
	public ActionResult SetDiscountCodeFromCmpRpt()
	{
		return View();
	}

	[HttpPost]
	public JsonResult ActSetDiscountCodeFromCmpRpt(string param)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			if (!string.IsNullOrWhiteSpace(param))
			{
				WSDiscountCodeLanguageViewModel wSDiscountCodeLanguageViewModel = new JavaScriptSerializer().Deserialize<WSDiscountCodeLanguageViewModel>(param);
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
				if (defLangID <= 0)
				{
					defLangID = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				now.AddSeconds(-7.0);
				_ = Messages.FOTicketErjaShow;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				now.ToString("HH:mm:ss");
				int id = Financial.Get().Id;
				string text3 = "";
				int num = 0;
				if (!UserLogin.IsUserAccess("frmCompanyReport", "actSetDiscountCode", UserLogin.CurrentUser))
				{
					text3 = text3 + Messages.ErrorNotAccess + "<br>";
					num++;
				}
				if (!VersionBuyer.DiscountCode)
				{
					text3 = text3 + Messages.VersionBuyWithoutCount + "<br>";
					num++;
				}
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(wSDiscountCodeLanguageViewModel.DisTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(wSDiscountCodeLanguageViewModel.DisTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = wSDiscountCodeLanguageViewModel.DisTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(wSDiscountCodeLanguageViewModel.DisTitle))
				{
					text3 = text3 + string.Format(Messages.ErrorEmpty, Labels.SetDiscountCodeFromCmpRptDisCodeTitle) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(wSDiscountCodeLanguageViewModel.DisTitle, list))
				{
					text3 = text3 + string.Format(Messages.CheckFieldInLang, Labels.SetDiscountCodeFromCmpRptDisCodeTitle) + "<br>";
					num++;
				}
				DateTime dateTime = default(DateTime);
				string text4 = "";
				try
				{
					if (!string.IsNullOrWhiteSpace(wSDiscountCodeLanguageViewModel.DisExpDatePersian))
					{
						text4 = PersianDate.GetFormatetdDate(wSDiscountCodeLanguageViewModel.DisExpDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text4 + " 00:00:00", new PersianCulture());
							wSDiscountCodeLanguageViewModel.DisExpDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text4 + " 00:00:00", new CultureInfo("ar-SA"));
							wSDiscountCodeLanguageViewModel.DisExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text4 + " 00:00:00", new CultureInfo("en-US"));
							wSDiscountCodeLanguageViewModel.DisExpDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						wSDiscountCodeLanguageViewModel.DisExpDate = dateTime;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text3 = text3 + string.Format(Messages.ErrorInFormat, Labels.SetDiscountCodeFromCmpRptExpDatePersian) + "<br>";
					num++;
				}
				if (wSDiscountCodeLanguageViewModel.DisExpDatePersian != null)
				{
					wSDiscountCodeLanguageViewModel.DisExpDatePersian = wSDiscountCodeLanguageViewModel.DisExpDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				if (num == 0)
				{
					if (list != null)
					{
						wSDiscountCodeLanguageViewModel.DisTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						wSDiscountCodeLanguageViewModel.DisTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
					}
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					text = "";
					_dbII.CRMspSetCompanyDiscountCodeFromRptFilterData(wSDiscountCodeLanguageViewModel.DisTitle, wSDiscountCodeLanguageViewModel.DisTitle_Lang, wSDiscountCodeLanguageViewModel.DisCode, wSDiscountCodeLanguageViewModel.DisAmount, wSDiscountCodeLanguageViewModel.DisAmountPercent, wSDiscountCodeLanguageViewModel.DisExpDate, wSDiscountCodeLanguageViewModel.DisExpDatePersian, wSDiscountCodeLanguageViewModel.DisPrdId, wSDiscountCodeLanguageViewModel.DisUseCnt, wSDiscountCodeLanguageViewModel.ScoreRate, userId, value, registerDatePersian, id, value2, appType, lCID, defLangID, objectParameter);
					string text5 = "";
					if (objectParameter.Value != null)
					{
						text5 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text5))
						{
							text5 = Messages.msgErrorRunFunction;
						}
					}
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text = "";
						text2 = text5;
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
					else
					{
						text = "";
						text2 = Messages.msgSuccessAction;
						commonResultStatusViewModel = CommonResultStatusViewModel.Success;
					}
				}
				else
				{
					text = "";
					text2 = text3;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				text = "";
				text2 = Messages.ErrorNotFound;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetDiscountCodeHistory(int disCodeId = 0, int lastRowId = 0, int pageSize = 100)
	{
		string result = "";
		try
		{
			if (disCodeId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspSelectDiscountCodeHistory_Result> list = Enumerable.ToList<WSspSelectDiscountCodeHistory_Result>((IEnumerable<WSspSelectDiscountCodeHistory_Result>)_dbII.WSspSelectDiscountCodeHistory(disCodeId, lCID, result2, lastRowId, pageSize));
				if (list != null)
				{
					foreach (WSspSelectDiscountCodeHistory_Result item in list)
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					}
					result = JsonConvert.SerializeObject(list);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
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
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
