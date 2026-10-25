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
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class WareHouseMovementItemSerialsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int docItemId;

		public int docItemSerialId;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public WSDocItemSerialsLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public WSDocItems orderItem;

		public WSDocItemSerials model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1;

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

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actInsertItemSerial,actEditItemSerial")]
	public ActionResult InsertEdit(int docItemId, int docItemSerialId, int docId = 0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.docItemId = docItemId;
		CS_0024_003C_003E8__locals0.docItemSerialId = docItemSerialId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSDocItemSerialsLanguageViewModel wSDocItemSerialsLanguageViewModel = new WSDocItemSerialsLanguageViewModel();
		bool flag = false;
		DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
		ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "m");
		WSDocItems wSDocItems2 = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		base.ViewBag.PrdId = wSDocItems2.PrdId;
		if (CS_0024_003C_003E8__locals0.docItemSerialId > 0)
		{
			DbSet<WSDocItemSerials_Lang> wSDocItemSerials_Lang = _dbTbl.WSDocItemSerials_Lang;
			val = Expression.Parameter(typeof(WSDocItemSerials_Lang), "c");
			List<WSDocItemSerials_Lang> list = Enumerable.ToList<WSDocItemSerials_Lang>((IEnumerable<WSDocItemSerials_Lang>)Queryable.Where<WSDocItemSerials_Lang>((IQueryable<WSDocItemSerials_Lang>)wSDocItemSerials_Lang, Expression.Lambda<Func<WSDocItemSerials_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSDocItemSerials> wSDocItemSerials = _dbTbl.WSDocItemSerials;
			val = Expression.Parameter(typeof(WSDocItemSerials), "c");
			WSDocItemSerials wSDocItemSerials2 = Queryable.FirstOrDefault<WSDocItemSerials>((IQueryable<WSDocItemSerials>)wSDocItemSerials, Expression.Lambda<Func<WSDocItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSDocItemSerials2 != null)
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSDocItemSerials_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSDocItemSerials_Lang>)list, (Func<WSDocItemSerials_Lang, CommonMultiLanguageViewModel>)((WSDocItemSerials_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSDocItemSerials2.Description,
					LanguageId = result
				});
				wSDocItemSerialsLanguageViewModel = new WSDocItemSerialsLanguageViewModel
				{
					LanguageID = wSDocItemSerials2.LanguageID,
					UserId = wSDocItemSerials2.UserId,
					FirstRegisterUserId = wSDocItemSerials2.FirstRegisterUserId,
					AppType = wSDocItemSerials2.AppType,
					FirstRegisterDate = wSDocItemSerials2.FirstRegisterDate,
					FirstRegisterDatePersian = wSDocItemSerials2.FirstRegisterDatePersian,
					GUId = wSDocItemSerials2.GUId,
					RegisterDate = wSDocItemSerials2.RegisterDate,
					Month1 = wSDocItemSerials2.Month1,
					RegisterDatePersian = wSDocItemSerials2.RegisterDatePersian,
					FPId = wSDocItemSerials2.FPId,
					WHId = wSDocItemSerials2.WHId,
					DocItemSerialID = wSDocItemSerials2.DocItemSerialID,
					ItemId = wSDocItemSerials2.ItemId,
					SerialId = wSDocItemSerials2.SerialId,
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Serial = wSDocItemSerials2.Serial,
					RootId = wSDocItemSerials2.RootId,
					SerialDetails = Enumerable.FirstOrDefault<WSspSelectDocItemSerialsWithId_Result>((IEnumerable<WSspSelectDocItemSerialsWithId_Result>)_dbI.WSspSelectDocItemSerialsWithId(wSDocItemSerials2.DocItemSerialID, CS_0024_003C_003E8__locals0.currLangID, result))
				};
			}
			flag = false;
		}
		else
		{
			wSDocItemSerialsLanguageViewModel = new WSDocItemSerialsLanguageViewModel();
			wSDocItemSerialsLanguageViewModel.ItemId = CS_0024_003C_003E8__locals0.docItemId;
			wSDocItemSerialsLanguageViewModel.DocItemSerialID = CS_0024_003C_003E8__locals0.docItemSerialId;
			wSDocItemSerialsLanguageViewModel.WHId = wSDocItems2.WHId;
			wSDocItemSerialsLanguageViewModel.FPId = Financial.Get().Id;
			flag = true;
			DateTime now = DateTime.Now;
			wSDocItemSerialsLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			wSDocItemSerialsLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSDocItemSerialsLanguageViewModel.RegisterDate = now;
			wSDocItemSerialsLanguageViewModel.FirstRegisterDate = now;
			wSDocItemSerialsLanguageViewModel.AppType = Configuration.AppType;
		}
		wSDocItemSerialsLanguageViewModel.DocId = docId;
		base.ViewBag.FromNew = flag;
		SetRegisterInfo(wSDocItemSerialsLanguageViewModel);
		return View(wSDocItemSerialsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmWareHouseMovementItemSerialDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSDocItemSerialsLanguageViewModel vm)
	{
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		bool flag = CS_0024_003C_003E8__locals0.vm.DocItemSerialID <= 0;
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		else if (!CS_0024_003C_003E8__locals0.vm.SerialId.HasValue || CS_0024_003C_003E8__locals0.vm.SerialId <= 0)
		{
			base.ViewBag.Error = Messages.msgErrorEnterSerialNumber;
		}
		else
		{
			if (WareHouseMovement.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.DocId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
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
				_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
				DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
				ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "m");
				_003C_003Ec__DisplayClass4_.orderItem = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
				val = Expression.Parameter(typeof(WSDoc), "m");
				if (Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null || _003C_003Ec__DisplayClass4_.orderItem == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					base.ViewBag.FromNew = flag;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				_003C_003Ec__DisplayClass4_.model = new WSDocItemSerials();
				if (CS_0024_003C_003E8__locals0.vm.DocItemSerialID > 0)
				{
					DbSet<WSDocItemSerials> wSDocItemSerials = _dbTbl.WSDocItemSerials;
					val = Expression.Parameter(typeof(WSDocItemSerials), "c");
					_003C_003Ec__DisplayClass4_.model = Queryable.FirstOrDefault<WSDocItemSerials>((IQueryable<WSDocItemSerials>)wSDocItemSerials, Expression.Lambda<Func<WSDocItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new WSDocItemSerials();
				}
				_003C_003Ec__DisplayClass4_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass4_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass4_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass4_.model.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass4_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass4_.model.WHId = CS_0024_003C_003E8__locals0.vm.WHId;
				_003C_003Ec__DisplayClass4_.model.ItemId = CS_0024_003C_003E8__locals0.vm.ItemId;
				_003C_003Ec__DisplayClass4_.model.SerialId = CS_0024_003C_003E8__locals0.vm.SerialId;
				_003C_003Ec__DisplayClass4_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass4_.model.Serial = CS_0024_003C_003E8__locals0.vm.Serial;
				_003C_003Ec__DisplayClass4_.model.RootId = CS_0024_003C_003E8__locals0.vm.RootId;
				if (_003C_003Ec__DisplayClass4_.model.DocItemSerialID <= 0)
				{
					_003C_003Ec__DisplayClass4_.model.FPId = Financial.Get().Id;
					_003C_003Ec__DisplayClass4_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass4_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass4_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass4_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass4_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass4_.model.DocISCId = Doc.GetDocItemCId(_003C_003Ec__DisplayClass4_.model.ItemId);
					_dbTbl.WSDocItemSerials.Add(_003C_003Ec__DisplayClass4_.model);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WSDocItemSerials_Lang wSDocItemSerials_Lang = new WSDocItemSerials_Lang();
						wSDocItemSerials_Lang.LanguageID = lang.LanguageID;
						wSDocItemSerials_Lang.DocItemSerialID = _003C_003Ec__DisplayClass4_.model.DocItemSerialID;
						wSDocItemSerials_Lang.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WSDocItemSerials_Lang.Add(wSDocItemSerials_Lang);
						_dbTbl.SaveChanges();
					}
					if (_003C_003Ec__DisplayClass4_.model.DocItemSerialID > 0)
					{
						int userId = UserLogin.CurrentUser.UserId;
						DateTime now2 = DateTime.Now;
						string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						short value = short.Parse(now2.ToString("MM", new PersianCulture()));
						int id = Financial.Get().Id;
						string appType = Configuration.AppType;
						_dbI.WSspUpdateDocItemSerialInfoById(_003C_003Ec__DisplayClass4_.model.DocItemSerialID, userId, value, id, now2, registerDatePersian, appType);
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				else
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass4_.model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass4_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass4_3();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass4_;
							CS_0024_003C_003E8__locals2.lang = enumerator.Current;
							DbSet<WSDocItemSerials_Lang> wSDocItemSerials_Lang2 = _dbTbl.WSDocItemSerials_Lang;
							val = Expression.Parameter(typeof(WSDocItemSerials_Lang), "c");
							WSDocItemSerials_Lang wSDocItemSerials_Lang3 = Queryable.FirstOrDefault<WSDocItemSerials_Lang>((IQueryable<WSDocItemSerials_Lang>)wSDocItemSerials_Lang2, Expression.Lambda<Func<WSDocItemSerials_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass4_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass4_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDocItemSerials_Lang3 != null)
							{
								wSDocItemSerials_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSDocItemSerials_Lang3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSDocItemSerials_Lang3 = new WSDocItemSerials_Lang();
							wSDocItemSerials_Lang3.LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID;
							wSDocItemSerials_Lang3.DocItemSerialID = CS_0024_003C_003E8__locals0.vm.DocItemSerialID;
							wSDocItemSerials_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
							_dbTbl.WSDocItemSerials_Lang.Add(wSDocItemSerials_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					if (_003C_003Ec__DisplayClass4_.model.DocItemSerialID > 0)
					{
						int userId2 = UserLogin.CurrentUser.UserId;
						DateTime now3 = DateTime.Now;
						string registerDatePersian2 = now3.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(now3.ToString("MM", new PersianCulture()));
						int id2 = Financial.Get().Id;
						string appType2 = Configuration.AppType;
						_dbI.WSspUpdateDocItemSerialInfoById(_003C_003Ec__DisplayClass4_.model.DocItemSerialID, userId2, value2, id2, now3, registerDatePersian2, appType2);
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				if (_003C_003Ec__DisplayClass4_.model.DocItemSerialID > 0)
				{
					bool flag2 = false;
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						flag2 = cRMspSelectCrmsysSetting_Result.AddTracingCodeFromSerial.HasValue && cRMspSelectCrmsysSetting_Result.AddTracingCodeFromSerial != false;
					}
					if (flag2)
					{
						CS_0024_003C_003E8__locals0.vm.Tracing = ((CS_0024_003C_003E8__locals0.vm.Tracing.ToLower() == "null") ? null : CS_0024_003C_003E8__locals0.vm.Tracing);
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.Tracing))
						{
							CS_0024_003C_003E8__locals0.vm.Tracing = ConvertCharacter.DecodeTracing(CS_0024_003C_003E8__locals0.vm.Tracing);
							DbSet<WSDocItems> wSDocItems2 = _dbTbl.WSDocItems;
							val = Expression.Parameter(typeof(WSDocItems), "m");
							WSDocItems wSDocItems3 = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems2, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDocItems3 != null && string.IsNullOrWhiteSpace(wSDocItems3.Tracing))
							{
								DateTime now4 = DateTime.Now;
								wSDocItems3.Month1 = short.Parse(now4.ToString("MM", new PersianCulture()));
								wSDocItems3.RegisterDate = now4;
								wSDocItems3.RegisterDatePersian = now4.ToString("yyyyMMdd", new PersianCulture());
								wSDocItems3.UserId = UserLogin.CurrentUser.UserId;
								wSDocItems3.Tracing = CS_0024_003C_003E8__locals0.vm.Tracing;
								_dbTbl.Entry(wSDocItems3).State = EntityState.Modified;
								_dbTbl.SaveChanges();
							}
						}
					}
				}
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass4_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass4_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass4_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass4_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass4_.model.AppType;
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

	public JsonResult SerialIdKendoLoad(int fPId, int whid, int prdId, int draftItemSerialId)
	{
		List<WSspReturnDocPrdSerial_Result> list = new List<WSspReturnDocPrdSerial_Result>();
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
			list = Enumerable.ToList<WSspReturnDocPrdSerial_Result>((IEnumerable<WSspReturnDocPrdSerial_Result>)_db.WSspReturnDocPrdSerial(fPId, whid, prdId, draftItemSerialId, lCID, result, 0, result2, ""));
			foreach (WSspReturnDocPrdSerial_Result item in list)
			{
				item.Docdate = ((!string.IsNullOrEmpty(item.Docdate) && lCID != 1065) ? ((lCID == 1025) ? DateTime.Parse(PersianDate.GetShamsi2Miladi(item.Docdate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA")) : DateTime.Parse(PersianDate.GetShamsi2Miladi(item.Docdate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"))) : item.Docdate);
				item.AppType = (item.ExpDate.HasValue ? item.ExpDate.Value.ToString("yyyyMMdd", new CultureInfo("en-US")) : "");
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

	public void SetRegisterInfo(WSDocItemSerialsLanguageViewModel model)
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
				WSDocItemSerialsLanguageViewModel wSDocItemSerialsLanguageViewModel = model;
				_ = model.UserId;
				wSDocItemSerialsLanguageViewModel.UserId = model.UserId;
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

	public string CheckDuplicateSerial(int oprId, int whId, int prdId, string serial, int currId, int docItemSerialId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int id = Financial.Get().Id;
			WSspCheckDuplicatePrdSerial_Result wSspCheckDuplicatePrdSerial_Result = Enumerable.FirstOrDefault<WSspCheckDuplicatePrdSerial_Result>((IEnumerable<WSspCheckDuplicatePrdSerial_Result>)_db.WSspCheckDuplicatePrdSerial(oprId, id, whId, prdId, serial, currId, lCID, result2, docItemSerialId));
			if (wSspCheckDuplicatePrdSerial_Result != null)
			{
				result = Messages.msgSerialNumberDuplicateInWareHouseMovement1 + wSspCheckDuplicatePrdSerial_Result.DocNumber + Messages.msgSerialNumberDuplicateInWareHouseMovement2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actInsertAutoItemSerial")]
	public string InsertAutoDocItemSerial(int docId, int docItemId, int whId)
	{
		string result = "1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (Doc.IsFixed(docId))
			{
				return Messages.msgErrorNotActiveWareHouseMovement;
			}
			if (WareHouseMovement.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			_dbI.WSspInsertAutoDocItemSerial(docItemId, whId, userId, value2, id, value, registerDatePersian, appType, result2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
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
