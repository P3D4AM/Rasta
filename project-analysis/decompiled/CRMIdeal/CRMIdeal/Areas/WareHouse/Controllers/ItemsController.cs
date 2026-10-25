using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class ItemsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public int detailId;

		public int currLangID;

		internal bool _003CAddProductItemI_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public WSDocItems docItem;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public int prdId;

		public int currLangID;

		internal bool _003CGetAllProductInfo_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetAllProductInfo_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int detailId;

		public int currLangID;

		internal bool _003CIndex_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CIndex_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CIndex_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public WSDocItems docItem;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int itemId;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__17;

		internal bool _003CAddProductItem_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public WSDocItems docItem;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1;

		internal bool _003CAddProductItem_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public const string ItemImportExcel_EXCEL_SHEET_NAME = "KaraAfzarIdeal";

	public ActionResult Index(string masterForm, string mode, int position, int masterId = 0, int detailId = 0, int whId = 0, int prdId = 0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.detailId = detailId;
		string text = "";
		string text2 = "";
		string text3 = "";
		switch (position)
		{
		case 1:
			text = "frmDoc";
			text2 = "actInsertDocItem";
			text3 = "frmDocItemDataEntry";
			break;
		case 2:
			text = "frmDoc";
			text2 = "actEditDocItem";
			text3 = "frmDocItemDataEntry";
			break;
		case 3:
			text = "frmDraft";
			text2 = "actInsertDraftItem";
			text3 = "frmDraftItemDataEntry";
			break;
		case 4:
			text = "frmDraft";
			text2 = "actEditDraftItem";
			text3 = "frmDraftItemDataEntry";
			break;
		case 5:
			text = "frmWareHouseMovement";
			text2 = "actInsertDocItem";
			text3 = "frmWareHouseMovementItemDataEntry";
			break;
		case 6:
			text = "frmWareHouseMovement";
			text2 = "actEditDocItem";
			text3 = "frmWareHouseMovementItemDataEntry";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text4 = "";
		AddProductViewModel addProductViewModel = new AddProductViewModel();
		string text5 = "";
		string text6 = "";
		string text7 = "";
		if (CS_0024_003C_003E8__locals0.detailId > 0 && masterId > 0)
		{
			_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
			DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
			ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "c");
			_003C_003Ec__DisplayClass4_.docItem = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (_003C_003Ec__DisplayClass4_.docItem != null)
			{
				DbSet<WSDocItems_Lang> wSDocItems_Lang = _dbTbl.WSDocItems_Lang;
				val = Expression.Parameter(typeof(WSDocItems_Lang), "c");
				List<WSDocItems_Lang> list = Enumerable.ToList<WSDocItems_Lang>((IEnumerable<WSDocItems_Lang>)Queryable.Where<WSDocItems_Lang>((IQueryable<WSDocItems_Lang>)wSDocItems_Lang, Expression.Lambda<Func<WSDocItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDocItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDocItems_Lang>)list, (Func<WSDocItems_Lang, CommonMultiLanguageViewModel>)((WSDocItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass4_.docItem.Description,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDocItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDocItems_Lang>)list, (Func<WSDocItems_Lang, CommonMultiLanguageViewModel>)((WSDocItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PrdNickname,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass4_.docItem.PrdNickname,
					LanguageId = result
				});
				text4 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				addProductViewModel.Tracing = _003C_003Ec__DisplayClass4_.docItem.Tracing;
				_ = DateTime.Now;
				addProductViewModel.UserId = _003C_003Ec__DisplayClass4_.docItem.UserId;
				addProductViewModel.RegisterDate = _003C_003Ec__DisplayClass4_.docItem.RegisterDate;
				addProductViewModel.AppType = _003C_003Ec__DisplayClass4_.docItem.AppType;
				addProductViewModel.FirstRegisterUserId = _003C_003Ec__DisplayClass4_.docItem.FirstRegisterUserId;
				addProductViewModel.FirstRegisterDate = _003C_003Ec__DisplayClass4_.docItem.FirstRegisterDate;
				addProductViewModel.PrdUnitId = _003C_003Ec__DisplayClass4_.docItem.PrdUnitId;
				addProductViewModel.ItemPrdWeight = _003C_003Ec__DisplayClass4_.docItem.PrdWeight;
				text5 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				text6 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				text7 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			}
		}
		else
		{
			DateTime now = DateTime.Now;
			addProductViewModel.UserId = UserLogin.CurrentUser.UserId;
			addProductViewModel.RegisterDate = now;
			addProductViewModel.AppType = Configuration.AppType;
			addProductViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			addProductViewModel.FirstRegisterDate = now;
		}
		base.ViewBag.DescriptionLang = text4;
		base.ViewBag.PrdNicknameLang = text5;
		base.ViewBag.PrdNickname = text6;
		base.ViewBag.Description = text7;
		base.ViewBag.PrdId = prdId;
		base.ViewBag.Mode = mode;
		base.ViewBag.MasterId = masterId;
		base.ViewBag.MasterForm = masterForm;
		base.ViewBag.DetailId = CS_0024_003C_003E8__locals0.detailId;
		base.ViewBag.FormName = text3;
		base.ViewBag.WhId = whId;
		base.ViewBag.ModeInsertEdit = ((CS_0024_003C_003E8__locals0.detailId > 0) ? "Edit" : "Insert");
		base.ViewBag.ItemPrdWeight = addProductViewModel.ItemPrdWeight.ToString() ?? "";
		SetRegisterInfo(addProductViewModel);
		GetPrdUnits();
		return View();
	}

	[AjaxOnly]
	public string AddProductItem(string masterForm, int masterId, int prdId, double quantity, string description, string descriptionLang, int itemId, int whId, double? fcr, double? fcrI, string tracing, int quantityRemain = 0, bool autoGenerateSerial = false, bool addLinkedPrd = false, int? prdUnitId = 0, double? quantityTotal = 0.0, int? prdUnitIdI = 0, double? prdUnitIRateResult = 0.0, string prdNickname = "", string prdNicknameLang = "", double? itemPrdWeight = null, int? prdUnitIdII = 0, double? prdUnitIIRateResult = 0.0)
	{
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		string result = "";
		string text = "";
		switch (masterForm)
		{
		case "Doc":
			text = "frmDocItemDataEntry";
			break;
		case "Draft":
			text = "frmDraftItemDataEntry";
			break;
		case "WareHouseMovement":
			text = "frmWareHouseMovementItemDataEntry";
			break;
		default:
			return "0|" + Messages.ErrorNotAccess;
		}
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess(text, "actPost", currentUser))
		{
			return "0|" + Messages.ErrorNotAccess;
		}
		string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		switch (masterForm.ToLower())
		{
		case "doc":
			if (Doc.IsSentToLinkAccByAction(masterId))
			{
				return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			break;
		case "draft":
			if (Draft.IsSentToLinkAccByAction(masterId))
			{
				return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			break;
		case "warehousemovement":
			if (WareHouseMovement.IsSentToLinkAccByAction(masterId))
			{
				return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			break;
		}
		if (prdId == 0)
		{
			return "0|" + Messages.msgErrorNotSelectProduct;
		}
		if (quantity == 0.0)
		{
			return "0|" + Messages.msgErrorNotSelectPrdQuantity;
		}
		tracing = ConvertCharacter.DecodeTracing(tracing);
		bool result2 = false;
		WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, CS_0024_003C_003E8__locals0.defLangID));
		if (wSspSelectProductsWithId_Result != null)
		{
			bool.TryParse(wSspSelectProductsWithId_Result.PrdMustFullTracingCode.ToString(), out result2);
		}
		bool flag = false;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			flag = cRMspSelectCrmsysSetting_Result.MustFullTracingCode.HasValue && cRMspSelectCrmsysSetting_Result.MustFullTracingCode != false;
		}
		if (flag)
		{
			if (string.IsNullOrWhiteSpace(tracing))
			{
				return "0|" + string.Format(Messages.msgErrorIsNotSpecified, Labels.prdTracing);
			}
		}
		else if (result2 && string.IsNullOrWhiteSpace(tracing))
		{
			return "0|" + string.Format(Messages.msgErrorIsNotSpecified, Labels.prdTracing);
		}
		if (masterForm == "Doc" && !string.IsNullOrWhiteSpace(tracing))
		{
			int value = prdId;
			if (UserLogin.IsUserAccess("frmDocItemDataEntry", "actLoadTracingCodeFromAllPrd", UserLogin.CurrentUser))
			{
				value = 0;
			}
			if (UserLogin.IsUserAccess("frmDocItemDataEntry", "actCanNotAddNewTracingCode", UserLogin.CurrentUser) && Enumerable.FirstOrDefault<WSspSelectDocItemTracing_Result>((IEnumerable<WSspSelectDocItemTracing_Result>)_dbI.WSspSelectDocItemTracing(tracing, value)) == null)
			{
				return "0|" + string.Format(Messages.msgErrorCanNotAddNewTracingCode, tracing);
			}
		}
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(descriptionLang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(descriptionLang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = description,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(prdNicknameLang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(prdNicknameLang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = prdNickname,
				LanguageId = lCID
			});
			_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
			switch (masterForm)
			{
			case "Draft":
			case "Doc":
			case "WareHouseMovement":
			{
				switch (masterForm)
				{
				case "Doc":
					if (Doc.IsFixed(masterId))
					{
						return "0|" + Messages.msgErrorNotActiveDoc;
					}
					break;
				case "Draft":
					if (Draft.IsFixed(masterId))
					{
						return "0|" + Messages.msgErrorNotActiveDraft;
					}
					break;
				case "WareHouseMovement":
					if (Draft.IsFixed(masterId))
					{
						return "0|" + Messages.msgErrorNotActiveWareHouseMovement;
					}
					break;
				}
				WSDocItems docItem;
				if (CS_0024_003C_003E8__locals0.itemId <= 0)
				{
					docItem = new WSDocItems();
				}
				else
				{
					DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
					ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "c");
					docItem = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass5_.docItem = docItem;
				_003C_003Ec__DisplayClass5_.docItem.PrdId = prdId;
				_003C_003Ec__DisplayClass5_.docItem.DocId = masterId;
				_003C_003Ec__DisplayClass5_.docItem.Quantity = quantity;
				_003C_003Ec__DisplayClass5_.docItem.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass5_.docItem.PrdWeight = itemPrdWeight;
				bool flag2 = false;
				if (CS_0024_003C_003E8__locals0.itemId > 0)
				{
					if (UserLogin.IsUserAccess(text, "actCanChangePrdNickname", currentUser))
					{
						_003C_003Ec__DisplayClass5_.docItem.PrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						flag2 = true;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass5_.docItem.PrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					flag2 = true;
				}
				_003C_003Ec__DisplayClass5_.docItem.WHId = whId;
				_003C_003Ec__DisplayClass5_.docItem.UserId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass5_.docItem.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass5_.docItem.UserId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass5_.docItem.FCR = fcr;
				_003C_003Ec__DisplayClass5_.docItem.FCRI = fcrI;
				_003C_003Ec__DisplayClass5_.docItem.PrdUnitId = ((prdUnitId == 0) ? null : prdUnitId);
				_003C_003Ec__DisplayClass5_.docItem.QuantityTotal = ((quantityTotal == 0.0) ? null : quantityTotal);
				_003C_003Ec__DisplayClass5_.docItem.PrdUnitIdI = ((prdUnitIdI == 0) ? null : prdUnitIdI);
				_003C_003Ec__DisplayClass5_.docItem.PrdUnitIRateResult = ((prdUnitIRateResult == 0.0) ? null : prdUnitIRateResult);
				_003C_003Ec__DisplayClass5_.docItem.PrdUnitIdII = ((prdUnitIdII == 0) ? null : prdUnitIdII);
				_003C_003Ec__DisplayClass5_.docItem.PrdUnitIIRateResult = ((prdUnitIIRateResult == 0.0) ? null : prdUnitIIRateResult);
				if (masterForm == "Doc")
				{
					if (CanUpdateDocItemTracing(_003C_003Ec__DisplayClass5_.docItem.WHId, _003C_003Ec__DisplayClass5_.docItem.PrdId, _003C_003Ec__DisplayClass5_.docItem.Tracing) == 1)
					{
						_003C_003Ec__DisplayClass5_.docItem.Tracing = ((!string.IsNullOrWhiteSpace(tracing)) ? tracing : null);
					}
				}
				else
				{
					_003C_003Ec__DisplayClass5_.docItem.Tracing = ((!string.IsNullOrWhiteSpace(tracing)) ? tracing : null);
				}
				if (CS_0024_003C_003E8__locals0.itemId > 0)
				{
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass5_.docItem.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass5_.docItem.RegisterDate = now;
					_003C_003Ec__DisplayClass5_.docItem.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_dbTbl.Entry(_003C_003Ec__DisplayClass5_.docItem).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass5_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSDocItems_Lang> wSDocItems_Lang = _dbTbl.WSDocItems_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSDocItems_Lang), "c");
							WSDocItems_Lang wSDocItems_Lang2 = Queryable.FirstOrDefault<WSDocItems_Lang>((IQueryable<WSDocItems_Lang>)wSDocItems_Lang, Expression.Lambda<Func<WSDocItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDocItems_Lang2 != null)
							{
								wSDocItems_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								if (flag2)
								{
									wSDocItems_Lang2.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								}
								_dbTbl.Entry(wSDocItems_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSDocItems_Lang2 = new WSDocItems_Lang();
							wSDocItems_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSDocItems_Lang2.DocItemID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.docItem.DocItemID;
							wSDocItems_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							if (flag2)
							{
								wSDocItems_Lang2.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							}
							_dbTbl.WSDocItems_Lang.Add(wSDocItems_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					result = "1|" + Messages.frmFormBaseEditSuccessFulMessage;
					break;
				}
				_003C_003Ec__DisplayClass5_.docItem.FPId = Financial.Get().Id;
				DateTime now2 = DateTime.Now;
				_003C_003Ec__DisplayClass5_.docItem.Month1 = short.Parse(now2.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass5_.docItem.RegisterDate = now2;
				_003C_003Ec__DisplayClass5_.docItem.RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass5_.docItem.GUId = Guid.NewGuid();
				_003C_003Ec__DisplayClass5_.docItem.FirstRegisterDate = now2;
				_003C_003Ec__DisplayClass5_.docItem.FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass5_.docItem.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass5_.docItem.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
				_003C_003Ec__DisplayClass5_.docItem.DocICId = Doc.GetDocCId(_003C_003Ec__DisplayClass5_.docItem.DocId);
				_dbTbl.WSDocItems.Add(_003C_003Ec__DisplayClass5_.docItem);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
				{
					WSDocItems_Lang wSDocItems_Lang3 = new WSDocItems_Lang();
					wSDocItems_Lang3.LanguageID = lang.LanguageID;
					wSDocItems_Lang3.DocItemID = _003C_003Ec__DisplayClass5_.docItem.DocItemID;
					wSDocItems_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					if (flag2)
					{
						wSDocItems_Lang3.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					}
					_dbTbl.WSDocItems_Lang.Add(wSDocItems_Lang3);
					_dbTbl.SaveChanges();
				}
				int result3 = 0;
				int.TryParse(_003C_003Ec__DisplayClass5_.docItem.DocItemID.ToString(), out result3);
				if (addLinkedPrd && result3 > 0)
				{
					DateTime now3 = DateTime.Now;
					string registerDatePersian = now3.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now3.ToString("MM", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id = Financial.Get().Id;
					string appType = Configuration.AppType;
					string prdStockTxt = Labels.PrdStockTxt;
					WSspInsertDocItemFromLinkedPrd_Result wSspInsertDocItemFromLinkedPrd_Result = Enumerable.FirstOrDefault<WSspInsertDocItemFromLinkedPrd_Result>((IEnumerable<WSspInsertDocItemFromLinkedPrd_Result>)_dbI.WSspInsertDocItemFromLinkedPrd(prdId, masterId, whId, userId, id, value2, now3, registerDatePersian, appType, lCID, CS_0024_003C_003E8__locals0.defLangID, prdStockTxt, centerId));
					if (wSspInsertDocItemFromLinkedPrd_Result != null)
					{
						int result4 = 0;
						int.TryParse(wSspInsertDocItemFromLinkedPrd_Result.Result.ToString(), out result4);
						if (result4 != 1)
						{
							return "0|" + Messages.msgErrorInAddLinkedPrd;
						}
						if (!string.IsNullOrWhiteSpace(wSspInsertDocItemFromLinkedPrd_Result.ErrorMessage))
						{
							string[] array = wSspInsertDocItemFromLinkedPrd_Result.ErrorMessage.Split(new char[1] { '|' });
							if (array != null)
							{
								string text2 = "";
								string[] array2 = array;
								foreach (string text3 in array2)
								{
									if (!string.IsNullOrWhiteSpace(text3))
									{
										text2 = text2 + text3 + "<br>";
									}
								}
								if (!string.IsNullOrWhiteSpace(text2))
								{
									return "2|" + result3 + "|" + Messages.frmFormBaseInsertSuccessFulMessage + "<br>" + Messages.msgErrorNotAddedLinkedPrdWithoutStockToDocItem + "<br>" + text2 + "<br>" + Messages.msgAddPrdWithMinStockInDoc;
								}
							}
						}
					}
				}
				result = ((_003C_003Ec__DisplayClass5_.docItem.DocItemID > 0) ? ("1|" + Messages.frmFormBaseInsertSuccessFulMessage) : ("0|" + Messages.frmErrorMessage));
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "0|" + Messages.msgErrorRunFunction;
		}
		return result;
	}

	public string CheckDuplicateProduct(string masterForm, int masterId, int prdId, int currentId)
	{
		string text = "0";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			switch (masterForm)
			{
			case "Draft":
			case "WhDraft":
			case "Doc":
			case "WhDoc":
			case "WareHouseMovement":
			case "WhMovement":
			{
				ObjectResult<WSspCheckDuplicateDocItemPrd_Result> objectResult = _db.WSspCheckDuplicateDocItemPrd(masterId, prdId, currentId, lCID, result);
				return (objectResult != null && Enumerable.Any<WSspCheckDuplicateDocItemPrd_Result>((IEnumerable<WSspCheckDuplicateDocItemPrd_Result>)objectResult)) ? "1" : "0";
			}
			default:
				return "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1";
		}
	}

	public void SetRegisterInfo(AddProductViewModel model)
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
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				AddProductViewModel addProductViewModel = model;
				_ = model.UserId;
				addProductViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[AjaxOnly]
	public ActionResult _PartialPrdTree(int mode, int cmpId, int prjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<WSspProductsTree_Result> list2 = Enumerable.ToList<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)_db.WSspProductsTree(mode, lCID, result, 1, 0, cmpId, prjId));
			foreach (WSspProductsTree_Result item in Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == 0))))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FId + "|" + item.SId + "|" + item.PrdId));
				treeViewItemModel.Id = item.FId + "|" + item.SId + "|" + item.PrdId;
				treeViewItemModel.Text = item.KEYName;
				treeViewItemModel.ImageUrl = "";
				List<WSspProductsTree_Result> list3 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == item.FId)));
				List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
				foreach (WSspProductsTree_Result itemIn in list3)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId));
					treeViewItemModel2.Id = itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId;
					treeViewItemModel2.Text = itemIn.KEYName;
					treeViewItemModel2.ImageUrl = "";
					int.Parse("100" + itemIn.SId);
					List<WSspProductsTree_Result> list5 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == itemIn.KeyId && c.FId == 0)));
					List<TreeViewItemModel> list6 = new List<TreeViewItemModel>();
					foreach (WSspProductsTree_Result item2 in list5)
					{
						TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
						treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.FId + "|" + item2.SId + "|" + item2.PrdId));
						treeViewItemModel3.Id = item2.FId + "|" + item2.SId + "|" + item2.PrdId;
						treeViewItemModel3.Text = item2.KEYName;
						treeViewItemModel3.ImageUrl = "";
						treeViewItemModel3.Items = null;
						list6.Add(treeViewItemModel3);
					}
					treeViewItemModel2.Items = new List<TreeViewItemModel>(list6);
					list4.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdGroups = list;
		return PartialView();
	}

	public ActionResult LoadProductTree(int? mode, int? prdKind, int? prdInActive, int? cmpId, int? prjId, int? level, int? parentId, int? productId, int pageNumber = 1, int pageSize = 20, string textSearch = "", int searchMode = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspProductsTreeByLevel_Result> data = new List<WSspProductsTreeByLevel_Result>();
		try
		{
			if (productId.HasValue && productId != 0)
			{
				textSearch = "";
			}
			if ((!parentId.HasValue || parentId == 0) && !string.IsNullOrEmpty(textSearch))
			{
				level = searchMode;
			}
			textSearch = textSearch.Trim();
			parentId = ((parentId.HasValue && parentId.GetValueOrDefault() == -1) ? new int?(0) : parentId);
			data = Enumerable.ToList<WSspProductsTreeByLevel_Result>((IEnumerable<WSspProductsTreeByLevel_Result>)_dbII.WSspProductsTreeByLevel(mode, lCID, result, prdKind, prdInActive, cmpId, prjId, level, textSearch, searchMode, parentId, productId, pageSize, pageNumber));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialSelectProduct(int prdFgroupId, int prdSgroupId, string barcode, string val, int prdId, int showMode, int cmpId, int prjId)
	{
		base.ViewBag.prdSgroupId = prdSgroupId;
		base.ViewBag.prdFgroupId = prdFgroupId;
		base.ViewBag.barcode = barcode;
		base.ViewBag.val = val;
		base.ViewBag.prdId = prdId;
		base.ViewBag.showMode = showMode;
		base.ViewBag.cmpId = cmpId;
		base.ViewBag.prjId = prjId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult SelectProduct_Read([DataSourceRequest] DataSourceRequest request, int prdFgroupId, int prdSgroupId, string barcode, string val, int prdId, int showMode, int cmpId, int prjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			string text = "";
			if (prdId > 0 && prdSgroupId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					text = ((!string.IsNullOrEmpty(wSspSelectProductsWithId_Result.PrdName)) ? wSspSelectProductsWithId_Result.PrdName : "");
				}
				val = text;
				prdId = 0;
				prdSgroupId = 0;
			}
			list = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(prdFgroupId, prdSgroupId, barcode, val, prdId, showMode, lCID, result, 1, 0, cmpId, prjId, "", null));
			if (list != null && Enumerable.Any<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)list))
			{
				foreach (WSspSearchProducts_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
				}
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
	public JsonResult GetDocTracing(int whId, int prdId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (whId != 0 && prdId != 0)
			{
				List<WSspReturnProductTracing_Result> list2 = Enumerable.ToList<WSspReturnProductTracing_Result>((IEnumerable<WSspReturnProductTracing_Result>)_db.WSspReturnProductTracing(whId, prdId, result2));
				list.AddRange(Enumerable.Select<WSspReturnProductTracing_Result, SelectListItem>((IEnumerable<WSspReturnProductTracing_Result>)list2, (Func<WSspReturnProductTracing_Result, SelectListItem>)((WSspReturnProductTracing_Result item) => new SelectListItem
				{
					Text = (item.Tracing ?? ""),
					Value = (item.Tracing ?? ""),
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
	public int CanUpdateDocItemTracing(int? whId = 0, int prdId = 0, string tracing = null)
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			tracing = ConvertCharacter.DecodeTracing(tracing);
			if (Enumerable.FirstOrDefault<WSspCheckCanUpdateDocItemTracing_Result>((IEnumerable<WSspCheckCanUpdateDocItemTracing_Result>)_db.WSspCheckCanUpdateDocItemTracing(prdId, whId, tracing, lCID, result2)) == null)
			{
				result = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string CheckDuplicateDocItemTracing(string masterForm, int masterId, int prdId, int currentId, string tracing)
	{
		if (!string.IsNullOrWhiteSpace(tracing))
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
		}
		string result = "1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (string.IsNullOrWhiteSpace(tracing))
			{
				return result;
			}
			bool flag = false;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.CanUseDupTracing.HasValue && cRMspSelectCrmsysSetting_Result.CanUseDupTracing != false) ? true : false);
			}
			if (!flag && (masterForm == "Doc" || masterForm == "WhDoc"))
			{
				WSspCheckDuplicateDocItemTracing_Result wSspCheckDuplicateDocItemTracing_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateDocItemTracing_Result>((IEnumerable<WSspCheckDuplicateDocItemTracing_Result>)_db.WSspCheckDuplicateDocItemTracing(prdId, currentId, tracing, lCID, result2));
				if (wSspCheckDuplicateDocItemTracing_Result != null)
				{
					result = string.Format(Messages.msgErrorDocItemTracingDuplicate, wSspCheckDuplicateDocItemTracing_Result.docNumber);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-1";
		}
		return result;
	}

	public string GetReturnPrdQuantity(int prdId, int wHId, int? currId = null, double? fcr = null, double? fcrI = null, string tracing = null)
	{
		string text = "0";
		if (!currId.HasValue)
		{
			currId = 0;
		}
		WSspReturnPrdQuantity_Result wSspReturnPrdQuantity_Result = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			tracing = ConvertCharacter.DecodeTracing(tracing);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			wSspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(prdId, Financial.Get().Id, wHId, currId, lCID, result, fcr, fcrI, tracing, result2));
			if (wSspReturnPrdQuantity_Result != null)
			{
				text = ((!wSspReturnPrdQuantity_Result.QuantityRemain.HasValue) ? "0|" : (wSspReturnPrdQuantity_Result.QuantityRemain + "|"));
				if (wSspReturnPrdQuantity_Result.TracingRemainCount.HasValue)
				{
					return text + wSspReturnPrdQuantity_Result.TracingRemainCount;
				}
				return text + "0";
			}
			return "0|0";
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			return "-9999999";
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return "-9999999";
		}
	}

	[AjaxOnly]
	public ActionResult LinkedProducts_Read([DataSourceRequest] DataSourceRequest request, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectLinkedProducts_Result> enumerable = new List<WSspSelectLinkedProducts_Result>();
		try
		{
			enumerable = Enumerable.ToList<WSspSelectLinkedProducts_Result>((IEnumerable<WSspSelectLinkedProducts_Result>)_db.WSspSelectLinkedProducts(prdId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string InsertDocItemFromLinkedPrdWithMinStock(int docItemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		string text = "";
		if (docItemId <= 0)
		{
			return "0|" + Messages.ErrorNotFound;
		}
		try
		{
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			int userId = UserLogin.CurrentUser.UserId;
			int id = Financial.Get().Id;
			string appType = Configuration.AppType;
			mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspInsertDocItemFromLinkedPrdWithMinStock(docItemId, userId, id, value, now, registerDatePersian, appType, result, centerId));
			if (mct_I_Result != null)
			{
				int result2 = 0;
				int.TryParse(mct_I_Result.Result.ToString(), out result2);
				return (result2 > 0) ? ("1|" + Messages.frmFormBaseInsertSuccessFulMessage) : ("0|" + Messages.msgErrorInAddLinkedPrd);
			}
			return "0|" + Messages.msgErrorInAddLinkedPrd;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "0|" + Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public JsonResult ReturnOrdItemQuantity(int docId, int itemId, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnOrdItemQuantityByDocItemId_Result wSspReturnOrdItemQuantityByDocItemId_Result = new WSspReturnOrdItemQuantityByDocItemId_Result();
		try
		{
			if (docId > 0 && prdId > 0)
			{
				wSspReturnOrdItemQuantityByDocItemId_Result = Enumerable.FirstOrDefault<WSspReturnOrdItemQuantityByDocItemId_Result>((IEnumerable<WSspReturnOrdItemQuantityByDocItemId_Result>)_dbI.WSspReturnOrdItemQuantityByDocItemId(docId, itemId, prdId));
			}
			if (wSspReturnOrdItemQuantityByDocItemId_Result == null)
			{
				wSspReturnOrdItemQuantityByDocItemId_Result = new WSspReturnOrdItemQuantityByDocItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(wSspReturnOrdItemQuantityByDocItemId_Result, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult AddProductItemI(string masterForm, string mode, int position, int masterId = 0, int detailId = 0, int whId = 0, int whIdI = 0, int prdId = 0)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.detailId = detailId;
		string text = "";
		string text2 = "";
		string text3 = "";
		switch (position)
		{
		case 1:
			text = "frmDoc";
			text2 = "actInsertDocItem";
			text3 = "frmDocItemDataEntry";
			break;
		case 2:
			text = "frmDoc";
			text2 = "actEditDocItem";
			text3 = "frmDocItemDataEntry";
			break;
		case 3:
			text = "frmDraft";
			text2 = "actInsertDraftItem";
			text3 = "frmDraftItemDataEntry";
			break;
		case 4:
			text = "frmDraft";
			text2 = "actEditDraftItem";
			text3 = "frmDraftItemDataEntry";
			break;
		case 5:
			text = "frmWareHouseMovement";
			text2 = "actInsertDocItem";
			text3 = "frmWareHouseMovementItemDataEntry";
			break;
		case 6:
			text = "frmWareHouseMovement";
			text2 = "actEditDocItem";
			text3 = "frmWareHouseMovementItemDataEntry";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text4 = "";
		AddProductViewModel addProductViewModel = new AddProductViewModel();
		if (CS_0024_003C_003E8__locals0.detailId > 0 && masterId > 0)
		{
			_003C_003Ec__DisplayClass19_1 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_1();
			DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
			ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "c");
			_003C_003Ec__DisplayClass19_.docItem = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass19_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (_003C_003Ec__DisplayClass19_.docItem != null)
			{
				DbSet<WSDocItems_Lang> wSDocItems_Lang = _dbTbl.WSDocItems_Lang;
				val = Expression.Parameter(typeof(WSDocItems_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDocItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDocItems_Lang>)Enumerable.ToList<WSDocItems_Lang>((IEnumerable<WSDocItems_Lang>)Queryable.Where<WSDocItems_Lang>((IQueryable<WSDocItems_Lang>)wSDocItems_Lang, Expression.Lambda<Func<WSDocItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSDocItems_Lang, CommonMultiLanguageViewModel>)((WSDocItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass19_.docItem.Description,
					LanguageId = result
				});
				text4 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				addProductViewModel.Tracing = _003C_003Ec__DisplayClass19_.docItem.Tracing;
				_ = DateTime.Now;
				addProductViewModel.UserId = _003C_003Ec__DisplayClass19_.docItem.UserId;
				addProductViewModel.RegisterDate = _003C_003Ec__DisplayClass19_.docItem.RegisterDate;
				addProductViewModel.AppType = _003C_003Ec__DisplayClass19_.docItem.AppType;
				addProductViewModel.FirstRegisterUserId = _003C_003Ec__DisplayClass19_.docItem.FirstRegisterUserId;
				addProductViewModel.FirstRegisterDate = _003C_003Ec__DisplayClass19_.docItem.FirstRegisterDate;
				addProductViewModel.PrdUnitId = _003C_003Ec__DisplayClass19_.docItem.PrdUnitId;
			}
		}
		base.ViewBag.DescriptionLang = text4;
		base.ViewBag.PrdId = prdId;
		base.ViewBag.Mode = mode;
		base.ViewBag.MasterId = masterId;
		if (masterForm.ToLower() == "doc")
		{
			masterForm = "WhDoc";
		}
		else if (masterForm.ToLower() == "draft")
		{
			masterForm = "WhDraft";
		}
		else if (masterForm.ToLower() == "warehousemovement")
		{
			masterForm = "WhMovement";
		}
		base.ViewBag.MasterForm = masterForm;
		base.ViewBag.DetailId = CS_0024_003C_003E8__locals0.detailId;
		base.ViewBag.FormName = text3;
		base.ViewBag.WhId = whId;
		base.ViewBag.WhIdI = whIdI;
		base.ViewBag.ModeInsertEdit = ((CS_0024_003C_003E8__locals0.detailId > 0) ? "Edit" : "Insert");
		SetRegisterInfo(addProductViewModel);
		GetPrdUnits();
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string AddProductItemI(string records = "")
	{
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		string ErrorCode = "3";
		string code = "4";
		List<CommonWithIdStrViewModel> list = new List<CommonWithIdStrViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			List<AddProductViewModel> list2 = new List<AddProductViewModel>();
			list2 = JsonConvert.DeserializeObject<List<AddProductViewModel>>(records);
			if (list2 != null && list2.Count > 0)
			{
				foreach (AddProductViewModel item in list2)
				{
					string formName = "";
					switch (item.MasterForm)
					{
					case "WhDoc":
						formName = "frmDocItemDataEntry";
						break;
					case "WhDraft":
						formName = "frmDraftItemDataEntry";
						break;
					case "WhMovement":
						formName = "frmWareHouseMovementItemDataEntry";
						break;
					default:
						list.Add(new CommonWithIdStrViewModel
						{
							Id = item.ProductId.ToString(),
							Name = item.ProductName,
							Extra = Messages.ErrorNotAccess,
							Code = ErrorCode
						});
						item.IsUnusable = true;
						break;
					}
					if (item.MasterForm == "WhDoc")
					{
						string text2 = CheckDuplicateDocItemTracing(item.MasterForm, item.MasterId, item.ProductId, item.DetailId, item.Tracing);
						if (text2 == "-1")
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Id = item.ProductId.ToString(),
								Name = item.ProductName,
								Extra = Messages.msgErrorRunFunction,
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
						if (text2 != "1")
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Id = item.ProductId.ToString(),
								Name = item.ProductName,
								Extra = text2,
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
					}
					if (!UserLogin.IsUserAccess(formName, "actPost", currentUser))
					{
						list.Add(new CommonWithIdStrViewModel
						{
							Extra = Messages.ErrorNotAccess,
							Code = ErrorCode
						});
						item.IsUnusable = true;
						continue;
					}
					if (item.ProductId <= 0)
					{
						list.Add(new CommonWithIdStrViewModel
						{
							Id = item.ProductId.ToString(),
							Name = item.ProductName,
							Extra = Messages.msgErrorNotSelectProduct,
							Code = ErrorCode
						});
						item.IsUnusable = true;
					}
					if (item.Quantity <= 0.0)
					{
						list.Add(new CommonWithIdStrViewModel
						{
							Id = item.ProductId.ToString(),
							Name = item.ProductName,
							Extra = Messages.msgErrorNotSelectPrdQuantity,
							Code = ErrorCode
						});
						item.IsUnusable = true;
					}
					bool result2 = false;
					WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(item.ProductId, lCID, defLangID));
					if (wSspSelectProductsWithId_Result != null)
					{
						bool.TryParse(wSspSelectProductsWithId_Result.PrdMustFullTracingCode.ToString(), out result2);
					}
					bool flag = false;
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						flag = cRMspSelectCrmsysSetting_Result.MustFullTracingCode.HasValue && cRMspSelectCrmsysSetting_Result.MustFullTracingCode != false;
					}
					if (flag)
					{
						if (string.IsNullOrWhiteSpace(item.Tracing))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Id = item.ProductId.ToString(),
								Name = item.ProductName,
								Extra = string.Format(Messages.msgErrorIsNotSpecified, Labels.prdTracing),
								Code = ErrorCode
							});
							item.IsUnusable = true;
						}
					}
					else if (result2 && string.IsNullOrWhiteSpace(item.Tracing))
					{
						list.Add(new CommonWithIdStrViewModel
						{
							Id = item.ProductId.ToString(),
							Name = item.ProductName,
							Extra = string.Format(Messages.msgErrorIsNotSpecified, Labels.prdTracing),
							Code = ErrorCode
						});
						item.IsUnusable = true;
					}
					if (item.MasterForm == "WhDoc" && !string.IsNullOrWhiteSpace(item.Tracing))
					{
						int value3 = item.ProductId;
						if (UserLogin.IsUserAccess("frmDocItemDataEntry", "actLoadTracingCodeFromAllPrd", UserLogin.CurrentUser))
						{
							value3 = 0;
						}
						if (UserLogin.IsUserAccess("frmDocItemDataEntry", "actCanNotAddNewTracingCode", UserLogin.CurrentUser) && Enumerable.FirstOrDefault<WSspSelectDocItemTracing_Result>((IEnumerable<WSspSelectDocItemTracing_Result>)_dbI.WSspSelectDocItemTracing(item.Tracing, value3)) == null && string.IsNullOrWhiteSpace(item.Tracing))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Id = item.ProductId.ToString(),
								Name = item.ProductName,
								Extra = string.Format(Messages.msgErrorCanNotAddNewTracingCode, item.Tracing),
								Code = ErrorCode
							});
							item.IsUnusable = true;
						}
					}
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(item.Description_Lang))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Description_Lang);
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = item.Description,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(item.PrdNickname_Lang))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.PrdNickname_Lang);
					}
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = item.PrdNickname,
						LanguageId = lCID
					});
					if (item.MasterForm == "WhDoc")
					{
						if (Doc.IsFixed(item.MasterId))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Extra = Messages.msgErrorNotActiveDoc,
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
						if (Doc.IsSentToLinkAccByAction(item.MasterId))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Extra = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle),
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
					}
					else if (item.MasterForm == "WhDraft")
					{
						if (Draft.IsFixed(item.MasterId))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Extra = Messages.msgErrorNotActiveDraft,
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
						if (Draft.IsSentToLinkAccByAction(item.MasterId))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Extra = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle),
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
					}
					else if (item.MasterForm == "WhMovement")
					{
						if (Draft.IsFixed(item.MasterId))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Extra = Messages.msgErrorNotActiveWareHouseMovement,
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
						if (WareHouseMovement.IsSentToLinkAccByAction(item.MasterId))
						{
							list.Add(new CommonWithIdStrViewModel
							{
								Extra = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle),
								Code = ErrorCode
							});
							item.IsUnusable = true;
							continue;
						}
					}
					item.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					item.Description_Lang = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)))) : null);
					item.PrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					item.PrdNickname_Lang = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)) != null) ? JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)))) : null);
					item.PrdUnitId = ((item.PrdUnitId == 0) ? null : item.PrdUnitId);
					item.PrdUnitIdI = ((item.PrdUnitIdI == 0) ? null : item.PrdUnitIdI);
					item.PrdUnitIdII = ((item.PrdUnitIdII == 0) ? null : item.PrdUnitIdII);
					item.QuantityTotal = ((item.QuantityTotal == 0.0) ? null : item.QuantityTotal);
					item.PrdUnitIRateResult = ((item.PrdUnitIRateResult == 0.0) ? null : item.PrdUnitIRateResult);
					if (item.MasterForm == "WhDoc")
					{
						if (CanUpdateDocItemTracing(item.WHId, item.ProductId, item.Tracing) == 1)
						{
							item.Tracing = ((!string.IsNullOrWhiteSpace(item.Tracing)) ? item.Tracing : null);
						}
					}
					else
					{
						item.Tracing = ((!string.IsNullOrWhiteSpace(item.Tracing)) ? item.Tracing : null);
					}
					if (!(item.MasterForm != "WhDoc"))
					{
						continue;
					}
					try
					{
						WSspReturnPrdQuantity_Result wSspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(item.ProductId, id, (item.MasterForm == "WhMovement") ? item.WHIdI : item.WHId, item.DetailId, lCID, defLangID, item.FCR, item.FCRI, item.Tracing, result));
						if (wSspReturnPrdQuantity_Result != null)
						{
							double? remainCount = wSspReturnPrdQuantity_Result.RemainCount;
							if (remainCount <= 0.0)
							{
								list.Add(new CommonWithIdStrViewModel
								{
									Id = item.ProductId.ToString(),
									Name = item.ProductName,
									Extra = Messages.DraftQuantityRemainLimitExceeded,
									Code = ErrorCode
								});
								item.IsUnusable = true;
							}
							else if (remainCount < item.Quantity)
							{
								list.Add(new CommonWithIdStrViewModel
								{
									Id = item.ProductId.ToString(),
									Name = item.ProductName,
									Extra = item.Quantity + "|" + remainCount,
									Code = code
								});
								item.IsUnusable = true;
							}
						}
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						list.Add(new CommonWithIdStrViewModel
						{
							Extra = "[SPError]: " + ex.Message,
							Code = ErrorCode
						});
						item.IsUnusable = true;
					}
				}
				List<AddProductViewModel> list5 = Enumerable.ToList<AddProductViewModel>(Enumerable.Where<AddProductViewModel>((IEnumerable<AddProductViewModel>)list2, (Func<AddProductViewModel, bool>)((AddProductViewModel x) => !x.IsUnusable.GetValueOrDefault())));
				if (Enumerable.Count<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)Enumerable.ToList<CommonWithIdStrViewModel>(Enumerable.Where<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Code == ErrorCode)))) <= 0 && list5 != null && list5.Count > 0)
				{
					string value4 = Enumerable.FirstOrDefault<string>((IEnumerable<string>)_dbI.WSspInsertDocItemsMulti(JsonConvert.SerializeObject(list5), userId, id, value2, value, text, appType, lCID, defLangID, userId, value, text));
					if (!string.IsNullOrWhiteSpace(value4))
					{
						List<CommonWithIdStrViewModel> collection = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(value4);
						list.AddRange(collection);
					}
				}
			}
			else
			{
				list.Add(new CommonWithIdStrViewModel
				{
					Extra = Messages.msgErrorNotSelectItem,
					Code = ErrorCode
				});
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			list.Add(new CommonWithIdStrViewModel
			{
				Extra = Messages.msgErrorOperationFailed + " - " + ex2.Message,
				Code = ErrorCode
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	public JsonResult ReturnSelectedLinkedPrdDetailsJs(string masterForm = "", int masterId = 0, int companyId = 0, string crmOrdType = "ord", int prdId = 0, int parentPrdQuan = 1, int prdPriceGroupId = 0, int whId = 0, int destCurrencyUnitId = 0, string selectedIds = "", int prdKind = 0, int orderOprType = 0)
	{
		List<AddProductViewModel> list = new List<AddProductViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = Financial.Get().Id;
			if (prdId > 0 && !string.IsNullOrWhiteSpace(selectedIds))
			{
				List<WSspSelectLinkedProductsWithPrice_Result> list2 = SelectLinkedProducts(prdId, prdPriceGroupId, destCurrencyUnitId, selectedIds);
				if (list2 != null)
				{
					string[] array = selectedIds.Split(new char[1] { ',' });
					foreach (string s in array)
					{
						int id = 0;
						int.TryParse(s, out id);
						if (id <= 0)
						{
							continue;
						}
						WSspSelectLinkedProductsWithPrice_Result wSspSelectLinkedProductsWithPrice_Result = Enumerable.FirstOrDefault<WSspSelectLinkedProductsWithPrice_Result>(Enumerable.Where<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)list2, (Func<WSspSelectLinkedProductsWithPrice_Result, bool>)((WSspSelectLinkedProductsWithPrice_Result x) => x.LinkedProductId == id)));
						if (wSspSelectLinkedProductsWithPrice_Result == null)
						{
							continue;
						}
						WSspSelectProductsWithId_Result prd = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSspSelectLinkedProductsWithPrice_Result.ProductIdForLoad, lCID, result));
						if (prd != null)
						{
							WSspReturnProductPriceViewModel wSspReturnProductPriceViewModel = SelectReturnProductPrice(prd.ProductID, prdPriceGroupId, destCurrencyUnitId, companyId, whId, crmOrdType, wSspSelectLinkedProductsWithPrice_Result.LinkedProductId.ToString());
							WSspSelectProductUnits_Result wSspSelectProductUnits_Result = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result), (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result x) => x.ProductUnitID == prd.PrdUnitId));
							string text = CheckDuplicateProduct(masterForm, masterId, prd.ProductID, 0);
							AddProductViewModel addProductViewModel = new AddProductViewModel
							{
								ErrorsList = new List<SelectListItem>()
							};
							if (text == "1")
							{
								addProductViewModel.ErrorsList.Add(new SelectListItem
								{
									Text = addProductViewModel.ProductName + ": " + Messages.msgErrorDupIProduct,
									Value = "dup"
								});
							}
							addProductViewModel.MasterForm = masterForm;
							addProductViewModel.MasterId = masterId;
							addProductViewModel.ProductId = prd.ProductID;
							addProductViewModel.ProductName = prd.PrdName;
							addProductViewModel.OprType = orderOprType;
							addProductViewModel.prdKind = prd.PrdKind;
							addProductViewModel.PrdCode = prd.PrdCode ?? "";
							addProductViewModel.PrdQtyCanDecimal = prd.PrdQtyCanDecimal.GetValueOrDefault();
							if (wSspSelectLinkedProductsWithPrice_Result.LinkedPrdAddQuantity.GetValueOrDefault())
							{
								double valueOrDefault = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdQuantity.GetValueOrDefault(1.0);
								addProductViewModel.Quantity = valueOrDefault * (double)parentPrdQuan;
							}
							else
							{
								addProductViewModel.Quantity = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdQuantity.GetValueOrDefault(1.0);
							}
							addProductViewModel.QuantityDesc = "";
							double result2 = 0.0;
							double.TryParse(prd.PrdUnitIRate.ToString(), out result2);
							if (result2 != 0.0)
							{
								addProductViewModel.PrdUnitIRateResult = 1.0 / result2 * addProductViewModel.Quantity;
								addProductViewModel.PrdUnitIdI = prd.PrdUnitIdI;
								addProductViewModel.PrdUnitIRateCalcAuto = prd.PrdUnitIRateCalcAuto;
								addProductViewModel.PrdUnitIRate = prd.PrdUnitIRate;
							}
							double result3 = 0.0;
							double.TryParse(prd.PrdUnitIIRate.ToString(), out result3);
							if (result3 != 0.0)
							{
								addProductViewModel.PrdUnitIIRateResult = 1.0 / result3 * addProductViewModel.Quantity;
								addProductViewModel.PrdUnitIdII = prd.PrdUnitIdII;
								addProductViewModel.PrdUnitIIRateCalcAuto = prd.PrdUnitIIRateCalcAuto;
								addProductViewModel.PrdUnitIIRate = prd.PrdUnitIIRate;
							}
							SelectReturnPrdQuantity(prdId, 0, whId, wSspSelectProductUnits_Result?.FCR.GetValueOrDefault() ?? 0.0, wSspSelectProductUnits_Result?.FCRI.GetValueOrDefault() ?? 0.0, "", companyId, prdPriceGroupId, crmOrdType);
							addProductViewModel.Round = default(decimal);
							addProductViewModel.RoundPlus = default(decimal);
							if (wSspSelectLinkedProductsWithPrice_Result.LinkedPrdAddPrice.GetValueOrDefault())
							{
								addProductViewModel.Price = wSspReturnProductPriceViewModel.Price.GetValueOrDefault();
								addProductViewModel.PriceSum = default(decimal);
								addProductViewModel.TotalPrice = default(decimal);
							}
							else
							{
								addProductViewModel.Price = default(decimal);
								addProductViewModel.PriceSum = default(decimal);
								addProductViewModel.TotalPrice = default(decimal);
							}
							if (wSspSelectLinkedProductsWithPrice_Result.LinkedPrdAddDiscount.GetValueOrDefault())
							{
								addProductViewModel.DiscountPrecent = wSspReturnProductPriceViewModel.DiscountPrecent.GetValueOrDefault();
								addProductViewModel.Discount = wSspReturnProductPriceViewModel.Discount.GetValueOrDefault();
								addProductViewModel.DiscountSum = default(decimal);
							}
							else
							{
								addProductViewModel.DiscountPrecent = default(decimal);
								addProductViewModel.Discount = default(decimal);
								addProductViewModel.DiscountSum = default(decimal);
							}
							double num = double.Parse(addProductViewModel.Price.ToString());
							double quantity = addProductViewModel.Quantity;
							double num2 = wSspSelectProductUnits_Result?.FCR.GetValueOrDefault() ?? 1.0;
							if (num2 <= 0.0)
							{
								num2 = 1.0;
							}
							double num3 = wSspSelectProductUnits_Result?.FCRI.GetValueOrDefault() ?? 1.0;
							if (num3 <= 0.0)
							{
								num3 = 1.0;
							}
							double num4 = double.Parse(addProductViewModel.Round.ToString());
							double num5 = double.Parse(addProductViewModel.RoundPlus.ToString());
							double num6 = quantity * num2 * num3;
							double num7 = double.Parse(addProductViewModel.Discount.GetValueOrDefault().ToString());
							double num8 = num - num7 - num4 + num5;
							double num9 = double.Parse(addProductViewModel.Discount.ToString());
							double num10 = double.Parse(addProductViewModel.DiscountPrecent.ToString());
							double num11 = 0.0;
							num11 = ((!(num10 > 0.0)) ? (num9 * num6) : (num * num6 * num10 / 100.0));
							double num12 = num11;
							if (num12 > 0.0)
							{
								addProductViewModel.DiscountSum = decimal.Parse(num12.ToString());
							}
							else
							{
								addProductViewModel.DiscountSum = default(decimal);
							}
							addProductViewModel.PriceSum = decimal.Parse((num - num9 - num4 + num5).ToString());
							num12 = num8 * num6;
							if (num12 > 0.0)
							{
								addProductViewModel.TotalPrice = decimal.Parse(num12.ToString());
							}
							else
							{
								addProductViewModel.TotalPrice = default(decimal);
							}
							addProductViewModel.Description = prd.PrdDescription;
							addProductViewModel.FCR = num2;
							addProductViewModel.FCRI = num3;
							addProductViewModel.PrdUnitId = prd.PrdUnitId;
							addProductViewModel.PrdColorId = prd.PrdColorId;
							addProductViewModel.CurrencyUnitId = destCurrencyUnitId;
							addProductViewModel.WHId = whId;
							addProductViewModel.PrdPriceGroupId = prdPriceGroupId;
							addProductViewModel.SelectedNotInSum = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdNotInSum.GetValueOrDefault();
							addProductViewModel.SelectedNotVisible = wSspSelectLinkedProductsWithPrice_Result.LinkedPrdNotVisible.GetValueOrDefault();
							list.Add(addProductViewModel);
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public WSspReturnProductPriceViewModel SelectReturnProductPrice(int prdId, int prdPriceGroupId, int currUnitId = 0, int cmpId = 0, int whId = 0, string crmOrdType = "ord", string linkedPrdIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		WSspReturnProductPriceViewModel wSspReturnProductPriceViewModel = new WSspReturnProductPriceViewModel();
		try
		{
			WSspReturnProductPrice_Result wSspReturnProductPrice_Result = Enumerable.FirstOrDefault<WSspReturnProductPrice_Result>((IEnumerable<WSspReturnProductPrice_Result>)_db.WSspReturnProductPrice(prdId, prdPriceGroupId, lCID, result, currUnitId, centerId)) ?? new WSspReturnProductPrice_Result
			{
				Price = 0m,
				CurrencyPrice = default(decimal),
				CurrencyUnit = "",
				CooperationPrice = default(decimal),
				CurrencyUnitId = 0,
				Discount = default(decimal),
				DiscountPrecent = default(decimal),
				DocNumber = null
			};
			if (wSspReturnProductPrice_Result != null)
			{
				wSspReturnProductPriceViewModel = new WSspReturnProductPriceViewModel
				{
					PrdId = wSspReturnProductPrice_Result.PrdId,
					DocDate = wSspReturnProductPrice_Result.DocDate,
					DocDateTime = wSspReturnProductPrice_Result.DocDateTime,
					DocNumber = wSspReturnProductPrice_Result.DocNumber,
					Price = wSspReturnProductPrice_Result.Price,
					CurrencyPrice = wSspReturnProductPrice_Result.CurrencyPrice,
					CurrencyUnitId = wSspReturnProductPrice_Result.CurrencyUnitId,
					CurrencyUnit = wSspReturnProductPrice_Result.CurrencyUnit,
					CurrencyUnitEn = wSspReturnProductPrice_Result.CurrencyUnitEn,
					CooperationPrice = wSspReturnProductPrice_Result.CooperationPrice,
					PricePercent = wSspReturnProductPrice_Result.PricePercent,
					DiscountPrecent = wSspReturnProductPrice_Result.DiscountPrecent,
					Discount = wSspReturnProductPrice_Result.Discount,
					OtherPrice = wSspReturnProductPrice_Result.OtherPrice,
					CurrencyRate = wSspReturnProductPrice_Result.CurrencyRate,
					IsDecimal = wSspReturnProductPrice_Result.IsDecimal
				};
				wSspReturnProductPriceViewModel.SumLinkedProductPrice = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnSumLinkedProductPrice(prdId, prdPriceGroupId, currUnitId, linkedPrdIds, centerId)) ?? new decimal?(default(decimal));
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.HasValue && cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0 && wSspReturnProductPriceViewModel != null)
			{
				ProductController productController = new ProductController();
				string text = "";
				if (num == 3)
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, prdPriceGroupId, ref prdPrice, ref prdQuantity, crmOrdType, 0);
					text = prdPrice.ToString();
				}
				decimal result2 = default(decimal);
				if (!string.IsNullOrEmpty(text))
				{
					decimal.TryParse(text, out result2);
					wSspReturnProductPriceViewModel.DocNumber = result2.ToString();
				}
				else
				{
					wSspReturnProductPriceViewModel.DocNumber = "0";
				}
			}
			else
			{
				wSspReturnProductPriceViewModel.DocNumber = null;
			}
			double result3 = 0.0;
			double? num2 = Enumerable.FirstOrDefault<double?>((IEnumerable<double?>)_db.WSspReturnPricePartRateFromCmpGroupII(cmpId));
			if (num2.HasValue)
			{
				double.TryParse(num2.ToString(), out result3);
			}
			wSspReturnProductPriceViewModel.CmpGroupIIRate = result3;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return wSspReturnProductPriceViewModel;
	}

	[HttpPost]
	public JsonResult SelectProduct(string barcode = "", string text = "", int showMode = 2, int prdKind = 0, int companyId = 0, int projectId = 0, string masterFormName = "", int currentMasterId = 0)
	{
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<WSspSearchProducts_Result>(Enumerable.Take<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(0, 0, text, text, 0, showMode, lCID, result, prdKind, 0, companyId, projectId, "", null), 800));
				foreach (WSspSearchProducts_Result item in list)
				{
					if (!item.PrdValidity.GetValueOrDefault() || !(masterFormName == "SaleOrder"))
					{
						continue;
					}
					WSspReturnProductValidity_Result wSspReturnProductValidity_Result = Enumerable.FirstOrDefault<WSspReturnProductValidity_Result>((IEnumerable<WSspReturnProductValidity_Result>)_dbI.WSspReturnProductValidity(item.PrdId));
					if (wSspReturnProductValidity_Result == null)
					{
						continue;
					}
					bool flag = false;
					int result2 = 0;
					int result3 = 0;
					int result4 = 0;
					if (wSspReturnProductValidity_Result.PrdValidityDay.HasValue)
					{
						int.TryParse(wSspReturnProductValidity_Result.PrdValidityDay.ToString(), out result2);
						flag = true;
					}
					if (!string.IsNullOrWhiteSpace(wSspReturnProductValidity_Result.PrdValidityTime))
					{
						string[] array = wSspReturnProductValidity_Result.PrdValidityTime.Split(new char[1] { ':' });
						if (array != null && Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
						{
							int.TryParse(array[0] ?? "0", out result3);
							int.TryParse(array[1] ?? "0", out result4);
						}
						flag = true;
					}
					if (flag && currentMasterId > 0)
					{
						WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(currentMasterId, lCID, result));
						if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordDateTime.HasValue)
						{
							DateTime dateTime = default(DateTime);
							dateTime = wSspSelectOrderById_Result.ordDateTime.Value.AddDays(result2).AddHours(result3).AddMinutes(result4);
							item.PrdValidityExpireDate = dateTime.ToString("yyyy/MM/dd");
							item.PrdValidityExpireTime = dateTime.ToString("HH:mm");
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductsList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public JsonResult SelectWarehouse()
	{
		List<WSspSelectActiveWareHouse_Result> list = new List<WSspSelectActiveWareHouse_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			list = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WarehousesList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ReturnPrdQuantityViewModel SelectReturnPrdQuantity(int prdId = 0, int currId = 0, int whId = 0, double fcr = 0.0, double fcrI = 0.0, string tracing = "", int cmpId = 0, int prdPriceGroupId = 0, string crmOrdType = "ord")
	{
		ReturnPrdQuantityViewModel returnPrdQuantityViewModel = new ReturnPrdQuantityViewModel();
		returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
		returnPrdQuantityViewModel.ValidpordQuantity = 0.0;
		returnPrdQuantityViewModel.QtyRemain = 0.0;
		returnPrdQuantityViewModel.ValidpordQuantityTotal = "0/0";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int id = Financial.Get().Id;
			tracing = ConvertCharacter.DecodeTracing(tracing);
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			returnPrdQuantityViewModel.PrdQuantity = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(prdId, id, whId, 0, lCID, result, fcr, fcrI, (!string.IsNullOrWhiteSpace(tracing)) ? tracing.Trim() : "", result2));
			if (returnPrdQuantityViewModel.PrdQuantity == null)
			{
				returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
			}
			WSspReturnValidPordPrdCount_Result wSspReturnValidPordPrdCount_Result = Enumerable.FirstOrDefault<WSspReturnValidPordPrdCount_Result>((IEnumerable<WSspReturnValidPordPrdCount_Result>)_db.WSspReturnValidPordPrdCount(prdId, 0, DateTime.Now, fcr, fcrI, whId, (!string.IsNullOrWhiteSpace(tracing)) ? tracing.Trim() : ""));
			if (wSspReturnValidPordPrdCount_Result != null)
			{
				returnPrdQuantityViewModel.ValidpordQuantity = wSspReturnValidPordPrdCount_Result.ValidpordQuantity.GetValueOrDefault();
				returnPrdQuantityViewModel.ValidpordQuantityTotal = wSspReturnValidPordPrdCount_Result.ValidpordQuantity.GetValueOrDefault() + "/" + wSspReturnValidPordPrdCount_Result.ValidpordQuantityTotal.GetValueOrDefault();
			}
			if (returnPrdQuantityViewModel.PrdQuantity != null)
			{
				double valueOrDefault = returnPrdQuantityViewModel.PrdQuantity.RemainCountAllWH.GetValueOrDefault();
				returnPrdQuantityViewModel.QtyRemain = valueOrDefault - returnPrdQuantityViewModel.ValidpordQuantity;
				double valueOrDefault2 = returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.GetValueOrDefault();
				returnPrdQuantityViewModel.QtyRemain = valueOrDefault2 - returnPrdQuantityViewModel.ValidpordQuantity;
				if (!UserLogin.IsUserAccess("frmAddProduct", "actShowPrdQuantityRemainCurrAndAll", UserLogin.CurrentUser))
				{
					string text = returnPrdQuantityViewModel.PrdQuantity.QuantityRemain.GetValueOrDefault().ToString();
					returnPrdQuantityViewModel.PrdQuantity.RemainCurrAndAll = text + "/" + text;
				}
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0 && returnPrdQuantityViewModel.PrdQuantity != null)
			{
				ProductController productController = new ProductController();
				string text2 = "";
				switch (num)
				{
				case 3:
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, prdPriceGroupId, ref prdPrice, ref prdQuantity, crmOrdType, 0);
					text2 = prdQuantity.ToString();
					break;
				}
				case 4:
					text2 = productController.HolooGetPrdQuantity(prdId);
					break;
				case 6:
					text2 = productController.KyanGetPrdQuantity(prdId, whId);
					break;
				case 7:
					text2 = productController.PayvastGetPrdQuantity(prdId, whId);
					break;
				case 11:
					text2 = productController.ShomaranGetPrdQuantity(prdId, whId, "", tracing);
					break;
				case 12:
					text2 = productController.LinkAccGetPrdQuantity(num, prdId, whId, "", tracing);
					break;
				default:
					text2 = productController.LinkAccGetPrdQuantity(num, prdId, whId, "", tracing, "", prdPriceGroupId);
					break;
				}
				double result3 = 0.0;
				if (!string.IsNullOrEmpty(text2) && text2 != Labels.frmError)
				{
					double.TryParse(text2, out result3);
				}
				returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount = result3;
				returnPrdQuantityViewModel.QtyRemain = result3 - returnPrdQuantityViewModel.ValidpordQuantity;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return returnPrdQuantityViewModel;
	}

	[HttpPost]
	public JsonResult SearchTracingInDoc(string tracing, int prdId)
	{
		List<WSspSearchTracingInDoc_Result> data = new List<WSspSearchTracingInDoc_Result>();
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			data = Enumerable.ToList<WSspSearchTracingInDoc_Result>((IEnumerable<WSspSearchTracingInDoc_Result>)_dbI.WSspSearchTracingInDoc(tracing, prdId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public string SearchTracingInDocJs(string tracing, int prdId)
	{
		string text = "";
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			return JsonConvert.SerializeObject(Enumerable.ToList<WSspSearchTracingInDoc_Result>((IEnumerable<WSspSearchTracingInDoc_Result>)_dbI.WSspSearchTracingInDoc(tracing, prdId)));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "";
		}
	}

	[HttpPost]
	public string SearchTracingInDocSelectListItemJs(string tracing, int prdId)
	{
		string text = "";
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			List<SelectListItem> list = new List<SelectListItem>();
			List<WSspSearchTracingInDoc_Result> list2 = Enumerable.ToList<WSspSearchTracingInDoc_Result>((IEnumerable<WSspSearchTracingInDoc_Result>)_dbI.WSspSearchTracingInDoc(tracing, prdId));
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(Enumerable.Select<WSspSearchTracingInDoc_Result, SelectListItem>((IEnumerable<WSspSearchTracingInDoc_Result>)list2, (Func<WSspSearchTracingInDoc_Result, SelectListItem>)((WSspSearchTracingInDoc_Result x) => new SelectListItem
				{
					Text = x.Tracing,
					Value = Guid.NewGuid().ToString()
				})));
			}
			return JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "";
		}
	}

	public List<WSspSelectLinkedProductsWithPrice_Result> SelectLinkedProducts(int prdId = 0, int productPriceGroupId = 0, int destCurrencyUnitId = 0, string selectedIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectLinkedProductsWithPrice_Result> list = new List<WSspSelectLinkedProductsWithPrice_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)_dbI.WSspSelectLinkedProductsWithPrice(prdId, productPriceGroupId, destCurrencyUnitId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkedProducts = list;
		base.ViewBag.LinkedProductsSelectedIds = selectedIds;
		return list;
	}

	public JsonResult SelectLinkedProductsJs(int prdId = 0, int productPriceGroupId = 0, int destCurrencyUnitId = 0, string selectedIds = "")
	{
		return Json(SelectLinkedProducts(prdId, productPriceGroupId, destCurrencyUnitId, selectedIds), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdUnits()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<WSProductUnitsListViewModel> list2 = new List<WSProductUnitsListViewModel>();
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductUnits_Result> list3 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list3, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
			{
				Text = item.Unit,
				Value = item.ProductUnitID.ToString(),
				Selected = false
			})));
			list2.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, WSProductUnitsListViewModel>((IEnumerable<WSspSelectProductUnits_Result>)list3, (Func<WSspSelectProductUnits_Result, WSProductUnitsListViewModel>)((WSspSelectProductUnits_Result item) => new WSProductUnitsListViewModel
			{
				ProductUnitID = item.ProductUnitID,
				Unit = item.Unit,
				QuantityInUnit = item.QuantityInUnit,
				UnitEn = item.UnitEn,
				FCR = item.FCR,
				FCRI = item.FCRI
			})));
			List<WSProductUnitsFormulaListViewModel> list4 = new List<WSProductUnitsFormulaListViewModel>();
			if (list3 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list3))
			{
				list4.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, WSProductUnitsFormulaListViewModel>((IEnumerable<WSspSelectProductUnits_Result>)list3, (Func<WSspSelectProductUnits_Result, WSProductUnitsFormulaListViewModel>)((WSspSelectProductUnits_Result item) => new WSProductUnitsFormulaListViewModel
				{
					ProductUnitID = item.ProductUnitID,
					UnitIFormula = item.UnitIFormula,
					UnitIIFormula = item.UnitIIFormula
				})));
			}
			text = "";
			if (list4 != null && Enumerable.Any<WSProductUnitsFormulaListViewModel>((IEnumerable<WSProductUnitsFormulaListViewModel>)list4))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<WSProductUnitsFormulaListViewModel>((IEnumerable<WSProductUnitsFormulaListViewModel>)list4));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UnitList = list;
		base.ViewBag.PrdUnitList = list2;
		base.ViewBag.UnitIList = list;
		base.ViewBag.PrdUnitFormulaListJson = text;
		base.ViewBag.UnitIIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult ItemImportExcel(int docId, int whId, int whIdI, int position)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		bool flag = false;
		switch (position)
		{
		case 1:
			text = "frmDoc";
			text2 = "actDocItemImportExcel";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actDraftItemImportExcel";
			flag = true;
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actDocItemImportExcel";
			flag = true;
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.DocId = docId;
		base.ViewBag.WhId = whId;
		base.ViewBag.WhIdI = whIdI;
		base.ViewBag.Position = position;
		base.ViewBag.IsCheckQty = flag;
		base.ViewBag.FormName = text;
		base.ViewBag.ActionName = text2;
		List<SelectListItem> list = new List<SelectListItem>();
		List<WSspSelectProductUnits_Result> list2 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
		list.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
		{
			Text = item.Unit + " (" + item.ProductUnitID + ")",
			Value = item.ProductUnitID.ToString(),
			Selected = false
		})));
		base.ViewBag.PrdUnitList = list;
		return View();
	}

	public ActionResult DownloadItemImportExcelFields()
	{
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ExcelPackage excelPackage = new ExcelPackage();
			ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("KaraAfzarIdeal");
			int num = 0;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdCode;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelQuantity;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelDesc;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelFCR;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelFCRI;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelTracing;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnit;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelQuantityTotal;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitI;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitIRateResult;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitII;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitIIRateResult;
			using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
			{
				excelRange.Style.Font.Bold = true;
				excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
				excelRange.Style.Font.Color.SetColor(Color.White);
			}
			excelPackage.Workbook.Properties.Title = Labels.CmpImportExcelPropertiesTitle;
			excelPackage.Workbook.Properties.Company = Labels.CmpImportExcelPropertiesCompany;
			excelPackage.SaveAs(base.Response.OutputStream);
			base.Response.Buffer = true;
			base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
			base.Response.ContentType = "application/ms-excel";
			base.Response.Charset = "";
			base.Response.Flush();
			base.Response.End();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	public ActionResult UploadFile([DataSourceRequest] DataSourceRequest request, HttpPostedFileBase attachFileUrlUpload, int docId, int whId, int whIdI, int position, bool isCheckQty = false)
	{
		//IL_0b11: Unknown result type (might be due to invalid IL or missing references)
		string filePath = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSDocItemImportExcelViewModel> list = new List<WSDocItemImportExcelViewModel>();
		try
		{
			_ = DateTime.Now;
			object[,] array = null;
			int num4 = 0;
			int num5 = 0;
			byte[] buffer = new byte[base.Request.ContentLength];
			base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
			using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
			{
				ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
				num4 = excelWorksheet.Dimension.End.Column;
				num5 = excelWorksheet.Dimension.End.Row;
				array = new object[num5, num4];
				array = (object[,])excelWorksheet.Cells.Value;
			}
			try
			{
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
				_ = Financial.Get().Id;
				List<WSspSelectProductUnits_Result> list2 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID2, result2));
				int num6 = 12;
				object[] array2 = new object[num6];
				int num7 = 1;
				for (int i = 1; i < num5; i++)
				{
					int num8 = 0;
					string text = "";
					double quantity = 0.0;
					string text2 = "";
					double? fCR = null;
					double? fCRI = null;
					string text3 = "";
					int? prdUnitId = null;
					double? quantityTotal = null;
					int? prdUnitIdI = null;
					double? prdUnitIRateResult = null;
					string prdUnit = "";
					string prdUnitI = "";
					int? prdUnitIdII = null;
					double? prdUnitIIRateResult = null;
					string prdUnitII = "";
					bool hasConflict = false;
					string text4 = "";
					for (num8 = 0; num8 < num4; num8++)
					{
						if (num8 >= num6)
						{
							continue;
						}
						string text5 = "";
						array2[num8] = array[i, num8];
						if (array[0, num8] != null)
						{
							array[0, num8].ToString();
						}
						text5 = ((array2[num8] == null) ? "" : array2[num8].ToString());
						if (num8 == 0 && string.IsNullOrWhiteSpace(text5))
						{
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorEmptyDocItemImportExcel, Labels.DocItemImportExcelPrdCode) + "|";
						}
						else if (num8 == 0)
						{
							text = text5;
							continue;
						}
						if (num8 == 1 && string.IsNullOrWhiteSpace(text5))
						{
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorEmptyDocItemImportExcel, "\"" + Labels.DocItemImportExcelQuantity + "\"") + "|";
						}
						else if (num8 == 1)
						{
							double result3 = 0.0;
							double.TryParse(text5, out result3);
							if (result3 != 0.0)
							{
								quantity = result3;
								continue;
							}
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelQuantity + "\"") + "|";
						}
						switch (num8)
						{
						case 2:
							text2 = text5;
							continue;
						case 3:
							if (!string.IsNullOrWhiteSpace(text5))
							{
								double result4 = 0.0;
								double.TryParse(text5, out result4);
								if (result4 != 0.0)
								{
									fCR = result4;
									continue;
								}
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelFCR + "\"") + "|";
							}
							break;
						}
						if (num8 == 4 && !string.IsNullOrWhiteSpace(text5))
						{
							double result5 = 0.0;
							double.TryParse(text5, out result5);
							if (result5 != 0.0)
							{
								fCRI = result5;
								continue;
							}
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelFCRI + "\"") + "|";
						}
						if (num8 == 5 && text5.Length > 4000)
						{
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorFieldLength, Labels.DocItemImportExcelTracing, "200") + "|";
						}
						else if (num8 == 5)
						{
							text3 = text5;
							continue;
						}
						if (num8 == 6 && !string.IsNullOrWhiteSpace(text5))
						{
							int num3 = 0;
							int.TryParse(text5, out num3);
							if (num3 == 0)
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelPrdUnit + "\"") + "|";
							}
							else if (list2 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2))
							{
								WSspSelectProductUnits_Result wSspSelectProductUnits_Result = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => m.ProductUnitID == num3));
								if (wSspSelectProductUnits_Result != null)
								{
									prdUnit = wSspSelectProductUnits_Result.Unit ?? "";
									prdUnitId = num3;
									continue;
								}
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorIsWrong, "\"" + Labels.DocItemImportExcelPrdUnit + "\"") + "|";
							}
							else
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorIsWrong, "\"" + Labels.DocItemImportExcelPrdUnit + "\"") + "|";
							}
						}
						if (num8 == 7 && !string.IsNullOrWhiteSpace(text5))
						{
							double result6 = 0.0;
							double.TryParse(text5, out result6);
							if (result6 != 0.0)
							{
								quantityTotal = result6;
								continue;
							}
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelQuantityTotal + "\"") + "|";
						}
						if (num8 == 8 && !string.IsNullOrWhiteSpace(text5))
						{
							int num2 = 0;
							int.TryParse(text5, out num2);
							if (num2 == 0)
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelPrdUnitI + "\"") + "|";
							}
							else if (list2 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2))
							{
								WSspSelectProductUnits_Result wSspSelectProductUnits_Result2 = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => m.ProductUnitID == num2));
								if (wSspSelectProductUnits_Result2 != null)
								{
									prdUnitI = wSspSelectProductUnits_Result2.Unit ?? "";
									prdUnitIdI = num2;
									continue;
								}
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorIsWrong, "\"" + Labels.DocItemImportExcelPrdUnitI + "\"") + "|";
							}
							else
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorIsWrong, "\"" + Labels.DocItemImportExcelPrdUnitI + "\"") + "|";
							}
						}
						if (num8 == 9 && !string.IsNullOrWhiteSpace(text5))
						{
							double result7 = 0.0;
							double.TryParse(text5, out result7);
							if (result7 != 0.0)
							{
								prdUnitIRateResult = result7;
								continue;
							}
							hasConflict = true;
							text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelPrdUnitIRateResult + "\"") + "|";
						}
						if (num8 == 10 && !string.IsNullOrWhiteSpace(text5))
						{
							int num = 0;
							int.TryParse(text5, out num);
							if (num == 0)
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelPrdUnitII + "\"") + "|";
							}
							else if (list2 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2))
							{
								WSspSelectProductUnits_Result wSspSelectProductUnits_Result3 = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list2, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => m.ProductUnitID == num));
								if (wSspSelectProductUnits_Result3 != null)
								{
									prdUnitII = wSspSelectProductUnits_Result3.Unit ?? "";
									prdUnitIdII = num;
									continue;
								}
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorIsWrong, "\"" + Labels.DocItemImportExcelPrdUnitII + "\"") + "|";
							}
							else
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorIsWrong, "\"" + Labels.DocItemImportExcelPrdUnitII + "\"") + "|";
							}
						}
						if (num8 == 11 && !string.IsNullOrWhiteSpace(text5))
						{
							double result8 = 0.0;
							double.TryParse(text5, out result8);
							if (result8 == 0.0)
							{
								hasConflict = true;
								text4 = text4 + string.Format(Messages.msgErrorCheckDigitMoreThanZero, "\"" + Labels.DocItemImportExcelPrdUnitIIRateResult + "\"") + "|";
							}
							else
							{
								prdUnitIIRateResult = result8;
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 = text4.Replace("<br>", "").Replace("</br>", "").Replace("<br />", "")
							.Replace("<br/>", "");
					}
					list.Add(new WSDocItemImportExcelViewModel
					{
						RowNumber = num7,
						ProductId = 0,
						PrdName = "",
						PrdCode = (text ?? ""),
						Quantity = quantity,
						Description = (text2 ?? ""),
						FCR = fCR,
						FCRI = fCRI,
						Tracing = (text3 ?? ""),
						PrdUnitId = prdUnitId,
						PrdUnit = prdUnit,
						QuantityTotal = quantityTotal,
						PrdUnitIdI = prdUnitIdI,
						PrdUnitI = prdUnitI,
						PrdUnitIRateResult = prdUnitIRateResult,
						HasConflict = hasConflict,
						ConflictDesc = (text4 ?? ""),
						PrdUnitIdII = prdUnitIdII,
						PrdUnitII = prdUnitII,
						PrdUnitIIRateResult = prdUnitIIRateResult
					});
					num7++;
				}
				if (list != null && Enumerable.Any<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list))
				{
					ObjectParameter objectParameter = new ObjectParameter("result", "");
					string docItemJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list));
					_dbI.WSspCheckDocItemsBeforeImportExcel(docItemJson, docId, whId, (whIdI == 0) ? null : new int?(whIdI), position, UserLogin.CurrentUser.UserId, objectParameter, lCID, result, centerId);
					if (objectParameter.Value != null)
					{
						string text6 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text6))
						{
							list = new JavaScriptSerializer().Deserialize<List<WSDocItemImportExcelViewModel>>(text6);
							if (list != null && Enumerable.Any<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list))
							{
								foreach (WSDocItemImportExcelViewModel item in list)
								{
									string text7 = item.ConflictErrorDb ?? "";
									if (string.IsNullOrWhiteSpace(text7))
									{
										continue;
									}
									string[] array3 = text7.Split(new char[1] { '|' });
									if (!((array3 != null) & (array3.Length != 0)))
									{
										continue;
									}
									string[] array4 = array3;
									foreach (string text8 in array4)
									{
										if (string.IsNullOrWhiteSpace(text8))
										{
											continue;
										}
										if (text8 == "1")
										{
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotFound, Labels.DocItemImportExcelPrdCode) + "|";
										}
										if (text8 == "2")
										{
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotSpecified, Labels.DocItemImportExcelTracing) + "|";
										}
										if (text8 == "3")
										{
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + Messages.DraftQuantityRemainLimitExceeded + "|";
										}
										if (text8.IndexOf("4,", StringComparison.Ordinal) >= 0)
										{
											string[] array5 = text8.Split(new char[1] { ',' });
											string arg = "";
											if (array5 != null && array5.Length == 2)
											{
												arg = array5[1];
											}
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorQtyCanNotMoreWithoutDocItemQty, arg) + "|";
										}
										if (text8 == "5")
										{
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorCanNotAddNewTracingCode, item.Tracing ?? "") + "|";
										}
										if (text8.IndexOf("6,", StringComparison.Ordinal) >= 0)
										{
											string[] array6 = text8.Split(new char[1] { ',' });
											string arg2 = "";
											if (array6 != null && array6.Length == 2)
											{
												arg2 = array6[1];
											}
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorDocItemTracingDuplicate, arg2) + "|";
										}
										if (text8 == "7")
										{
											item.HasConflict = true;
											item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotFound, Labels.DocItemImportExcelTracing) + "|";
										}
										if (!string.IsNullOrWhiteSpace(item.ConflictDesc))
										{
											item.ConflictDesc = item.ConflictDesc.Replace("<br>", "").Replace("</br>", "").Replace("<br />", "")
												.Replace("<br/>", "");
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				FinishXlsJob(filePath);
			}
			FinishXlsJob(filePath);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			FinishXlsJob(filePath);
		}
		JsonResult jsonResult = Json(((IEnumerable)new List<WSDocItemImportExcelViewModel>[1] { list }).ToDataSourceResult(request));
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	private void FinishXlsJob(string FilePath = "")
	{
		try
		{
			if (System.IO.File.Exists(FilePath))
			{
				System.IO.File.Delete(FilePath);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public string DocItemsImportExcelFinalImport(string records, int docId, int whId, int whIdI, int position)
	{
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
		switch (position)
		{
		case 1:
			if (Doc.IsSentToLinkAccByAction(docId))
			{
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			break;
		case 2:
			if (Draft.IsSentToLinkAccByAction(docId))
			{
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			break;
		case 3:
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			break;
		}
		if (!string.IsNullOrWhiteSpace(records))
		{
			List<WSDocItemImportExcelViewModel> list = JsonConvert.DeserializeObject<List<WSDocItemImportExcelViewModel>>(records);
			List<WSDocItemImportExcelViewModel> list2 = new List<WSDocItemImportExcelViewModel>();
			if (list != null || Enumerable.Any<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list))
			{
				list2 = Enumerable.ToList<WSDocItemImportExcelViewModel>(Enumerable.Where<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list, (Func<WSDocItemImportExcelViewModel, bool>)((WSDocItemImportExcelViewModel m) => !m.HasConflict)));
			}
			if (list2 != null && list2.Count > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_ = UserLogin.CurrentUser.UserId;
				int id = Financial.Get().Id;
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				ObjectParameter objectParameter = new ObjectParameter("result", "");
				string docItemJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list2));
				List<WSDocItemImportExcelViewModel> list3 = new List<WSDocItemImportExcelViewModel>();
				_dbI.WSspImportDocItemsFromExcelMultiRec(docItemJson, docId, whId, (whIdI == 0) ? null : new int?(whIdI), position, UserLogin.CurrentUser.UserId, value, registerDatePersian, id, value2, appType, lCID, result2, objectParameter, centerId);
				if (objectParameter.Value != null)
				{
					string text = objectParameter.Value.ToString();
					if (!string.IsNullOrWhiteSpace(text))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<WSDocItemImportExcelViewModel>>(text);
						if (list3 != null && Enumerable.Any<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list3))
						{
							foreach (WSDocItemImportExcelViewModel item in list3)
							{
								string text2 = item.ConflictErrorDb ?? "";
								if (string.IsNullOrWhiteSpace(text2))
								{
									continue;
								}
								string[] array = text2.Split(new char[1] { '|' });
								if (!((array != null) & (array.Length != 0)))
								{
									continue;
								}
								string[] array2 = array;
								foreach (string text3 in array2)
								{
									if (string.IsNullOrWhiteSpace(text3))
									{
										continue;
									}
									if (text3 == "1")
									{
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotFound, Labels.DocItemImportExcelPrdCode) + "|";
									}
									if (text3 == "2")
									{
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotSpecified, Labels.DocItemImportExcelTracing) + "|";
									}
									if (text3 == "3")
									{
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + Messages.DraftQuantityRemainLimitExceeded + "|";
									}
									if (text3.IndexOf("4,", StringComparison.Ordinal) >= 0)
									{
										string[] array3 = text3.Split(new char[1] { ',' });
										string arg = "";
										if (array3 != null && array3.Length == 2)
										{
											arg = array3[1];
										}
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorQtyCanNotMoreWithoutDocItemQty, arg) + "|";
									}
									if (text3 == "5")
									{
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorCanNotAddNewTracingCode, item.Tracing ?? "") + "|";
									}
									if (text3.IndexOf("6,", StringComparison.Ordinal) >= 0)
									{
										string[] array4 = text3.Split(new char[1] { ',' });
										string arg2 = "";
										if (array4 != null && array4.Length == 2)
										{
											arg2 = array4[1];
										}
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorDocItemTracingDuplicate, arg2) + "|";
									}
									if (text3 == "7")
									{
										item.HasConflict = true;
										item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotFound, Labels.DocItemImportExcelTracing) + "|";
									}
									if (!string.IsNullOrWhiteSpace(item.ConflictDesc))
									{
										item.ConflictDesc = item.ConflictDesc.Replace("<br>", "").Replace("</br>", "").Replace("<br />", "")
											.Replace("<br/>", "");
									}
								}
							}
						}
					}
				}
				if (list3 != null && Enumerable.Any<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)list3))
				{
					string text4 = "";
					text4 = GetFileErrorDocItemImportExcel(list3);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						result = Messages.msgNotCompeleteSuccessAction;
						result = result + "<br><a href='" + text4 + "' class='link-excel-file'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
					}
				}
				else
				{
					result = "";
				}
			}
			else
			{
				result = Messages.ErrorNotFindRecord;
			}
		}
		else
		{
			result = Messages.ErrorNotFindRecord;
		}
		return result;
	}

	public string GetFileErrorDocItemImportExcel(List<WSDocItemImportExcelViewModel> res)
	{
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<WSDocItemImportExcelViewModel>((IEnumerable<WSDocItemImportExcelViewModel>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("KaraAfzarIdeal");
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdCode;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelQuantity;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelDesc;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelFCR;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelFCRI;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelTracing;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnit;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelQuantityTotal;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitI;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitIRateResult;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitII;
				num++;
				excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelPrdUnitIIRateResult;
				foreach (WSDocItemImportExcelViewModel re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.Quantity.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.Description ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.FCR.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[1, num].Value = Labels.DocItemImportExcelFCRI;
					excelWorksheet.Cells[num2, num].Value = re.FCRI.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.Tracing ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdUnitId.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.QuantityTotal.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdUnitIdI.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdUnitIRateResult.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.ConflictDesc ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdUnitIdII.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdUnitIIRateResult.GetValueOrDefault().ToString();
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportDocItemsImportExcel\\" + UserLogin.CurrentUser.UserId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.CmpImportExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.CmpImportExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportDocItemsImportExcel/" + userId + "/" + text3;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetAllProductInfo(int prdId)
	{
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals0.prdId = prdId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentAllProductInfoViewModel currentAllProductInfoViewModel = new CurrentAllProductInfoViewModel();
		currentAllProductInfoViewModel.PrdNickname_Lang = "";
		currentAllProductInfoViewModel.Description_Lang = "";
		try
		{
			if (CS_0024_003C_003E8__locals0.prdId != 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(CS_0024_003C_003E8__locals0.prdId, result, result));
				DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts_Lang), "c");
				List<WSProducts_Lang> list = Enumerable.ToList<WSProducts_Lang>((IEnumerable<WSProducts_Lang>)Queryable.Where<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass39_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				if (wSspSelectProductsWithId_Result != null)
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (list != null)
					{
						list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.PrdNickname,
							LanguageId = item.LanguageID
						})));
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSspSelectProductsWithId_Result.PrdNickname,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (list != null)
					{
						list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.PrdDescription,
							LanguageId = item.LanguageID
						})));
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = wSspSelectProductsWithId_Result.PrdDescription,
						LanguageId = result
					});
					currentAllProductInfoViewModel.PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					currentAllProductInfoViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				}
				currentAllProductInfoViewModel.ProductId = CS_0024_003C_003E8__locals0.prdId;
				currentAllProductInfoViewModel.IsFind = true;
				currentAllProductInfoViewModel.Message = "";
			}
			else
			{
				currentAllProductInfoViewModel.IsFind = false;
				currentAllProductInfoViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			currentAllProductInfoViewModel.IsFind = false;
			currentAllProductInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(currentAllProductInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
