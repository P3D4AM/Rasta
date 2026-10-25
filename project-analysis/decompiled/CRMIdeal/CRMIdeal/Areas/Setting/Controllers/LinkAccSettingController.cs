using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_3
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_2
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_1
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int linkAccId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public CrmLinkAccSettingLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__21;

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

		internal bool _003CInsertEdit_003Eb__21(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public CrmLinkAccSetting model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1;

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

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		GetOrderOpr();
		GetPreOrderOpr();
		GetOrdPayType();
		GetRetOrdPayType();
		GetBuyOrdPayType();
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEdit(int linkAccId = 0, int linkAccSettingDBId = 0)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.linkAccId = linkAccId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
		List<CrmLinkAccSetting_Lang> list = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		DateTime now = DateTime.Now;
		CrmLinkAccSetting crmLinkAccSetting = new CrmLinkAccSetting();
		if (CS_0024_003C_003E8__locals0.linkAccId == 0)
		{
			crmLinkAccSetting = new CrmLinkAccSetting();
			crmLinkAccSetting.LinkAccSettingId = 0;
			crmLinkAccSetting.RegisterDate = now;
			crmLinkAccSetting.FirstRegisterDate = now;
			crmLinkAccSetting.LinkAccSystemId = 1;
			crmLinkAccSetting.LinkAccSettingDBId = linkAccSettingDBId;
		}
		else
		{
			DbSet<CrmLinkAccSetting> crmLinkAccSetting2 = _dbTbl.CrmLinkAccSetting;
			val = Expression.Parameter(typeof(CrmLinkAccSetting), "m");
			crmLinkAccSetting = Queryable.FirstOrDefault<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting2, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccSetting == null)
			{
				crmLinkAccSetting = new CrmLinkAccSetting();
				crmLinkAccSetting.LinkAccSettingId = 0;
				crmLinkAccSetting.RegisterDate = now;
				crmLinkAccSetting.FirstRegisterDate = now;
				crmLinkAccSetting.LinkAccSystemId = 1;
				crmLinkAccSetting.LinkAccSettingDBId = linkAccSettingDBId;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Description,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmLinkAccSetting.Description,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PartDescription,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = crmLinkAccSetting.PartDescription,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PartLabelTitle,
			LanguageId = item.LanguageID
		})));
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = crmLinkAccSetting.PartLabelTitle,
			LanguageId = result
		});
		CrmLinkAccSettingLanguageViewModel crmLinkAccSettingLanguageViewModel = new CrmLinkAccSettingLanguageViewModel
		{
			LinkAccSettingId = crmLinkAccSetting.LinkAccSettingId,
			PartTitle = crmLinkAccSetting.PartTitle,
			PartField = crmLinkAccSetting.PartField,
			PartValue = crmLinkAccSetting.PartValue,
			ObjectType = crmLinkAccSetting.ObjectType,
			PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PartDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PartLabelTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			FirstRegisterUserId = crmLinkAccSetting.FirstRegisterUserId,
			FirstRegisterDate = crmLinkAccSetting.FirstRegisterDate,
			FirstRegisterDatePersian = crmLinkAccSetting.FirstRegisterDatePersian,
			UserId = crmLinkAccSetting.UserId,
			Year1 = crmLinkAccSetting.Year1,
			Month1 = crmLinkAccSetting.Month1,
			RegisterDate = crmLinkAccSetting.RegisterDate,
			RegisterDatePersian = crmLinkAccSetting.RegisterDatePersian,
			GUId = crmLinkAccSetting.GUId,
			AppType = crmLinkAccSetting.AppType,
			LanguageID = crmLinkAccSetting.LanguageID,
			LinkAccSystemId = crmLinkAccSetting.LinkAccSystemId,
			LinkAccSettingDBId = crmLinkAccSetting.LinkAccSettingDBId
		};
		GetList(crmLinkAccSettingLanguageViewModel.PartTitle, linkAccSettingDBId);
		GetCmpLinkAccFieldValue(crmLinkAccSettingLanguageViewModel.PartField);
		return View(crmLinkAccSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmLinkAccSettingLanguageViewModel vm)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetList(CS_0024_003C_003E8__locals0.vm.PartTitle, CS_0024_003C_003E8__locals0.vm.LinkAccSettingDBId.GetValueOrDefault());
		GetCmpLinkAccFieldValue(CS_0024_003C_003E8__locals0.vm.PartField);
		if (base.ModelState.IsValid)
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
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PartDescription_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PartDescription_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PartDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PartLabelTitle_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PartLabelTitle_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.PartLabelTitle,
				LanguageId = lCID
			});
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass6_1 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_1();
					_003C_003Ec__DisplayClass6_.model = new CrmLinkAccSetting();
					if (CS_0024_003C_003E8__locals0.vm.LinkAccSettingId > 0)
					{
						DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting), "m");
						_003C_003Ec__DisplayClass6_.model = Queryable.FirstOrDefault<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass6_.model.PartTitle = CS_0024_003C_003E8__locals0.vm.PartTitle;
					_003C_003Ec__DisplayClass6_.model.PartField = CS_0024_003C_003E8__locals0.vm.PartField;
					_003C_003Ec__DisplayClass6_.model.PartValue = CS_0024_003C_003E8__locals0.vm.PartValue;
					_003C_003Ec__DisplayClass6_.model.ObjectType = CS_0024_003C_003E8__locals0.vm.ObjectType;
					_003C_003Ec__DisplayClass6_.model.PartDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass6_.model.PartLabelTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass6_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass6_.model.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass6_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass6_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass6_.model.RegisterDate = now;
					_003C_003Ec__DisplayClass6_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass6_.model.AppType = Configuration.AppType;
					if (CS_0024_003C_003E8__locals0.vm.LinkAccSettingId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass6_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass6_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass6_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
								CrmLinkAccSetting_Lang crmLinkAccSetting_Lang2 = Queryable.FirstOrDefault<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccSetting_Lang2 != null)
								{
									crmLinkAccSetting_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmLinkAccSetting_Lang2.PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmLinkAccSetting_Lang2.PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmLinkAccSetting_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmLinkAccSetting_Lang2 = new CrmLinkAccSetting_Lang();
								crmLinkAccSetting_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								crmLinkAccSetting_Lang2.LinkAccSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.LinkAccSettingId;
								crmLinkAccSetting_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmLinkAccSetting_Lang2.PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmLinkAccSetting_Lang2.PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.CrmLinkAccSetting_Lang.Add(crmLinkAccSetting_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass6_.model.LinkAccSystemId = CS_0024_003C_003E8__locals0.vm.LinkAccSystemId;
						_003C_003Ec__DisplayClass6_.model.LinkAccSettingDBId = CS_0024_003C_003E8__locals0.vm.LinkAccSettingDBId;
						_003C_003Ec__DisplayClass6_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass6_.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass6_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass6_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass6_.model.GUId = Guid.NewGuid();
						_dbTbl.CrmLinkAccSetting.Add(_003C_003Ec__DisplayClass6_.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmLinkAccSetting_Lang crmLinkAccSetting_Lang3 = new CrmLinkAccSetting_Lang();
							crmLinkAccSetting_Lang3.LanguageID = lang.LanguageID;
							crmLinkAccSetting_Lang3.LinkAccSettingId = _003C_003Ec__DisplayClass6_.model.LinkAccSettingId;
							crmLinkAccSetting_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmLinkAccSetting_Lang3.PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmLinkAccSetting_Lang3.PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmLinkAccSetting_Lang.Add(crmLinkAccSetting_Lang3);
							_dbTbl.SaveChanges();
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					CS_0024_003C_003E8__locals0.vm.LinkAccSettingId = _003C_003Ec__DisplayClass6_.model.LinkAccSettingId;
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
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPreOrderOpr()
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
			List<WSspSelectPreOrderOpr_Result> list2 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list2, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
			{
				Text = item.PreOrderOpr,
				Value = item.PreOrderOprID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetPreOrderOprList()
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
			List<WSspSelectPreOrderOpr_Result> list2 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list2, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
				{
					Text = item.PreOrderOpr,
					Value = item.PreOrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetPreOrderTypeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectPreOrderTypes_Result> list2 = PreOrder.SelectPreOrderTypes();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectPreOrderTypes_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderTypes_Result>)list2, (Func<WSspSelectPreOrderTypes_Result, SelectListItem>)((WSspSelectPreOrderTypes_Result item) => new SelectListItem
				{
					Text = item.PreOrderType,
					Value = item.PreOrderTypeId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetSettlementType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = GetSettlementTypeList();
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetSettlementTypeList()
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
			List<WSspSettlementType_Result> list2 = Enumerable.ToList<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSettlementType_Result, SelectListItem>((IEnumerable<WSspSettlementType_Result>)list2, (Func<WSspSettlementType_Result, SelectListItem>)((WSspSettlementType_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.Id.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPartTitle(string objType)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!string.IsNullOrEmpty(objType) && objType == "OrderOpr")
			{
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingMoienSalesCode,
					Value = "MoienSalesCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingSaleTypeCode,
					Value = "SaleTypeCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingProductSalesCode,
					Value = "ProductSalesCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingServiceSalesCode,
					Value = "ServiceSalesCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingProductSalesDiscountCode,
					Value = "ProductSalesDiscountCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingServiceSalesDiscountCode,
					Value = "ServiceSalesDiscountCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingProductSalesReturnCode,
					Value = "ProductSalesReturnCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingServiceSalesReturnCode,
					Value = "ServiceSalesReturnCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingSalesAdditionCode,
					Value = "SalesAdditionCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingTaxCode,
					Value = "TaxCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingDutyCode,
					Value = "DutyCode",
					Selected = false
				});
				list.Add(new SelectListItem
				{
					Text = Labels.CrmLinkAccSettingWarehouseCode,
					Value = "WarehouseCode",
					Selected = false
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PartTitleList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetList(string partTitle, int linkAccSettingDBId)
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
			if (!string.IsNullOrEmpty(partTitle))
			{
				switch (partTitle)
				{
				case "CmpLinkAccField":
					list.Add(new SelectListItem
					{
						Text = Labels.CrmLinkAccSettingCompanyType,
						Value = "cmpTypeId",
						Selected = false
					});
					list.Add(new SelectListItem
					{
						Text = Labels.CrmLinkAccSettingCompanyGroups,
						Value = "cmpGroupId",
						Selected = false
					});
					list.Add(new SelectListItem
					{
						Text = Labels.CrmLinkAccSettingCompanyGroupsII,
						Value = "cmpGroupIdII",
						Selected = false
					});
					list.Add(new SelectListItem
					{
						Text = Labels.CrmLinkAccSettingCompanyGroupsIII,
						Value = "cmpGroupIdIII",
						Selected = false
					});
					list.Add(new SelectListItem
					{
						Text = Labels.CrmLinkAccSettingCompanyGroupsIV,
						Value = "cmpGroupIdIV",
						Selected = false
					});
					break;
				case "DefOrdPayTypeId":
				{
					int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
					List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
					list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
					{
						Text = item.ordpayType,
						Value = item.OrderPaymentTypeId.ToString(),
						Selected = false
					})));
					break;
				}
				case "DefTspOrdSetmId":
				{
					List<SelectListItem> tspSetm = GetTspSetm();
					if (tspSetm != null)
					{
						list.AddRange(Enumerable.Select<SelectListItem, SelectListItem>((IEnumerable<SelectListItem>)tspSetm, (Func<SelectListItem, SelectListItem>)((SelectListItem item) => new SelectListItem
						{
							Text = item.Text,
							Value = item.Value.ToString(),
							Selected = false
						})));
					}
					break;
				}
				case "DefSepReferUserId":
					list = GetSepUserList(linkAccSettingDBId);
					if (list == null)
					{
						list = new List<SelectListItem>();
					}
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PartFieldList = list;
		base.ViewBag.partValueListI = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCmpLinkAccFieldValue(string partField)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!string.IsNullOrEmpty(partField))
			{
				switch (partField)
				{
				case "cmpTypeId":
					list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
					{
						Text = item.CompanyTypeName,
						Value = item.CompanyTypeID.ToString()
					})));
					break;
				case "cmpGroupId":
					list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
					{
						Text = item.GroupName,
						Value = item.CompanyGroupID.ToString()
					})));
					break;
				case "cmpGroupIdII":
					list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result)), (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
					{
						Text = item.GroupIIName,
						Value = item.CompanyGroupIIID.ToString()
					})));
					break;
				case "cmpGroupIdIII":
					list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result)), (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
					{
						Text = item.GroupIIIName,
						Value = item.CompanyGroupIIIID.ToString()
					})));
					break;
				case "cmpGroupIdIV":
					list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
					{
						Text = item.GroupIVName,
						Value = item.CompanyGroupIVID.ToString()
					})));
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.partValueList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdPayType()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetRetOrdPayType()
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
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RetOrdPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBuyOrdPayType()
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
			List<WSspSelectBuyOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)list2, (Func<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>)((WSspSelectBuyOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.bordpayType,
				Value = item.BuyOrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BuyOrdPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public List<SelectListItem> GetTspSetm()
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetSepUser(int linkAccSettingDBId)
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
			list = GetSepUserList(linkAccSettingDBId);
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetSepUserList(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectUser_Result> list2 = Enumerable.ToList<CRMspLkSepSelectUser_Result>((IEnumerable<CRMspLkSepSelectUser_Result>)_dbLink.CRMspLkSepSelectUser(linkAccSettingDBId, lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspLkSepSelectUser_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectUser_Result>)list2, (Func<CRMspLkSepSelectUser_Result, SelectListItem>)((CRMspLkSepSelectUser_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.UserID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> SelectConversationStatusGroups()
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
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectConversationStatusGroups_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Value = item2.ConversationStatusGroupID.ToString(),
						Text = item2.ConversationStatusGroup,
						Selected = false
					};
					list.Add(item);
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
	public JsonResult GetTaxAndDutyAccLinkAccSetting(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrder", lCID, result, 1, linkAccSettingDBId, null));
			if (list2 != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list2))
			{
				list.AddRange(list2);
			}
			List<CRMspSelectLinkAccSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "Order", lCID, result, 1, linkAccSettingDBId, null));
			if (list3 != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list3))
			{
				list.AddRange(list3);
			}
			List<CRMspSelectLinkAccSetting_Result> list4 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "BuyOrder", lCID, result, 1, linkAccSettingDBId, null));
			if (list4 != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list4))
			{
				list.AddRange(list4);
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
	public JsonResult GetPrdLinkedFieldLinkAccSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = new CRMspSelectLinkAccSetting_Result();
		try
		{
			cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "Product", lCID, result, 1, 0, "PrdLinkedField"));
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				if (!string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result.PartValue))
				{
					if (cRMspSelectLinkAccSetting_Result.PartValue.ToLower() == "prdcode")
					{
						cRMspSelectLinkAccSetting_Result.PartValue = Labels.OtherSystemsLinkedPrdCode;
					}
					else if (cRMspSelectLinkAccSetting_Result.PartValue.ToLower() == "prdfirstbarcode")
					{
						cRMspSelectLinkAccSetting_Result.PartValue = Labels.OtherSystemsLinkedPrdFirstBarcode;
					}
					else if (cRMspSelectLinkAccSetting_Result.PartValue.ToLower() == "prdmodel")
					{
						cRMspSelectLinkAccSetting_Result.PartValue = Labels.OtherSystemsLinkedPrdModel;
					}
				}
				else
				{
					cRMspSelectLinkAccSetting_Result.PartValue = "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(cRMspSelectLinkAccSetting_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetOtherPartLinkAccSetting(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccSettingOtherPartViewModel crmLinkAccSettingOtherPartViewModel = new CrmLinkAccSettingOtherPartViewModel();
		crmLinkAccSettingOtherPartViewModel.CmpAccountRemainPart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.ExcSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccSettingOtherPartViewModel.ShowCmpAccountingSummaryPart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails = new List<CRMspSelectLinkAccSettingDetails_Result>();
		crmLinkAccSettingOtherPartViewModel.CompanyLinkAccSetting = new CRMspSelectCompanyLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.CmpAccFromLink = false;
		crmLinkAccSettingOtherPartViewModel.DefWarehouseLinkAccSetting = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSetting = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails = new List<CRMspSelectLinkAccSettingDetails_Result>();
		crmLinkAccSettingOtherPartViewModel.DefOrdPayTypeSetting = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.DefSepReferUserLinkAccSetting = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.CmpAccountRemainingMoienAccCodePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.SepNotHavePordModulePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.SepNotHaveOrdModulePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.SepNotHaveBordModulePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.SepNotHaveDocModulePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.SepNotHavePayModulePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccSettingOtherPartViewModel.SepNotHaveCommModulePart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.IssueVoucherWithoutOrdDiscPart = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccSettingOtherPartViewModel.PrdCodeSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccSettingOtherPartViewModel.CmpProjectSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccSettingOtherPartViewModel.CmpCodeSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, null, lCID, result, 1, linkAccSettingDBId, null));
			if (list != null)
			{
				crmLinkAccSettingOtherPartViewModel.CmpAccountRemainPart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "CmpAccountRemain" && (m.PartTitle ?? "") == "CmpAccountRemainingAccCode")));
				if (crmLinkAccSettingOtherPartViewModel.CmpAccountRemainPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.CmpAccountRemainPart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.CmpAccountRemainingMoienAccCodePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "CmpAccountRemain" && (m.PartTitle ?? "") == "CmpAccountRemainingMoienAccCode")));
				if (crmLinkAccSettingOtherPartViewModel.CmpAccountRemainingMoienAccCodePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.CmpAccountRemainingMoienAccCodePart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.ExcSettingPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "ExcSetting")));
				if (crmLinkAccSettingOtherPartViewModel.ExcSettingPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.ExcSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				crmLinkAccSettingOtherPartViewModel.ShowCmpAccountingSummaryPart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "CmpAccountRemain" && (m.PartTitle ?? "") == "ShowCmpAccountingSummary")));
				if (crmLinkAccSettingOtherPartViewModel.ShowCmpAccountingSummaryPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.ShowCmpAccountingSummaryPart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "DefTspOrdSetm")));
				if (crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart = new CRMspSelectLinkAccSetting_Result();
				}
				else
				{
					int result2 = 0;
					int.TryParse(crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart.PartValue, out result2);
					switch (result2)
					{
					case 1:
						crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart.PartValue = Labels.TspSetmI;
						break;
					case 2:
						crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart.PartValue = Labels.TspSetmII;
						break;
					case 3:
						crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart.PartValue = Labels.TspSetmIII;
						break;
					default:
						crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmPart.PartValue = "";
						break;
					}
				}
				int result3 = 0;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "DefTspOrdSetm" && (m.PartTitle ?? "") == "DefTspOrdSetmId")));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result3);
				}
				crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "DefTspOrdSetm", lCID, result, 1, linkAccSettingDBId));
				if (crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails == null)
				{
					crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails = new List<CRMspSelectLinkAccSettingDetails_Result>();
				}
				if (crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails != null)
				{
					if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails))
					{
						List<SelectListItem> settlementTypeList = GetSettlementTypeList();
						if (settlementTypeList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)settlementTypeList))
						{
							foreach (SelectListItem item8 in settlementTypeList)
							{
								int settlemetTypeId = 0;
								int.TryParse(item8.Value, out settlemetTypeId);
								if (settlemetTypeId != 0)
								{
									bool flag = false;
									if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == settlemetTypeId)) != null)
									{
										flag = true;
									}
									if (!flag)
									{
										CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
										{
											LinkAccSettingDetailId = -1,
											LinkAccSettingId = result3,
											ObjectId = settlemetTypeId,
											PartTitle = "DefTspOrdSetmId",
											ObjectTypeTitle = (item8.Text ?? ""),
											ObjectType = "DefTspOrdSetm",
											PartLabelTitle = (item8.Text ?? "")
										};
										crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails.Add(item2);
									}
								}
							}
						}
						foreach (CRMspSelectLinkAccSettingDetails_Result defTspOrdSetmSettingDetail in crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails)
						{
							int result4 = 0;
							int.TryParse(defTspOrdSetmSettingDetail.PartValue, out result4);
							switch (result4)
							{
							case 1:
								defTspOrdSetmSettingDetail.PartValue = Labels.TspSetmI;
								break;
							case 2:
								defTspOrdSetmSettingDetail.PartValue = Labels.TspSetmII;
								break;
							case 3:
								defTspOrdSetmSettingDetail.PartValue = Labels.TspSetmIII;
								break;
							default:
								defTspOrdSetmSettingDetail.PartValue = "";
								break;
							}
						}
					}
					else
					{
						List<SelectListItem> settlementTypeList2 = GetSettlementTypeList();
						if (settlementTypeList2 != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)settlementTypeList2))
						{
							foreach (SelectListItem item9 in settlementTypeList2)
							{
								int result5 = 0;
								int.TryParse(item9.Value, out result5);
								if (result5 != 0)
								{
									CRMspSelectLinkAccSettingDetails_Result item3 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result3,
										ObjectId = result5,
										PartTitle = "DefTspOrdSetmId",
										ObjectTypeTitle = (item9.Text ?? ""),
										ObjectType = "DefTspOrdSetm",
										PartLabelTitle = (item9.Text ?? "")
									};
									crmLinkAccSettingOtherPartViewModel.DefTspOrdSetmSettingDetails.Add(item3);
								}
							}
						}
					}
				}
				crmLinkAccSettingOtherPartViewModel.SepNotHavePordModulePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrder" && (m.PartTitle ?? "") == "SepNotHavePordModule")));
				if (crmLinkAccSettingOtherPartViewModel.SepNotHavePordModulePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.SepNotHavePordModulePart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.SepNotHaveOrdModulePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Order" && (m.PartTitle ?? "") == "SepNotHaveOrdModule")));
				if (crmLinkAccSettingOtherPartViewModel.SepNotHaveOrdModulePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.SepNotHaveOrdModulePart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.SepNotHaveBordModulePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "BuyOrder" && (m.PartTitle ?? "") == "SepNotHaveBordModule")));
				if (crmLinkAccSettingOtherPartViewModel.SepNotHaveBordModulePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.SepNotHaveBordModulePart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.SepNotHaveDocModulePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Doc" && (m.PartTitle ?? "") == "SepNotHaveDocModule")));
				if (crmLinkAccSettingOtherPartViewModel.SepNotHaveDocModulePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.SepNotHaveDocModulePart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.SepNotHavePayModulePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Payment" && (m.PartTitle ?? "") == "SepNotHavePayModule")));
				if (crmLinkAccSettingOtherPartViewModel.SepNotHavePayModulePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.SepNotHavePayModulePart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.SepNotHaveCommModulePart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Commission" && (m.PartTitle ?? "") == "SepNotHaveCommModule")));
				if (crmLinkAccSettingOtherPartViewModel.SepNotHaveCommModulePart == null)
				{
					crmLinkAccSettingOtherPartViewModel.SepNotHaveCommModulePart = new CRMspSelectLinkAccSetting_Result();
				}
				string crmLinkAccSettingCompanyType = Labels.CrmLinkAccSettingCompanyType;
				string crmLinkAccSettingCompanyGroups = Labels.CrmLinkAccSettingCompanyGroups;
				string crmLinkAccSettingCompanyGroupsII = Labels.CrmLinkAccSettingCompanyGroupsII;
				string crmLinkAccSettingCompanyGroupsIII = Labels.CrmLinkAccSettingCompanyGroupsIII;
				string crmLinkAccSettingCompanyGroupsIV = Labels.CrmLinkAccSettingCompanyGroupsIV;
				crmLinkAccSettingOtherPartViewModel.CompanyLinkAccSetting = Enumerable.FirstOrDefault<CRMspSelectCompanyLinkAccSetting_Result>((IEnumerable<CRMspSelectCompanyLinkAccSetting_Result>)_dbLink.CRMspSelectCompanyLinkAccSetting(crmLinkAccSettingCompanyType, crmLinkAccSettingCompanyGroups, crmLinkAccSettingCompanyGroupsII, crmLinkAccSettingCompanyGroupsIII, crmLinkAccSettingCompanyGroupsIV, lCID, result, 1, linkAccSettingDBId));
				if (crmLinkAccSettingOtherPartViewModel.CompanyLinkAccSetting == null)
				{
					crmLinkAccSettingOtherPartViewModel.CompanyLinkAccSetting = new CRMspSelectCompanyLinkAccSetting_Result();
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					crmLinkAccSettingOtherPartViewModel.CmpAccFromLink = cRMspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault();
				}
				crmLinkAccSettingOtherPartViewModel.DefSepReferUserLinkAccSetting = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "DefSepReferUser" && (m.PartTitle ?? "") == "DefSepReferUserId")));
				if (crmLinkAccSettingOtherPartViewModel.DefSepReferUserLinkAccSetting == null)
				{
					crmLinkAccSettingOtherPartViewModel.DefSepReferUserLinkAccSetting = new CRMspSelectLinkAccSetting_Result();
				}
				else
				{
					string defUserPartVal = crmLinkAccSettingOtherPartViewModel.DefSepReferUserLinkAccSetting.PartValue ?? "";
					if (!string.IsNullOrWhiteSpace(defUserPartVal))
					{
						List<SelectListItem> sepUserList = GetSepUserList(linkAccSettingDBId);
						if (sepUserList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)sepUserList))
						{
							SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)sepUserList, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == defUserPartVal));
							if (selectListItem != null)
							{
								crmLinkAccSettingOtherPartViewModel.DefSepReferUserLinkAccSetting.PartValue = selectListItem.Text ?? "";
							}
						}
					}
				}
				crmLinkAccSettingOtherPartViewModel.DefWarehouseLinkAccSetting = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "" && (m.PartTitle ?? "") == "WarehouseAccCode")));
				if (crmLinkAccSettingOtherPartViewModel.DefWarehouseLinkAccSetting == null)
				{
					crmLinkAccSettingOtherPartViewModel.DefWarehouseLinkAccSetting = new CRMspSelectLinkAccSetting_Result();
				}
				int result6 = 0;
				crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSetting = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrderOpr" && (m.PartTitle ?? "") == "PordFieldLinkToSaleType")));
				if (crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSetting == null)
				{
					crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSetting = new CRMspSelectLinkAccSetting_Result();
				}
				else
				{
					int.TryParse(crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSetting.PartValue, out result6);
				}
				int result7 = 0;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrderOpr" && (m.PartTitle ?? "") == "SaleTypeAccCode")));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result2.LinkAccSettingId.ToString(), out result7);
				}
				crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "PreOrderOpr", lCID, result, 1, linkAccSettingDBId));
				if (crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails == null)
				{
					crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails = new List<CRMspSelectLinkAccSettingDetails_Result>();
				}
				if (crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails != null)
				{
					if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails))
					{
						switch (result6)
						{
						case 1:
						{
							List<SelectListItem> preOrderOprList = GetPreOrderOprList();
							if (preOrderOprList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList))
							{
								break;
							}
							foreach (SelectListItem item10 in preOrderOprList)
							{
								int pordOprId = 0;
								int.TryParse(item10.Value, out pordOprId);
								if (pordOprId != 0)
								{
									bool flag3 = false;
									if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)) != null)
									{
										flag3 = true;
									}
									if (!flag3)
									{
										CRMspSelectLinkAccSettingDetails_Result item5 = new CRMspSelectLinkAccSettingDetails_Result
										{
											LinkAccSettingDetailId = -1,
											LinkAccSettingId = result7,
											ObjectId = pordOprId,
											PartTitle = "SaleTypeAccCode",
											ObjectTypeTitle = (item10.Text ?? ""),
											ObjectType = "PreOrderOpr"
										};
										crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails.Add(item5);
									}
								}
							}
							break;
						}
						case 2:
						{
							List<SelectListItem> preOrderTypeList = GetPreOrderTypeList();
							if (preOrderTypeList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList))
							{
								break;
							}
							foreach (SelectListItem item11 in preOrderTypeList)
							{
								int pordTypeId = 0;
								int.TryParse(item11.Value, out pordTypeId);
								if (pordTypeId != 0)
								{
									bool flag2 = false;
									if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)) != null)
									{
										flag2 = true;
									}
									if (!flag2)
									{
										CRMspSelectLinkAccSettingDetails_Result item4 = new CRMspSelectLinkAccSettingDetails_Result
										{
											LinkAccSettingDetailId = -1,
											LinkAccSettingId = result7,
											ObjectId = pordTypeId,
											PartTitle = "SaleTypeAccCode",
											ObjectTypeTitle = (item11.Text ?? ""),
											ObjectType = "PreOrderOpr"
										};
										crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails.Add(item4);
									}
								}
							}
							break;
						}
						}
					}
					else
					{
						switch (result6)
						{
						case 1:
						{
							List<SelectListItem> preOrderOprList2 = GetPreOrderOprList();
							if (preOrderOprList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList2))
							{
								break;
							}
							foreach (SelectListItem item12 in preOrderOprList2)
							{
								int result9 = 0;
								int.TryParse(item12.Value, out result9);
								if (result9 != 0)
								{
									CRMspSelectLinkAccSettingDetails_Result item7 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result7,
										ObjectId = result9,
										PartTitle = "SaleTypeAccCode",
										ObjectTypeTitle = (item12.Text ?? ""),
										ObjectType = "PreOrderOpr"
									};
									crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails.Add(item7);
								}
							}
							break;
						}
						case 2:
						{
							List<SelectListItem> preOrderTypeList2 = GetPreOrderTypeList();
							if (preOrderTypeList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList2))
							{
								break;
							}
							foreach (SelectListItem item13 in preOrderTypeList2)
							{
								int result8 = 0;
								int.TryParse(item13.Value, out result8);
								if (result8 != 0)
								{
									CRMspSelectLinkAccSettingDetails_Result item6 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result7,
										ObjectId = result8,
										PartTitle = "SaleTypeAccCode",
										ObjectTypeTitle = (item13.Text ?? ""),
										ObjectType = "PreOrderOpr"
									};
									crmLinkAccSettingOtherPartViewModel.PordFieldLinkToSaleTypeSettingDetails.Add(item6);
								}
							}
							break;
						}
						}
					}
				}
				crmLinkAccSettingOtherPartViewModel.DefOrdPayTypeSetting = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "DefOrdPayType" && (m.PartTitle ?? "") == "DefOrdPayTypeId")));
				if (crmLinkAccSettingOtherPartViewModel.DefOrdPayTypeSetting == null)
				{
					crmLinkAccSettingOtherPartViewModel.DefOrdPayTypeSetting = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "OrdComm")));
				if (crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart))
				{
					foreach (CRMspSelectLinkAccSetting_Result item14 in crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart)
					{
						if ((item14.PartTitle ?? "") == "DebitType" || (item14.PartTitle ?? "") == "CreditType")
						{
							switch (item14.PartValue)
							{
							case "1":
								item14.PartValue = Labels.LinkAccSettingDebitCreditTypeI;
								break;
							case "2":
								item14.PartValue = Labels.LinkAccSettingDebitCreditTypeII;
								break;
							case "3":
								item14.PartValue = Labels.LinkAccSettingDebitCreditTypeIII;
								break;
							case "4":
								item14.PartValue = Labels.LinkAccSettingDebitCreditTypeIV;
								break;
							}
						}
					}
				}
				if (crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.OrdCommSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				crmLinkAccSettingOtherPartViewModel.IssueVoucherWithoutOrdDiscPart = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Order" && (m.PartTitle ?? "") == "IssueVoucherWithoutOrdDisc")));
				if (crmLinkAccSettingOtherPartViewModel.IssueVoucherWithoutOrdDiscPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.IssueVoucherWithoutOrdDiscPart = new CRMspSelectLinkAccSetting_Result();
				}
				crmLinkAccSettingOtherPartViewModel.PrdCodeSettingPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PrdCode")));
				if (crmLinkAccSettingOtherPartViewModel.PrdCodeSettingPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.PrdCodeSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				crmLinkAccSettingOtherPartViewModel.CmpProjectSettingPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "CmpProject")));
				if (crmLinkAccSettingOtherPartViewModel.CmpProjectSettingPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.CmpProjectSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				else
				{
					foreach (CRMspSelectLinkAccSetting_Result item in crmLinkAccSettingOtherPartViewModel.CmpProjectSettingPart)
					{
						if (string.IsNullOrWhiteSpace(item.PartValue) || !((item.PartTitle ?? "") == "DefPrjCvnsStatusGroupId"))
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(item.PartValue))
						{
							List<SelectListItem> list2 = SelectConversationStatusGroups();
							if (list2 != null)
							{
								SelectListItem selectListItem2 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.PartValue));
								if (selectListItem2 != null)
								{
									item.PartValue = selectListItem2.Text ?? "";
								}
							}
						}
						else
						{
							item.PartValue = "";
						}
					}
				}
				crmLinkAccSettingOtherPartViewModel.CmpCodeSettingPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "CmpCode")));
				if (crmLinkAccSettingOtherPartViewModel.CmpCodeSettingPart == null)
				{
					crmLinkAccSettingOtherPartViewModel.CmpCodeSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(crmLinkAccSettingOtherPartViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetPordFieldLinkToSaleTypeList(int pordFieldLinkToSaleType, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			List<CRMspSelectLinkAccSettingDetails_Result> list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			int result2 = 0;
			CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = new CRMspSelectLinkAccSetting_Result();
			List<CRMspSelectLinkAccSetting_Result> list4 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrderOpr", currLangID, result, 1, linkAccSettingDBId, ""));
			int result3 = 0;
			int result4 = 0;
			if (list4 != null)
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list4, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "SaleTypeAccCode"));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result2.LinkAccSettingId.ToString(), out result3);
				}
				cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list4, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "PordFieldLinkToSaleType"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result4);
				}
			}
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				int.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
			}
			if (result2 == pordFieldLinkToSaleType)
			{
				list3 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "PreOrderOpr", currLangID, result, 1, linkAccSettingDBId));
			}
			if (list3 == null)
			{
				list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			}
			if (list3 != null)
			{
				if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3))
				{
					switch (pordFieldLinkToSaleType)
					{
					case 1:
					{
						List<SelectListItem> preOrderOprList = GetPreOrderOprList();
						if (preOrderOprList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList))
						{
							break;
						}
						foreach (SelectListItem item5 in preOrderOprList)
						{
							int pordOprId = 0;
							int.TryParse(item5.Value, out pordOprId);
							if (pordOprId == 0)
							{
								continue;
							}
							bool flag2 = false;
							if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)) != null)
							{
								Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)).PartLabelTitle = item5.Text ?? "";
								flag2 = true;
							}
							if (!flag2)
							{
								CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = pordOprId,
									PartTitle = "SaleTypeAccCode",
									ObjectTypeTitle = (item5.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item5.Text ?? "")
								};
								list3.Add(item2);
							}
						}
						break;
					}
					case 2:
					{
						List<SelectListItem> preOrderTypeList = GetPreOrderTypeList();
						if (preOrderTypeList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList))
						{
							break;
						}
						foreach (SelectListItem item6 in preOrderTypeList)
						{
							int pordTypeId = 0;
							int.TryParse(item6.Value, out pordTypeId);
							if (pordTypeId == 0)
							{
								continue;
							}
							bool flag = false;
							if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)) != null)
							{
								Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)).PartLabelTitle = item6.Text ?? "";
								flag = true;
							}
							if (!flag)
							{
								CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = pordTypeId,
									PartTitle = "SaleTypeAccCode",
									ObjectTypeTitle = (item6.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item6.Text ?? "")
								};
								list3.Add(item);
							}
						}
						break;
					}
					}
				}
				else
				{
					switch (pordFieldLinkToSaleType)
					{
					case 1:
					{
						List<SelectListItem> preOrderOprList2 = GetPreOrderOprList();
						if (preOrderOprList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList2))
						{
							break;
						}
						foreach (SelectListItem item7 in preOrderOprList2)
						{
							int result6 = 0;
							int.TryParse(item7.Value, out result6);
							if (result6 != 0)
							{
								CRMspSelectLinkAccSettingDetails_Result item4 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = result6,
									PartTitle = "SaleTypeAccCode",
									ObjectTypeTitle = (item7.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item7.Text ?? "")
								};
								list3.Add(item4);
							}
						}
						break;
					}
					case 2:
					{
						List<SelectListItem> preOrderTypeList2 = GetPreOrderTypeList();
						if (preOrderTypeList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList2))
						{
							break;
						}
						foreach (SelectListItem item8 in preOrderTypeList2)
						{
							int result5 = 0;
							int.TryParse(item8.Value, out result5);
							if (result5 != 0)
							{
								CRMspSelectLinkAccSettingDetails_Result item3 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = result5,
									PartTitle = "SaleTypeAccCode",
									ObjectTypeTitle = (item8.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item8.Text ?? "")
								};
								list3.Add(item3);
							}
						}
						break;
					}
					}
				}
				list2.AddRange(list3);
			}
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSettingDetails_Result>.Enumerator enumerator2 = list2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass26_3 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_3();
					_003C_003Ec__DisplayClass26_.item = enumerator2.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list5 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (list5 != null)
					{
						list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSettingDetails_Lang>)list5, (Func<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccSettingDetails2 != null)
					{
						list6.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetails2.Description,
							LanguageId = result
						});
					}
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass26_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass26_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass26_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass26_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass26_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass26_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.ObjectId = _003C_003Ec__DisplayClass26_.item.ObjectId.GetValueOrDefault();
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
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
	public JsonResult GetDefTspOrdSetmList(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			List<CRMspSelectLinkAccSettingDetails_Result> list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "DefTspOrdSetm", currLangID, result, 1, linkAccSettingDBId, "DefTspOrdSetmId"));
			int result2 = 0;
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result2);
			}
			list3 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "DefTspOrdSetm", currLangID, result, 1, linkAccSettingDBId));
			if (list3 == null)
			{
				list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			}
			if (list3 != null)
			{
				if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3))
				{
					List<SelectListItem> settlementTypeList = GetSettlementTypeList();
					if (settlementTypeList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)settlementTypeList))
					{
						foreach (SelectListItem item3 in settlementTypeList)
						{
							int settlemetTypeId = 0;
							int.TryParse(item3.Value, out settlemetTypeId);
							if (settlemetTypeId == 0)
							{
								continue;
							}
							bool flag = false;
							if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == settlemetTypeId)) != null)
							{
								Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == settlemetTypeId)).PartLabelTitle = item3.Text ?? "";
								flag = true;
							}
							if (!flag)
							{
								CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result2,
									ObjectId = settlemetTypeId,
									PartTitle = "DefTspOrdSetmId",
									ObjectTypeTitle = (item3.Text ?? ""),
									ObjectType = "DefTspOrdSetm",
									PartLabelTitle = (item3.Text ?? "")
								};
								list3.Add(item);
							}
						}
					}
				}
				else
				{
					List<SelectListItem> settlementTypeList2 = GetSettlementTypeList();
					if (settlementTypeList2 != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)settlementTypeList2))
					{
						foreach (SelectListItem item4 in settlementTypeList2)
						{
							int result3 = 0;
							int.TryParse(item4.Value, out result3);
							if (result3 != 0)
							{
								CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result2,
									ObjectId = result3,
									PartTitle = "DefTspOrdSetmId",
									ObjectTypeTitle = (item4.Text ?? ""),
									ObjectType = "DefTspOrdSetm",
									PartLabelTitle = (item4.Text ?? "")
								};
								list3.Add(item2);
							}
						}
					}
				}
				list2.AddRange(list3);
			}
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSettingDetails_Result>.Enumerator enumerator2 = list2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass27_2 _003C_003Ec__DisplayClass27_ = new _003C_003Ec__DisplayClass27_2();
					_003C_003Ec__DisplayClass27_.item = enumerator2.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list4 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass27_, typeof(_003C_003Ec__DisplayClass27_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass27_, typeof(_003C_003Ec__DisplayClass27_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (list4 != null)
					{
						list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSettingDetails_Lang>)list4, (Func<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccSettingDetails2 != null)
					{
						list5.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetails2.Description,
							LanguageId = result
						});
					}
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass27_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass27_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass27_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass27_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass27_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass27_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.ObjectId = _003C_003Ec__DisplayClass27_.item.ObjectId.GetValueOrDefault();
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
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
	public JsonResult GetSelectLinkAccSettingDetails(int objId = 0, string objType = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingDetails_Result> list = new List<CRMspSelectLinkAccSettingDetails_Result>();
		try
		{
			if (objId != 0 && !string.IsNullOrEmpty(objType))
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				_dbLink.CRMspInsertLinkAccSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result, 1, linkAccSettingDBId);
				list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, lCID, result, 1, linkAccSettingDBId), (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "WarehouseAccCode")));
				if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list) && objType == "OrderOpr")
				{
					WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(objId, lCID, result));
					if (wSspSelectOrderOprById_Result != null)
					{
						int result2 = 0;
						int.TryParse(wSspSelectOrderOprById_Result.OprType.ToString(), out result2);
						switch (result2)
						{
						case 1:
							list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesReturnedAccCode" && (m.PartTitle ?? "") != "ServiceSalesReturnedAccCode")));
							break;
						case 2:
							list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesAccCode" && (m.PartTitle ?? "") != "ServiceSalesAccCode")));
							break;
						}
						if (list == null)
						{
							list = new List<CRMspSelectLinkAccSettingDetails_Result>();
						}
					}
				}
				int num = 0;
				switch (objType)
				{
				case "OrdPayType":
				case "RetOrdPayType_Negative":
				case "BuyOrdPayType_Negative":
				case "PordPayType":
					num = 1;
					break;
				case "RetOrdPayType":
				case "BuyOrdPayType":
				case "OrdPayType_Negative":
				case "PordPayType_Negative":
					num = 2;
					break;
				}
				foreach (CRMspSelectLinkAccSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.PartTitle ?? "") == "PayTypeAccCode" && num == 1)
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.LinkAccSettingCash;
							break;
						case "2":
							item.PartValue = Labels.LinkAccSettingChqeue;
							break;
						case "3":
							item.PartValue = Labels.LinkAccSettingDraft;
							break;
						case "4":
							item.PartValue = Labels.LinkAccSettingCardReader;
							break;
						}
					}
					if (item.PartTitle == "PayTypeAccCode" && num == 2)
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.LinkAccSettingCash;
							break;
						case "2":
							item.PartValue = Labels.LinkAccSettingChqeue;
							break;
						case "3":
							item.PartValue = Labels.LinkAccSettingWithdrawalNotice;
							break;
						}
					}
					string partValue;
					if ((item.PartTitle ?? "") == "DurationTypeAccCode" && num == 2)
					{
						partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingDurationTypeLongLasting;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingDurationTypeDaily;
						}
					}
					if (!((item.PartTitle ?? "") == "ChqReceiptDate") && !((item.PartTitle ?? "") == "DetailDateType") && !((item.PartTitle ?? "") == "HeaderDateType"))
					{
						continue;
					}
					partValue = item.PartValue;
					if (!(partValue == "1"))
					{
						if (partValue == "2")
						{
							item.PartValue = Labels.LinkAccSettingPayDocDate;
						}
					}
					else
					{
						item.PartValue = Labels.LinkAccSettingPayImportDate;
					}
				}
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
	public JsonResult GetSelectLinkAccSettingDetailsByObjType(int objId = 0, string objType = "", string objTypeI = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccSettingDetailsInfoViewModel crmLinkAccSettingDetailsInfoViewModel = new CrmLinkAccSettingDetailsInfoViewModel();
		crmLinkAccSettingDetailsInfoViewModel.ListInfo = new List<CRMspSelectLinkAccSettingDetails_Result>();
		crmLinkAccSettingDetailsInfoViewModel.ListInfoI = new List<CRMspSelectLinkAccSettingDetails_Result>();
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			if (objId != 0)
			{
				if (!string.IsNullOrWhiteSpace(objType))
				{
					_dbLink.CRMspInsertLinkAccSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result, 1, linkAccSettingDBId);
					List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, lCID, result, 1, linkAccSettingDBId), (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "WarehouseAccCode")));
					if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list))
					{
						if (objType == "OrderOpr")
						{
							WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(objId, lCID, result));
							if (wSspSelectOrderOprById_Result != null)
							{
								int result2 = 0;
								int.TryParse(wSspSelectOrderOprById_Result.OprType.ToString(), out result2);
								switch (result2)
								{
								case 1:
									list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesReturnedAccCode" && (m.PartTitle ?? "") != "ServiceSalesReturnedAccCode")));
									break;
								case 2:
									list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesAccCode" && (m.PartTitle ?? "") != "ServiceSalesAccCode")));
									break;
								}
								if (list == null)
								{
									list = new List<CRMspSelectLinkAccSettingDetails_Result>();
								}
							}
						}
						int num = 0;
						switch (objType)
						{
						case "OrdPayType":
						case "RetOrdPayType_Negative":
						case "BuyOrdPayType_Negative":
						case "PordPayType":
							num = 1;
							break;
						case "RetOrdPayType":
						case "BuyOrdPayType":
						case "OrdPayType_Negative":
						case "PordPayType_Negative":
							num = 2;
							break;
						}
						foreach (CRMspSelectLinkAccSettingDetails_Result item in list)
						{
							item.AppType = item.PartValue;
							if (string.IsNullOrWhiteSpace(item.PartValue))
							{
								continue;
							}
							if ((item.PartTitle ?? "") == "PayTypeAccCode" && num == 1)
							{
								switch (item.PartValue)
								{
								case "1":
									item.PartValue = Labels.LinkAccSettingCash;
									break;
								case "2":
									item.PartValue = Labels.LinkAccSettingChqeue;
									break;
								case "3":
									item.PartValue = Labels.LinkAccSettingDraft;
									break;
								case "4":
									item.PartValue = Labels.LinkAccSettingCardReader;
									break;
								}
							}
							if (item.PartTitle == "PayTypeAccCode" && num == 2)
							{
								switch (item.PartValue)
								{
								case "1":
									item.PartValue = Labels.LinkAccSettingCash;
									break;
								case "2":
									item.PartValue = Labels.LinkAccSettingChqeue;
									break;
								case "3":
									item.PartValue = Labels.LinkAccSettingWithdrawalNotice;
									break;
								}
							}
							string partValue;
							if ((item.PartTitle ?? "") == "DurationTypeAccCode" && num == 2)
							{
								partValue = item.PartValue;
								if (!(partValue == "1"))
								{
									if (partValue == "2")
									{
										item.PartValue = Labels.LinkAccSettingDurationTypeLongLasting;
									}
								}
								else
								{
									item.PartValue = Labels.LinkAccSettingDurationTypeDaily;
								}
							}
							if (!((item.PartTitle ?? "") == "ChqReceiptDate") && !((item.PartTitle ?? "") == "DetailDateType") && !((item.PartTitle ?? "") == "HeaderDateType"))
							{
								continue;
							}
							partValue = item.PartValue;
							if (!(partValue == "1"))
							{
								if (partValue == "2")
								{
									item.PartValue = Labels.LinkAccSettingPayDocDate;
								}
							}
							else
							{
								item.PartValue = Labels.LinkAccSettingPayImportDate;
							}
						}
						crmLinkAccSettingDetailsInfoViewModel.ListInfo = list;
					}
				}
				if (!string.IsNullOrWhiteSpace(objTypeI))
				{
					_dbLink.CRMspInsertLinkAccSettingDetails(objId, objTypeI, userId, value, value2, value3, registerDatePersian, appType, result, 1, linkAccSettingDBId);
					List<CRMspSelectLinkAccSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objTypeI, lCID, result, 1, linkAccSettingDBId), (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "WarehouseAccCode")));
					if (list2 != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2))
					{
						if (objTypeI == "OrderOpr")
						{
							WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(objId, lCID, result));
							if (wSspSelectOrderOprById_Result2 != null)
							{
								int result3 = 0;
								int.TryParse(wSspSelectOrderOprById_Result2.OprType.ToString(), out result3);
								switch (result3)
								{
								case 1:
									list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesReturnedAccCode" && (m.PartTitle ?? "") != "ServiceSalesReturnedAccCode")));
									break;
								case 2:
									list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesAccCode" && (m.PartTitle ?? "") != "ServiceSalesAccCode")));
									break;
								}
								if (list2 == null)
								{
									list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
								}
							}
						}
						int num2 = 0;
						switch (objTypeI)
						{
						case "OrdPayType":
						case "RetOrdPayType_Negative":
						case "BuyOrdPayType_Negative":
						case "PordPayType":
							num2 = 1;
							break;
						case "RetOrdPayType":
						case "BuyOrdPayType":
						case "OrdPayType_Negative":
						case "PordPayType_Negative":
							num2 = 2;
							break;
						}
						foreach (CRMspSelectLinkAccSettingDetails_Result item2 in list2)
						{
							item2.AppType = item2.PartValue;
							if (string.IsNullOrWhiteSpace(item2.PartValue))
							{
								continue;
							}
							if ((item2.PartTitle ?? "") == "PayTypeAccCode" && num2 == 1)
							{
								switch (item2.PartValue)
								{
								case "1":
									item2.PartValue = Labels.LinkAccSettingCash;
									break;
								case "2":
									item2.PartValue = Labels.LinkAccSettingChqeue;
									break;
								case "3":
									item2.PartValue = Labels.LinkAccSettingDraft;
									break;
								case "4":
									item2.PartValue = Labels.LinkAccSettingCardReader;
									break;
								}
							}
							if (item2.PartTitle == "PayTypeAccCode" && num2 == 2)
							{
								switch (item2.PartValue)
								{
								case "1":
									item2.PartValue = Labels.LinkAccSettingCash;
									break;
								case "2":
									item2.PartValue = Labels.LinkAccSettingChqeue;
									break;
								case "3":
									item2.PartValue = Labels.LinkAccSettingWithdrawalNotice;
									break;
								}
							}
							string partValue;
							if ((item2.PartTitle ?? "") == "DurationTypeAccCode" && num2 == 2)
							{
								partValue = item2.PartValue;
								if (!(partValue == "1"))
								{
									if (partValue == "2")
									{
										item2.PartValue = Labels.LinkAccSettingDurationTypeLongLasting;
									}
								}
								else
								{
									item2.PartValue = Labels.LinkAccSettingDurationTypeDaily;
								}
							}
							if (!((item2.PartTitle ?? "") == "ChqReceiptDate") && !((item2.PartTitle ?? "") == "DetailDateType") && !((item2.PartTitle ?? "") == "HeaderDateType"))
							{
								continue;
							}
							partValue = item2.PartValue;
							if (!(partValue == "1"))
							{
								if (partValue == "2")
								{
									item2.PartValue = Labels.LinkAccSettingPayDocDate;
								}
							}
							else
							{
								item2.PartValue = Labels.LinkAccSettingPayImportDate;
							}
						}
						crmLinkAccSettingDetailsInfoViewModel.ListInfoI = list2;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(crmLinkAccSettingDetailsInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEditDetail(string objType = "", int objId = 0, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		base.ViewBag.LinkAccSettingDBId = linkAccSettingDBId;
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			if (objType == "PreOrderOpr")
			{
				int result2 = 0;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrderOpr", currLangID, result, 1, linkAccSettingDBId, "PordFieldLinkToSaleType"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
					int result3 = 0;
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result3);
					CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
					{
						LinkAccSettingDetailId = -1 * result3,
						LinkAccSettingId = result3,
						ObjectId = result3,
						PartTitle = "PordFieldLinkToSaleType",
						ObjectType = "PreOrderOpr",
						PartValue = result2.ToString()
					};
					list2.Add(item);
				}
			}
			else if (objType == "DefTspOrdSetm")
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "DefTspOrdSetm", currLangID, result, 1, linkAccSettingDBId, "DefTspOrdSetmId"));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					int result4 = 0;
					int.TryParse(cRMspSelectLinkAccSetting_Result2.LinkAccSettingId.ToString(), out result4);
					CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
					{
						LinkAccSettingDetailId = -1 * result4,
						LinkAccSettingId = result4,
						ObjectId = result4,
						PartTitle = "DefTspOrdSetmId",
						ObjectType = "DefTspOrdSetm",
						PartValue = "0"
					};
					list2.Add(item2);
				}
			}
			else
			{
				list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, currLangID, result, 1, linkAccSettingDBId), (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "WarehouseAccCode")));
				if (list2 != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2) && objType == "OrderOpr")
				{
					WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(objId, currLangID, result));
					if (wSspSelectOrderOprById_Result != null)
					{
						int result5 = 0;
						int.TryParse(wSspSelectOrderOprById_Result.OprType.ToString(), out result5);
						switch (result5)
						{
						case 1:
							list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesReturnedAccCode" && (m.PartTitle ?? "") != "ServiceSalesReturnedAccCode")));
							break;
						case 2:
							list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartTitle ?? "") != "ProductSalesAccCode" && (m.PartTitle ?? "") != "ServiceSalesAccCode")));
							break;
						}
						if (list2 == null)
						{
							list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
						}
					}
				}
			}
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass30_1 _003C_003Ec__DisplayClass30_ = new _003C_003Ec__DisplayClass30_1();
					_003C_003Ec__DisplayClass30_.item = enumerator.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass30_, typeof(_003C_003Ec__DisplayClass30_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass30_, typeof(_003C_003Ec__DisplayClass30_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (list3 != null)
					{
						list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSettingDetails_Lang>)list3, (Func<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccSettingDetails2 != null)
					{
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetails2.Description,
							LanguageId = result
						});
					}
					text = _003C_003Ec__DisplayClass30_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass30_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass30_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass30_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass30_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass30_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass30_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass30_.item.PartTitle;
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectTypeTitle = text;
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSettingDetails(int objId, string objType, string settingDetail, int linkAccSettingDBId)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			if (objId != 0 && !string.IsNullOrEmpty(objType))
			{
				List<CrmLinkAccSettingDetailsViewModel> list = new List<CrmLinkAccSettingDetailsViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingDetailsViewModel>>(settingDetail);
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				string text = "";
				string text2 = "";
				bool flag = true;
				if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
				{
					if (objType.ToLower() == "preorderopr")
					{
						List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrderOpr", lCID, defLangID, 1, linkAccSettingDBId, ""));
						int result2 = 0;
						int pordOrdPordFieldLinkToSaleTypeSettingId = 0;
						if (list2 != null)
						{
							CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list2, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "SaleTypeAccCode"));
							if (cRMspSelectLinkAccSetting_Result != null)
							{
								int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result2);
							}
							CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list2, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "PordFieldLinkToSaleType"));
							if (cRMspSelectLinkAccSetting_Result2 != null)
							{
								int.TryParse(cRMspSelectLinkAccSetting_Result2.LinkAccSettingId.ToString(), out pordOrdPordFieldLinkToSaleTypeSettingId);
							}
						}
						flag = false;
						CrmLinkAccSettingDetailsViewModel crmLinkAccSettingDetailsViewModel = Enumerable.FirstOrDefault<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list, (Func<CrmLinkAccSettingDetailsViewModel, bool>)((CrmLinkAccSettingDetailsViewModel m) => (m.PartTitle ?? "") == "PordFieldLinkToSaleType" && m.AccSdId == -1 * pordOrdPordFieldLinkToSaleTypeSettingId));
						if (crmLinkAccSettingDetailsViewModel != null)
						{
							string text3 = "";
							string text4 = "";
							int num = pordOrdPordFieldLinkToSaleTypeSettingId;
							string text5 = crmLinkAccSettingDetailsViewModel.PartValue ?? "";
							string text6 = crmLinkAccSettingDetailsViewModel.PartField ?? "";
							List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
							if (!string.IsNullOrEmpty(crmLinkAccSettingDetailsViewModel.Desc_Lang))
							{
								list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmLinkAccSettingDetailsViewModel.Desc_Lang);
							}
							list3.Add(new CommonMultiLanguageViewModel
							{
								Value = crmLinkAccSettingDetailsViewModel.Desc,
								LanguageId = lCID
							});
							string text7 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
							List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
							if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
							{
								foreach (CommonMultiLanguageViewModel item in list4)
								{
									text4 = text4 + "[AccSettimgId=" + num + ",Desc=" + item.Value + ",LangId=" + item.LanguageId + ",]|";
								}
							}
							text3 = text3 + "[AccSettimgId=" + num + ",PartField=" + text6 + ",PartValue=" + text5 + ",Desc=" + text7 + ",]|";
							_dbLink.CRMspUpdateLinkAccSetting(text3, text4, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
						}
						list = Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>(Enumerable.Where<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list, (Func<CrmLinkAccSettingDetailsViewModel, bool>)((CrmLinkAccSettingDetailsViewModel m) => m.AccSdId != -1 * pordOrdPordFieldLinkToSaleTypeSettingId)));
						if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
						{
							foreach (CrmLinkAccSettingDetailsViewModel item2 in list)
							{
								List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
								if (!string.IsNullOrEmpty(item2.Desc_Lang))
								{
									list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item2.Desc_Lang);
								}
								list5.Add(new CommonMultiLanguageViewModel
								{
									Value = item2.Desc,
									LanguageId = lCID
								});
								string desc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
								string desc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
								item2.Desc = desc;
								item2.Desc_Lang = desc_Lang;
							}
							string objectJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list));
							_dbLink.CRMspInsertUpdateLinkAccSettingDetails(objType, objectJson, false, result2.ToString(), true, pordOrdPordFieldLinkToSaleTypeSettingId.ToString(), userId, value, value2, value3, registerDatePersian, appType, defLangID, 1, linkAccSettingDBId);
						}
					}
					else if (objType.ToLower() == "deftspordsetm")
					{
						CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "DefTspOrdSetm", lCID, defLangID, 1, linkAccSettingDBId, "DefTspOrdSetmId"));
						int defTspOrdSetmSettingId = 0;
						if (cRMspSelectLinkAccSetting_Result3 != null)
						{
							int.TryParse(cRMspSelectLinkAccSetting_Result3.LinkAccSettingId.ToString(), out defTspOrdSetmSettingId);
						}
						flag = false;
						list = Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>(Enumerable.Where<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list, (Func<CrmLinkAccSettingDetailsViewModel, bool>)((CrmLinkAccSettingDetailsViewModel m) => m.AccSdId != -1 * defTspOrdSetmSettingId)));
						if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
						{
							foreach (CrmLinkAccSettingDetailsViewModel item3 in list)
							{
								List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
								if (!string.IsNullOrEmpty(item3.Desc_Lang))
								{
									list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item3.Desc_Lang);
								}
								list6.Add(new CommonMultiLanguageViewModel
								{
									Value = item3.Desc,
									LanguageId = lCID
								});
								string desc2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
								string desc_Lang2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
								item3.Desc = desc2;
								item3.Desc_Lang = desc_Lang2;
							}
							string objectJson2 = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list));
							_dbLink.CRMspInsertUpdateLinkAccSettingDetails(objType, objectJson2, false, defTspOrdSetmSettingId.ToString(), true, "", userId, value, value2, value3, registerDatePersian, appType, defLangID, 1, linkAccSettingDBId);
						}
					}
				}
				if (list != null && flag && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
				{
					foreach (CrmLinkAccSettingDetailsViewModel item4 in list)
					{
						int accSdId = item4.AccSdId;
						string text8 = item4.PartValue ?? "";
						string text9 = item4.PartField ?? "";
						List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(item4.Desc_Lang))
						{
							list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item4.Desc_Lang);
						}
						list7.Add(new CommonMultiLanguageViewModel
						{
							Value = item4.Desc,
							LanguageId = lCID
						});
						string text10 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
						{
							foreach (CommonMultiLanguageViewModel item5 in list8)
							{
								text2 = text2 + "[AccSdId=" + accSdId + ",Desc=" + item5.Value + ",LangId=" + item5.LanguageId + ",]|";
							}
						}
						text = text + "[AccSdId=" + accSdId + ",PartField=" + text9 + ",PartValue=" + text8 + ",Desc=" + text10 + ",]|";
					}
					_dbLink.CRMspUpdateLinkAccSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult EditOrderOprLinkAccSetting(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "OrderOpr", currLangID, result, 1, linkAccSettingDBId, null), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") != "WarehouseAccCode")));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass32_1 _003C_003Ec__DisplayClass32_ = new _003C_003Ec__DisplayClass32_1();
					_003C_003Ec__DisplayClass32_.item = enumerator.Current;
					DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
					List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass32_, typeof(_003C_003Ec__DisplayClass32_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
					val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass32_, typeof(_003C_003Ec__DisplayClass32_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass32_.item.LinkAccSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass32_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass32_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass32_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass32_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingOtherLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateOrderOprLinkAccSetting(string setting)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			new List<CrmLinkAccSettingViewModel>();
			List<CrmLinkAccSettingViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingViewModel>>(setting);
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			string text = "";
			string text2 = "";
			foreach (CrmLinkAccSettingViewModel item in list)
			{
				int accSettimgId = item.AccSettimgId;
				string text3 = item.PartValue ?? "";
				string text4 = item.PartField ?? "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(item.Desc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = item.Desc,
					LanguageId = lCID
				});
				string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
				if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					foreach (CommonMultiLanguageViewModel item2 in list3)
					{
						text2 = text2 + "[AccSettimgId=" + accSettimgId + ",Desc=" + item2.Value + ",LangId=" + item2.LanguageId + ",]|";
					}
				}
				text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
			}
			_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult EditMultiItemLinkAccSetting(string objectType, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objectType, currLangID, result, 1, linkAccSettingDBId, null));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass34_1 _003C_003Ec__DisplayClass34_ = new _003C_003Ec__DisplayClass34_1();
					_003C_003Ec__DisplayClass34_.item = enumerator.Current;
					DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
					List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass34_, typeof(_003C_003Ec__DisplayClass34_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
					val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass34_, typeof(_003C_003Ec__DisplayClass34_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass34_.item.LinkAccSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass34_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass34_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass34_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass34_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass34_.item.PartTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingOtherLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectType = objectType;
		if (objectType == "CmpProject")
		{
			base.ViewBag.StatusGroupslist = SelectConversationStatusGroups();
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateMultiItemLinkAccSetting(string setting, string objectType, bool cmpAccFromLink = false)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			new List<CrmLinkAccSettingViewModel>();
			List<CrmLinkAccSettingViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingViewModel>>(setting);
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			string text = "";
			string text2 = "";
			foreach (CrmLinkAccSettingViewModel item in list)
			{
				int accSettimgId = item.AccSettimgId;
				string text3 = item.PartValue ?? "";
				string text4 = item.PartField ?? "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(item.Desc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = item.Desc,
					LanguageId = lCID
				});
				string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
				if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					foreach (CommonMultiLanguageViewModel item2 in list3)
					{
						text2 = text2 + "[AccSettimgId=" + accSettimgId + ",Desc=" + item2.Value + ",LangId=" + item2.LanguageId + ",]|";
					}
				}
				text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
			}
			_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
			if (objectType.ToLower() == "cmpaccountremain")
			{
				CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
				if (crmsysSetting != null)
				{
					crmsysSetting.CmpAccFromLink = cmpAccFromLink;
					crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
					crmsysSetting.RegisterDate = DateTime.Now;
					crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmsysSetting.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					crmsysSetting.AppType = Configuration.AppType;
					_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					SysSeting.Update();
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult EditLinkAccSetting(string objectType, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objectType, currLangID, result, 1, linkAccSettingDBId, null));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass36_1 _003C_003Ec__DisplayClass36_ = new _003C_003Ec__DisplayClass36_1();
					_003C_003Ec__DisplayClass36_.item = enumerator.Current;
					DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
					List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass36_, typeof(_003C_003Ec__DisplayClass36_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
					val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass36_, typeof(_003C_003Ec__DisplayClass36_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass36_.item.LinkAccSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass36_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass36_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass36_.item.PartTitle;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass36_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass36_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingOtherLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectType = objectType;
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSetting(string setting, string objType)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			new List<CrmLinkAccSettingViewModel>();
			List<CrmLinkAccSettingViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingViewModel>>(setting);
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			string text = "";
			string text2 = "";
			foreach (CrmLinkAccSettingViewModel item in list)
			{
				int accSettimgId = item.AccSettimgId;
				string text3 = item.PartValue ?? "";
				string text4 = item.PartField ?? "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(item.Desc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = item.Desc,
					LanguageId = lCID
				});
				string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
				if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					foreach (CommonMultiLanguageViewModel item2 in list3)
					{
						text2 = text2 + "[AccSettimgId=" + accSettimgId + ",Desc=" + item2.Value + ",LangId=" + item2.LanguageId + ",]|";
					}
				}
				text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
			}
			_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
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

	[AjaxOnly]
	public JsonResult GetDefaultLinkAccSetting(string objType = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, currLangID, result, 1, linkAccSettingDBId, null));
				if (list2 != null)
				{
					using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass39_1 _003C_003Ec__DisplayClass39_ = new _003C_003Ec__DisplayClass39_1();
						_003C_003Ec__DisplayClass39_.item = enumerator.Current;
						DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
						List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass39_, typeof(_003C_003Ec__DisplayClass39_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
						val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
						CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass39_, typeof(_003C_003Ec__DisplayClass39_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSetting2.Description,
							LanguageId = result
						});
						CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
						crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass39_.item.LinkAccSettingId;
						crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass39_.item.PartField;
						crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass39_.item.PartValue;
						crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass39_.item.PartTitle;
						crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass39_.item.PartDescription;
						crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass39_.item.PartLabelTitle;
						crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
						list.Add(crmLinkAccSettingOtherLanguageViewModel);
					}
				}
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
	public string CheckPassword(string pswd)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "-1";
		try
		{
			if (!string.IsNullOrEmpty(pswd))
			{
				string text = "s1LrihXDLPo=";
				if (!string.IsNullOrEmpty(text))
				{
					try
					{
						text = CodeDecode.DeCodding(text);
						text = text.Trim().Replace("/", "").Replace("-", "")
							.Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						result2 = ((!(text == pswd)) ? Messages.msgNotCorrectLinkAccSettingPassword : "");
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					result2 = Messages.msgNotSetLinkAccSettingPassword;
				}
			}
			else
			{
				result2 = Messages.msgNotEnterLinkAccSettingPassword;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result2 = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result2;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string LinkedPrdUnitBySep(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkSepWSLinkedProductUnit(linkAccSettingDBId));
			int result2 = 0;
			if (mct_Link_Result != null)
			{
				int.TryParse(mct_Link_Result.Result.ToString(), out result2);
			}
			if (result2 > 0)
			{
				return "1";
			}
			return Messages.msgErrorRunFunction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEditDetailForBank(string objType = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		GetSepBanks(linkAccSettingDBId);
		GetOrdPayType();
		GetBuyOrdPayType();
		base.ViewBag.ObjectType = objType;
		base.ViewBag.LinkAccSettingDBId = linkAccSettingDBId;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, currLangID, result, 1, linkAccSettingDBId, null));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass42_1 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_1();
					_003C_003Ec__DisplayClass42_.item = enumerator.Current;
					DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
					List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
					val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass42_.item.LinkAccSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass42_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass42_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass42_.item.PartTitle;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass42_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass42_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingOtherLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSettingDetailsForBank(string objType, string objectJson, string defObjectJson, int linkAccSettingDBId)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			if (!string.IsNullOrWhiteSpace(objType) && !string.IsNullOrWhiteSpace(objectJson) && !string.IsNullOrWhiteSpace(defObjectJson))
			{
				List<CrmLinkAccSettingDetailsIViewModel> list = new List<CrmLinkAccSettingDetailsIViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingDetailsIViewModel>>(defObjectJson);
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				foreach (CrmLinkAccSettingDetailsIViewModel item in list)
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(item.Desc_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = item.Desc,
						LanguageId = lCID
					});
					string desc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					string desc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
					item.Desc = desc;
					item.Desc_Lang = desc_Lang;
				}
				if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsIViewModel>((IEnumerable<CrmLinkAccSettingDetailsIViewModel>)list))
				{
					defObjectJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccSettingDetailsIViewModel>((IEnumerable<CrmLinkAccSettingDetailsIViewModel>)list));
				}
				_dbLink.CRMspInsertUpdateLinkAccSettingDetailsByDefValue(objType, objectJson, defObjectJson, userId, value, value2, value3, registerDatePersian, appType, defLangID, 1, linkAccSettingDBId);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetSepBanks(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectBank_Result> list2 = Enumerable.ToList<CRMspLkSepSelectBank_Result>((IEnumerable<CRMspLkSepSelectBank_Result>)_dbLink.CRMspLkSepSelectBank(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectBank_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectBank_Result>)list2, (Func<CRMspLkSepSelectBank_Result, SelectListItem>)((CRMspLkSepSelectBank_Result item) => new SelectListItem
			{
				Text = item.TitleStr,
				Value = item.Title,
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepBankList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult ShowLinkAccSettingDB()
	{
		return View();
	}

	public List<CRMspSelectLinkAccSettingDB_Result> ListLinkAccSettingDB()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingDB_Result> list = new List<CRMspSelectLinkAccSettingDB_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(linkAccSettingDBId: 0, linkAccSystemId: 1, languageID: lCID, defaultLanguageID: result));
			foreach (CRMspSelectLinkAccSettingDB_Result item in list)
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
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult LinkAccSettingDB_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListLinkAccSettingDB()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListLinkAccSettingDB()
	{
		return Json(ListLinkAccSettingDB(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public string ActDeActiveLinkAccSettingDB(int linkAccSettingDbId)
	{
		string text = "";
		try
		{
			if (linkAccSettingDbId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					short value3 = short.Parse(Financial.Get().Id.ToString());
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					_dbLink.CRMspUpdateLinkAccSettingDBIsActive(linkAccSettingDbId, false, userId, value3, value2, value, registerDatePersian, appType);
					return "1";
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	public ActionResult InsertEditLinkAccSettingDB(int linkAccSettingDbId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccSettingDBLanguageViewModel crmLinkAccSettingDBLanguageViewModel = new CrmLinkAccSettingDBLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actSetting", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			CRMspSelectLinkAccSettingDB_Result cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
			if (linkAccSettingDbId == 0)
			{
				cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
				cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDBId = 0;
				cRMspSelectLinkAccSettingDB_Result.LinkAccSystemId = 1;
				base.ViewBag.SepDataBaseList = new List<SelectListItem>();
			}
			else
			{
				cRMspSelectLinkAccSettingDB_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(linkAccSettingDBId: linkAccSettingDbId, linkAccSystemId: 1, languageID: lCID, defaultLanguageID: result));
				if (cRMspSelectLinkAccSettingDB_Result == null)
				{
					cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
					cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDBId = 0;
					cRMspSelectLinkAccSettingDB_Result.LinkAccSystemId = 1;
				}
			}
			crmLinkAccSettingDBLanguageViewModel = new CrmLinkAccSettingDBLanguageViewModel
			{
				LinkAccSettingDBId = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDBId,
				LinkAccSettingDbTitle = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDbTitle,
				LinkAccSettingDbName = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDbName,
				IsActive = cRMspSelectLinkAccSettingDB_Result.IsActive,
				OrderView = cRMspSelectLinkAccSettingDB_Result.OrderView,
				LinkAccSettingServerName = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingServerName
			};
			if (crmLinkAccSettingDBLanguageViewModel.LinkAccSettingDBId == 0)
			{
				int maxAccDbCount = Configuration.MaxAccDbCount;
				List<SelectListItem> linkAccSettingDB = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
				if (linkAccSettingDB != null)
				{
					int num = Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)linkAccSettingDB);
					if (num != 0 && maxAccDbCount <= num)
					{
						base.ViewBag.ErrActiveDbCnt = string.Format(Messages.msgErrorNotsaveMoreThanLinkAccSettingDB, Labels.Sepidar, maxAccDbCount.ToString());
					}
				}
				crmLinkAccSettingDBLanguageViewModel.OrderView = 10;
				List<CRMspSelectLinkAccSettingDB_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(1, 0, lCID, result));
				if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list))
				{
					CRMspSelectLinkAccSettingDB_Result cRMspSelectLinkAccSettingDB_Result2 = Enumerable.LastOrDefault<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list);
					if (cRMspSelectLinkAccSettingDB_Result2 != null)
					{
						crmLinkAccSettingDBLanguageViewModel.OrderView = cRMspSelectLinkAccSettingDB_Result2.OrderView.GetValueOrDefault() + 10;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmLinkAccSettingDBLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult InsertEditLinkAccSettingDB(CrmLinkAccSettingDBLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		List<SelectListItem> sepDataBasesList = GetSepDataBasesList(model.LinkAccSettingServerName);
		base.ViewBag.SepDataBaseList = sepDataBasesList;
		if (base.ModelState.IsValid)
		{
			if (model.LinkAccSettingDBId == 0)
			{
				int maxAccDbCount = Configuration.MaxAccDbCount;
				List<SelectListItem> linkAccSettingDB = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
				if (linkAccSettingDB != null)
				{
					int num2 = Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)linkAccSettingDB);
					if (num2 != 0 && maxAccDbCount <= num2)
					{
						text = string.Format(Messages.msgErrorNotsaveMoreThanLinkAccSettingDB, Labels.Sepidar, maxAccDbCount.ToString());
						base.ViewBag.ErrActiveDbCnt = string.Format(Messages.msgErrorNotsaveMoreThanLinkAccSettingDB, Labels.Sepidar, maxAccDbCount.ToString());
						num++;
					}
				}
			}
			if (string.IsNullOrWhiteSpace(model.LinkAccSettingDbName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.LinkAccSettingDbName) + "<br/>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(model.LinkAccSettingDbTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.LinkAccSettingDbTitle) + "<br/>";
				num++;
			}
			if (model.LinkAccSettingDBId == 0)
			{
				if (sepDataBasesList != null)
				{
					if (!Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)sepDataBasesList, (Func<SelectListItem, bool>)((SelectListItem db) => db.Value == model.LinkAccSettingDbName)))
					{
						text += Messages.msgErrorTheEnteredDatabaseNameDoesNotBelongToThisServer;
						num++;
					}
				}
				else
				{
					text += Messages.msgErrorNoDatabaseWasFoundForThisServer;
					num++;
				}
			}
			if (num == 0)
			{
				_ = DateTime.Now;
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					short value3 = short.Parse(Financial.Get().Id.ToString());
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					if (model.LinkAccSettingDBId > 0)
					{
						_dbLink.CRMspUpdateLinkAccSettingDB(model.LinkAccSettingDBId, model.OrderView, model.LinkAccSettingDbTitle, userId, value3, value2, value, registerDatePersian, appType);
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						ObjectParameter objectParameter = new ObjectParameter("insertedLinkAccSettingDBId", typeof(int));
						ObjectParameter objectParameter2 = new ObjectParameter("errorCode", typeof(int));
						_dbLink.CRMspInsertLinkAccSettingDB(1, model.LinkAccSettingDbName, true, model.OrderView, model.LinkAccSettingDbTitle, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2, model.LinkAccSettingServerName);
						int result2 = 0;
						if (objectParameter != null && objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result2);
						}
						int result3 = 0;
						if (objectParameter2 != null && objectParameter2.Value != null)
						{
							int.TryParse(objectParameter2.Value.ToString(), out result3);
						}
						if (result2 != 0)
						{
							model.LinkAccSettingDBId = result2;
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						else
						{
							if (result3 == -1)
							{
								text = Messages.msgErrorRunFunction;
							}
							if (result3 == -2)
							{
								text = Messages.msgErrorNotPossibleSaveDupDatabase;
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	public List<SelectListItem> GetSepDataBasesList(string linkAccSettingServerName)
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
			List<CRMspLkSepSelectDatabases_Result> list2 = Enumerable.ToList<CRMspLkSepSelectDatabases_Result>((IEnumerable<CRMspLkSepSelectDatabases_Result>)_dbLink.CRMspLkSepSelectDatabases(linkAccSettingServerName));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspLkSepSelectDatabases_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectDatabases_Result>)list2, (Func<CRMspLkSepSelectDatabases_Result, SelectListItem>)((CRMspLkSepSelectDatabases_Result item) => new SelectListItem
				{
					Text = (item.name ?? ""),
					Value = (item.name ?? ""),
					Selected = false
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetSepDataBases(string linkAccSettingServerName)
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
			list = GetSepDataBasesList(linkAccSettingServerName);
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepDataBaseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLinkAccSettingDBActive()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string LinkedDeliveryTermBySep(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkSepWSLinkedDeliveryTerms(linkAccSettingDBId));
			int result2 = 0;
			if (mct_Link_Result != null)
			{
				int.TryParse(mct_Link_Result.Result.ToString(), out result2);
			}
			if (result2 > 0)
			{
				return "1";
			}
			return Messages.msgErrorRunFunction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[AjaxOnly]
	public JsonResult GetSepidarModules(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel sepidarHaveModulesViewModel = new CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel
		{
			SepNotHavePordModule = false,
			SepNotHaveOrdModule = false,
			SepNotHaveBordModule = false,
			SepNotHaveDocModule = false,
			SepNotHavePayModule = false,
			SepNotHaveCommModule = false
		};
		try
		{
			sepidarHaveModulesViewModel = CRMIdeal.Classes.Helper.OtherSystems.GetSepidarModules(linkAccSettingDBId);
			if (sepidarHaveModulesViewModel == null)
			{
				sepidarHaveModulesViewModel = new CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel
				{
					SepNotHavePordModule = false,
					SepNotHaveOrdModule = false,
					SepNotHaveBordModule = false,
					SepNotHaveDocModule = false,
					SepNotHavePayModule = false,
					SepNotHaveCommModule = false
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(sepidarHaveModulesViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
