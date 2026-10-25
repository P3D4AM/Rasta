using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace CRMIdeal.Areas.Products.Controllers;

public class UnitsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
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

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public WSProductUnitsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__21;

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

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int id;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdUnits")]
	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSProductUnitsLanguageViewModel model = null;
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			DbSet<WSProductUnits_Lang> wSProductUnits_Lang = _dbTbl.WSProductUnits_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSProductUnits_Lang), "c");
			List<WSProductUnits_Lang> list = Enumerable.ToList<WSProductUnits_Lang>((IEnumerable<WSProductUnits_Lang>)Queryable.Where<WSProductUnits_Lang>((IQueryable<WSProductUnits_Lang>)wSProductUnits_Lang, Expression.Lambda<Func<WSProductUnits_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			WSProductUnits wSProductUnits = _dbTbl.WSProductUnits.Find(CS_0024_003C_003E8__locals0.id);
			if (wSProductUnits != null)
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductUnits_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductUnits_Lang>)list, (Func<WSProductUnits_Lang, CommonMultiLanguageViewModel>)((WSProductUnits_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Unit,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductUnits.Unit,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductUnits_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductUnits_Lang>)list, (Func<WSProductUnits_Lang, CommonMultiLanguageViewModel>)((WSProductUnits_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SHPUnit,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductUnits.SHPUnit,
					LanguageId = result
				});
				model = new WSProductUnitsLanguageViewModel
				{
					Month1 = wSProductUnits.Month1,
					LanguageID = wSProductUnits.LanguageID,
					UserId = wSProductUnits.UserId,
					FirstRegisterUserId = wSProductUnits.FirstRegisterUserId,
					FirstRegisterDatePersian = wSProductUnits.FirstRegisterDatePersian,
					FirstRegisterDate = wSProductUnits.FirstRegisterDate,
					RegisterDate = wSProductUnits.RegisterDate,
					RegisterDatePersian = wSProductUnits.RegisterDatePersian,
					AppType = wSProductUnits.AppType,
					GUId = wSProductUnits.GUId,
					UnitEn = wSProductUnits.UnitEn,
					Description = wSProductUnits.Description,
					QuantityInUnit = wSProductUnits.QuantityInUnit,
					ProductUnitID = wSProductUnits.ProductUnitID,
					FCR = wSProductUnits.FCR,
					Unit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Unit_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					FCRI = wSProductUnits.FCRI,
					SHPUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					SHPUnit_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					TspUnitCode = wSProductUnits.TspUnitCode,
					UnitIFormula = wSProductUnits.UnitIFormula,
					UnitIIFormula = wSProductUnits.UnitIIFormula
				};
			}
		}
		else
		{
			model = new WSProductUnitsLanguageViewModel();
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSProductUnitsLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Unit_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Unit_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Unit,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SHPUnit_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SHPUnit_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.SHPUnit,
			LanguageId = lCID
		});
		try
		{
			string text = "";
			if (CS_0024_003C_003E8__locals0.vm.Unit == null && CS_0024_003C_003E8__locals0.vm.Unit == "")
			{
				text = text + Messages.CheckUnit + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Unit, list))
			{
				text = text + Messages.CheckUnitLang + "<br>";
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			DateTime now = DateTime.Now;
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.UnitIFormula))
				{
					CS_0024_003C_003E8__locals0.vm.UnitIFormula = "{\"result\":\"sub1\",\"expression\":{\"type\":\"operator\",\"operator\":\"*\",\"left\":{\"type\":\"group\",\"expression\":{\"type\":\"operator\",\"operator\":\"/\",\"left\":{\"type\":\"constant\",\"value\":1},\"right\":{\"type\":\"variable\",\"name\":\"rate1\"}}},\"right\":{\"type\":\"variable\",\"name\":\"quantity\"}}}";
				}
				if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.UnitIIFormula))
				{
					CS_0024_003C_003E8__locals0.vm.UnitIIFormula = "{\"result\":\"sub2\",\"expression\":{\"type\":\"operator\",\"operator\":\"*\",\"left\":{\"type\":\"group\",\"expression\":{\"type\":\"operator\",\"operator\":\"/\",\"left\":{\"type\":\"constant\",\"value\":1},\"right\":{\"type\":\"variable\",\"name\":\"rate2\"}}},\"right\":{\"type\":\"variable\",\"name\":\"quantity\"}}}";
				}
				if (CS_0024_003C_003E8__locals0.vm.ProductUnitID > 0)
				{
					DbSet<WSProductUnits> wSProductUnits = _dbTbl.WSProductUnits;
					ParameterExpression val = Expression.Parameter(typeof(WSProductUnits), "c");
					WSProductUnits wSProductUnits2 = Queryable.FirstOrDefault<WSProductUnits>((IQueryable<WSProductUnits>)wSProductUnits, Expression.Lambda<Func<WSProductUnits, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					wSProductUnits2.UserId = UserLogin.CurrentUser.UserId;
					wSProductUnits2.RegisterDate = now;
					wSProductUnits2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductUnits2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSProductUnits2.AppType = Configuration.AppType;
					wSProductUnits2.UnitEn = CS_0024_003C_003E8__locals0.vm.UnitEn;
					wSProductUnits2.Description = CS_0024_003C_003E8__locals0.vm.Description;
					wSProductUnits2.FCR = CS_0024_003C_003E8__locals0.vm.FCR;
					wSProductUnits2.FCRI = CS_0024_003C_003E8__locals0.vm.FCRI;
					wSProductUnits2.QuantityInUnit = CS_0024_003C_003E8__locals0.vm.QuantityInUnit;
					wSProductUnits2.Unit = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProductUnits2.SHPUnit = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProductUnits2.TspUnitCode = CS_0024_003C_003E8__locals0.vm.TspUnitCode;
					wSProductUnits2.UnitIFormula = CS_0024_003C_003E8__locals0.vm.UnitIFormula;
					wSProductUnits2.UnitIIFormula = CS_0024_003C_003E8__locals0.vm.UnitIIFormula;
					_dbTbl.Entry(wSProductUnits2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProductUnits_Lang> wSProductUnits_Lang = _dbTbl.WSProductUnits_Lang;
							val = Expression.Parameter(typeof(WSProductUnits_Lang), "c");
							WSProductUnits_Lang wSProductUnits_Lang2 = Queryable.FirstOrDefault<WSProductUnits_Lang>((IQueryable<WSProductUnits_Lang>)wSProductUnits_Lang, Expression.Lambda<Func<WSProductUnits_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProductUnits_Lang2 != null)
							{
								wSProductUnits_Lang2.Unit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProductUnits_Lang2.SHPUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProductUnits_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProductUnits_Lang2 = new WSProductUnits_Lang();
							wSProductUnits_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wSProductUnits_Lang2.ProductUnitID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.vm.ProductUnitID;
							wSProductUnits_Lang2.Unit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wSProductUnits_Lang2.SHPUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WSProductUnits_Lang.Add(wSProductUnits_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					WSProductUnits wSProductUnits3 = new WSProductUnits
					{
						GUId = Guid.NewGuid(),
						UserId = UserLogin.CurrentUser.UserId,
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						AppType = Configuration.AppType,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						LanguageID = CS_0024_003C_003E8__locals0.defLangID,
						UnitEn = CS_0024_003C_003E8__locals0.vm.UnitEn,
						Description = CS_0024_003C_003E8__locals0.vm.Description,
						FCR = CS_0024_003C_003E8__locals0.vm.FCR,
						FCRI = CS_0024_003C_003E8__locals0.vm.FCRI,
						QuantityInUnit = CS_0024_003C_003E8__locals0.vm.QuantityInUnit,
						Unit = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
						SHPUnit = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
						TspUnitCode = CS_0024_003C_003E8__locals0.vm.TspUnitCode,
						UnitIFormula = CS_0024_003C_003E8__locals0.vm.UnitIFormula,
						UnitIIFormula = CS_0024_003C_003E8__locals0.vm.UnitIIFormula
					};
					_dbTbl.WSProductUnits.Add(wSProductUnits3);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSProductUnits_Lang wSProductUnits_Lang3 = new WSProductUnits_Lang();
						wSProductUnits_Lang3.LanguageID = lang.LanguageID;
						wSProductUnits_Lang3.ProductUnitID = wSProductUnits3.ProductUnitID;
						wSProductUnits_Lang3.Unit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wSProductUnits_Lang3.SHPUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSProductUnits_Lang.Add(wSProductUnits_Lang3);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
					CS_0024_003C_003E8__locals0.vm.ProductUnitID = wSProductUnits3.ProductUnitID;
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public ActionResult _PartialProductUnits()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductUnits_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductUnits_Result> list = new List<WSspSelectProductUnits_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			foreach (WSspSelectProductUnits_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoI", ActionName = "actDelete")]
	[AjaxOnly]
	public string Delete(int id)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.id = id;
		string result = "-1";
		try
		{
			if (_003C_003Ec__DisplayClass8_.id > 0)
			{
				DbSet<WSProductUnits> wSProductUnits = _dbTbl.WSProductUnits;
				ParameterExpression val = Expression.Parameter(typeof(WSProductUnits), "c");
				if (Queryable.FirstOrDefault<WSProductUnits>((IQueryable<WSProductUnits>)wSProductUnits, Expression.Lambda<Func<WSProductUnits, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductUnits(_003C_003Ec__DisplayClass8_.id)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
						result = "1";
					}
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

	public ActionResult ShowTspUnitCode()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetTspUnitCode()
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
			List<TSPspSelectUnitCode_Result> list2 = Enumerable.ToList<TSPspSelectUnitCode_Result>((IEnumerable<TSPspSelectUnitCode_Result>)_dbI.TSPspSelectUnitCode(lCID, result));
			if (list2 != null && Enumerable.Any<TSPspSelectUnitCode_Result>((IEnumerable<TSPspSelectUnitCode_Result>)list2))
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<TSPspSelectUnitCode_Result, SelectListItem>((IEnumerable<TSPspSelectUnitCode_Result>)list2, (Func<TSPspSelectUnitCode_Result, SelectListItem>)((TSPspSelectUnitCode_Result item) => new SelectListItem
				{
					Text = item.TspUnitCodeTitle + ((!string.IsNullOrWhiteSpace(item.TspUnitCode)) ? (" (" + item.TspUnitCode + ")") : ""),
					Value = (item.TspUnitCode ?? "")
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
