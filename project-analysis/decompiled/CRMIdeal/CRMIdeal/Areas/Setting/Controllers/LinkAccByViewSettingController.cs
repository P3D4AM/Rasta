using System;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccByViewSettingController : Controller
{
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
		public CrmLinkAccByViewSetting model;
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
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEdit(int linkAccId = 0)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.linkAccId = linkAccId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmLinkAccByViewSetting_Lang> crmLinkAccByViewSetting_Lang = _dbTbl.CrmLinkAccByViewSetting_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccByViewSetting_Lang), "c");
		List<CrmLinkAccByViewSetting_Lang> list = Enumerable.ToList<CrmLinkAccByViewSetting_Lang>((IEnumerable<CrmLinkAccByViewSetting_Lang>)Queryable.Where<CrmLinkAccByViewSetting_Lang>((IQueryable<CrmLinkAccByViewSetting_Lang>)crmLinkAccByViewSetting_Lang, Expression.Lambda<Func<CrmLinkAccByViewSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		DateTime now = DateTime.Now;
		CrmLinkAccByViewSetting crmLinkAccByViewSetting = new CrmLinkAccByViewSetting();
		if (CS_0024_003C_003E8__locals0.linkAccId == 0)
		{
			crmLinkAccByViewSetting = new CrmLinkAccByViewSetting();
			crmLinkAccByViewSetting.LinkAccByViewSettingId = 0;
			crmLinkAccByViewSetting.RegisterDate = now;
			crmLinkAccByViewSetting.FirstRegisterDate = now;
		}
		else
		{
			DbSet<CrmLinkAccByViewSetting> crmLinkAccByViewSetting2 = _dbTbl.CrmLinkAccByViewSetting;
			val = Expression.Parameter(typeof(CrmLinkAccByViewSetting), "m");
			crmLinkAccByViewSetting = Queryable.FirstOrDefault<CrmLinkAccByViewSetting>((IQueryable<CrmLinkAccByViewSetting>)crmLinkAccByViewSetting2, Expression.Lambda<Func<CrmLinkAccByViewSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmLinkAccByViewSetting == null)
			{
				crmLinkAccByViewSetting = new CrmLinkAccByViewSetting();
				crmLinkAccByViewSetting.LinkAccByViewSettingId = 0;
				crmLinkAccByViewSetting.RegisterDate = now;
				crmLinkAccByViewSetting.FirstRegisterDate = now;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccByViewSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccByViewSetting_Lang>)list, (Func<CrmLinkAccByViewSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccByViewSetting_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Description,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmLinkAccByViewSetting.Description,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccByViewSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccByViewSetting_Lang>)list, (Func<CrmLinkAccByViewSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccByViewSetting_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PartDescription,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = crmLinkAccByViewSetting.PartDescription,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccByViewSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccByViewSetting_Lang>)list, (Func<CrmLinkAccByViewSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccByViewSetting_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PartLabelTitle,
			LanguageId = item.LanguageID
		})));
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = crmLinkAccByViewSetting.PartLabelTitle,
			LanguageId = result
		});
		CrmLinkAccSettingLanguageViewModel model = new CrmLinkAccSettingLanguageViewModel
		{
			LinkAccSettingId = crmLinkAccByViewSetting.LinkAccByViewSettingId,
			PartTitle = crmLinkAccByViewSetting.PartTitle,
			PartField = crmLinkAccByViewSetting.PartField,
			PartValue = crmLinkAccByViewSetting.PartValue,
			ObjectType = crmLinkAccByViewSetting.ObjectType,
			PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PartDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PartLabelTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			FirstRegisterUserId = crmLinkAccByViewSetting.FirstRegisterUserId,
			FirstRegisterDate = crmLinkAccByViewSetting.FirstRegisterDate,
			FirstRegisterDatePersian = crmLinkAccByViewSetting.FirstRegisterDatePersian,
			UserId = crmLinkAccByViewSetting.UserId,
			Year1 = crmLinkAccByViewSetting.Year1,
			Month1 = crmLinkAccByViewSetting.Month1,
			RegisterDate = crmLinkAccByViewSetting.RegisterDate,
			RegisterDatePersian = crmLinkAccByViewSetting.RegisterDatePersian,
			GUId = crmLinkAccByViewSetting.GUId,
			AppType = crmLinkAccByViewSetting.AppType,
			LanguageID = crmLinkAccByViewSetting.LanguageID
		};
		GetCmpDupByField();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmLinkAccSettingLanguageViewModel vm)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
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
		GetCmpDupByField();
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
					_003C_003Ec__DisplayClass6_.model = new CrmLinkAccByViewSetting();
					if (CS_0024_003C_003E8__locals0.vm.LinkAccSettingId > 0)
					{
						DbSet<CrmLinkAccByViewSetting> crmLinkAccByViewSetting = _dbTbl.CrmLinkAccByViewSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccByViewSetting), "m");
						_003C_003Ec__DisplayClass6_.model = Queryable.FirstOrDefault<CrmLinkAccByViewSetting>((IQueryable<CrmLinkAccByViewSetting>)crmLinkAccByViewSetting, Expression.Lambda<Func<CrmLinkAccByViewSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
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
								DbSet<CrmLinkAccByViewSetting_Lang> crmLinkAccByViewSetting_Lang = _dbTbl.CrmLinkAccByViewSetting_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccByViewSetting_Lang), "c");
								CrmLinkAccByViewSetting_Lang crmLinkAccByViewSetting_Lang2 = Queryable.FirstOrDefault<CrmLinkAccByViewSetting_Lang>((IQueryable<CrmLinkAccByViewSetting_Lang>)crmLinkAccByViewSetting_Lang, Expression.Lambda<Func<CrmLinkAccByViewSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass6_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccByViewSetting_Lang2 != null)
								{
									crmLinkAccByViewSetting_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmLinkAccByViewSetting_Lang2.PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmLinkAccByViewSetting_Lang2.PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmLinkAccByViewSetting_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmLinkAccByViewSetting_Lang2 = new CrmLinkAccByViewSetting_Lang();
								crmLinkAccByViewSetting_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								crmLinkAccByViewSetting_Lang2.LinkAccByViewSettingId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.LinkAccByViewSettingId;
								crmLinkAccByViewSetting_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmLinkAccByViewSetting_Lang2.PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmLinkAccByViewSetting_Lang2.PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.CrmLinkAccByViewSetting_Lang.Add(crmLinkAccByViewSetting_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass6_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass6_.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass6_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass6_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass6_.model.GUId = Guid.NewGuid();
						_dbTbl.CrmLinkAccByViewSetting.Add(_003C_003Ec__DisplayClass6_.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmLinkAccByViewSetting_Lang crmLinkAccByViewSetting_Lang3 = new CrmLinkAccByViewSetting_Lang();
							crmLinkAccByViewSetting_Lang3.LanguageID = lang.LanguageID;
							crmLinkAccByViewSetting_Lang3.LinkAccByViewSettingId = _003C_003Ec__DisplayClass6_.model.LinkAccByViewSettingId;
							crmLinkAccByViewSetting_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmLinkAccByViewSetting_Lang3.PartDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmLinkAccByViewSetting_Lang3.PartLabelTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmLinkAccByViewSetting_Lang.Add(crmLinkAccByViewSetting_Lang3);
							_dbTbl.SaveChanges();
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					CS_0024_003C_003E8__locals0.vm.LinkAccSettingId = _003C_003Ec__DisplayClass6_.model.LinkAccByViewSettingId;
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

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult EditCmpAccFromLinkSetting()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateCmpAccFromLinkSetting(bool cmpAccFromLink = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "1";
		try
		{
			new List<CrmLinkAccSettingViewModel>();
			DateTime now = DateTime.Now;
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(now.ToString("MM", new PersianCulture()));
			now.ToString("yyyyMMdd", new PersianCulture());
			_ = Configuration.AppType;
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
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result2 = ex.Message;
		}
		return result2;
	}

	[AjaxOnly]
	public List<SelectListItem> GetCmpDupByField()
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
				Text = Labels.OtherSystemCmpCode,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OtherSystemPrsNationalCode,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OtherSystemPrsMobile,
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
		base.ViewBag.CmpDupByFieldList = list;
		return list;
	}

	[AjaxOnly]
	public JsonResult GetOtherPartLinkAccSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccByViewSettingOtherPartViewModel crmLinkAccByViewSettingOtherPartViewModel = new CrmLinkAccByViewSettingOtherPartViewModel();
		crmLinkAccByViewSettingOtherPartViewModel.SettingPart = new List<CRMspSelectLinkAccByViewSetting_Result>();
		crmLinkAccByViewSettingOtherPartViewModel.CmpAccFromLink = false;
		try
		{
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			crmLinkAccByViewSettingOtherPartViewModel.SettingPart = Enumerable.ToList<CRMspSelectLinkAccByViewSetting_Result>((IEnumerable<CRMspSelectLinkAccByViewSetting_Result>)_dbLink.CRMspSelectLinkAccByViewSetting(linkAccByViewSettingId: 0, linkAccSystemId: result2, objectType: "Setting", languageID: lCID, defaultLanguageID: result));
			if (crmLinkAccByViewSettingOtherPartViewModel.SettingPart == null)
			{
				crmLinkAccByViewSettingOtherPartViewModel.SettingPart = new List<CRMspSelectLinkAccByViewSetting_Result>();
			}
			else if (Enumerable.Any<CRMspSelectLinkAccByViewSetting_Result>((IEnumerable<CRMspSelectLinkAccByViewSetting_Result>)crmLinkAccByViewSettingOtherPartViewModel.SettingPart))
			{
				foreach (CRMspSelectLinkAccByViewSetting_Result item in crmLinkAccByViewSettingOtherPartViewModel.SettingPart)
				{
					if (item.LinkAccByViewSettingId == 2 && !string.IsNullOrWhiteSpace(item.PartValue))
					{
						if (item.PartValue == "1")
						{
							item.PartValue = Labels.OtherSystemCmpCode;
						}
						else if (item.PartValue == "2")
						{
							item.PartValue = Labels.OtherSystemPrsNationalCode;
						}
						else if (item.PartValue == "3")
						{
							item.PartValue = Labels.OtherSystemPrsMobile;
						}
					}
				}
			}
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				crmLinkAccByViewSettingOtherPartViewModel.CmpAccFromLink = cRMspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(crmLinkAccByViewSettingOtherPartViewModel, JsonRequestBehavior.AllowGet);
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
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
