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

namespace CRMIdeal.Areas.FormBase.Controllers;

public class CmsNewsGroupController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int groupId;

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
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public CrmCmsNewsGroupsLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CrmCmsNewsGroups model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1;

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
		public int groupId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmCmsDefineNewsDataEntry", ActionName = "actDefineGroup")]
	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int groupId = 0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.groupId = groupId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCmsNewsGroupsLanguageViewModel crmCmsNewsGroupsLanguageViewModel = new CrmCmsNewsGroupsLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.groupId > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<CrmCmsNewsGroups_Lang> crmCmsNewsGroups_Lang = _dbTbl.CrmCmsNewsGroups_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsNewsGroups_Lang), "c");
			List<CrmCmsNewsGroups_Lang> list = Enumerable.ToList<CrmCmsNewsGroups_Lang>((IEnumerable<CrmCmsNewsGroups_Lang>)Queryable.Where<CrmCmsNewsGroups_Lang>((IQueryable<CrmCmsNewsGroups_Lang>)crmCmsNewsGroups_Lang, Expression.Lambda<Func<CrmCmsNewsGroups_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmCmsNewsGroups> crmCmsNewsGroups = _dbTbl.CrmCmsNewsGroups;
			val = Expression.Parameter(typeof(CrmCmsNewsGroups), "c");
			CrmCmsNewsGroups crmCmsNewsGroups2 = Queryable.FirstOrDefault<CrmCmsNewsGroups>((IQueryable<CrmCmsNewsGroups>)crmCmsNewsGroups, Expression.Lambda<Func<CrmCmsNewsGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCmsNewsGroups2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsNewsGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsNewsGroups_Lang>)list, (Func<CrmCmsNewsGroups_Lang, CommonMultiLanguageViewModel>)((CrmCmsNewsGroups_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.GroupName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmCmsNewsGroups2.GroupName,
				LanguageId = result
			});
			crmCmsNewsGroupsLanguageViewModel = new CrmCmsNewsGroupsLanguageViewModel
			{
				NewsGroupId = crmCmsNewsGroups2.NewsGroupId,
				GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				GroupName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				IsActive = crmCmsNewsGroups2.IsActive,
				OrderView = crmCmsNewsGroups2.OrderView,
				FirstRegisterUserId = crmCmsNewsGroups2.FirstRegisterUserId,
				FirstRegisterDate = crmCmsNewsGroups2.FirstRegisterDate,
				FirstRegisterDatePersian = crmCmsNewsGroups2.FirstRegisterDatePersian,
				UserId = crmCmsNewsGroups2.UserId,
				Year1 = crmCmsNewsGroups2.Year1,
				Month1 = crmCmsNewsGroups2.Month1,
				RegisterDate = crmCmsNewsGroups2.RegisterDate,
				RegisterDatePersian = crmCmsNewsGroups2.RegisterDatePersian,
				GUId = crmCmsNewsGroups2.GUId,
				AppType = crmCmsNewsGroups2.AppType,
				LanguageID = crmCmsNewsGroups2.LanguageID
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			crmCmsNewsGroupsLanguageViewModel = new CrmCmsNewsGroupsLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				Year1 = short.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = Configuration.AppType,
				LanguageID = result,
				IsActive = true
			};
			if (!Enumerable.Any<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)Enumerable.ToList<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)_db.CRMspCmsSelectNewsGroups(CS_0024_003C_003E8__locals0.currLangID, result))))
			{
				crmCmsNewsGroupsLanguageViewModel.OrderView = 10;
			}
		}
		return View(crmCmsNewsGroupsLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmCmsNewsGroupsLanguageViewModel vm)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
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
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.GroupName_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.GroupName_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.GroupName,
				LanguageId = lCID
			});
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.GroupName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsNewsGroupName) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.GroupName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsNewsGroupName) + "<br>";
				num++;
			}
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
						_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
						_003C_003Ec__DisplayClass4_.model = new CrmCmsNewsGroups();
						if (CS_0024_003C_003E8__locals0.vm.NewsGroupId > 0)
						{
							DbSet<CrmCmsNewsGroups> crmCmsNewsGroups = _dbTbl.CrmCmsNewsGroups;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsNewsGroups), "c");
							_003C_003Ec__DisplayClass4_.model = Queryable.FirstOrDefault<CrmCmsNewsGroups>((IQueryable<CrmCmsNewsGroups>)crmCmsNewsGroups, Expression.Lambda<Func<CrmCmsNewsGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						}
						_003C_003Ec__DisplayClass4_.model.UserId = UserLogin.CurrentUser.UserId;
						DateTime now = DateTime.Now;
						_003C_003Ec__DisplayClass4_.model.RegisterDate = now;
						_003C_003Ec__DisplayClass4_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass4_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass4_.model.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass4_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
						_003C_003Ec__DisplayClass4_.model.GroupName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_003C_003Ec__DisplayClass4_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
						_003C_003Ec__DisplayClass4_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
						if (_003C_003Ec__DisplayClass4_.model.NewsGroupId > 0)
						{
							_dbTbl.Entry(_003C_003Ec__DisplayClass4_.model).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass4_;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmCmsNewsGroups_Lang> crmCmsNewsGroups_Lang = _dbTbl.CrmCmsNewsGroups_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmCmsNewsGroups_Lang), "c");
									CrmCmsNewsGroups_Lang crmCmsNewsGroups_Lang2 = Queryable.FirstOrDefault<CrmCmsNewsGroups_Lang>((IQueryable<CrmCmsNewsGroups_Lang>)crmCmsNewsGroups_Lang, Expression.Lambda<Func<CrmCmsNewsGroups_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmCmsNewsGroups_Lang2 != null)
									{
										crmCmsNewsGroups_Lang2.GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmCmsNewsGroups_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									crmCmsNewsGroups_Lang2 = new CrmCmsNewsGroups_Lang();
									crmCmsNewsGroups_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									crmCmsNewsGroups_Lang2.NewsGroupId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.NewsGroupId;
									crmCmsNewsGroups_Lang2.GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.CrmCmsNewsGroups_Lang.Add(crmCmsNewsGroups_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsNewsGroups");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
							{
								List<CRMspCmsSelectNewsGroups_Result> list2 = Enumerable.ToList<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)_db.CRMspCmsSelectNewsGroups(lCID, CS_0024_003C_003E8__locals0.defLangID));
								int num2 = (Enumerable.Any<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)list2) ? Enumerable.Count<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)list2) : 0);
								_003C_003Ec__DisplayClass4_.model.OrderView = num2 * 10 + 10;
								if (Enumerable.LastOrDefault<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)list2) != null)
								{
									int valueOrDefault = Enumerable.LastOrDefault<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)list2).OrderView.GetValueOrDefault();
									if (valueOrDefault > 0)
									{
										_003C_003Ec__DisplayClass4_.model.OrderView = valueOrDefault + 10;
									}
								}
							}
							else
							{
								_003C_003Ec__DisplayClass4_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
							}
							_003C_003Ec__DisplayClass4_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass4_.model.FirstRegisterDate = now;
							_003C_003Ec__DisplayClass4_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass4_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							_003C_003Ec__DisplayClass4_.model.GUId = Guid.NewGuid();
							_dbTbl.CrmCmsNewsGroups.Add(_003C_003Ec__DisplayClass4_.model);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmCmsNewsGroups_Lang crmCmsNewsGroups_Lang3 = new CrmCmsNewsGroups_Lang();
								crmCmsNewsGroups_Lang3.LanguageID = lang.LanguageID;
								crmCmsNewsGroups_Lang3.NewsGroupId = _003C_003Ec__DisplayClass4_.model.NewsGroupId;
								crmCmsNewsGroups_Lang3.GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								_dbTbl.CrmCmsNewsGroups_Lang.Add(crmCmsNewsGroups_Lang3);
								_dbTbl.SaveChanges();
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsNewsGroups");
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						CS_0024_003C_003E8__locals0.vm.NewsGroupId = _003C_003Ec__DisplayClass4_.model.NewsGroupId;
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

	public List<CRMspCmsSelectNewsGroups_Result> NewsGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectNewsGroups_Result> list = new List<CRMspCmsSelectNewsGroups_Result>();
		try
		{
			list = Enumerable.ToList<CRMspCmsSelectNewsGroups_Result>((IEnumerable<CRMspCmsSelectNewsGroups_Result>)_db.CRMspCmsSelectNewsGroups(lCID, result));
			foreach (CRMspCmsSelectNewsGroups_Result item in list)
			{
				item.IsActive = item.IsActive.HasValue && item.IsActive.GetValueOrDefault();
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
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
		return list;
	}

	[AjaxOnly]
	public ActionResult NewsGroups_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)NewsGroups()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult NewsGroupList()
	{
		JsonResult jsonResult = Json(NewsGroups(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string GroupDelete(int groupId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.groupId = groupId;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass8_.groupId > 0)
			{
				DbSet<CrmCmsNewsGroups> crmCmsNewsGroups = _dbTbl.CrmCmsNewsGroups;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsNewsGroups), "m");
				if (Queryable.FirstOrDefault<CrmCmsNewsGroups>((IQueryable<CrmCmsNewsGroups>)crmCmsNewsGroups, Expression.Lambda<Func<CrmCmsNewsGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteNewsGroups(_003C_003Ec__DisplayClass8_.groupId));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsNewsGroups");
							result = "1";
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
		base.Dispose(disposing);
	}
}
