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
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class OrderPaymentTypeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int ordPayTypeId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int ordPayTypeId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public WSOrderPaymentTypesLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__15;

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

		internal bool _003CInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public WSOrderPaymentTypes ordpayType;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 0)
	{
		base.ViewBag.Position = position;
		return View();
	}

	public List<WSspSelectOrderPaymentTypes_Result> ListOrderPaymentTypes()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderPaymentTypes_Result> list = new List<WSspSelectOrderPaymentTypes_Result>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			list = Enumerable.ToList<WSspSelectOrderPaymentTypes_Result>(Enumerable.Where<WSspSelectOrderPaymentTypes_Result>((IEnumerable<WSspSelectOrderPaymentTypes_Result>)_db.WSspSelectOrderPaymentTypes(lCID, result, value), (Func<WSspSelectOrderPaymentTypes_Result, bool>)((WSspSelectOrderPaymentTypes_Result m) => m.OrderPaymentTypeId > 0)));
			foreach (WSspSelectOrderPaymentTypes_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				item.ordPayTypePosPassword = ((!string.IsNullOrEmpty(item.ordPayTypePosPassword)) ? XorCipher.DecryptByPrivateKey(item.ordPayTypePosPassword) : null);
				int result2 = 0;
				int.TryParse(item.ordpayTypeKind.ToString(), out result2);
				switch (result2)
				{
				case 1:
					item.ordpayTypeKindTitle = Labels.lblCash;
					break;
				case 2:
					item.ordpayTypeKindTitle = Labels.lblChq;
					break;
				case 3:
					item.ordpayTypeKindTitle = Labels.lblDeposit;
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
	public ActionResult OrderPaymentTypes_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListOrderPaymentTypes()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListOrderPaymentTypes()
	{
		return Json(ListOrderPaymentTypes(), JsonRequestBehavior.AllowGet);
	}

	public ActionResult InsertEdit(int ordPayTypeId = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.ordPayTypeId = ordPayTypeId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSOrderPaymentTypesLanguageViewModel model = new WSOrderPaymentTypesLanguageViewModel();
		_ = DateTime.Now;
		GetTspPmt();
		GetOrdpayTypeKind();
		try
		{
			DbSet<WSOrderPaymentTypes_Lang> wSOrderPaymentTypes_Lang = _dbTbl.WSOrderPaymentTypes_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderPaymentTypes_Lang), "c");
			List<WSOrderPaymentTypes_Lang> list = Enumerable.ToList<WSOrderPaymentTypes_Lang>((IEnumerable<WSOrderPaymentTypes_Lang>)Queryable.Where<WSOrderPaymentTypes_Lang>((IQueryable<WSOrderPaymentTypes_Lang>)wSOrderPaymentTypes_Lang, Expression.Lambda<Func<WSOrderPaymentTypes_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			WSOrderPaymentTypes wSOrderPaymentTypes = new WSOrderPaymentTypes();
			bool value = false;
			if (CS_0024_003C_003E8__locals0.ordPayTypeId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				wSOrderPaymentTypes = new WSOrderPaymentTypes();
				wSOrderPaymentTypes.OrderPaymentTypeId = 0;
				value = true;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<WSOrderPaymentTypes> wSOrderPaymentTypes2 = _dbTbl.WSOrderPaymentTypes;
				val = Expression.Parameter(typeof(WSOrderPaymentTypes), "m");
				wSOrderPaymentTypes = Queryable.FirstOrDefault<WSOrderPaymentTypes>((IQueryable<WSOrderPaymentTypes>)wSOrderPaymentTypes2, Expression.Lambda<Func<WSOrderPaymentTypes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSOrderPaymentTypes == null)
				{
					wSOrderPaymentTypes = new WSOrderPaymentTypes();
					wSOrderPaymentTypes.OrderPaymentTypeId = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPaymentTypes_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPaymentTypes_Lang>)list, (Func<WSOrderPaymentTypes_Lang, CommonMultiLanguageViewModel>)((WSOrderPaymentTypes_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayType,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPaymentTypes.ordpayType,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderPaymentTypes_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderPaymentTypes_Lang>)list, (Func<WSOrderPaymentTypes_Lang, CommonMultiLanguageViewModel>)((WSOrderPaymentTypes_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ordpayTypeDescription,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSOrderPaymentTypes.ordpayTypeDescription,
				LanguageId = result
			});
			string ordpayTypePordFileTypeJsonByName = "";
			string ordpayTypeOrdFileTypeJsonByName = "";
			if (CS_0024_003C_003E8__locals0.ordPayTypeId != 0)
			{
				WSspSelectOrderPaymentTypesById_Result wSspSelectOrderPaymentTypesById_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesById_Result>((IEnumerable<WSspSelectOrderPaymentTypesById_Result>)_dbI.WSspSelectOrderPaymentTypesById(CS_0024_003C_003E8__locals0.ordPayTypeId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectOrderPaymentTypesById_Result != null)
				{
					ordpayTypePordFileTypeJsonByName = wSspSelectOrderPaymentTypesById_Result.ordpayTypePordFileTypeJsonByName ?? "";
					ordpayTypeOrdFileTypeJsonByName = wSspSelectOrderPaymentTypesById_Result.ordpayTypeOrdFileTypeJsonByName ?? "";
				}
			}
			model = new WSOrderPaymentTypesLanguageViewModel
			{
				OrderPaymentTypeId = wSOrderPaymentTypes.OrderPaymentTypeId,
				ordpayType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordpayType_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ordpayTypeDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ordpayTypeDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				OrderView = wSOrderPaymentTypes.OrderView,
				DeActive = wSOrderPaymentTypes.DeActive,
				ordpayTypeIsActivePayOnline = wSOrderPaymentTypes.ordpayTypeIsActivePayOnline,
				ordpayTypeIsActiveAddFile = wSOrderPaymentTypes.ordpayTypeIsActiveAddFile,
				ordpayTypePordFileTypeJson = wSOrderPaymentTypes.ordpayTypePordFileTypeJson,
				ordpayTypePordFileTypeJsonByName = ordpayTypePordFileTypeJsonByName,
				ordpayTypeOrdFileTypeJson = wSOrderPaymentTypes.ordpayTypeOrdFileTypeJson,
				ordpayTypeOrdFileTypeJsonByName = ordpayTypeOrdFileTypeJsonByName,
				ordpayTypeIsChq = wSOrderPaymentTypes.ordpayTypeIsChq,
				TspOrdpayTypePmt = wSOrderPaymentTypes.TspOrdpayTypePmt,
				TspOrdpayTypeIinn = wSOrderPaymentTypes.TspOrdpayTypeIinn,
				TspOrdpayTypeAcn = wSOrderPaymentTypes.TspOrdpayTypeAcn,
				TspOrdpayTypeTrmn = wSOrderPaymentTypes.TspOrdpayTypeTrmn,
				ordPayTypeIsPos = wSOrderPaymentTypes.ordPayTypeIsPos,
				ordPayTypePosTerminal = wSOrderPaymentTypes.ordPayTypePosTerminal,
				ordPayTypePosUserName = wSOrderPaymentTypes.ordPayTypePosUserName,
				ordPayTypePosPassword = ((!string.IsNullOrEmpty(wSOrderPaymentTypes.ordPayTypePosPassword)) ? XorCipher.DecryptByPrivateKey(wSOrderPaymentTypes.ordPayTypePosPassword) : null),
				ordPayTypePosURL = wSOrderPaymentTypes.ordPayTypePosURL,
				ordpayTypeBankingBankID = wSOrderPaymentTypes.ordpayTypeBankingBankID,
				ordpayTypeBankingBranchID = wSOrderPaymentTypes.ordpayTypeBankingBranchID,
				ordpayTypeBankingAccountID = wSOrderPaymentTypes.ordpayTypeBankingAccountID,
				ordpayTypeCashId = wSOrderPaymentTypes.ordpayTypeCashId,
				ordpayTypeGroupIdI = wSOrderPaymentTypes.ordpayTypeGroupIdI,
				ordpayTypeGroupIdII = wSOrderPaymentTypes.ordpayTypeGroupIdII,
				ordpayTypeKind = wSOrderPaymentTypes.ordpayTypeKind,
				ordpayTypeMode = wSOrderPaymentTypes.ordpayTypeMode,
				ordpayTypeUserAccessAll = value
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSOrderPaymentTypesLanguageViewModel model)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetTspPmt();
		GetOrdpayTypeKind();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ordpayType_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ordpayType_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordpayType,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ordpayTypeDescription_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ordpayTypeDescription_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ordpayTypeDescription,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.ordpayType))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.OrderPaymentTypeTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.ordpayType, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.OrderPaymentTypeTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
					_003C_003Ec__DisplayClass9_.ordpayType = new WSOrderPaymentTypes();
					if (CS_0024_003C_003E8__locals0.model.OrderPaymentTypeId > 0)
					{
						DbSet<WSOrderPaymentTypes> wSOrderPaymentTypes = _dbTbl.WSOrderPaymentTypes;
						ParameterExpression val = Expression.Parameter(typeof(WSOrderPaymentTypes), "m");
						_003C_003Ec__DisplayClass9_.ordpayType = Queryable.FirstOrDefault<WSOrderPaymentTypes>((IQueryable<WSOrderPaymentTypes>)wSOrderPaymentTypes, Expression.Lambda<Func<WSOrderPaymentTypes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime dateTime = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short num2 = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int id = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass9_.ordpayType.UserId = userId;
					_003C_003Ec__DisplayClass9_.ordpayType.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass9_.ordpayType.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass9_.ordpayType.Month1 = num2;
					_003C_003Ec__DisplayClass9_.ordpayType.FPId = id;
					_003C_003Ec__DisplayClass9_.ordpayType.AppType = appType;
					_003C_003Ec__DisplayClass9_.ordpayType.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
					_003C_003Ec__DisplayClass9_.ordpayType.DeActive = CS_0024_003C_003E8__locals0.model.DeActive;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeIsActivePayOnline = CS_0024_003C_003E8__locals0.model.ordpayTypeIsActivePayOnline;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeIsActiveAddFile = CS_0024_003C_003E8__locals0.model.ordpayTypeIsActiveAddFile;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypePordFileTypeJson = CS_0024_003C_003E8__locals0.model.ordpayTypePordFileTypeJson;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeOrdFileTypeJson = CS_0024_003C_003E8__locals0.model.ordpayTypeOrdFileTypeJson;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayType = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeKind = CS_0024_003C_003E8__locals0.model.ordpayTypeKind;
					if (_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeKind.GetValueOrDefault() == 2)
					{
						_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeIsChq = true;
					}
					else
					{
						_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeIsChq = false;
					}
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeMode = CS_0024_003C_003E8__locals0.model.ordpayTypeMode;
					_003C_003Ec__DisplayClass9_.ordpayType.TspOrdpayTypePmt = CS_0024_003C_003E8__locals0.model.TspOrdpayTypePmt;
					_003C_003Ec__DisplayClass9_.ordpayType.TspOrdpayTypeIinn = CS_0024_003C_003E8__locals0.model.TspOrdpayTypeIinn;
					_003C_003Ec__DisplayClass9_.ordpayType.TspOrdpayTypeAcn = CS_0024_003C_003E8__locals0.model.TspOrdpayTypeAcn;
					_003C_003Ec__DisplayClass9_.ordpayType.TspOrdpayTypeTrmn = CS_0024_003C_003E8__locals0.model.TspOrdpayTypeTrmn;
					_003C_003Ec__DisplayClass9_.ordpayType.ordPayTypeIsPos = CS_0024_003C_003E8__locals0.model.ordPayTypeIsPos;
					_003C_003Ec__DisplayClass9_.ordpayType.ordPayTypePosTerminal = CS_0024_003C_003E8__locals0.model.ordPayTypePosTerminal;
					_003C_003Ec__DisplayClass9_.ordpayType.ordPayTypePosUserName = CS_0024_003C_003E8__locals0.model.ordPayTypePosUserName;
					_003C_003Ec__DisplayClass9_.ordpayType.ordPayTypePosPassword = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ordPayTypePosPassword)) ? XorCipher.EncryptByPrivateKey(CS_0024_003C_003E8__locals0.model.ordPayTypePosPassword) : null);
					_003C_003Ec__DisplayClass9_.ordpayType.ordPayTypePosURL = CS_0024_003C_003E8__locals0.model.ordPayTypePosURL;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeBankingBankID = CS_0024_003C_003E8__locals0.model.ordpayTypeBankingBankID;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeBankingBranchID = CS_0024_003C_003E8__locals0.model.ordpayTypeBankingBranchID;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeBankingAccountID = CS_0024_003C_003E8__locals0.model.ordpayTypeBankingAccountID;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeCashId = CS_0024_003C_003E8__locals0.model.ordpayTypeCashId;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeGroupIdI = CS_0024_003C_003E8__locals0.model.ordpayTypeGroupIdI;
					_003C_003Ec__DisplayClass9_.ordpayType.ordpayTypeGroupIdII = CS_0024_003C_003E8__locals0.model.ordpayTypeGroupIdII;
					if (CS_0024_003C_003E8__locals0.model.OrderPaymentTypeId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass9_.ordpayType).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSOrderPaymentTypes_Lang> wSOrderPaymentTypes_Lang = _dbTbl.WSOrderPaymentTypes_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSOrderPaymentTypes_Lang), "c");
								WSOrderPaymentTypes_Lang wSOrderPaymentTypes_Lang2 = Queryable.FirstOrDefault<WSOrderPaymentTypes_Lang>((IQueryable<WSOrderPaymentTypes_Lang>)wSOrderPaymentTypes_Lang, Expression.Lambda<Func<WSOrderPaymentTypes_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSOrderPaymentTypes_Lang2 != null)
								{
									wSOrderPaymentTypes_Lang2.ordpayType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSOrderPaymentTypes_Lang2.ordpayTypeDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSOrderPaymentTypes_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSOrderPaymentTypes_Lang2 = new WSOrderPaymentTypes_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									OrderPaymentTypeId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.ordpayType.OrderPaymentTypeId,
									ordpayType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									ordpayTypeDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.WSOrderPaymentTypes_Lang.Add(wSOrderPaymentTypes_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderPaymentTypes");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass9_.ordpayType.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass9_.ordpayType.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass9_.ordpayType.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass9_.ordpayType.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass9_.ordpayType.GUId = Guid.NewGuid();
						_dbTbl.WSOrderPaymentTypes.Add(_003C_003Ec__DisplayClass9_.ordpayType);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass9_.ordpayType.OrderPaymentTypeId > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSOrderPaymentTypes_Lang entity = new WSOrderPaymentTypes_Lang
								{
									LanguageID = lang.LanguageID,
									OrderPaymentTypeId = _003C_003Ec__DisplayClass9_.ordpayType.OrderPaymentTypeId,
									ordpayType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									ordpayTypeDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.WSOrderPaymentTypes_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderPaymentTypes");
						string appType2 = Configuration.AppType;
						if (_003C_003Ec__DisplayClass9_.ordpayType.OrderPaymentTypeId > 0)
						{
							bool result = false;
							bool.TryParse(CS_0024_003C_003E8__locals0.model.ordpayTypeUserAccessAll.ToString(), out result);
							if (result)
							{
								_dbII.WSspInsertOrderPaymentTypeUserAccessToAllUsers(_003C_003Ec__DisplayClass9_.ordpayType.OrderPaymentTypeId, userId, id, num2, dateTime, registerDatePersian, appType2, CS_0024_003C_003E8__locals0.defLangID);
							}
							else
							{
								_dbII.WSspInsertOrderPaymentTypeUserAccess(userId.ToString(), _003C_003Ec__DisplayClass9_.ordpayType.OrderPaymentTypeId, userId, id, num2, dateTime, registerDatePersian, appType2, CS_0024_003C_003E8__locals0.defLangID);
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderPaymentTypeUserAccess");
						}
						CS_0024_003C_003E8__locals0.model.OrderPaymentTypeId = _003C_003Ec__DisplayClass9_.ordpayType.OrderPaymentTypeId;
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
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActDelete(int ordPayTypeId)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.ordPayTypeId = ordPayTypeId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass10_.ordPayTypeId > 0)
			{
				DbSet<WSOrderPaymentTypes> wSOrderPaymentTypes = _dbTbl.WSOrderPaymentTypes;
				ParameterExpression val = Expression.Parameter(typeof(WSOrderPaymentTypes), "m");
				if (Queryable.FirstOrDefault<WSOrderPaymentTypes>((IQueryable<WSOrderPaymentTypes>)wSOrderPaymentTypes, Expression.Lambda<Func<WSOrderPaymentTypes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.WSspDeleteWSOrderPaymentTypes(_003C_003Ec__DisplayClass10_.ordPayTypeId)).GetValueOrDefault() > 0)
						{
							DbSet<WSOrderPaymentTypes> wSOrderPaymentTypes2 = _dbTbl.WSOrderPaymentTypes;
							val = Expression.Parameter(typeof(WSOrderPaymentTypes), "m");
							if (Queryable.FirstOrDefault<WSOrderPaymentTypes>((IQueryable<WSOrderPaymentTypes>)wSOrderPaymentTypes2, Expression.Lambda<Func<WSOrderPaymentTypes, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
							{
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderPaymentTypes");
								return "1";
							}
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
			return Messages.frmErrorMessage;
		}
	}

	public ActionResult SelectFileTypes(int typeOprId, string frameName = "", string formName = "", string selectedFileTypeIds = "", bool canChangeIsIsRequired = false)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			base.ViewBag.TypeOprId = typeOprId;
			base.ViewBag.FrameName = frameName;
			base.ViewBag.FormName = formName;
			base.ViewBag.SelectedFileTypeIds = selectedFileTypeIds;
			base.ViewBag.CanChangeIsIsRequired = canChangeIsIsRequired;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetFileTypes(int typeOprId = 0)
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
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectFileDirectoryTypeByOprId_Result> list2 = Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)_db.CRMspSelectFileDirectoryTypeByOprId(typeOprId, lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)list2))
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectFileDirectoryTypeByOprId_Result, SelectListItem>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)list2, (Func<CRMspSelectFileDirectoryTypeByOprId_Result, SelectListItem>)((CRMspSelectFileDirectoryTypeByOprId_Result item) => new SelectListItem
				{
					Text = (item.FileDirectoryType ?? ""),
					Value = item.FileDirectoryTypeID.ToString()
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetTspSetm()
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
				Text = Labels.TspSetmI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspSetmII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspSetmIII,
				Value = "3",
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
		base.ViewBag.TspSetmList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTspPmt()
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
				Text = Labels.TspPmtI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtIII,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtIV,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtV,
				Value = "5",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtVI,
				Value = "6",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtVII,
				Value = "7",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.TspPmtVIII,
				Value = "8",
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
		base.ViewBag.TspPmtList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBankingBankLists()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectBankingBanks_Result> list2 = Enumerable.ToList<CRMspSelectBankingBanks_Result>((IEnumerable<CRMspSelectBankingBanks_Result>)_dbI.CRMspSelectBankingBanks(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingBanks_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBanks_Result>)list2, (Func<CRMspSelectBankingBanks_Result, SelectListItem>)((CRMspSelectBankingBanks_Result item) => new SelectListItem
			{
				Text = (item.BankName ?? ""),
				Value = item.BankingBankID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetBankingBrancheLists(int bankId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (bankId != 0)
			{
				List<CRMspSelectBankingBranches_Result> list2 = Enumerable.ToList<CRMspSelectBankingBranches_Result>((IEnumerable<CRMspSelectBankingBranches_Result>)_dbI.CRMspSelectBankingBranches(bankId, lCID, result));
				SelectListItem item2 = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = ""
				};
				list.Add(item2);
				list.AddRange(Enumerable.Select<CRMspSelectBankingBranches_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBranches_Result>)list2, (Func<CRMspSelectBankingBranches_Result, SelectListItem>)((CRMspSelectBankingBranches_Result item) => new SelectListItem
				{
					Text = (item.BranchName ?? ""),
					Value = item.BankingBranchID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetBankingAccountLists(int branchId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (branchId != 0)
			{
				List<CRMspSelectBankingAccountsByBranchAndUserId_Result> list2 = Enumerable.ToList<CRMspSelectBankingAccountsByBranchAndUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByBranchAndUserId_Result>)_dbII.CRMspSelectBankingAccountsByBranchAndUserId(branchId, 0, lCID, result));
				SelectListItem item2 = new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = ""
				};
				list.Add(item2);
				list.AddRange(Enumerable.Select<CRMspSelectBankingAccountsByBranchAndUserId_Result, SelectListItem>((IEnumerable<CRMspSelectBankingAccountsByBranchAndUserId_Result>)list2, (Func<CRMspSelectBankingAccountsByBranchAndUserId_Result, SelectListItem>)((CRMspSelectBankingAccountsByBranchAndUserId_Result item) => new SelectListItem
				{
					Text = (item.AccountTitle ?? ""),
					Value = item.BankingAccountID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetCashLists()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectCashes_Result> list2 = Enumerable.ToList<CRMspSelectCashes_Result>((IEnumerable<CRMspSelectCashes_Result>)_dbII.CRMspSelectCashes(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectCashes_Result, SelectListItem>((IEnumerable<CRMspSelectCashes_Result>)list2, (Func<CRMspSelectCashes_Result, SelectListItem>)((CRMspSelectCashes_Result item) => new SelectListItem
			{
				Text = (item.CashTitle ?? ""),
				Value = item.CashId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetOrderPaymentGroupsILists()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderPaymentGroupsI_Result> list2 = Enumerable.ToList<WSspSelectOrderPaymentGroupsI_Result>((IEnumerable<WSspSelectOrderPaymentGroupsI_Result>)_dbII.WSspSelectOrderPaymentGroupsI(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectOrderPaymentGroupsI_Result, SelectListItem>((IEnumerable<WSspSelectOrderPaymentGroupsI_Result>)list2, (Func<WSspSelectOrderPaymentGroupsI_Result, SelectListItem>)((WSspSelectOrderPaymentGroupsI_Result item) => new SelectListItem
			{
				Text = (item.ordpayGroupIName ?? ""),
				Value = item.OrderPaymentGroupIId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetOrderPaymentGroupsIILists()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderPaymentGroupsII_Result> list2 = Enumerable.ToList<WSspSelectOrderPaymentGroupsII_Result>((IEnumerable<WSspSelectOrderPaymentGroupsII_Result>)_dbII.WSspSelectOrderPaymentGroupsII(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectOrderPaymentGroupsII_Result, SelectListItem>((IEnumerable<WSspSelectOrderPaymentGroupsII_Result>)list2, (Func<WSspSelectOrderPaymentGroupsII_Result, SelectListItem>)((WSspSelectOrderPaymentGroupsII_Result item) => new SelectListItem
			{
				Text = (item.ordpayGroupIIName ?? ""),
				Value = item.OrderPaymentGroupIIId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetOrdpayTypeKind()
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
				Text = Labels.lblCash,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblChq,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.lblDeposit,
				Value = "3",
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
		base.ViewBag.OrdpayTypeKindList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
