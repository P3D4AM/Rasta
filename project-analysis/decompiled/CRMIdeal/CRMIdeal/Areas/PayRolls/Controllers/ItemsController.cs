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

namespace CRMIdeal.Areas.PayRolls.Controllers;

public class ItemsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int itemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int id;

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
		public PayRollItemsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__6;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public PayRollItems model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_3
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
		public int itemId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPayRollItems")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetItemTypes()
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
			List<PayRollspSelectItemTypes_Result> list2 = Enumerable.ToList<PayRollspSelectItemTypes_Result>((IEnumerable<PayRollspSelectItemTypes_Result>)_db.PayRollspSelectItemTypes(lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectItemTypes_Result, SelectListItem>((IEnumerable<PayRollspSelectItemTypes_Result>)list2, (Func<PayRollspSelectItemTypes_Result, SelectListItem>)((PayRollspSelectItemTypes_Result item) => new SelectListItem
			{
				Text = item.ItemType,
				Value = item.PayRollItemTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ItemTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public List<SelectListItem> GetMonth()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
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
				Value = "1",
				Text = Labels.FirstMonth
			});
			list.Add(new SelectListItem
			{
				Value = "2",
				Text = Labels.SecondMonth
			});
			list.Add(new SelectListItem
			{
				Value = "3",
				Text = Labels.ThirdMonth
			});
			list.Add(new SelectListItem
			{
				Value = "4",
				Text = Labels.FourthMonth
			});
			list.Add(new SelectListItem
			{
				Value = "5",
				Text = Labels.FifthMonth
			});
			list.Add(new SelectListItem
			{
				Value = "6",
				Text = Labels.SixthMonth
			});
			list.Add(new SelectListItem
			{
				Value = "7",
				Text = Labels.SeventhMonth
			});
			list.Add(new SelectListItem
			{
				Value = "8",
				Text = Labels.EighthMonth
			});
			list.Add(new SelectListItem
			{
				Value = "9",
				Text = Labels.NinthMonth
			});
			list.Add(new SelectListItem
			{
				Value = "10",
				Text = Labels.TenthMonth
			});
			list.Add(new SelectListItem
			{
				Value = "11",
				Text = Labels.EleventhMonth
			});
			list.Add(new SelectListItem
			{
				Value = "12",
				Text = Labels.TwelfthMonth
			});
			list2.AddRange(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.MonthList = list;
		base.ViewBag.MonthListI = list2;
		return list;
	}

	[AjaxOnly]
	public ActionResult PayRollItems_Read([DataSourceRequest] DataSourceRequest request, int kind)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<PayRollItemsLanguageViewModel> list = new List<PayRollItemsLanguageViewModel>();
		try
		{
			string payRollItemKindAdditive = Labels.PayRollItemKindAdditive;
			string payRollItemKindReduction = Labels.PayRollItemKindReduction;
			List<PayRollspSelectItems_Result> list2 = new List<PayRollspSelectItems_Result>();
			list2 = ((kind != 0) ? Enumerable.ToList<PayRollspSelectItems_Result>(Enumerable.Where<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)_db.PayRollspSelectItems(payRollItemKindAdditive, payRollItemKindReduction, lCID, result), (Func<PayRollspSelectItems_Result, bool>)((PayRollspSelectItems_Result model) => model.ItemKind == kind))) : Enumerable.ToList<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)_db.PayRollspSelectItems(payRollItemKindAdditive, payRollItemKindReduction, lCID, result)));
			List<SelectListItem> month = GetMonth();
			foreach (PayRollspSelectItems_Result item in list2)
			{
				PayRollItemsLanguageViewModel payRollItemsLanguageViewModel = new PayRollItemsLanguageViewModel();
				payRollItemsLanguageViewModel.PayRollItemId = item.PayRollItemId;
				payRollItemsLanguageViewModel.ItemName = item.ItemName;
				payRollItemsLanguageViewModel.ItemKind = item.ItemKind;
				payRollItemsLanguageViewModel.ItemTypeId = item.ItemTypeId;
				payRollItemsLanguageViewModel.ItemDefaultValue = item.ItemDefaultValue;
				payRollItemsLanguageViewModel.ItemFormulaTag = item.ItemFormulaTag;
				payRollItemsLanguageViewModel.ItemFormula = item.ItemFormula;
				payRollItemsLanguageViewModel.ItemJustForShow = item.ItemJustForShow;
				payRollItemsLanguageViewModel.ItemIsActive = item.ItemIsActive;
				payRollItemsLanguageViewModel.ItemOrderView = item.ItemOrderView;
				payRollItemsLanguageViewModel.FirstRegisterUserId = item.FirstRegisterUserId;
				payRollItemsLanguageViewModel.FirstRegisterDate = item.FirstRegisterDate;
				payRollItemsLanguageViewModel.FirstRegisterDatePersian = item.FirstRegisterDatePersian;
				payRollItemsLanguageViewModel.UserId = item.UserId;
				payRollItemsLanguageViewModel.RegisterDate = item.RegisterDate;
				payRollItemsLanguageViewModel.RegisterDatePersian = item.RegisterDatePersian;
				payRollItemsLanguageViewModel.Year1 = item.Year1;
				payRollItemsLanguageViewModel.Month1 = item.Month1;
				payRollItemsLanguageViewModel.GUId = item.GUId;
				payRollItemsLanguageViewModel.LanguageID = item.LanguageID;
				payRollItemsLanguageViewModel.ItemKindName = item.ItemKindName;
				payRollItemsLanguageViewModel.ItemType = item.ItemType;
				_ = item.FirstRegisterDate;
				payRollItemsLanguageViewModel.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = item.RegisterDate;
				payRollItemsLanguageViewModel.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				payRollItemsLanguageViewModel.FirstRegisterUser = item.FirstRegisterUser ?? "";
				payRollItemsLanguageViewModel.EditUser = item.EditUser ?? "";
				payRollItemsLanguageViewModel.ItemNotVisiblePrint = item.ItemNotVisiblePrint;
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				payRollItemsLanguageViewModel.AppType = Configuration.GetAppType(item.AppType);
				payRollItemsLanguageViewModel.FirstRegisterUser = payRollItemsLanguageViewModel.FirstRegisterUser + " (" + payRollItemsLanguageViewModel.FirstRegisterDatePersian + ")";
				string text = (string.IsNullOrEmpty(payRollItemsLanguageViewModel.AppType) ? "" : (" (" + Labels.AppType + ": " + payRollItemsLanguageViewModel.AppType + ") "));
				PayRollItemsLanguageViewModel payRollItemsLanguageViewModel2 = payRollItemsLanguageViewModel;
				payRollItemsLanguageViewModel2.EditUser = payRollItemsLanguageViewModel2.EditUser + text + "(" + payRollItemsLanguageViewModel.RegisterDatePersian + ")";
				payRollItemsLanguageViewModel.ItemDurStartDay = item.ItemDurStartDay;
				payRollItemsLanguageViewModel.ItemDurStartMonth = item.ItemDurStartMonth;
				payRollItemsLanguageViewModel.ItemCopyInCycle = item.ItemCopyInCycle;
				payRollItemsLanguageViewModel.ItemDescCopyInCycle = item.ItemDescCopyInCycle;
				int durStartMonth = 0;
				int.TryParse(payRollItemsLanguageViewModel.ItemDurStartMonth.ToString(), out durStartMonth);
				if (durStartMonth != 0 && month != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)month))
				{
					SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)month, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == durStartMonth.ToString()));
					if (selectListItem != null)
					{
						payRollItemsLanguageViewModel.ItemDurStartMonthName = selectListItem.Text ?? "";
					}
				}
				payRollItemsLanguageViewModel.ItemDurEndDay = item.ItemDurEndDay;
				payRollItemsLanguageViewModel.ItemDurEndMonth = item.ItemDurEndMonth;
				int durEndMonth = 0;
				int.TryParse(payRollItemsLanguageViewModel.ItemDurEndMonth.ToString(), out durEndMonth);
				if (durEndMonth != 0 && month != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)month))
				{
					SelectListItem selectListItem2 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)month, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == durEndMonth.ToString()));
					if (selectListItem2 != null)
					{
						payRollItemsLanguageViewModel.ItemDurEndMonthName = selectListItem2.Text ?? "";
					}
				}
				list.Add(payRollItemsLanguageViewModel);
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

	[DynamicAuthorize(ControllerName = "frmPayRollItems", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		int userId = UserLogin.CurrentUser.UserId;
		PayRollItemsLanguageViewModel payRollItemsLanguageViewModel = new PayRollItemsLanguageViewModel();
		GetItemTypes();
		GetMonth();
		try
		{
			if (CS_0024_003C_003E8__locals0.id > 0)
			{
				if (!UserLogin.IsUserAccess("frmPayRollItems", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<PayRollItems_Lang> payRollItems_Lang = _dbTbl.PayRollItems_Lang;
				ParameterExpression val = Expression.Parameter(typeof(PayRollItems_Lang), "m");
				List<PayRollItems_Lang> list = Enumerable.ToList<PayRollItems_Lang>((IEnumerable<PayRollItems_Lang>)Queryable.Where<PayRollItems_Lang>((IQueryable<PayRollItems_Lang>)payRollItems_Lang, Expression.Lambda<Func<PayRollItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<PayRollItems> payRollItems = _dbTbl.PayRollItems;
				val = Expression.Parameter(typeof(PayRollItems), "m");
				PayRollItems payRollItems2 = Queryable.FirstOrDefault<PayRollItems>((IQueryable<PayRollItems>)payRollItems, Expression.Lambda<Func<PayRollItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (payRollItems2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<PayRollItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<PayRollItems_Lang>)list, (Func<PayRollItems_Lang, CommonMultiLanguageViewModel>)((PayRollItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ItemName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = payRollItems2.ItemName,
					LanguageId = result
				});
				payRollItemsLanguageViewModel = new PayRollItemsLanguageViewModel
				{
					PayRollItemId = payRollItems2.PayRollItemId,
					ItemName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					ItemName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					ItemKind = payRollItems2.ItemKind,
					ItemTypeId = payRollItems2.ItemTypeId,
					ItemDefaultValue = payRollItems2.ItemDefaultValue,
					ItemFormulaTag = payRollItems2.ItemFormulaTag,
					ItemFormula = payRollItems2.ItemFormula,
					ItemJustForShow = payRollItems2.ItemJustForShow,
					ItemIsActive = payRollItems2.ItemIsActive,
					ItemOrderView = payRollItems2.ItemOrderView,
					FirstRegisterUserId = payRollItems2.FirstRegisterUserId,
					FirstRegisterDate = payRollItems2.FirstRegisterDate,
					FirstRegisterDatePersian = payRollItems2.FirstRegisterDatePersian,
					UserId = payRollItems2.UserId,
					RegisterDate = payRollItems2.RegisterDate,
					RegisterDatePersian = payRollItems2.RegisterDatePersian,
					Year1 = payRollItems2.Year1,
					Month1 = payRollItems2.Month1,
					GUId = payRollItems2.GUId,
					AppType = payRollItems2.AppType,
					LanguageID = payRollItems2.LanguageID,
					ItemNotVisiblePrint = payRollItems2.ItemNotVisiblePrint,
					ItemDurStartDay = payRollItems2.ItemDurStartDay,
					ItemDurStartMonth = payRollItems2.ItemDurStartMonth,
					ItemCopyInCycle = payRollItems2.ItemCopyInCycle,
					ItemDescCopyInCycle = payRollItems2.ItemDescCopyInCycle,
					ItemDurEndDay = payRollItems2.ItemDurEndDay,
					ItemDurEndMonth = payRollItems2.ItemDurEndMonth
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmPayRollItems", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				payRollItemsLanguageViewModel = new PayRollItemsLanguageViewModel
				{
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = userId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					ItemKind = 1,
					ItemIsActive = true,
					ItemCopyInCycle = true,
					ItemDescCopyInCycle = true
				};
				string payRollItemKindAdditive = Labels.PayRollItemKindAdditive;
				string payRollItemKindReduction = Labels.PayRollItemKindReduction;
				List<PayRollspSelectItems_Result> list3 = Enumerable.ToList<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)_db.PayRollspSelectItems(payRollItemKindAdditive, payRollItemKindReduction, CS_0024_003C_003E8__locals0.currLangID, result));
				if (list3 == null)
				{
					list3 = new List<PayRollspSelectItems_Result>();
				}
				if (!Enumerable.Any<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list3))
				{
					payRollItemsLanguageViewModel.ItemOrderView = 10;
				}
				else
				{
					int num = (Enumerable.Any<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list3) ? Enumerable.Count<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list3) : 0);
					payRollItemsLanguageViewModel.ItemOrderView = num * 10 + 10;
					if (Enumerable.LastOrDefault<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list3) != null)
					{
						int valueOrDefault = Enumerable.LastOrDefault<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list3).ItemOrderView.GetValueOrDefault();
						if (valueOrDefault > 0)
						{
							payRollItemsLanguageViewModel.ItemOrderView = valueOrDefault + 10;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(payRollItemsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmPayRollItemDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(PayRollItemsLanguageViewModel vm)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetItemTypes();
		GetMonth();
		string appType = CS_0024_003C_003E8__locals0.vm.AppType;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ItemName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ItemName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.ItemName,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.ItemName == null && CS_0024_003C_003E8__locals0.vm.ItemName == "")
		{
			text = text + string.Format(Messages.ErrorEmpty, Labels.PayRollItemName) + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ItemName, list))
		{
			text = text + string.Format(Messages.CheckFieldInLang, Labels.PayRollItemName) + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		else
		{
			_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
			_003C_003Ec__DisplayClass8_.model = new PayRollItems();
			if (CS_0024_003C_003E8__locals0.vm.PayRollItemId > 0)
			{
				DbSet<PayRollItems> payRollItems = _dbTbl.PayRollItems;
				ParameterExpression val = Expression.Parameter(typeof(PayRollItems), "m");
				_003C_003Ec__DisplayClass8_.model = Queryable.FirstOrDefault<PayRollItems>((IQueryable<PayRollItems>)payRollItems, Expression.Lambda<Func<PayRollItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType2 = Configuration.AppType;
			short year = short.Parse(Financial.Get().Id.ToString());
			_003C_003Ec__DisplayClass8_.model.ItemName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			_003C_003Ec__DisplayClass8_.model.ItemKind = CS_0024_003C_003E8__locals0.vm.ItemKind;
			_003C_003Ec__DisplayClass8_.model.ItemTypeId = CS_0024_003C_003E8__locals0.vm.ItemTypeId;
			_003C_003Ec__DisplayClass8_.model.ItemDefaultValue = CS_0024_003C_003E8__locals0.vm.ItemDefaultValue;
			_003C_003Ec__DisplayClass8_.model.ItemFormulaTag = CS_0024_003C_003E8__locals0.vm.ItemFormulaTag;
			_003C_003Ec__DisplayClass8_.model.ItemFormula = CS_0024_003C_003E8__locals0.vm.ItemFormula;
			if (CS_0024_003C_003E8__locals0.vm.ItemTypeId == 15)
			{
				CS_0024_003C_003E8__locals0.vm.ItemJustForShow = true;
			}
			_003C_003Ec__DisplayClass8_.model.ItemJustForShow = CS_0024_003C_003E8__locals0.vm.ItemJustForShow;
			_003C_003Ec__DisplayClass8_.model.ItemIsActive = CS_0024_003C_003E8__locals0.vm.ItemIsActive;
			_003C_003Ec__DisplayClass8_.model.UserId = userId;
			_003C_003Ec__DisplayClass8_.model.Year1 = year;
			_003C_003Ec__DisplayClass8_.model.Month1 = month;
			_003C_003Ec__DisplayClass8_.model.RegisterDate = dateTime;
			_003C_003Ec__DisplayClass8_.model.RegisterDatePersian = text2;
			_003C_003Ec__DisplayClass8_.model.AppType = appType2;
			_003C_003Ec__DisplayClass8_.model.ItemNotVisiblePrint = CS_0024_003C_003E8__locals0.vm.ItemNotVisiblePrint;
			_003C_003Ec__DisplayClass8_.model.ItemDurStartDay = CS_0024_003C_003E8__locals0.vm.ItemDurStartDay;
			_003C_003Ec__DisplayClass8_.model.ItemDurStartMonth = CS_0024_003C_003E8__locals0.vm.ItemDurStartMonth;
			_003C_003Ec__DisplayClass8_.model.ItemCopyInCycle = CS_0024_003C_003E8__locals0.vm.ItemCopyInCycle;
			_003C_003Ec__DisplayClass8_.model.ItemDescCopyInCycle = CS_0024_003C_003E8__locals0.vm.ItemDescCopyInCycle;
			_003C_003Ec__DisplayClass8_.model.ItemDurEndDay = CS_0024_003C_003E8__locals0.vm.ItemDurEndDay;
			_003C_003Ec__DisplayClass8_.model.ItemDurEndMonth = CS_0024_003C_003E8__locals0.vm.ItemDurEndMonth;
			if (!CS_0024_003C_003E8__locals0.vm.ItemOrderView.HasValue)
			{
				string payRollItemKindAdditive = Labels.PayRollItemKindAdditive;
				string payRollItemKindReduction = Labels.PayRollItemKindReduction;
				List<PayRollspSelectItems_Result> list2 = Enumerable.ToList<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)_db.PayRollspSelectItems(payRollItemKindAdditive, payRollItemKindReduction, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (list2 == null)
				{
					list2 = new List<PayRollspSelectItems_Result>();
				}
				if (!Enumerable.Any<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list2))
				{
					CS_0024_003C_003E8__locals0.vm.ItemOrderView = 10;
				}
				else
				{
					int num = (Enumerable.Any<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list2) ? Enumerable.Count<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list2) : 0);
					CS_0024_003C_003E8__locals0.vm.ItemOrderView = num * 10 + 10;
					if (Enumerable.LastOrDefault<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list2) != null)
					{
						int valueOrDefault = Enumerable.LastOrDefault<PayRollspSelectItems_Result>((IEnumerable<PayRollspSelectItems_Result>)list2).ItemOrderView.GetValueOrDefault();
						if (valueOrDefault > 0)
						{
							CS_0024_003C_003E8__locals0.vm.ItemOrderView = valueOrDefault + 10;
						}
					}
				}
			}
			_003C_003Ec__DisplayClass8_.model.ItemOrderView = CS_0024_003C_003E8__locals0.vm.ItemOrderView;
			try
			{
				if (CS_0024_003C_003E8__locals0.vm.PayRollItemId <= 0)
				{
					_003C_003Ec__DisplayClass8_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDate = dateTime;
					_003C_003Ec__DisplayClass8_.model.FirstRegisterDatePersian = text2;
					_003C_003Ec__DisplayClass8_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass8_.model.GUId = Guid.NewGuid();
					_dbTbl.PayRollItems.Add(_003C_003Ec__DisplayClass8_.model);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						PayRollItems_Lang payRollItems_Lang = new PayRollItems_Lang();
						payRollItems_Lang.LanguageID = lang.LanguageID;
						payRollItems_Lang.PayRollItemId = _003C_003Ec__DisplayClass8_.model.PayRollItemId;
						payRollItems_Lang.ItemName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.PayRollItems_Lang.Add(payRollItems_Lang);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("PayRollItems");
					CS_0024_003C_003E8__locals0.vm.PayRollItemId = _003C_003Ec__DisplayClass8_.model.PayRollItemId;
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass8_.model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass8_3();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
							CS_0024_003C_003E8__locals2.lang = enumerator.Current;
							DbSet<PayRollItems_Lang> payRollItems_Lang2 = _dbTbl.PayRollItems_Lang;
							ParameterExpression val = Expression.Parameter(typeof(PayRollItems_Lang), "c");
							PayRollItems_Lang payRollItems_Lang3 = Queryable.FirstOrDefault<PayRollItems_Lang>((IQueryable<PayRollItems_Lang>)payRollItems_Lang2, Expression.Lambda<Func<PayRollItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (payRollItems_Lang3 != null)
							{
								payRollItems_Lang3.ItemName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.Entry(payRollItems_Lang3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							payRollItems_Lang3 = new PayRollItems_Lang();
							payRollItems_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
							payRollItems_Lang3.PayRollItemId = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.PayRollItemId;
							payRollItems_Lang3.ItemName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							_dbTbl.PayRollItems_Lang.Add(payRollItems_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("PayRollItems");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
				base.ViewBag.Error = Messages.msgErrorRunFunction;
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.msgErrorRunFunction;
			}
		}
		CS_0024_003C_003E8__locals0.vm.AppType = appType;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollItems", ActionName = "actDelete")]
	public JsonResult ActDelete(int itemId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.itemId = itemId;
		string data = "";
		try
		{
			DbSet<PayRollItems> payRollItems = _dbTbl.PayRollItems;
			ParameterExpression val = Expression.Parameter(typeof(PayRollItems), "m");
			if (Queryable.FirstOrDefault<PayRollItems>((IQueryable<PayRollItems>)payRollItems, Expression.Lambda<Func<PayRollItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				_db.PayRollspDeleteItem(_003C_003Ec__DisplayClass9_.itemId);
				DbSet<PayRollItems> payRollItems2 = _dbTbl.PayRollItems;
				val = Expression.Parameter(typeof(PayRollItems), "m");
				if (Queryable.FirstOrDefault<PayRollItems>((IQueryable<PayRollItems>)payRollItems2, Expression.Lambda<Func<PayRollItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("PayRollItems");
					data = "ok";
				}
				else
				{
					data = "redun";
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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

	[DynamicAuthorize(ControllerName = "frmPayRollItems", ActionName = "actMakeFormula")]
	public ActionResult CreateFormula(int itemId = 0)
	{
		GetIncItems(itemId);
		GetDecItems(itemId);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetDecItems(int itemId = 0)
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
			string payRollItemKindAdditive = Labels.PayRollItemKindAdditive;
			string payRollItemKindReduction = Labels.PayRollItemKindReduction;
			List<PayRollspSelectDecItemsForFormula_Result> list2 = Enumerable.ToList<PayRollspSelectDecItemsForFormula_Result>((IEnumerable<PayRollspSelectDecItemsForFormula_Result>)_dbII.PayRollspSelectDecItemsForFormula(itemId, payRollItemKindAdditive, payRollItemKindReduction, lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectDecItemsForFormula_Result, SelectListItem>((IEnumerable<PayRollspSelectDecItemsForFormula_Result>)list2, (Func<PayRollspSelectDecItemsForFormula_Result, SelectListItem>)((PayRollspSelectDecItemsForFormula_Result item) => new SelectListItem
			{
				Text = item.ItemName + " (" + item.ItemFormulaTag + ")",
				Value = (item.ItemFormulaTag ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ItemKindReductionList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetIncItems(int itemId = 0)
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
			string payRollItemKindAdditive = Labels.PayRollItemKindAdditive;
			string payRollItemKindReduction = Labels.PayRollItemKindReduction;
			List<PayRollspSelectIncItemsForFormula_Result> list2 = Enumerable.ToList<PayRollspSelectIncItemsForFormula_Result>((IEnumerable<PayRollspSelectIncItemsForFormula_Result>)_dbII.PayRollspSelectIncItemsForFormula(itemId, payRollItemKindAdditive, payRollItemKindReduction, lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectIncItemsForFormula_Result, SelectListItem>((IEnumerable<PayRollspSelectIncItemsForFormula_Result>)list2, (Func<PayRollspSelectIncItemsForFormula_Result, SelectListItem>)((PayRollspSelectIncItemsForFormula_Result item) => new SelectListItem
			{
				Text = item.ItemName + " (" + item.ItemFormulaTag + ")",
				Value = (item.ItemFormulaTag ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ItemKindAdditiveList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string UpdateItemFormula(int itemId, string itemFormula)
	{
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.itemId = itemId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPayRollMakeFormula", "actPost", currentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DbSet<PayRollItems> payRollItems = _dbTbl.PayRollItems;
			ParameterExpression val = Expression.Parameter(typeof(PayRollItems), "m");
			PayRollItems payRollItems2 = Queryable.FirstOrDefault<PayRollItems>((IQueryable<PayRollItems>)payRollItems, Expression.Lambda<Func<PayRollItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (payRollItems2 != null)
			{
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime registerDate = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short year = short.Parse(Financial.Get().Id.ToString());
				payRollItems2.UserId = userId;
				payRollItems2.RegisterDate = registerDate;
				payRollItems2.RegisterDatePersian = registerDatePersian;
				payRollItems2.Year1 = year;
				payRollItems2.Month1 = month;
				payRollItems2.AppType = appType;
				payRollItems2.ItemFormula = itemFormula;
				_dbTbl.Entry(payRollItems2).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				return "";
			}
			return Messages.msgNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
