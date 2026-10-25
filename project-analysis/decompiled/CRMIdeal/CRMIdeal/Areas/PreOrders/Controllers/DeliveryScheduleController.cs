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

public class DeliveryScheduleController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int delvSchExceptId;

		public int currLangID;

		internal bool _003CExInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CExInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CExInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CExInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CExInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CExInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public WSDeliveryScheduleExceptLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__17;

		internal bool _003CExInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CExInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CExInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CExInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CExInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CExInsertEdit_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public WSDeliveryScheduleExcept model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1;

		internal bool _003CExInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CExInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int delvSchExceptId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int deliveryScheduleId;

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
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public WSDeliveryScheduleLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__11;

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

		internal bool _003CInsertEdit_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public WSDeliverySchedule model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int deliveryScheduleId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actManageDeliverySchedule")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult DayDeliveries_Read([DataSourceRequest] DataSourceRequest request, string dayNumber)
	{
		List<WSspSelectDeliveryScheduleByDayNumber_Result> enumerable = new List<WSspSelectDeliveryScheduleByDayNumber_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			enumerable = Enumerable.ToList<WSspSelectDeliveryScheduleByDayNumber_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumber_Result>)_db.WSspSelectDeliveryScheduleByDayNumber(short.Parse(dayNumber), lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public void SetDelSchRegisterInfo(WSDeliveryScheduleLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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

	[DynamicAuthorize(ControllerName = "frmManageDeliverySchedule", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int deliveryScheduleId = 0, int dayNumber = 0)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.deliveryScheduleId = deliveryScheduleId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSDeliveryScheduleLanguageViewModel wSDeliveryScheduleLanguageViewModel = new WSDeliveryScheduleLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.deliveryScheduleId > 0)
		{
			if (!UserLogin.IsUserAccess("frmManageDeliverySchedule", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSDeliverySchedule_Lang> wSDeliverySchedule_Lang = _dbTbl.WSDeliverySchedule_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSDeliverySchedule_Lang), "c");
			List<WSDeliverySchedule_Lang> list = Enumerable.ToList<WSDeliverySchedule_Lang>((IEnumerable<WSDeliverySchedule_Lang>)Queryable.Where<WSDeliverySchedule_Lang>((IQueryable<WSDeliverySchedule_Lang>)wSDeliverySchedule_Lang, Expression.Lambda<Func<WSDeliverySchedule_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSDeliverySchedule> wSDeliverySchedule = _dbTbl.WSDeliverySchedule;
			val = Expression.Parameter(typeof(WSDeliverySchedule), "c");
			WSDeliverySchedule wSDeliverySchedule2 = Queryable.FirstOrDefault<WSDeliverySchedule>((IQueryable<WSDeliverySchedule>)wSDeliverySchedule, Expression.Lambda<Func<WSDeliverySchedule, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSDeliverySchedule2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDeliverySchedule_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDeliverySchedule_Lang>)list, (Func<WSDeliverySchedule_Lang, CommonMultiLanguageViewModel>)((WSDeliverySchedule_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Title,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDeliverySchedule2.Title,
				LanguageId = result
			});
			wSDeliveryScheduleLanguageViewModel = new WSDeliveryScheduleLanguageViewModel
			{
				DeliveryScheduleId = wSDeliverySchedule2.DeliveryScheduleId,
				Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				DayNumber = wSDeliverySchedule2.DayNumber,
				Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				FTime = wSDeliverySchedule2.FTime,
				TTime = wSDeliverySchedule2.TTime,
				Cnt = wSDeliverySchedule2.Cnt,
				OrderView = wSDeliverySchedule2.OrderView,
				FirstRegisterUserId = wSDeliverySchedule2.FirstRegisterUserId,
				FirstRegisterDate = wSDeliverySchedule2.FirstRegisterDate,
				FirstRegisterDatePersian = wSDeliverySchedule2.FirstRegisterDatePersian,
				UserId = wSDeliverySchedule2.UserId,
				FPId = wSDeliverySchedule2.FPId,
				Month1 = wSDeliverySchedule2.Month1,
				RegisterDate = wSDeliverySchedule2.RegisterDate,
				RegisterDatePersian = wSDeliverySchedule2.RegisterDatePersian,
				GUId = wSDeliverySchedule2.GUId,
				AppType = wSDeliverySchedule2.AppType,
				LanguageID = wSDeliverySchedule2.LanguageID,
				Prdjson = wSDeliverySchedule2.PrdJson,
				DeActive = wSDeliverySchedule2.DeActive
			};
			if (wSDeliveryScheduleLanguageViewModel != null && wSDeliveryScheduleLanguageViewModel.DeliveryScheduleId != 0)
			{
				List<WSspSelectDeliverySchedulePrdJson_Result> list3 = Enumerable.ToList<WSspSelectDeliverySchedulePrdJson_Result>((IEnumerable<WSspSelectDeliverySchedulePrdJson_Result>)_dbI.WSspSelectDeliverySchedulePrdJson(wSDeliveryScheduleLanguageViewModel.DeliveryScheduleId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (list3 != null && Enumerable.Any<WSspSelectDeliverySchedulePrdJson_Result>((IEnumerable<WSspSelectDeliverySchedulePrdJson_Result>)list3))
				{
					wSDeliveryScheduleLanguageViewModel.PrdjsonByName = JsonConvert.SerializeObject(Enumerable.ToList<WSspSelectDeliverySchedulePrdJson_Result>((IEnumerable<WSspSelectDeliverySchedulePrdJson_Result>)list3));
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmManageDeliverySchedule", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wSDeliveryScheduleLanguageViewModel = new WSDeliveryScheduleLanguageViewModel
			{
				DayNumber = short.Parse(dayNumber.ToString()),
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
				Cnt = 1
			};
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetDelSchRegisterInfo(wSDeliveryScheduleLanguageViewModel, ref firstRegInfo, ref regInfo);
		wSDeliveryScheduleLanguageViewModel.FirstRegisterUser = firstRegInfo;
		wSDeliveryScheduleLanguageViewModel.EditUser = regInfo;
		return View(wSDeliveryScheduleLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmManageDeliveryScheduleDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(WSDeliveryScheduleLanguageViewModel vm)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
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
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Title,
				LanguageId = lCID
			});
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.DelvSchTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Title, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.DelvSchTitle) + "<br>";
				num++;
			}
			string prdjson = "";
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.PrdjsonByName))
			{
				List<WSspSelectDeliverySchedulePrdJson_Result> list2 = new List<WSspSelectDeliverySchedulePrdJson_Result>();
				list2 = new JavaScriptSerializer().Deserialize<List<WSspSelectDeliverySchedulePrdJson_Result>>(CS_0024_003C_003E8__locals0.vm.PrdjsonByName);
				if (list2 != null && Enumerable.Any<WSspSelectDeliverySchedulePrdJson_Result>((IEnumerable<WSspSelectDeliverySchedulePrdJson_Result>)list2))
				{
					List<WSDeliverySchedulePrdJsonViewModel> list3 = new List<WSDeliverySchedulePrdJsonViewModel>();
					foreach (WSspSelectDeliverySchedulePrdJson_Result item2 in list2)
					{
						WSDeliverySchedulePrdJsonViewModel item = new WSDeliverySchedulePrdJsonViewModel
						{
							PrdId = item2.PrdId,
							Cnt = item2.Cnt
						};
						list3.Add(item);
					}
					if (list3 != null && Enumerable.Any<WSDeliverySchedulePrdJsonViewModel>((IEnumerable<WSDeliverySchedulePrdJsonViewModel>)list3))
					{
						prdjson = JsonConvert.SerializeObject(Enumerable.ToList<WSDeliverySchedulePrdJsonViewModel>((IEnumerable<WSDeliverySchedulePrdJsonViewModel>)list3));
					}
				}
			}
			CS_0024_003C_003E8__locals0.vm.Prdjson = prdjson;
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
						_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
						_003C_003Ec__DisplayClass7_.model = new WSDeliverySchedule();
						if (CS_0024_003C_003E8__locals0.vm.DeliveryScheduleId > 0)
						{
							DbSet<WSDeliverySchedule> wSDeliverySchedule = _dbTbl.WSDeliverySchedule;
							ParameterExpression val = Expression.Parameter(typeof(WSDeliverySchedule), "c");
							_003C_003Ec__DisplayClass7_.model = Queryable.FirstOrDefault<WSDeliverySchedule>((IQueryable<WSDeliverySchedule>)wSDeliverySchedule, Expression.Lambda<Func<WSDeliverySchedule, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						_003C_003Ec__DisplayClass7_.model.UserId = UserLogin.CurrentUser.UserId;
						DateTime now = DateTime.Now;
						_003C_003Ec__DisplayClass7_.model.RegisterDate = now;
						_003C_003Ec__DisplayClass7_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass7_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass7_.model.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass7_.model.DayNumber = CS_0024_003C_003E8__locals0.vm.DayNumber;
						_003C_003Ec__DisplayClass7_.model.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_003C_003Ec__DisplayClass7_.model.FTime = CS_0024_003C_003E8__locals0.vm.FTime;
						_003C_003Ec__DisplayClass7_.model.TTime = CS_0024_003C_003E8__locals0.vm.TTime;
						_003C_003Ec__DisplayClass7_.model.Cnt = CS_0024_003C_003E8__locals0.vm.Cnt;
						if (_003C_003Ec__DisplayClass7_.model.DayNumber == 7)
						{
							_003C_003Ec__DisplayClass7_.model.OrderView = 1;
						}
						else
						{
							_003C_003Ec__DisplayClass7_.model.OrderView = _003C_003Ec__DisplayClass7_.model.DayNumber + 1;
						}
						_003C_003Ec__DisplayClass7_.model.PrdJson = CS_0024_003C_003E8__locals0.vm.Prdjson;
						_003C_003Ec__DisplayClass7_.model.DeActive = CS_0024_003C_003E8__locals0.vm.DeActive;
						if (_003C_003Ec__DisplayClass7_.model.DeliveryScheduleId > 0)
						{
							_dbTbl.Entry(_003C_003Ec__DisplayClass7_.model).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							using (List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									_003C_003Ec__DisplayClass7_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_;
									CS_0024_003C_003E8__locals1.lang = enumerator2.Current;
									DbSet<WSDeliverySchedule_Lang> wSDeliverySchedule_Lang = _dbTbl.WSDeliverySchedule_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSDeliverySchedule_Lang), "c");
									WSDeliverySchedule_Lang wSDeliverySchedule_Lang2 = Queryable.FirstOrDefault<WSDeliverySchedule_Lang>((IQueryable<WSDeliverySchedule_Lang>)wSDeliverySchedule_Lang, Expression.Lambda<Func<WSDeliverySchedule_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSDeliverySchedule_Lang2 != null)
									{
										wSDeliverySchedule_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSDeliverySchedule_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSDeliverySchedule_Lang2 = new WSDeliverySchedule_Lang();
									wSDeliverySchedule_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									wSDeliverySchedule_Lang2.DeliveryScheduleId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DeliveryScheduleId;
									wSDeliverySchedule_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.WSDeliverySchedule_Lang.Add(wSDeliverySchedule_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliverySchedule");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							_003C_003Ec__DisplayClass7_.model.FPId = int.Parse(Financial.Get().Id.ToString());
							_003C_003Ec__DisplayClass7_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass7_.model.FirstRegisterDate = now;
							_003C_003Ec__DisplayClass7_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass7_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							_003C_003Ec__DisplayClass7_.model.GUId = Guid.NewGuid();
							_dbTbl.WSDeliverySchedule.Add(_003C_003Ec__DisplayClass7_.model);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSDeliverySchedule_Lang wSDeliverySchedule_Lang3 = new WSDeliverySchedule_Lang();
								wSDeliverySchedule_Lang3.LanguageID = lang.LanguageID;
								wSDeliverySchedule_Lang3.DeliveryScheduleId = _003C_003Ec__DisplayClass7_.model.DeliveryScheduleId;
								wSDeliverySchedule_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								_dbTbl.WSDeliverySchedule_Lang.Add(wSDeliverySchedule_Lang3);
								_dbTbl.SaveChanges();
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliverySchedule");
							CS_0024_003C_003E8__locals0.vm.DeliveryScheduleId = _003C_003Ec__DisplayClass7_.model.DeliveryScheduleId;
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						CS_0024_003C_003E8__locals0.vm.DeliveryScheduleId = _003C_003Ec__DisplayClass7_.model.DeliveryScheduleId;
						CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass7_.model.UserId;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass7_.model.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass7_.model.RegisterDate;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass7_.model.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass7_.model.AppType;
						string firstRegInfo = "";
						string regInfo = "";
						SetDelSchRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
						CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
					}
				}
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
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
	[DynamicAuthorize(ControllerName = "frmManageDeliverySchedule", ActionName = "actDelete")]
	public string Delete(int deliveryScheduleId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.deliveryScheduleId = deliveryScheduleId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass8_.deliveryScheduleId > 0)
			{
				DbSet<WSDeliverySchedule> wSDeliverySchedule = _dbTbl.WSDeliverySchedule;
				ParameterExpression val = Expression.Parameter(typeof(WSDeliverySchedule), "m");
				if (Queryable.FirstOrDefault<WSDeliverySchedule>((IQueryable<WSDeliverySchedule>)wSDeliverySchedule, Expression.Lambda<Func<WSDeliverySchedule, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteDeliverySchedule(_003C_003Ec__DisplayClass8_.deliveryScheduleId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliverySchedule");
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
	public ActionResult DayDeliveriesExcept_Read([DataSourceRequest] DataSourceRequest request, short dayNumber)
	{
		List<WSspSelectDeliveryScheduleExceptByDayNumber_Result> list = new List<WSspSelectDeliveryScheduleExceptByDayNumber_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			list = Enumerable.ToList<WSspSelectDeliveryScheduleExceptByDayNumber_Result>((IEnumerable<WSspSelectDeliveryScheduleExceptByDayNumber_Result>)_db.WSspSelectDeliveryScheduleExceptByDayNumber(dayNumber, lCID, result));
			foreach (WSspSelectDeliveryScheduleExceptByDayNumber_Result item in list)
			{
				_ = item.ExDate;
				item.ExDatePersian = item.ExDate.ToString("yyyy/MM/dd");
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

	public void SetDelSchExRegisterInfo(WSDeliveryScheduleExceptLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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

	[DynamicAuthorize(ControllerName = "frmManageDeliverySchedule", ActionName = "actExInsert,actExEdit")]
	public ActionResult ExInsertEdit(int delvSchExceptId = 0)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.delvSchExceptId = delvSchExceptId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSDeliveryScheduleExceptLanguageViewModel wSDeliveryScheduleExceptLanguageViewModel = new WSDeliveryScheduleExceptLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.delvSchExceptId > 0)
		{
			if (!UserLogin.IsUserAccess("frmManageDeliverySchedule", "actExEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WSDeliveryScheduleExcept_Lang> wSDeliveryScheduleExcept_Lang = _dbTbl.WSDeliveryScheduleExcept_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSDeliveryScheduleExcept_Lang), "c");
			List<WSDeliveryScheduleExcept_Lang> list = Enumerable.ToList<WSDeliveryScheduleExcept_Lang>((IEnumerable<WSDeliveryScheduleExcept_Lang>)Queryable.Where<WSDeliveryScheduleExcept_Lang>((IQueryable<WSDeliveryScheduleExcept_Lang>)wSDeliveryScheduleExcept_Lang, Expression.Lambda<Func<WSDeliveryScheduleExcept_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSDeliveryScheduleExcept> wSDeliveryScheduleExcept = _dbTbl.WSDeliveryScheduleExcept;
			val = Expression.Parameter(typeof(WSDeliveryScheduleExcept), "c");
			WSDeliveryScheduleExcept wSDeliveryScheduleExcept2 = Queryable.FirstOrDefault<WSDeliveryScheduleExcept>((IQueryable<WSDeliveryScheduleExcept>)wSDeliveryScheduleExcept, Expression.Lambda<Func<WSDeliveryScheduleExcept, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSDeliveryScheduleExcept2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDeliveryScheduleExcept_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDeliveryScheduleExcept_Lang>)list, (Func<WSDeliveryScheduleExcept_Lang, CommonMultiLanguageViewModel>)((WSDeliveryScheduleExcept_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ExDesc,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDeliveryScheduleExcept2.ExDesc,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDeliveryScheduleExcept_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDeliveryScheduleExcept_Lang>)list, (Func<WSDeliveryScheduleExcept_Lang, CommonMultiLanguageViewModel>)((WSDeliveryScheduleExcept_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ExTitle,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSDeliveryScheduleExcept2.ExTitle,
				LanguageId = result
			});
			WSDeliveryScheduleExceptLanguageViewModel obj = new WSDeliveryScheduleExceptLanguageViewModel
			{
				DeliveryScheduleExceptId = wSDeliveryScheduleExcept2.DeliveryScheduleExceptId,
				ExTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ExTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ExDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ExDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ExDate = wSDeliveryScheduleExcept2.ExDate
			};
			_ = wSDeliveryScheduleExcept2.ExDate;
			obj.ExDatePersian = wSDeliveryScheduleExcept2.ExDate.ToString("yyyy/MM/dd");
			obj.ExFTime = wSDeliveryScheduleExcept2.ExFTime;
			obj.ExTTime = wSDeliveryScheduleExcept2.ExTTime;
			obj.ExCnt = wSDeliveryScheduleExcept2.ExCnt;
			obj.FirstRegisterUserId = wSDeliveryScheduleExcept2.FirstRegisterUserId;
			obj.FirstRegisterDate = wSDeliveryScheduleExcept2.FirstRegisterDate;
			obj.FirstRegisterDatePersian = wSDeliveryScheduleExcept2.FirstRegisterDatePersian;
			obj.UserId = wSDeliveryScheduleExcept2.UserId;
			obj.FPId = wSDeliveryScheduleExcept2.FPId;
			obj.Month1 = wSDeliveryScheduleExcept2.Month1;
			obj.RegisterDate = wSDeliveryScheduleExcept2.RegisterDate;
			obj.RegisterDatePersian = wSDeliveryScheduleExcept2.RegisterDatePersian;
			obj.GUId = wSDeliveryScheduleExcept2.GUId;
			obj.AppType = wSDeliveryScheduleExcept2.AppType;
			obj.LanguageID = wSDeliveryScheduleExcept2.LanguageID;
			obj.ExPrdJson = wSDeliveryScheduleExcept2.ExPrdJson;
			obj.ExDeActive = wSDeliveryScheduleExcept2.ExDeActive;
			wSDeliveryScheduleExceptLanguageViewModel = obj;
			if (wSDeliveryScheduleExceptLanguageViewModel != null && wSDeliveryScheduleExceptLanguageViewModel.DeliveryScheduleExceptId != 0)
			{
				List<WSspSelectDeliveryScheduleExceptPrdJson_Result> list4 = Enumerable.ToList<WSspSelectDeliveryScheduleExceptPrdJson_Result>((IEnumerable<WSspSelectDeliveryScheduleExceptPrdJson_Result>)_dbI.WSspSelectDeliveryScheduleExceptPrdJson(wSDeliveryScheduleExceptLanguageViewModel.DeliveryScheduleExceptId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (list4 != null && Enumerable.Any<WSspSelectDeliveryScheduleExceptPrdJson_Result>((IEnumerable<WSspSelectDeliveryScheduleExceptPrdJson_Result>)list4))
				{
					wSDeliveryScheduleExceptLanguageViewModel.PrdjsonByName = JsonConvert.SerializeObject(Enumerable.ToList<WSspSelectDeliveryScheduleExceptPrdJson_Result>((IEnumerable<WSspSelectDeliveryScheduleExceptPrdJson_Result>)list4));
				}
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmManageDeliverySchedule", "actExInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wSDeliveryScheduleExceptLanguageViewModel = new WSDeliveryScheduleExceptLanguageViewModel
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
				ExDate = now,
				ExDatePersian = now.ToString("yyyy/MM/dd"),
				ExCnt = 1
			};
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetDelSchExRegisterInfo(wSDeliveryScheduleExceptLanguageViewModel, ref firstRegInfo, ref regInfo);
		wSDeliveryScheduleExceptLanguageViewModel.FirstRegisterUser = firstRegInfo;
		wSDeliveryScheduleExceptLanguageViewModel.EditUser = regInfo;
		return View(wSDeliveryScheduleExceptLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmManageDeliveryScheduleDataEntry", ActionName = "actPost")]
	public ActionResult ExInsertEdit(WSDeliveryScheduleExceptLanguageViewModel vm)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
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
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExDesc_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ExDesc_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ExDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ExTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ExTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.DelvSchExTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ExTitle, list2))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.DelvSchExTitle) + "<br>";
				num++;
			}
			string exPrdJson = "";
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.PrdjsonByName))
			{
				List<WSspSelectDeliveryScheduleExceptPrdJson_Result> list3 = new List<WSspSelectDeliveryScheduleExceptPrdJson_Result>();
				list3 = new JavaScriptSerializer().Deserialize<List<WSspSelectDeliveryScheduleExceptPrdJson_Result>>(CS_0024_003C_003E8__locals0.vm.PrdjsonByName);
				if (list3 != null && Enumerable.Any<WSspSelectDeliveryScheduleExceptPrdJson_Result>((IEnumerable<WSspSelectDeliveryScheduleExceptPrdJson_Result>)list3))
				{
					List<WSDeliverySchedulePrdJsonViewModel> list4 = new List<WSDeliverySchedulePrdJsonViewModel>();
					foreach (WSspSelectDeliveryScheduleExceptPrdJson_Result item2 in list3)
					{
						WSDeliverySchedulePrdJsonViewModel item = new WSDeliverySchedulePrdJsonViewModel
						{
							PrdId = item2.PrdId,
							Cnt = item2.Cnt
						};
						list4.Add(item);
					}
					if (list4 != null && Enumerable.Any<WSDeliverySchedulePrdJsonViewModel>((IEnumerable<WSDeliverySchedulePrdJsonViewModel>)list4))
					{
						exPrdJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDeliverySchedulePrdJsonViewModel>((IEnumerable<WSDeliverySchedulePrdJsonViewModel>)list4));
					}
				}
			}
			CS_0024_003C_003E8__locals0.vm.ExPrdJson = exPrdJson;
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
						_003C_003Ec__DisplayClass12_1 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_1();
						_003C_003Ec__DisplayClass12_.model = new WSDeliveryScheduleExcept();
						if (CS_0024_003C_003E8__locals0.vm.DeliveryScheduleExceptId > 0)
						{
							DbSet<WSDeliveryScheduleExcept> wSDeliveryScheduleExcept = _dbTbl.WSDeliveryScheduleExcept;
							ParameterExpression val = Expression.Parameter(typeof(WSDeliveryScheduleExcept), "c");
							_003C_003Ec__DisplayClass12_.model = Queryable.FirstOrDefault<WSDeliveryScheduleExcept>((IQueryable<WSDeliveryScheduleExcept>)wSDeliveryScheduleExcept, Expression.Lambda<Func<WSDeliveryScheduleExcept, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						_003C_003Ec__DisplayClass12_.model.UserId = UserLogin.CurrentUser.UserId;
						DateTime now = DateTime.Now;
						_003C_003Ec__DisplayClass12_.model.RegisterDate = now;
						_003C_003Ec__DisplayClass12_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass12_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass12_.model.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass12_.model.ExTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_003C_003Ec__DisplayClass12_.model.ExDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						DateTime dateTime = default(DateTime);
						string text2 = "";
						try
						{
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ExDatePersian))
							{
								text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ExDatePersian.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
									_003C_003Ec__DisplayClass12_.model.ExDatePersian = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
									_003C_003Ec__DisplayClass12_.model.ExDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
									_003C_003Ec__DisplayClass12_.model.ExDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								_003C_003Ec__DisplayClass12_.model.ExDate = dateTime;
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							base.ViewBag.Error = Messages.WrongDateTime;
							return View(CS_0024_003C_003E8__locals0.vm);
						}
						if (_003C_003Ec__DisplayClass12_.model.ExDatePersian != null)
						{
							_003C_003Ec__DisplayClass12_.model.ExDatePersian = _003C_003Ec__DisplayClass12_.model.ExDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						_003C_003Ec__DisplayClass12_.model.ExFTime = CS_0024_003C_003E8__locals0.vm.ExFTime;
						_003C_003Ec__DisplayClass12_.model.ExTTime = CS_0024_003C_003E8__locals0.vm.ExTTime;
						_003C_003Ec__DisplayClass12_.model.ExCnt = CS_0024_003C_003E8__locals0.vm.ExCnt;
						_003C_003Ec__DisplayClass12_.model.ExPrdJson = CS_0024_003C_003E8__locals0.vm.ExPrdJson;
						_003C_003Ec__DisplayClass12_.model.ExDeActive = CS_0024_003C_003E8__locals0.vm.ExDeActive;
						if (_003C_003Ec__DisplayClass12_.model.DeliveryScheduleExceptId > 0)
						{
							_dbTbl.Entry(_003C_003Ec__DisplayClass12_.model).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							using (List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									_003C_003Ec__DisplayClass12_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass12_;
									CS_0024_003C_003E8__locals1.lang = enumerator2.Current;
									DbSet<WSDeliveryScheduleExcept_Lang> wSDeliveryScheduleExcept_Lang = _dbTbl.WSDeliveryScheduleExcept_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSDeliveryScheduleExcept_Lang), "c");
									WSDeliveryScheduleExcept_Lang wSDeliveryScheduleExcept_Lang2 = Queryable.FirstOrDefault<WSDeliveryScheduleExcept_Lang>((IQueryable<WSDeliveryScheduleExcept_Lang>)wSDeliveryScheduleExcept_Lang, Expression.Lambda<Func<WSDeliveryScheduleExcept_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass12_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass12_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSDeliveryScheduleExcept_Lang2 != null)
									{
										wSDeliveryScheduleExcept_Lang2.ExDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSDeliveryScheduleExcept_Lang2.ExTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSDeliveryScheduleExcept_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSDeliveryScheduleExcept_Lang2 = new WSDeliveryScheduleExcept_Lang();
									wSDeliveryScheduleExcept_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									wSDeliveryScheduleExcept_Lang2.DeliveryScheduleExceptId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DeliveryScheduleExceptId;
									wSDeliveryScheduleExcept_Lang2.ExDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSDeliveryScheduleExcept_Lang2.ExTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.WSDeliveryScheduleExcept_Lang.Add(wSDeliveryScheduleExcept_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliveryScheduleExcept");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							_003C_003Ec__DisplayClass12_.model.FPId = int.Parse(Financial.Get().Id.ToString());
							_003C_003Ec__DisplayClass12_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass12_.model.FirstRegisterDate = now;
							_003C_003Ec__DisplayClass12_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass12_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							_003C_003Ec__DisplayClass12_.model.GUId = Guid.NewGuid();
							_dbTbl.WSDeliveryScheduleExcept.Add(_003C_003Ec__DisplayClass12_.model);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSDeliveryScheduleExcept_Lang wSDeliveryScheduleExcept_Lang3 = new WSDeliveryScheduleExcept_Lang();
								wSDeliveryScheduleExcept_Lang3.LanguageID = lang.LanguageID;
								wSDeliveryScheduleExcept_Lang3.DeliveryScheduleExceptId = _003C_003Ec__DisplayClass12_.model.DeliveryScheduleExceptId;
								wSDeliveryScheduleExcept_Lang3.ExDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								wSDeliveryScheduleExcept_Lang3.ExTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								_dbTbl.WSDeliveryScheduleExcept_Lang.Add(wSDeliveryScheduleExcept_Lang3);
								_dbTbl.SaveChanges();
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliveryScheduleExcept");
							CS_0024_003C_003E8__locals0.vm.DeliveryScheduleExceptId = _003C_003Ec__DisplayClass12_.model.DeliveryScheduleExceptId;
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						CS_0024_003C_003E8__locals0.vm.DeliveryScheduleExceptId = _003C_003Ec__DisplayClass12_.model.DeliveryScheduleExceptId;
						CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass12_.model.UserId;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass12_.model.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass12_.model.RegisterDate;
						CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass12_.model.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass12_.model.AppType;
						string firstRegInfo = "";
						string regInfo = "";
						SetDelSchExRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
						CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
						CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
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
	[DynamicAuthorize(ControllerName = "frmManageDeliverySchedule", ActionName = "actExDelete")]
	public string ExDelete(int delvSchExceptId)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.delvSchExceptId = delvSchExceptId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass13_.delvSchExceptId > 0)
			{
				DbSet<WSDeliveryScheduleExcept> wSDeliveryScheduleExcept = _dbTbl.WSDeliveryScheduleExcept;
				ParameterExpression val = Expression.Parameter(typeof(WSDeliveryScheduleExcept), "m");
				if (Queryable.FirstOrDefault<WSDeliveryScheduleExcept>((IQueryable<WSDeliveryScheduleExcept>)wSDeliveryScheduleExcept, Expression.Lambda<Func<WSDeliveryScheduleExcept, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteDeliveryScheduleExcept(_003C_003Ec__DisplayClass13_.delvSchExceptId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliveryScheduleExcept");
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

	public PartialViewResult _PartialDeliveryScheduleDays(int days)
	{
		base.ViewBag.Days = days;
		return PartialView();
	}

	public ActionResult _PartialDeliverySchedule(int dayNum, string date)
	{
		List<WSspSelectDeliveryScheduleByDayNumberAndDate_Result> list = new List<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(date))
				{
					text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					text += " 00:00:00";
					value = lCID switch
					{
						1065 => DateTime.Parse(text, new PersianCulture()), 
						1025 => DateTime.Parse(text, new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text, new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			list = Enumerable.ToList<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>)_dbI.WSspSelectDeliveryScheduleByDayNumberAndDate(dayNum, value, lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectDeliveryScheduleByDayNumberAndDate_Result>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return PartialView(list);
	}

	public PartialViewResult _PartialPrdDeliveryScheduleDays(int days, int prdId)
	{
		base.ViewBag.Days = days;
		base.ViewBag.PrdId = prdId;
		return PartialView();
	}

	public ActionResult _PartialPrdDeliverySchedule(int dayNum, string date, int prdId)
	{
		base.ViewBag.PrdId = prdId;
		List<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result> list = new List<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			try
			{
				if (!string.IsNullOrWhiteSpace(date))
				{
					date = date.Replace("\n", "");
					text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					text += " 00:00:00";
					value = lCID switch
					{
						1065 => DateTime.Parse(text, new PersianCulture()), 
						1025 => DateTime.Parse(text, new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(text, new CultureInfo("en-US")), 
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			list = Enumerable.ToList<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>((IEnumerable<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>)_dbI.WSspSelectDeliveryScheduleByDayNumberAndDateForPrd(dayNum, value, prdId.ToString(), lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return PartialView(list);
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
