using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
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

namespace CRMIdeal.Areas.Orders.Controllers;

public class DefineOrderOprController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public WSspSelectOrderOpr_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public WSOrderOprLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__6;

		internal bool _003CIndex_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CIndex_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal bool _003CIndex_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actordOrderOpr")]
	public ActionResult Index()
	{
		WSOrderOprLanguageViewModel model = new WSOrderOprLanguageViewModel();
		GetTspInty();
		GetTspInp();
		GetTspIns();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineOrderOpr", ActionName = "actInsert,actEdit")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(WSOrderOprLanguageViewModel vm)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string appType = CS_0024_003C_003E8__locals0.vm.AppType;
		GetTspInty();
		GetTspInp();
		GetTspIns();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Name_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Name_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Name,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.Name == null && CS_0024_003C_003E8__locals0.vm.Name == "")
		{
			text = text + Messages.CheckOrderOprName + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Name, list))
		{
			text = text + Messages.CheckOrderOprNameLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		else
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType2 = Configuration.AppType;
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			WSOrderOpr wSOrderOpr = new WSOrderOpr();
			if (CS_0024_003C_003E8__locals0.vm.OrderOprID > 0)
			{
				DbSet<WSOrderOpr> wSOrderOpr2 = _dbTbl.WSOrderOpr;
				ParameterExpression val = Expression.Parameter(typeof(WSOrderOpr), "c");
				wSOrderOpr = Queryable.FirstOrDefault<WSOrderOpr>((IQueryable<WSOrderOpr>)wSOrderOpr2, Expression.Lambda<Func<WSOrderOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			wSOrderOpr.UserId = userId;
			wSOrderOpr.RegisterDate = value;
			wSOrderOpr.RegisterDatePersian = registerDatePersian;
			wSOrderOpr.Month1 = value2;
			wSOrderOpr.AppType = appType2;
			wSOrderOpr.OprType = CS_0024_003C_003E8__locals0.vm.OprType;
			wSOrderOpr.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
			wSOrderOpr.DailyCounter = CS_0024_003C_003E8__locals0.vm.DailyCounter;
			wSOrderOpr.DocOprId = CS_0024_003C_003E8__locals0.vm.DocOprId;
			wSOrderOpr.Name = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			wSOrderOpr.TspInty = CS_0024_003C_003E8__locals0.vm.TspInty;
			if (wSOrderOpr.TspInty.GetValueOrDefault() == 1 || wSOrderOpr.TspInty.GetValueOrDefault() == 2)
			{
				wSOrderOpr.TspInp = CS_0024_003C_003E8__locals0.vm.TspInp;
			}
			else
			{
				wSOrderOpr.TspInp = null;
			}
			wSOrderOpr.TspIns = CS_0024_003C_003E8__locals0.vm.TspIns;
			wSOrderOpr.TspIntyI = CS_0024_003C_003E8__locals0.vm.TspIntyI;
			if (wSOrderOpr.TspIntyI.GetValueOrDefault() == 1 || wSOrderOpr.TspIntyI.GetValueOrDefault() == 2)
			{
				wSOrderOpr.TspInpI = CS_0024_003C_003E8__locals0.vm.TspInpI;
			}
			else
			{
				wSOrderOpr.TspInpI = null;
			}
			wSOrderOpr.TspInsI = CS_0024_003C_003E8__locals0.vm.TspInsI;
			wSOrderOpr.VerifyAfterIssue = CS_0024_003C_003E8__locals0.vm.VerifyAfterIssue;
			wSOrderOpr.Taxable = CS_0024_003C_003E8__locals0.vm.Taxable;
			wSOrderOpr.IssueOrdWithoutPordDisc = CS_0024_003C_003E8__locals0.vm.IssueOrdWithoutPordDisc;
			wSOrderOpr.TspSendOrdWithoutDisc = CS_0024_003C_003E8__locals0.vm.TspSendOrdWithoutDisc;
			try
			{
				if (appType == "insert")
				{
					int result = 0;
					int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSspSelectOrderOprMAXID())).ToString(), out result);
					if (result > 0)
					{
						result++;
					}
					wSOrderOpr.OrderOprID = result;
					wSOrderOpr.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSOrderOpr.FirstRegisterDate = DateTime.Now;
					wSOrderOpr.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSOrderOpr.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					wSOrderOpr.GUId = Guid.NewGuid();
					wSOrderOpr.FPId = id;
					_dbTbl.WSOrderOpr.Add(wSOrderOpr);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSOrderOpr_Lang wSOrderOpr_Lang = new WSOrderOpr_Lang();
						wSOrderOpr_Lang.LanguageID = lang.LanguageID;
						wSOrderOpr_Lang.OrderOprID = wSOrderOpr.OrderOprID;
						wSOrderOpr_Lang.Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSOrderOpr_Lang.Add(wSOrderOpr_Lang);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderOpr");
					CS_0024_003C_003E8__locals0.vm.OrderOprID = wSOrderOpr.OrderOprID;
					int userId2 = UserLogin.CurrentUser.UserId;
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					short.Parse(Financial.Get().Id.ToString());
					int id2 = Financial.Get().Id;
					DateTime now2 = DateTime.Now;
					string registerDatePersian2 = now2.ToString("yyyyMMdd", new PersianCulture());
					string appType3 = Configuration.AppType;
					bool result2 = false;
					bool.TryParse(CS_0024_003C_003E8__locals0.vm.OrderOprUserAccessAll.ToString(), out result2);
					if (result2)
					{
						_dbII.WSspInsertOrderOprUserAccessToAllUsers(wSOrderOpr.OrderOprID, userId2, id2, value3, now2, registerDatePersian2, appType3, CS_0024_003C_003E8__locals0.defLangID);
					}
					else
					{
						_dbII.WSspInsertOrderOprUserAccess(userId2.ToString(), wSOrderOpr.OrderOprID, userId2, id2, value3, now2, registerDatePersian2, appType3, CS_0024_003C_003E8__locals0.defLangID);
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderOprUserAccess");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else if (appType == "edit")
				{
					_dbTbl.Entry(wSOrderOpr).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass4_2();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals2.lang = enumerator.Current;
							DbSet<WSOrderOpr_Lang> wSOrderOpr_Lang2 = _dbTbl.WSOrderOpr_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSOrderOpr_Lang), "c");
							WSOrderOpr_Lang wSOrderOpr_Lang3 = Queryable.FirstOrDefault<WSOrderOpr_Lang>((IQueryable<WSOrderOpr_Lang>)wSOrderOpr_Lang2, Expression.Lambda<Func<WSOrderOpr_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSOrderOpr_Lang3 != null)
							{
								wSOrderOpr_Lang3.Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSOrderOpr_Lang3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSOrderOpr_Lang3 = new WSOrderOpr_Lang();
							wSOrderOpr_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
							wSOrderOpr_Lang3.OrderOprID = wSOrderOpr.OrderOprID;
							wSOrderOpr_Lang3.Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							_dbTbl.WSOrderOpr_Lang.Add(wSOrderOpr_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderOpr");
					CS_0024_003C_003E8__locals0.vm.OrderOprID = wSOrderOpr.OrderOprID;
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		CS_0024_003C_003E8__locals0.vm.AppType = appType;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetDocOpr(int oprType)
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
			List<WSspSelectDocOprByoprType_Result> list2 = Enumerable.ToList<WSspSelectDocOprByoprType_Result>((IEnumerable<WSspSelectDocOprByoprType_Result>)_db.WSspSelectDocOprByoprType(oprType, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectDocOprByoprType_Result, SelectListItem>((IEnumerable<WSspSelectDocOprByoprType_Result>)list2, (Func<WSspSelectDocOprByoprType_Result, SelectListItem>)((WSspSelectDocOprByoprType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.DocOprID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetListTspInty()
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
				Text = Labels.OrderOprTspIntyI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspIntyII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspIntyIII,
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetTspInty()
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
			list = GetListTspInty();
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspIntyList = list;
		base.ViewBag.TspIntyIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetListTspInp()
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
				Text = Labels.OrderOprTspInpI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInpII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInpIII,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInpIV,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInpV,
				Value = "5",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInpVI,
				Value = "6",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInpVII,
				Value = "7",
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetTspInp()
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
			list = GetListTspInp();
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspInpList = list;
		base.ViewBag.TspInpIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetListTspIns()
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
				Text = Labels.OrderOprTspInsI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprTspInsIV,
				Value = "4",
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetTspIns()
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
			list = GetListTspIns();
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspInsList = list;
		base.ViewBag.TspInsIList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult LoadGrid()
	{
		List<OrderOprViewModel> list = new List<OrderOprViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null && Enumerable.Any<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)list2))
			{
				list2 = Enumerable.ToList<WSspSelectOrderOpr_Result>(Enumerable.Where<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, bool>)((WSspSelectOrderOpr_Result m) => m.OrderOprID > 0)));
			}
			if (list2 != null)
			{
				using List<WSspSelectOrderOpr_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass12_1 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_1();
					_003C_003Ec__DisplayClass12_.item = enumerator.Current;
					OrderOprViewModel orderOprViewModel = new OrderOprViewModel();
					DbSet<WSOrderOpr> wSOrderOpr = _dbTbl.WSOrderOpr;
					ParameterExpression val = Expression.Parameter(typeof(WSOrderOpr), "c");
					WSOrderOpr wSOrderOpr2 = Queryable.FirstOrDefault<WSOrderOpr>((IQueryable<WSOrderOpr>)wSOrderOpr, Expression.Lambda<Func<WSOrderOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					DbSet<WSOrderOpr_Lang> wSOrderOpr_Lang = _dbTbl.WSOrderOpr_Lang;
					val = Expression.Parameter(typeof(WSOrderOpr_Lang), "c");
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderOpr_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderOpr_Lang>)Enumerable.ToList<WSOrderOpr_Lang>((IEnumerable<WSOrderOpr_Lang>)Queryable.Where<WSOrderOpr_Lang>((IQueryable<WSOrderOpr_Lang>)wSOrderOpr_Lang, Expression.Lambda<Func<WSOrderOpr_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<WSOrderOpr_Lang, CommonMultiLanguageViewModel>)((WSOrderOpr_Lang itemVm) => new CommonMultiLanguageViewModel
					{
						Value = itemVm.Name,
						LanguageId = itemVm.LanguageID
					})));
					if (wSOrderOpr2 != null)
					{
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = wSOrderOpr2.Name,
							LanguageId = result
						});
					}
					orderOprViewModel.AppType = _003C_003Ec__DisplayClass12_.item.AppType;
					orderOprViewModel.GUId = _003C_003Ec__DisplayClass12_.item.GUId;
					orderOprViewModel.OrderOprID = _003C_003Ec__DisplayClass12_.item.OrderOprID;
					orderOprViewModel.DocOprId = _003C_003Ec__DisplayClass12_.item.DocOprId;
					orderOprViewModel.OprType = _003C_003Ec__DisplayClass12_.item.OprType;
					orderOprViewModel.OrderView = _003C_003Ec__DisplayClass12_.item.OrderView;
					orderOprViewModel.DailyCounter = _003C_003Ec__DisplayClass12_.item.DailyCounter;
					orderOprViewModel.Name = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					orderOprViewModel.Name_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					orderOprViewModel.FirstRegisterUser = _003C_003Ec__DisplayClass12_.item.FirstRegisterUser ?? "";
					if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass12_.item.AppType))
					{
						_003C_003Ec__DisplayClass12_.item.AppType = Configuration.AppType;
					}
					_ = Labels.AppType + ": " + Configuration.GetAppType(_003C_003Ec__DisplayClass12_.item.AppType);
					string text = _003C_003Ec__DisplayClass12_.item.FirstRegisterUser ?? "";
					string text2 = (_003C_003Ec__DisplayClass12_.item.FirstRegisterDate.HasValue ? _003C_003Ec__DisplayClass12_.item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					orderOprViewModel.FirstRegisterUser = text + " (" + text2 + ")";
					string text3 = _003C_003Ec__DisplayClass12_.item.EditUser ?? "";
					string text4 = (_003C_003Ec__DisplayClass12_.item.RegisterDate.HasValue ? _003C_003Ec__DisplayClass12_.item.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					orderOprViewModel.EditUser = text3 + " (" + Labels.AppType + ":" + _003C_003Ec__DisplayClass12_.item.AppType + ")  (" + text4 + ")";
					orderOprViewModel.TspInty = _003C_003Ec__DisplayClass12_.item.TspInty;
					orderOprViewModel.TspInp = _003C_003Ec__DisplayClass12_.item.TspInp;
					orderOprViewModel.TspIns = _003C_003Ec__DisplayClass12_.item.TspIns;
					orderOprViewModel.TspIntyI = _003C_003Ec__DisplayClass12_.item.TspIntyI;
					orderOprViewModel.TspInpI = _003C_003Ec__DisplayClass12_.item.TspInpI;
					orderOprViewModel.TspInsI = _003C_003Ec__DisplayClass12_.item.TspInsI;
					orderOprViewModel.VerifyAfterIssue = _003C_003Ec__DisplayClass12_.item.VerifyAfterIssue;
					orderOprViewModel.Taxable = _003C_003Ec__DisplayClass12_.item.Taxable;
					orderOprViewModel.IssueOrdWithoutPordDisc = _003C_003Ec__DisplayClass12_.item.IssueOrdWithoutPordDisc;
					orderOprViewModel.TspSendOrdWithoutDisc = _003C_003Ec__DisplayClass12_.item.TspSendOrdWithoutDisc;
					list.Add(orderOprViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult DeleteOrderOpr(int id)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.id = id;
		string data = "";
		try
		{
			DbSet<WSOrderOpr> wSOrderOpr = _dbTbl.WSOrderOpr;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderOpr), "c");
			if (Queryable.FirstOrDefault<WSOrderOpr>((IQueryable<WSOrderOpr>)wSOrderOpr, Expression.Lambda<Func<WSOrderOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSspDeleteWSOrderOpr(_003C_003Ec__DisplayClass13_.id)));
				DbSet<WSOrderOpr> wSOrderOpr2 = _dbTbl.WSOrderOpr;
				val = Expression.Parameter(typeof(WSOrderOpr), "c");
				if (Queryable.FirstOrDefault<WSOrderOpr>((IQueryable<WSOrderOpr>)wSOrderOpr2, Expression.Lambda<Func<WSOrderOpr, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderOpr");
					data = "ok";
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

	[DynamicAuthorize(ControllerName = "frmDefineOrderOpr", ActionName = "actAddOprExceptTspCmp")]
	public ActionResult DefineExceptTspCmp(int orderOprId, string parameters = "")
	{
		base.ViewBag.OrderOprId = orderOprId;
		string text = "";
		int num = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string[] array = parameters.Split(new char[1] { '|' });
			base.ViewBag.MyParameters = array;
			if (num != 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(num);
				if (companyById != null)
				{
					text = companyById.cmpTitle ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += " ";
					}
					text += companyById.cmpName;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpId = num;
		base.ViewBag.CmpFullName = text;
		GetTspInty();
		GetTspInp();
		GetTspIns();
		return View();
	}

	public List<WSspSelectOrderOprExceptTspCmp_Result> ListOrderOprExceptTspCmp(int orderOprId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderOprExceptTspCmp_Result> list = new List<WSspSelectOrderOprExceptTspCmp_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectOrderOprExceptTspCmp_Result>((IEnumerable<WSspSelectOrderOprExceptTspCmp_Result>)_dbII.WSspSelectOrderOprExceptTspCmp(orderOprId, lCID, result));
			List<SelectListItem> listTspInty = GetListTspInty();
			List<SelectListItem> listTspInp = GetListTspInp();
			List<SelectListItem> listTspIns = GetListTspIns();
			foreach (WSspSelectOrderOprExceptTspCmp_Result item in list)
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
				if (listTspInty != null)
				{
					SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)listTspInty, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == item.TspInty.GetValueOrDefault().ToString()));
					if (selectListItem != null)
					{
						item.TspIntyTitle = selectListItem.Text ?? "";
					}
				}
				if (listTspInp != null)
				{
					SelectListItem selectListItem2 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)listTspInp, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == item.TspInp.GetValueOrDefault().ToString()));
					if (selectListItem2 != null)
					{
						item.TspInpTitle = selectListItem2.Text ?? "";
					}
				}
				if (listTspIns != null)
				{
					SelectListItem selectListItem3 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)listTspIns, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == item.TspIns.GetValueOrDefault().ToString()));
					if (selectListItem3 != null)
					{
						item.TspInsTitle = selectListItem3.Text ?? "";
					}
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
	public ActionResult OrderOprExceptTspCmp_Read([DataSourceRequest] DataSourceRequest request, int orderOprId)
	{
		return Json(((IEnumerable)ListOrderOprExceptTspCmp(orderOprId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListOrderOprExceptTspCmp(int orderOprId)
	{
		return Json(ListOrderOprExceptTspCmp(orderOprId), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineOrderOpr", ActionName = "actAddOprExceptTspCmp")]
	public string ActDeleteExceptTspCmp(int exceptTspCmpId)
	{
		string text = "";
		try
		{
			if (exceptTspCmpId > 0)
			{
				try
				{
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteOrderOprExceptTspCmp(exceptTspCmpId));
					int result = 0;
					if (mct_II_Result != null)
					{
						int.TryParse(mct_II_Result.Result.ToString(), out result);
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
	public string AddExceptTspCmp(int orderoprId, int cmpId, int tspInty, int tspInp, int tspIns)
	{
		string result = "-1";
		if (orderoprId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				int id = Financial.Get().Id;
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", typeof(int));
				_dbII.WSspInsertOrderOprExceptTspCmp(orderoprId, cmpId, tspInty, tspInp, tspIns, userId, id, value2, value, registerDatePersian, appType, result2, objectParameter);
				int result3 = 0;
				if (objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result3);
				}
				result = result3 switch
				{
					0 => Messages.msgErrorRunFunction, 
					-1 => string.Format(Messages.msgErrorItemDuplicate, Labels.lblCmp), 
					_ => "1", 
				};
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
