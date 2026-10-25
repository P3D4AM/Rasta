using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class DraftItemSerialsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int docItemSerialId;

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
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public WSDocItemSerialsLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public WSDocItemSerials model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1;

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

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public const string SerialImportExcel_EXCEL_SHEET_NAME = "KaraAfzarIdeal";

	[DynamicAuthorize(ControllerName = "frmDraft", ActionName = "actInsertItemSerial,actEditItemSerial")]
	public ActionResult InsertEdit(int docItemId, int docItemSerialId, int docId = 0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.docItemSerialId = docItemSerialId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WSDocItemSerialsLanguageViewModel wSDocItemSerialsLanguageViewModel = new WSDocItemSerialsLanguageViewModel();
		bool flag = false;
		WSDocItems wSDocItems = _dbTbl.WSDocItems.Find(docItemId);
		base.ViewBag.PrdId = wSDocItems.PrdId;
		if (CS_0024_003C_003E8__locals0.docItemSerialId > 0)
		{
			DbSet<WSDocItemSerials_Lang> wSDocItemSerials_Lang = _dbTbl.WSDocItemSerials_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WSDocItemSerials_Lang), "c");
			List<WSDocItemSerials_Lang> list = Enumerable.ToList<WSDocItemSerials_Lang>((IEnumerable<WSDocItemSerials_Lang>)Queryable.Where<WSDocItemSerials_Lang>((IQueryable<WSDocItemSerials_Lang>)wSDocItemSerials_Lang, Expression.Lambda<Func<WSDocItemSerials_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WSDocItemSerials> wSDocItemSerials = _dbTbl.WSDocItemSerials;
			val = Expression.Parameter(typeof(WSDocItemSerials), "c");
			WSDocItemSerials wSDocItemSerials2 = Queryable.FirstOrDefault<WSDocItemSerials>((IQueryable<WSDocItemSerials>)wSDocItemSerials, Expression.Lambda<Func<WSDocItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
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
			wSDocItemSerialsLanguageViewModel.ItemId = docItemId;
			wSDocItemSerialsLanguageViewModel.DocItemSerialID = CS_0024_003C_003E8__locals0.docItemSerialId;
			wSDocItemSerialsLanguageViewModel.WHId = wSDocItems.WHId;
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
	[DynamicAuthorize(ControllerName = "frmDraftItemSerialDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WSDocItemSerialsLanguageViewModel vm)
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
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
			if (Draft.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.vm.DocId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				base.ViewBag.Error = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			try
			{
				WSDocItems wSDocItems = _dbTbl.WSDocItems.Find(CS_0024_003C_003E8__locals0.vm.ItemId);
				WSDoc wSDoc = _dbTbl.WSDoc.Find(wSDocItems.DocId);
				WSspCheckDuplicatePrdSerial_Result wSspCheckDuplicatePrdSerial_Result = Enumerable.FirstOrDefault<WSspCheckDuplicatePrdSerial_Result>((IEnumerable<WSspCheckDuplicatePrdSerial_Result>)Enumerable.ToList<WSspCheckDuplicatePrdSerial_Result>((IEnumerable<WSspCheckDuplicatePrdSerial_Result>)_db.WSspCheckDuplicatePrdSerial(wSDoc.OprId, Financial.Get().Id, CS_0024_003C_003E8__locals0.vm.WHId, wSDocItems.PrdId, CS_0024_003C_003E8__locals0.vm.Serial, CS_0024_003C_003E8__locals0.vm.DocItemSerialID, lCID, CS_0024_003C_003E8__locals0.defLangID, CS_0024_003C_003E8__locals0.vm.SerialId)));
				if (wSspCheckDuplicatePrdSerial_Result != null)
				{
					base.ViewBag.Error = Messages.msgSerialNumberDuplicateInDraft1 + wSspCheckDuplicatePrdSerial_Result.DocNumber + Messages.msgSerialNumberDuplicateInDraft2;
				}
				else
				{
					_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
					_003C_003Ec__DisplayClass5_.model = new WSDocItemSerials();
					if (CS_0024_003C_003E8__locals0.vm.DocItemSerialID > 0)
					{
						DbSet<WSDocItemSerials> wSDocItemSerials = _dbTbl.WSDocItemSerials;
						ParameterExpression val = Expression.Parameter(typeof(WSDocItemSerials), "c");
						_003C_003Ec__DisplayClass5_.model = Queryable.FirstOrDefault<WSDocItemSerials>((IQueryable<WSDocItemSerials>)wSDocItemSerials, Expression.Lambda<Func<WSDocItemSerials, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new WSDocItemSerials();
					}
					_003C_003Ec__DisplayClass5_.model.UserId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass5_.model.RegisterDate = now;
					_003C_003Ec__DisplayClass5_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass5_.model.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass5_.model.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass5_.model.WHId = CS_0024_003C_003E8__locals0.vm.WHId;
					_003C_003Ec__DisplayClass5_.model.ItemId = CS_0024_003C_003E8__locals0.vm.ItemId;
					_003C_003Ec__DisplayClass5_.model.SerialId = CS_0024_003C_003E8__locals0.vm.SerialId;
					_003C_003Ec__DisplayClass5_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass5_.model.Serial = CS_0024_003C_003E8__locals0.vm.Serial;
					_003C_003Ec__DisplayClass5_.model.RootId = CS_0024_003C_003E8__locals0.vm.RootId;
					if (_003C_003Ec__DisplayClass5_.model.DocItemSerialID <= 0)
					{
						_003C_003Ec__DisplayClass5_.model.FPId = Financial.Get().Id;
						_003C_003Ec__DisplayClass5_.model.GUId = Guid.NewGuid();
						_003C_003Ec__DisplayClass5_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass5_.model.FirstRegisterDate = DateTime.Now;
						_003C_003Ec__DisplayClass5_.model.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass5_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass5_.model.DocISCId = Doc.GetDocItemCId(_003C_003Ec__DisplayClass5_.model.ItemId);
						_dbTbl.WSDocItemSerials.Add(_003C_003Ec__DisplayClass5_.model);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSDocItemSerials_Lang wSDocItemSerials_Lang = new WSDocItemSerials_Lang();
							wSDocItemSerials_Lang.LanguageID = lang.LanguageID;
							wSDocItemSerials_Lang.DocItemSerialID = _003C_003Ec__DisplayClass5_.model.DocItemSerialID;
							wSDocItemSerials_Lang.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSDocItemSerials_Lang.Add(wSDocItemSerials_Lang);
							_dbTbl.SaveChanges();
						}
						if (_003C_003Ec__DisplayClass5_.model.DocItemSerialID > 0)
						{
							int userId = UserLogin.CurrentUser.UserId;
							DateTime now2 = DateTime.Now;
							string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
							short value = short.Parse(now2.ToString("MM", new PersianCulture()));
							int id = Financial.Get().Id;
							string appType = Configuration.AppType;
							_dbI.WSspUpdateDocItemSerialInfoById(_003C_003Ec__DisplayClass5_.model.DocItemSerialID, userId, value, id, now2, registerDatePersian, appType);
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					else
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass5_.model).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass5_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass5_3();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass5_;
								CS_0024_003C_003E8__locals2.lang = enumerator.Current;
								DbSet<WSDocItemSerials_Lang> wSDocItemSerials_Lang2 = _dbTbl.WSDocItemSerials_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSDocItemSerials_Lang), "c");
								WSDocItemSerials_Lang wSDocItemSerials_Lang3 = Queryable.FirstOrDefault<WSDocItemSerials_Lang>((IQueryable<WSDocItemSerials_Lang>)wSDocItemSerials_Lang2, Expression.Lambda<Func<WSDocItemSerials_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass5_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass5_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
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
						if (_003C_003Ec__DisplayClass5_.model.DocItemSerialID > 0)
						{
							int userId2 = UserLogin.CurrentUser.UserId;
							DateTime now3 = DateTime.Now;
							string registerDatePersian2 = now3.ToString("yyyyMMdd", new PersianCulture());
							short value2 = short.Parse(now3.ToString("MM", new PersianCulture()));
							int id2 = Financial.Get().Id;
							string appType2 = Configuration.AppType;
							_dbI.WSspUpdateDocItemSerialInfoById(_003C_003Ec__DisplayClass5_.model.DocItemSerialID, userId2, value2, id2, now3, registerDatePersian2, appType2);
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					if (_003C_003Ec__DisplayClass5_.model.DocItemSerialID > 0)
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
								ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "m");
								WSDocItems wSDocItems3 = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems2, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
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
					CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass5_.model.UserId;
					CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass5_.model.FirstRegisterUserId;
					CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass5_.model.RegisterDate;
					CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass5_.model.FirstRegisterDate;
					CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass5_.model.AppType;
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

	public JsonResult SerialIdKendoLoad(int fPId, int whid, int prdId, int draftItemSerialId, int ordId = 0, string searchedValue = "", string ordIds = "")
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
			List<WSspReturnDocPrdSerial_Result> list2 = Enumerable.ToList<WSspReturnDocPrdSerial_Result>((IEnumerable<WSspReturnDocPrdSerial_Result>)_db.WSspReturnDocPrdSerial(fPId, whid, prdId, draftItemSerialId, lCID, result, 0, result2, ordIds));
			if (list2 != null)
			{
				list = (string.IsNullOrWhiteSpace(searchedValue) ? Enumerable.ToList<WSspReturnDocPrdSerial_Result>(Enumerable.Take<WSspReturnDocPrdSerial_Result>((IEnumerable<WSspReturnDocPrdSerial_Result>)list2, 500)) : Enumerable.ToList<WSspReturnDocPrdSerial_Result>(Enumerable.Take<WSspReturnDocPrdSerial_Result>(Enumerable.Where<WSspReturnDocPrdSerial_Result>((IEnumerable<WSspReturnDocPrdSerial_Result>)list2, (Func<WSspReturnDocPrdSerial_Result, bool>)((WSspReturnDocPrdSerial_Result x) => x.Serial.ToLower().Contains(searchedValue.ToLower()))), 500)));
				foreach (WSspReturnDocPrdSerial_Result item in list)
				{
					item.Docdate = ((!string.IsNullOrEmpty(item.Docdate) && lCID != 1065) ? ((lCID == 1025) ? DateTime.Parse(PersianDate.GetShamsi2Miladi(item.Docdate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA")) : DateTime.Parse(PersianDate.GetShamsi2Miladi(item.Docdate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"))) : item.Docdate);
					item.AppType = (item.ExpDate.HasValue ? item.ExpDate.Value.ToString("yyyyMMdd", new CultureInfo("en-US")) : "");
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDraft", ActionName = "actInsertAutoItemSerial")]
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
				return Messages.msgErrorNotActiveDraft;
			}
			if (Draft.IsSentToLinkAccByAction(docId))
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

	[DynamicAuthorize(ControllerName = "frmDraft", ActionName = "actSerialImportExcel")]
	public ActionResult SerialImportExcel()
	{
		return View();
	}

	public ActionResult SerialImportExcelGenerateExcelFields()
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
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
			excelWorksheet.Cells[1, num].Value = Labels.DraftSerialImportExcelSerialI + " (" + string.Format(Labels.lblMaxCharacter, "50") + ")";
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.DraftSerialImportExcelDesc + " (" + string.Format(Labels.lblMaxCharacter, "300") + ")";
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

	public ActionResult UploadFile([DataSourceRequest] DataSourceRequest request, HttpPostedFileBase attachFileUrlUpload, int DocIPrdId, int whId, int oprId)
	{
		string filePath = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSDraftSerialImportExcelViewModel> list = new List<WSDraftSerialImportExcelViewModel>();
		try
		{
			_ = DateTime.Now;
			object[,] array = null;
			int num = 0;
			int num2 = 0;
			byte[] buffer = new byte[base.Request.ContentLength];
			base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
			using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
			{
				ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
				num = excelWorksheet.Dimension.End.Column;
				num2 = excelWorksheet.Dimension.End.Row;
				array = new object[num2, num];
				array = (object[,])excelWorksheet.Cells.Value;
			}
			try
			{
				if (num2 <= 1001)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					_ = Financial.Get().Id;
					int num3 = 2;
					object[] array2 = new object[num3];
					int num4 = 1;
					for (int i = 1; i < num2; i++)
					{
						int num5 = 0;
						string text = "";
						string text2 = "";
						bool hasConflict = false;
						string text3 = "";
						for (num5 = 0; num5 < num; num5++)
						{
							if (num5 < num3)
							{
								string text4 = "";
								array2[num5] = array[i, num5];
								if (array[0, num5] != null)
								{
									array[0, num5].ToString();
								}
								text4 = ((array2[num5] == null) ? "" : array2[num5].ToString());
								switch (num5)
								{
								case 0:
									text = text4;
									break;
								case 1:
									text2 = text4;
									break;
								}
							}
						}
						list.Add(new WSDraftSerialImportExcelViewModel
						{
							RowNumber = num4,
							Serial = (text ?? ""),
							Desc = (text2 ?? ""),
							HasConflict = hasConflict,
							ConflictDesc = (text3 ?? "")
						});
						num4++;
					}
				}
				else
				{
					list.Add(new WSDraftSerialImportExcelViewModel
					{
						RowNumber = -1,
						Serial = "",
						Desc = "",
						HasConflict = true,
						ConflictDesc = string.Format(Messages.msgErrorUploadExcelByMoreThanRecord, "1000")
					});
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
		JsonResult jsonResult = Json(((IEnumerable)new List<WSDraftSerialImportExcelViewModel>[1] { list }).ToDataSourceResult(request));
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

	public string SerialImportExcelFinalImport(string records, int docItemId, int docISerialAvailable, int mode, int docId = 0)
	{
		string result = "";
		try
		{
			if (Draft.IsSentToLinkAccByAction(docId))
			{
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				return "-1#|#" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<WSDraftSerialImportExcelViewModel> list = JsonConvert.DeserializeObject<List<WSDraftSerialImportExcelViewModel>>(records);
				if (list != null && Enumerable.Any<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list))
				{
					list = Enumerable.ToList<WSDraftSerialImportExcelViewModel>(Enumerable.Where<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list, (Func<WSDraftSerialImportExcelViewModel, bool>)((WSDraftSerialImportExcelViewModel m) => !m.HasConflict)));
				}
				if (list != null && Enumerable.Any<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list))
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
					int userId = UserLogin.CurrentUser.UserId;
					short.Parse(Financial.Get().Id.ToString());
					int id = Financial.Get().Id;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int? centerId = null;
					if (UserLogin.CurrentUser != null)
					{
						centerId = UserLogin.CurrentUser.UserLastCId;
					}
					ObjectParameter objectParameter = new ObjectParameter("Result", "");
					string docItemSerialJson = JsonConvert.SerializeObject(Enumerable.ToList<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list));
					_dbII.WSspImportDocItemSerialsFromExcelMultiRec(docItemId, docItemSerialJson, mode, userId, value, registerDatePersian, id, value2, appType, result2, objectParameter, centerId);
					if (objectParameter != null)
					{
						if (objectParameter.Value != null)
						{
							string value3 = objectParameter.Value.ToString();
							List<WSDraftSerialImportExcelViewModel> list2 = new List<WSDraftSerialImportExcelViewModel>();
							if (!string.IsNullOrWhiteSpace(value3))
							{
								List<WSDraftSerialImportExcelViewModel> list3 = JsonConvert.DeserializeObject<List<WSDraftSerialImportExcelViewModel>>(value3);
								if (list3 != null && Enumerable.Any<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list3))
								{
									if (list3.Count == 1 && (list3[0].ConflictErrorCode ?? "") == "-100")
									{
										return "-1#|#" + Messages.ErrorNotFindRecord;
									}
									foreach (WSDraftSerialImportExcelViewModel item in list3)
									{
										string text = "";
										bool hasConflict = false;
										if (!string.IsNullOrWhiteSpace(item.ConflictErrorCode))
										{
											string[] array = item.ConflictErrorCode.Split(new char[1] { ',' });
											if (array != null && array.Length != 0)
											{
												foreach (string text2 in array)
												{
													if (string.IsNullOrWhiteSpace(text2))
													{
														continue;
													}
													int result3 = 0;
													int.TryParse(text2, out result3);
													switch (result3)
													{
													case 1:
														hasConflict = false;
														text = Messages.msgSerialSaveInDoc;
														break;
													case -1:
														hasConflict = true;
														if (!string.IsNullOrWhiteSpace(text))
														{
															text += "|";
														}
														text += Messages.msgErrorSerialNumberCanNotGreaterNumberOfProduct;
														break;
													case -2:
														hasConflict = true;
														if (!string.IsNullOrWhiteSpace(text))
														{
															text += "|";
														}
														text += Messages.msgErrorSerialNotFoundAndInsert;
														break;
													case -3:
														hasConflict = true;
														if (!string.IsNullOrWhiteSpace(text))
														{
															text += "|";
														}
														text += Messages.msgErrorSerialIsDup;
														break;
													}
												}
											}
										}
										item.ConflictDesc = text;
										item.HasConflict = hasConflict;
									}
									list2.AddRange(list3);
								}
							}
							if (list != null && Enumerable.Any<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list))
							{
								List<WSDraftSerialImportExcelViewModel> list4 = Enumerable.ToList<WSDraftSerialImportExcelViewModel>(Enumerable.Where<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list, (Func<WSDraftSerialImportExcelViewModel, bool>)((WSDraftSerialImportExcelViewModel m) => m.HasConflict)));
								if (list4 != null && Enumerable.Any<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list4))
								{
									foreach (WSDraftSerialImportExcelViewModel item2 in list4)
									{
										item2.ConflictDesc = "";
										item2.HasConflict = true;
									}
									list2.AddRange(list4);
								}
							}
							if (list2 != null && Enumerable.Any<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list2))
							{
								list2 = Enumerable.ToList<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)Enumerable.OrderBy<WSDraftSerialImportExcelViewModel, int>((IEnumerable<WSDraftSerialImportExcelViewModel>)list2, (Func<WSDraftSerialImportExcelViewModel, int>)((WSDraftSerialImportExcelViewModel m) => m.RowNumber)));
								result = JsonConvert.SerializeObject(Enumerable.ToList<WSDraftSerialImportExcelViewModel>((IEnumerable<WSDraftSerialImportExcelViewModel>)list2));
							}
						}
						else
						{
							result = "-1#|#" + Messages.ErrorNotFindRecord;
						}
					}
					else
					{
						result = "-1#|#" + Messages.ErrorNotFindRecord;
					}
				}
				else
				{
					result = "-1#|#" + Messages.ErrorNotFindRecord;
				}
			}
			else
			{
				result = "-1#|#" + Messages.ErrorNotFindRecord;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-1#|#" + Messages.msgErrorRunFunction;
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
