using System;
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
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Orders.Controllers;

public class SerialsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int orderItemSerialId;

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
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public WSOrderItemSerialsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__8;

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

		internal bool _003CInsertEdit_003Eb__8(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

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
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult _PartialSerials()
	{
		return PartialView();
	}

	public void SetRegisterInfo(WSOrderItemSerialsLanguageViewModel model)
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
				WSOrderItemSerialsLanguageViewModel wSOrderItemSerialsLanguageViewModel = model;
				_ = model.UserId;
				wSOrderItemSerialsLanguageViewModel.UserId = model.UserId;
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

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actInsertItemSerial,actEditItemSerial")]
	public ActionResult InsertEdit(int orderItemId, int orderItemSerialId)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.orderItemSerialId = orderItemSerialId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSOrderItemSerialsLanguageViewModel wSOrderItemSerialsLanguageViewModel = new WSOrderItemSerialsLanguageViewModel();
		bool flag = false;
		WSOrderItems wSOrderItems = _dbTbl.WSOrderItems.Find(orderItemId);
		if (CS_0024_003C_003E8__locals0.orderItemSerialId > 0)
		{
			DbSet<WSOrderItemSerials_Lang> wSOrderItemSerials_Lang = _dbTbl.WSOrderItemSerials_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSOrderItemSerials_Lang), "c");
			List<WSOrderItemSerials_Lang> list = Enumerable.ToList<WSOrderItemSerials_Lang>((IEnumerable<WSOrderItemSerials_Lang>)Queryable.Where<WSOrderItemSerials_Lang>((IQueryable<WSOrderItemSerials_Lang>)wSOrderItemSerials_Lang, Expression.Lambda<Func<WSOrderItemSerials_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSOrderItemSerials> wSOrderItemSerials = _dbTbl.WSOrderItemSerials;
			val = Expression.Parameter(typeof(WSOrderItemSerials), "c");
			WSOrderItemSerials wSOrderItemSerials2 = Queryable.FirstOrDefault<WSOrderItemSerials>((IQueryable<WSOrderItemSerials>)wSOrderItemSerials, Expression.Lambda<Func<WSOrderItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrderItemSerials2 != null)
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderItemSerials_Lang>)list, (Func<WSOrderItemSerials_Lang, CommonMultiLanguageViewModel>)((WSOrderItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSOrderItemSerials2.Description,
					LanguageId = result
				});
				wSOrderItemSerialsLanguageViewModel = new WSOrderItemSerialsLanguageViewModel
				{
					LanguageID = wSOrderItemSerials2.LanguageID,
					UserId = wSOrderItemSerials2.UserId,
					FirstRegisterUserId = wSOrderItemSerials2.FirstRegisterUserId,
					AppType = wSOrderItemSerials2.AppType,
					FirstRegisterDate = wSOrderItemSerials2.FirstRegisterDate,
					FirstRegisterDatePersian = wSOrderItemSerials2.FirstRegisterDatePersian,
					GUId = wSOrderItemSerials2.GUId,
					RegisterDate = wSOrderItemSerials2.RegisterDate,
					Month1 = wSOrderItemSerials2.Month1,
					RegisterDatePersian = wSOrderItemSerials2.RegisterDatePersian,
					FPId = wSOrderItemSerials2.FPId,
					WHId = wSOrderItemSerials2.WHId,
					OrderItemSerialID = wSOrderItemSerials2.OrderItemSerialID,
					OrderItemId = wSOrderItemSerials2.OrderItemId,
					SerialId = wSOrderItemSerials2.SerialId,
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SerialDetails = Enumerable.FirstOrDefault<WSspSelectDocItemSerialsWithId_Result>((IEnumerable<WSspSelectDocItemSerialsWithId_Result>)_dbI.WSspSelectDocItemSerialsWithId(wSOrderItemSerials2.SerialId, CS_0024_003C_003E8__locals0.currLangID, result))
				};
			}
			flag = false;
		}
		else
		{
			wSOrderItemSerialsLanguageViewModel = new WSOrderItemSerialsLanguageViewModel();
			wSOrderItemSerialsLanguageViewModel.OrderItemId = orderItemId;
			wSOrderItemSerialsLanguageViewModel.OrderItemSerialID = CS_0024_003C_003E8__locals0.orderItemSerialId;
			wSOrderItemSerialsLanguageViewModel.WHId = wSOrderItems.ordIWHId;
			flag = true;
			DateTime now = DateTime.Now;
			wSOrderItemSerialsLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			wSOrderItemSerialsLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSOrderItemSerialsLanguageViewModel.RegisterDate = now;
			wSOrderItemSerialsLanguageViewModel.FirstRegisterDate = now;
			wSOrderItemSerialsLanguageViewModel.AppType = Configuration.AppType;
		}
		base.ViewBag.FromNew = flag;
		SetRegisterInfo(wSOrderItemSerialsLanguageViewModel);
		return View(wSOrderItemSerialsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmOrderItemSerialsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSOrderItemSerialsLanguageViewModel vm)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = CS_0024_003C_003E8__locals0.vm.OrderItemSerialID <= 0;
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Description,
				LanguageId = lCID
			});
			try
			{
				WSfnCheckDuplicateOrderSerial_Result wSfnCheckDuplicateOrderSerial_Result = Enumerable.FirstOrDefault<WSfnCheckDuplicateOrderSerial_Result>((IEnumerable<WSfnCheckDuplicateOrderSerial_Result>)Enumerable.ToList<WSfnCheckDuplicateOrderSerial_Result>((IEnumerable<WSfnCheckDuplicateOrderSerial_Result>)_db.WSfnCheckDuplicateOrderSerial(CS_0024_003C_003E8__locals0.vm.OrderItemId, CS_0024_003C_003E8__locals0.vm.SerialId, CS_0024_003C_003E8__locals0.vm.FPId, CS_0024_003C_003E8__locals0.vm.OrderItemSerialID)));
				if (wSfnCheckDuplicateOrderSerial_Result != null)
				{
					base.ViewBag.Error = Messages.MsgErrorOrderItemSerial1 + "<br/>" + Messages.MsgErrorOrderItemSerial2 + "<br/>" + wSfnCheckDuplicateOrderSerial_Result.ordNumber + "<br/>" + Messages.MsgErrorOrderItemSerial3;
				}
				else
				{
					WSOrderItemSerials wSOrderItemSerials = new WSOrderItemSerials();
					if (CS_0024_003C_003E8__locals0.vm.OrderItemSerialID > 0)
					{
						DbSet<WSOrderItemSerials> wSOrderItemSerials2 = _dbTbl.WSOrderItemSerials;
						ParameterExpression val = Expression.Parameter(typeof(WSOrderItemSerials), "c");
						wSOrderItemSerials = Queryable.FirstOrDefault<WSOrderItemSerials>((IQueryable<WSOrderItemSerials>)wSOrderItemSerials2, Expression.Lambda<Func<WSOrderItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new WSOrderItemSerials();
					}
					CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
					DateTime dateTime = (wSOrderItemSerials.RegisterDate = DateTime.Now);
					wSOrderItemSerials.UserId = currentUser.UserId;
					wSOrderItemSerials.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					wSOrderItemSerials.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
					wSOrderItemSerials.AppType = Configuration.AppType;
					wSOrderItemSerials.WHId = CS_0024_003C_003E8__locals0.vm.WHId;
					wSOrderItemSerials.OrderItemId = CS_0024_003C_003E8__locals0.vm.OrderItemId;
					wSOrderItemSerials.SerialId = CS_0024_003C_003E8__locals0.vm.SerialId;
					wSOrderItemSerials.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (wSOrderItemSerials.OrderItemSerialID <= 0)
					{
						wSOrderItemSerials.FPId = Financial.Get().Id;
						wSOrderItemSerials.GUId = Guid.NewGuid();
						wSOrderItemSerials.FirstRegisterUserId = currentUser.UserId;
						wSOrderItemSerials.FirstRegisterDate = DateTime.Now;
						wSOrderItemSerials.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSOrderItemSerials.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						wSOrderItemSerials.CId = Order.GetOrdItemCId(wSOrderItemSerials.OrderItemId);
						_dbTbl.WSOrderItemSerials.Add(wSOrderItemSerials);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSOrderItemSerials_Lang wSOrderItemSerials_Lang = new WSOrderItemSerials_Lang();
							wSOrderItemSerials_Lang.LanguageID = lang.LanguageID;
							wSOrderItemSerials_Lang.OrderItemSerialID = wSOrderItemSerials.OrderItemSerialID;
							wSOrderItemSerials_Lang.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSOrderItemSerials_Lang.Add(wSOrderItemSerials_Lang);
							_dbTbl.SaveChanges();
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					else
					{
						_dbTbl.Entry(wSOrderItemSerials).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass6_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass6_2();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals2.lang = enumerator.Current;
								DbSet<WSOrderItemSerials_Lang> wSOrderItemSerials_Lang2 = _dbTbl.WSOrderItemSerials_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSOrderItemSerials_Lang), "c");
								WSOrderItemSerials_Lang wSOrderItemSerials_Lang3 = Queryable.FirstOrDefault<WSOrderItemSerials_Lang>((IQueryable<WSOrderItemSerials_Lang>)wSOrderItemSerials_Lang2, Expression.Lambda<Func<WSOrderItemSerials_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSOrderItemSerials_Lang3 != null)
								{
									wSOrderItemSerials_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSOrderItemSerials_Lang3).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSOrderItemSerials_Lang3 = new WSOrderItemSerials_Lang();
								wSOrderItemSerials_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
								wSOrderItemSerials_Lang3.OrderItemSerialID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.vm.OrderItemSerialID;
								wSOrderItemSerials_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.WSOrderItemSerials_Lang.Add(wSOrderItemSerials_Lang3);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					if (wSOrderItemSerials.OrderItemSerialID > 0)
					{
						bool flag2 = false;
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
						if (cRMspSelectCrmsysSetting_Result != null)
						{
							flag2 = cRMspSelectCrmsysSetting_Result.AddTracingCodeFromSerial.HasValue && cRMspSelectCrmsysSetting_Result.AddTracingCodeFromSerial != false;
						}
						if (flag2 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.Tracing))
						{
							DbSet<WSOrderItems> wSOrderItems = _dbTbl.WSOrderItems;
							ParameterExpression val = Expression.Parameter(typeof(WSOrderItems), "m");
							WSOrderItems wSOrderItems2 = Queryable.FirstOrDefault<WSOrderItems>((IQueryable<WSOrderItems>)wSOrderItems, Expression.Lambda<Func<WSOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSOrderItems2 != null && string.IsNullOrWhiteSpace(wSOrderItems2.ordITracing))
							{
								DateTime now2 = DateTime.Now;
								wSOrderItems2.Month1 = short.Parse(now2.ToString("MM", new PersianCulture()));
								wSOrderItems2.RegisterDate = now2;
								wSOrderItems2.RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
								wSOrderItems2.UserId = UserLogin.CurrentUser.UserId;
								wSOrderItems2.ordITracing = CS_0024_003C_003E8__locals0.vm.Tracing;
								_dbTbl.Entry(wSOrderItems2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
							}
						}
					}
					CS_0024_003C_003E8__locals0.vm.UserId = wSOrderItemSerials.UserId;
					CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = wSOrderItemSerials.FirstRegisterUserId;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = wSOrderItemSerials.RegisterDate;
					CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = wSOrderItemSerials.FirstRegisterDate;
					CS_0024_003C_003E8__locals0.vm.AppType = wSOrderItemSerials.AppType;
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
		base.ViewBag.FromNew = flag;
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public JsonResult SerialIdKendoLoad(int orderItemId = 0, int orderItemSerialId = 0, int whid = 0, string searchedValue = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnOrderItemSerial_Result> list = new List<WSspReturnOrderItemSerial_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspReturnOrderItemSerial_Result> list2 = Enumerable.ToList<WSspReturnOrderItemSerial_Result>((IEnumerable<WSspReturnOrderItemSerial_Result>)_db.WSspReturnOrderItemSerial(orderItemId, orderItemSerialId, whid, lCID, result, result2));
			if (list2 != null)
			{
				list = (string.IsNullOrWhiteSpace(searchedValue) ? Enumerable.ToList<WSspReturnOrderItemSerial_Result>(Enumerable.Take<WSspReturnOrderItemSerial_Result>((IEnumerable<WSspReturnOrderItemSerial_Result>)list2, 500)) : Enumerable.ToList<WSspReturnOrderItemSerial_Result>(Enumerable.Take<WSspReturnOrderItemSerial_Result>(Enumerable.Where<WSspReturnOrderItemSerial_Result>((IEnumerable<WSspReturnOrderItemSerial_Result>)list2, (Func<WSspReturnOrderItemSerial_Result, bool>)((WSspReturnOrderItemSerial_Result x) => x.Serial.ToLower().Contains(searchedValue.ToLower()))), 500)));
				foreach (WSspReturnOrderItemSerial_Result item in list)
				{
					item.DocDate = ((!string.IsNullOrEmpty(item.DocDate) && lCID != 1065) ? ((lCID == 1025) ? DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA")) : DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"))) : item.DocDate);
					item.AppType = (item.ExpDate.HasValue ? item.ExpDate.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "");
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actInsertItemSerialMulti")]
	public ActionResult InsertItemSerialMulti(int orderItemId, int currOrderItemSerialId, int whId)
	{
		List<WSspReturnOrderItemSerial_Result> list = new List<WSspReturnOrderItemSerial_Result>();
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
			list = Enumerable.ToList<WSspReturnOrderItemSerial_Result>((IEnumerable<WSspReturnOrderItemSerial_Result>)_db.WSspReturnOrderItemSerial(orderItemId, currOrderItemSerialId, whId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SerialsList = list;
		base.ViewBag.OrderItemId = orderItemId;
		base.ViewBag.CurrOrderItemSerialId = currOrderItemSerialId;
		base.ViewBag.WhId = whId;
		return View(list);
	}

	[HttpPost]
	public string InsertItemSerialMulti(int orderItemId, int whId, string selectedSerialIds)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_db.WSspInsertOrderItemSerialMulti(orderItemId.ToString(), UserLogin.CurrentUser.UserId.ToString(), DateTime.Now.ToString("MM", new PersianCulture()), Financial.Get().Id.ToString(), DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), whId.ToString(), Configuration.AppType, selectedSerialIds, result2);
		}
		catch (Exception ex)
		{
			result = ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
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
