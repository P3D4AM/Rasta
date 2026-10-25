using System;
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
using CRM.General.IO.FTP;
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

namespace CRMIdeal.Areas.Cms.Controllers;

public class WidgetsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int widgetId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public CrmCmsWidgetsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__17;

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

		internal bool _003CInsertEdit_003Eb__17(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_1
	{
		public CrmCmsWidgets model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass11_1 CS_0024_003C_003E8__locals1;

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
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int widgetId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int widgetGroupId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public CrmCmsWidgetGroupsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__11;

		internal bool _003CInsertEditWidgetGroup_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditWidgetGroup_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditWidgetGroup_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEditWidgetGroup_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CrmCmsWidgetGroups model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEditWidgetGroup_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditWidgetGroup_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditWidgetGroup_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditWidgetGroup_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int widgetGroupId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsManageWidget")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetWidgetGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectWidgetGroups_Result> list = new List<CRMspCmsSelectWidgetGroups_Result>();
		try
		{
			list = Enumerable.ToList<CRMspCmsSelectWidgetGroups_Result>((IEnumerable<CRMspCmsSelectWidgetGroups_Result>)_dbII.CRMspCmsSelectWidgetGroups(lCID, result));
			if (list != null)
			{
				if (Enumerable.Any<CRMspCmsSelectWidgetGroups_Result>((IEnumerable<CRMspCmsSelectWidgetGroups_Result>)list))
				{
					foreach (CRMspCmsSelectWidgetGroups_Result item in list)
					{
						_ = item.FirstRegisterDate;
						item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.FirstRegisterUser += ((!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian)) ? (" (" + item.FirstRegisterDatePersian + ")") : "");
						_ = item.RegisterDate;
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						if (string.IsNullOrWhiteSpace(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						item.EditUser = item.EditUser + "(" + Labels.AppType + ":" + item.AppType + ")" + ((!string.IsNullOrWhiteSpace(item.RegisterDatePersian)) ? (" (" + item.RegisterDatePersian + ")") : "");
					}
				}
			}
			else
			{
				list = new List<CRMspCmsSelectWidgetGroups_Result>();
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

	[DynamicAuthorize(ControllerName = "frmCmsManageWidgets", ActionName = "actInsertGroup,actEditGroup")]
	public ActionResult InsertEditWidgetGroup(int widgetGroupId = 0)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.widgetGroupId = widgetGroupId;
		CrmCmsWidgetGroupsLanguageViewModel crmCmsWidgetGroupsLanguageViewModel = new CrmCmsWidgetGroupsLanguageViewModel();
		try
		{
			new BaseInfo();
			CrmCmsWidgetGroups crmCmsWidgetGroups = new CrmCmsWidgetGroups();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass6_.widgetGroupId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsManageWidgets", "actEditGroup"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsWidgetGroups_Lang> crmCmsWidgetGroups_Lang = _dbTbl.CrmCmsWidgetGroups_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgetGroups_Lang), "c");
				List<CrmCmsWidgetGroups_Lang> list = Enumerable.ToList<CrmCmsWidgetGroups_Lang>((IEnumerable<CrmCmsWidgetGroups_Lang>)Queryable.Where<CrmCmsWidgetGroups_Lang>((IQueryable<CrmCmsWidgetGroups_Lang>)crmCmsWidgetGroups_Lang, Expression.Lambda<Func<CrmCmsWidgetGroups_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsWidgetGroups> crmCmsWidgetGroups2 = _dbTbl.CrmCmsWidgetGroups;
				val = Expression.Parameter(typeof(CrmCmsWidgetGroups), "c");
				crmCmsWidgetGroups = Queryable.FirstOrDefault<CrmCmsWidgetGroups>((IQueryable<CrmCmsWidgetGroups>)crmCmsWidgetGroups2, Expression.Lambda<Func<CrmCmsWidgetGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsWidgetGroups == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsWidgetGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsWidgetGroups_Lang>)list, (Func<CrmCmsWidgetGroups_Lang, CommonMultiLanguageViewModel>)((CrmCmsWidgetGroups_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.WidgetGroupTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsWidgetGroups.WidgetGroupTitle,
					LanguageId = result
				});
				crmCmsWidgetGroupsLanguageViewModel = new CrmCmsWidgetGroupsLanguageViewModel
				{
					WidgetGroupId = crmCmsWidgetGroups.WidgetGroupId,
					WidgetGroupSystemPartId = crmCmsWidgetGroups.WidgetGroupSystemPartId,
					WidgetGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					WidgetGroupTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					WidgetGroupStyle = crmCmsWidgetGroups.WidgetGroupStyle,
					WidgetGroupScript = crmCmsWidgetGroups.WidgetGroupScript,
					IsActive = crmCmsWidgetGroups.IsActive,
					OrderView = crmCmsWidgetGroups.OrderView
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsManageWidgets", "actInsertGroup"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				_ = DateTime.Now;
				crmCmsWidgetGroupsLanguageViewModel = new CrmCmsWidgetGroupsLanguageViewModel
				{
					IsActive = true,
					WidgetGroupSystemPartId = 210
				};
				List<CRMspCmsSelectWidgetGroups_Result> list3 = Enumerable.ToList<CRMspCmsSelectWidgetGroups_Result>((IEnumerable<CRMspCmsSelectWidgetGroups_Result>)_dbII.CRMspCmsSelectWidgetGroups(currLangID, result));
				if (!Enumerable.Any<CRMspCmsSelectWidgetGroups_Result>((IEnumerable<CRMspCmsSelectWidgetGroups_Result>)list3))
				{
					crmCmsWidgetGroupsLanguageViewModel.OrderView = 10;
				}
				else
				{
					int result2 = 10;
					CRMspCmsSelectWidgetGroups_Result cRMspCmsSelectWidgetGroups_Result = Enumerable.LastOrDefault<CRMspCmsSelectWidgetGroups_Result>((IEnumerable<CRMspCmsSelectWidgetGroups_Result>)list3);
					if (cRMspCmsSelectWidgetGroups_Result != null)
					{
						int.TryParse(cRMspCmsSelectWidgetGroups_Result.OrderView.ToString(), out result2);
						result2 = ((result2 == 0) ? 10 : (result2 + 10));
					}
					crmCmsWidgetGroupsLanguageViewModel.OrderView = result2;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetSystemParts();
		return View(crmCmsWidgetGroupsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsManageWidgetsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEditWidgetGroup(CrmCmsWidgetGroupsLanguageViewModel vm)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetSystemParts();
		try
		{
			_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
			_003C_003Ec__DisplayClass7_.model = new CrmCmsWidgetGroups();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.WidgetGroupTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WidgetGroupTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.WidgetGroupTitle,
				LanguageId = lCID
			});
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WidgetGroupTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.WidgetGroupTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.WidgetGroupTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.WidgetGroupTitle) + "<br>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			new BaseInfo();
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass7_.model = new CrmCmsWidgetGroups();
				if (CS_0024_003C_003E8__locals0.vm.WidgetGroupId > 0)
				{
					DbSet<CrmCmsWidgetGroups> crmCmsWidgetGroups = _dbTbl.CrmCmsWidgetGroups;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgetGroups), "c");
					_003C_003Ec__DisplayClass7_.model = Queryable.FirstOrDefault<CrmCmsWidgetGroups>((IQueryable<CrmCmsWidgetGroups>)crmCmsWidgetGroups, Expression.Lambda<Func<CrmCmsWidgetGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass7_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass7_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass7_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass7_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass7_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass7_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass7_.model.WidgetGroupSystemPartId = CS_0024_003C_003E8__locals0.vm.WidgetGroupSystemPartId;
				_003C_003Ec__DisplayClass7_.model.WidgetGroupTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass7_.model.WidgetGroupStyle = CS_0024_003C_003E8__locals0.vm.WidgetGroupStyle;
				_003C_003Ec__DisplayClass7_.model.WidgetGroupScript = CS_0024_003C_003E8__locals0.vm.WidgetGroupScript;
				_003C_003Ec__DisplayClass7_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass7_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				if (_003C_003Ec__DisplayClass7_.model.WidgetGroupId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass7_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass7_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsWidgetGroups_Lang> crmCmsWidgetGroups_Lang = _dbTbl.CrmCmsWidgetGroups_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgetGroups_Lang), "c");
							CrmCmsWidgetGroups_Lang crmCmsWidgetGroups_Lang2 = Queryable.FirstOrDefault<CrmCmsWidgetGroups_Lang>((IQueryable<CrmCmsWidgetGroups_Lang>)crmCmsWidgetGroups_Lang, Expression.Lambda<Func<CrmCmsWidgetGroups_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsWidgetGroups_Lang2 != null)
							{
								crmCmsWidgetGroups_Lang2.WidgetGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsWidgetGroups_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsWidgetGroups_Lang2 = new CrmCmsWidgetGroups_Lang();
							crmCmsWidgetGroups_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsWidgetGroups_Lang2.WidgetGroupId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.WidgetGroupId;
							crmCmsWidgetGroups_Lang2.WidgetGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsWidgetGroups_Lang.Add(crmCmsWidgetGroups_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass7_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass7_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass7_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass7_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass7_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmCmsWidgetGroups.Add(_003C_003Ec__DisplayClass7_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsWidgetGroups_Lang crmCmsWidgetGroups_Lang3 = new CrmCmsWidgetGroups_Lang();
						crmCmsWidgetGroups_Lang3.LanguageID = lang.LanguageID;
						crmCmsWidgetGroups_Lang3.WidgetGroupId = _003C_003Ec__DisplayClass7_.model.WidgetGroupId;
						crmCmsWidgetGroups_Lang3.WidgetGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsWidgetGroups_Lang.Add(crmCmsWidgetGroups_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.WidgetGroupId = _003C_003Ec__DisplayClass7_.model.WidgetGroupId;
				base.ViewBag.Successfull = text;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsWidgetGroups");
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				base.ViewBag.Error = text;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsManageWidgets", ActionName = "actDeleteGroup")]
	public string DeleteWidgetGroup(int widgetGroupId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.widgetGroupId = widgetGroupId;
		string result = "";
		try
		{
			DbSet<CrmCmsWidgetGroups> crmCmsWidgetGroups = _dbTbl.CrmCmsWidgetGroups;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgetGroups), "c");
			if (Queryable.FirstOrDefault<CrmCmsWidgetGroups>((IQueryable<CrmCmsWidgetGroups>)crmCmsWidgetGroups, Expression.Lambda<Func<CrmCmsWidgetGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspCmsDeleteWidgetGroups(_003C_003Ec__DisplayClass8_.widgetGroupId));
					if (mct_II_Result != null && mct_II_Result.Result > 0)
					{
						result = "";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsWidgetGroups");
					}
					else if (mct_II_Result != null && mct_II_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public void GetSystemParts()
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
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "210"));
			if (list2 != null && Enumerable.Any<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2, (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result item) => new SelectListItem
				{
					Text = item.PartTitle,
					Value = item.SystemPartId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SystemPartList = list;
	}

	[DynamicAuthorize(ControllerName = "frmCmsManageWidgets", ActionName = "actAddWidget,actEditWidget")]
	public ActionResult InsertEdit(int widgetGroupId, int widgetId = 0)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.widgetId = widgetId;
		CrmCmsWidgetsLanguageViewModel crmCmsWidgetsLanguageViewModel = new CrmCmsWidgetsLanguageViewModel();
		try
		{
			new BaseInfo();
			CrmCmsWidgets crmCmsWidgets = new CrmCmsWidgets();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass10_.widgetId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsManageWidgets", "actEditWidget"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsWidgets_Lang> crmCmsWidgets_Lang = _dbTbl.CrmCmsWidgets_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgets_Lang), "c");
				List<CrmCmsWidgets_Lang> list = Enumerable.ToList<CrmCmsWidgets_Lang>((IEnumerable<CrmCmsWidgets_Lang>)Queryable.Where<CrmCmsWidgets_Lang>((IQueryable<CrmCmsWidgets_Lang>)crmCmsWidgets_Lang, Expression.Lambda<Func<CrmCmsWidgets_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsWidgets> crmCmsWidgets2 = _dbTbl.CrmCmsWidgets;
				val = Expression.Parameter(typeof(CrmCmsWidgets), "c");
				crmCmsWidgets = Queryable.FirstOrDefault<CrmCmsWidgets>((IQueryable<CrmCmsWidgets>)crmCmsWidgets2, Expression.Lambda<Func<CrmCmsWidgets, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsWidgets == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsWidgets_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsWidgets_Lang>)list, (Func<CrmCmsWidgets_Lang, CommonMultiLanguageViewModel>)((CrmCmsWidgets_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.WidgetTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsWidgets.WidgetTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsWidgets_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsWidgets_Lang>)list, (Func<CrmCmsWidgets_Lang, CommonMultiLanguageViewModel>)((CrmCmsWidgets_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.WidgetBody,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsWidgets.WidgetBody,
					LanguageId = result
				});
				crmCmsWidgetsLanguageViewModel = new CrmCmsWidgetsLanguageViewModel
				{
					WidgetId = crmCmsWidgets.WidgetId,
					WidgetGroupId = crmCmsWidgets.WidgetGroupId,
					WidgetTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					WidgetTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					WidgetBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					WidgetBody_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					WidgetRowStart = crmCmsWidgets.WidgetRowStart,
					WidgetRowCnt = crmCmsWidgets.WidgetRowCnt,
					WidgetColStart = crmCmsWidgets.WidgetColStart,
					WidgetColCnt = crmCmsWidgets.WidgetColCnt,
					IsActive = crmCmsWidgets.IsActive,
					OrderView = crmCmsWidgets.OrderView,
					FirstRegisterUserId = crmCmsWidgets.FirstRegisterUserId,
					FirstRegisterDate = crmCmsWidgets.FirstRegisterDate,
					UserId = crmCmsWidgets.UserId,
					RegisterDate = crmCmsWidgets.RegisterDate,
					AppType = crmCmsWidgets.AppType
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsManageWidgets", "actAddWidget"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				string appType = Configuration.AppType;
				int userId = UserLogin.CurrentUser.UserId;
				crmCmsWidgetsLanguageViewModel = new CrmCmsWidgetsLanguageViewModel
				{
					IsActive = true,
					WidgetGroupId = widgetGroupId,
					FirstRegisterUserId = userId,
					FirstRegisterDate = now,
					UserId = userId,
					RegisterDate = now,
					AppType = appType
				};
				List<CRMspCmsSelectWidgets_Result> list4 = Enumerable.ToList<CRMspCmsSelectWidgets_Result>((IEnumerable<CRMspCmsSelectWidgets_Result>)_dbII.CRMspCmsSelectWidgets(widgetGroupId, currLangID, result));
				if (!Enumerable.Any<CRMspCmsSelectWidgets_Result>((IEnumerable<CRMspCmsSelectWidgets_Result>)list4))
				{
					crmCmsWidgetsLanguageViewModel.OrderView = 10;
				}
				else
				{
					int result2 = 10;
					CRMspCmsSelectWidgets_Result cRMspCmsSelectWidgets_Result = Enumerable.LastOrDefault<CRMspCmsSelectWidgets_Result>((IEnumerable<CRMspCmsSelectWidgets_Result>)list4);
					if (cRMspCmsSelectWidgets_Result != null)
					{
						int.TryParse(cRMspCmsSelectWidgets_Result.OrderView.ToString(), out result2);
						result2 = ((result2 == 0) ? 10 : (result2 + 10));
					}
					crmCmsWidgetsLanguageViewModel.OrderView = result2;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		string firstRegInfo = "";
		string regInfo = "";
		if (crmCmsWidgetsLanguageViewModel != null)
		{
			SetWidgetRegisterInfo(crmCmsWidgetsLanguageViewModel, ref firstRegInfo, ref regInfo);
			crmCmsWidgetsLanguageViewModel.FirstRegisterUser = firstRegInfo;
			crmCmsWidgetsLanguageViewModel.EditUser = regInfo;
		}
		return View(crmCmsWidgetsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsManageWidgetsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsWidgetsLanguageViewModel vm)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetSystemParts();
		try
		{
			_003C_003Ec__DisplayClass11_1 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_1();
			_003C_003Ec__DisplayClass11_.model = new CrmCmsWidgets();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.WidgetTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WidgetTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.WidgetTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.WidgetBody_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WidgetBody_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.WidgetBody,
				LanguageId = lCID
			});
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.WidgetTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.WidgetTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.WidgetTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.WidgetTitle) + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.WidgetBody))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.WidgetBody) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.WidgetBody, list2))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.WidgetBody) + "<br>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			new BaseInfo();
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass11_.model = new CrmCmsWidgets();
				if (CS_0024_003C_003E8__locals0.vm.WidgetId > 0)
				{
					DbSet<CrmCmsWidgets> crmCmsWidgets = _dbTbl.CrmCmsWidgets;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgets), "c");
					_003C_003Ec__DisplayClass11_.model = Queryable.FirstOrDefault<CrmCmsWidgets>((IQueryable<CrmCmsWidgets>)crmCmsWidgets, Expression.Lambda<Func<CrmCmsWidgets, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass11_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass11_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass11_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass11_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass11_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass11_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass11_.model.WidgetGroupId = CS_0024_003C_003E8__locals0.vm.WidgetGroupId;
				_003C_003Ec__DisplayClass11_.model.WidgetTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass11_.model.WidgetBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass11_.model.WidgetRowStart = CS_0024_003C_003E8__locals0.vm.WidgetRowStart;
				_003C_003Ec__DisplayClass11_.model.WidgetRowCnt = CS_0024_003C_003E8__locals0.vm.WidgetRowCnt;
				_003C_003Ec__DisplayClass11_.model.WidgetColStart = CS_0024_003C_003E8__locals0.vm.WidgetColStart;
				_003C_003Ec__DisplayClass11_.model.WidgetColCnt = CS_0024_003C_003E8__locals0.vm.WidgetColCnt;
				_003C_003Ec__DisplayClass11_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass11_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				if (_003C_003Ec__DisplayClass11_.model.WidgetId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass11_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass11_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass11_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass11_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsWidgets_Lang> crmCmsWidgets_Lang = _dbTbl.CrmCmsWidgets_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgets_Lang), "c");
							CrmCmsWidgets_Lang crmCmsWidgets_Lang2 = Queryable.FirstOrDefault<CrmCmsWidgets_Lang>((IQueryable<CrmCmsWidgets_Lang>)crmCmsWidgets_Lang, Expression.Lambda<Func<CrmCmsWidgets_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass11_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass11_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsWidgets_Lang2 != null)
							{
								crmCmsWidgets_Lang2.WidgetTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsWidgets_Lang2.WidgetBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsWidgets_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsWidgets_Lang2 = new CrmCmsWidgets_Lang();
							crmCmsWidgets_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsWidgets_Lang2.WidgetId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.WidgetId;
							crmCmsWidgets_Lang2.WidgetTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsWidgets_Lang2.WidgetBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsWidgets_Lang.Add(crmCmsWidgets_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass11_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass11_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass11_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass11_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass11_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmCmsWidgets.Add(_003C_003Ec__DisplayClass11_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (_003C_003Ec__DisplayClass11_.model.WidgetId > 0)
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmCmsWidgets_Lang crmCmsWidgets_Lang3 = new CrmCmsWidgets_Lang();
							crmCmsWidgets_Lang3.LanguageID = lang.LanguageID;
							crmCmsWidgets_Lang3.WidgetId = _003C_003Ec__DisplayClass11_.model.WidgetId;
							crmCmsWidgets_Lang3.WidgetTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							crmCmsWidgets_Lang3.WidgetBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsWidgets_Lang.Add(crmCmsWidgets_Lang3);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.WidgetId = _003C_003Ec__DisplayClass11_.model.WidgetId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass11_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass11_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass11_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass11_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass11_.model.AppType;
				base.ViewBag.Successfull = text;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsWidgets");
				new FilesManager();
				new FacadeFTP(Configuration.FacadeFtpFo);
				string pathFtpFo = Configuration.PathFtpFo;
				string userNameFtpFo = Configuration.UserNameFtpFo;
				string passwordFtpFo = Configuration.PasswordFtpFo;
				bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
				if (!string.IsNullOrWhiteSpace(pathFtpFo) && !string.IsNullOrWhiteSpace(userNameFtpFo) && !string.IsNullOrWhiteSpace(passwordFtpFo))
				{
					try
					{
						if (list2 != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list2);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				base.ViewBag.Error = text;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		string firstRegInfo = "";
		string regInfo = "";
		if (CS_0024_003C_003E8__locals0.vm != null)
		{
			SetWidgetRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
			CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
			CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public void SetWidgetRegisterInfo(CrmCmsWidgetsLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsManageWidgets", ActionName = "actDeleteWidget")]
	public string DeleteWidget(int widgetId)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.widgetId = widgetId;
		string result = "";
		try
		{
			DbSet<CrmCmsWidgets> crmCmsWidgets = _dbTbl.CrmCmsWidgets;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsWidgets), "c");
			if (Queryable.FirstOrDefault<CrmCmsWidgets>((IQueryable<CrmCmsWidgets>)crmCmsWidgets, Expression.Lambda<Func<CrmCmsWidgets, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspCmsDeleteWidgets(_003C_003Ec__DisplayClass13_.widgetId));
					if (mct_II_Result != null && mct_II_Result.Result > 0)
					{
						result = "";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsWidgets");
					}
					else if (mct_II_Result != null && mct_II_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetWidgets(int widgetGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectWidgets_Result> list = new List<CRMspCmsSelectWidgets_Result>();
		try
		{
			list = Enumerable.ToList<CRMspCmsSelectWidgets_Result>((IEnumerable<CRMspCmsSelectWidgets_Result>)_dbII.CRMspCmsSelectWidgets(widgetGroupId, lCID, result));
			if (list != null)
			{
				if (Enumerable.Any<CRMspCmsSelectWidgets_Result>((IEnumerable<CRMspCmsSelectWidgets_Result>)list))
				{
					foreach (CRMspCmsSelectWidgets_Result item in list)
					{
						_ = item.FirstRegisterDate;
						item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.FirstRegisterUser += ((!string.IsNullOrWhiteSpace(item.FirstRegisterDatePersian)) ? (" (" + item.FirstRegisterDatePersian + ")") : "");
						_ = item.RegisterDate;
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						if (string.IsNullOrWhiteSpace(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						item.EditUser = item.EditUser + "(" + Labels.AppType + ":" + item.AppType + ")" + ((!string.IsNullOrWhiteSpace(item.RegisterDatePersian)) ? (" (" + item.RegisterDatePersian + ")") : "");
					}
				}
			}
			else
			{
				list = new List<CRMspCmsSelectWidgets_Result>();
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
	public string UpdateWidgetByRowAndCol(int widgetId, int widgetRowStart, int widgetRowCnt, int widgetColStart, int widgetColCnt)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			_dbII.CRMspCmsUpdateWidgetByRowAndCol(widgetId, widgetRowStart, widgetRowCnt, widgetColStart, widgetColCnt, userId, value, registerDatePersian, value3, value2, appType);
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsWidgets");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
