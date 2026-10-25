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
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Fund.Controllers;

public class GroupsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int groupId;
	}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public CrmFundGroupsLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CrmFundGroups model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1;

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

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmFundDataEntry", ActionName = "actDefineGroup")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineFundGroups", ActionName = "actDelete")]
	public string ActDelete(int groupId)
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
			if (!UserLogin.IsUserAccess("frmDefineFundGroups", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (groupId > 0)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteFundGroup(groupId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
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
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineFundGroups", ActionName = "actInsert,actEdit")]
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
		GetVerificationWorkFlows();
		CrmFundGroupsLanguageViewModel crmFundGroupsLanguageViewModel = new CrmFundGroupsLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineFundGroups", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<CrmFundGroups_Lang> crmFundGroups_Lang = _dbTbl.CrmFundGroups_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmFundGroups_Lang), "c");
			List<CrmFundGroups_Lang> list = Enumerable.ToList<CrmFundGroups_Lang>((IEnumerable<CrmFundGroups_Lang>)Queryable.Where<CrmFundGroups_Lang>((IQueryable<CrmFundGroups_Lang>)crmFundGroups_Lang, Expression.Lambda<Func<CrmFundGroups_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmFundGroups> crmFundGroups = _dbTbl.CrmFundGroups;
			val = Expression.Parameter(typeof(CrmFundGroups), "c");
			CrmFundGroups crmFundGroups2 = Queryable.FirstOrDefault<CrmFundGroups>((IQueryable<CrmFundGroups>)crmFundGroups, Expression.Lambda<Func<CrmFundGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmFundGroups2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFundGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFundGroups_Lang>)list, (Func<CrmFundGroups_Lang, CommonMultiLanguageViewModel>)((CrmFundGroups_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.GroupName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmFundGroups2.GroupName,
				LanguageId = result
			});
			crmFundGroupsLanguageViewModel = new CrmFundGroupsLanguageViewModel
			{
				FundGroupId = crmFundGroups2.FundGroupId,
				GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				GroupName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ParentId = crmFundGroups2.ParentId,
				FirstRegisterUserId = crmFundGroups2.FirstRegisterUserId,
				FirstRegisterDate = crmFundGroups2.FirstRegisterDate,
				FirstRegisterDatePersian = crmFundGroups2.FirstRegisterDatePersian,
				UserId = crmFundGroups2.UserId,
				Year1 = crmFundGroups2.Year1,
				Month1 = crmFundGroups2.Month1,
				RegisterDate = crmFundGroups2.RegisterDate,
				RegisterDatePersian = crmFundGroups2.RegisterDatePersian,
				GUId = crmFundGroups2.GUId,
				AppType = crmFundGroups2.AppType,
				LanguageID = crmFundGroups2.LanguageID,
				GroupVerificationWorkFlowId = crmFundGroups2.GroupVerificationWorkFlowId
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineFundGroups", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			crmFundGroupsLanguageViewModel = new CrmFundGroupsLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDate = now,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
			};
		}
		return View(crmFundGroupsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineFundGroupsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmFundGroupsLanguageViewModel vm, HttpPostedFileBase[] fileSending)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetVerificationWorkFlows();
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
		try
		{
			string text = "";
			if (CS_0024_003C_003E8__locals0.vm.GroupName == null && CS_0024_003C_003E8__locals0.vm.GroupName == "")
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.FundGroupName) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.GroupName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.FundGroupName) + "<br>";
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short year = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass5_.model = new CrmFundGroups();
				if (CS_0024_003C_003E8__locals0.vm.FundGroupId > 0)
				{
					DbSet<CrmFundGroups> crmFundGroups = _dbTbl.CrmFundGroups;
					ParameterExpression val = Expression.Parameter(typeof(CrmFundGroups), "c");
					_003C_003Ec__DisplayClass5_.model = Queryable.FirstOrDefault<CrmFundGroups>((IQueryable<CrmFundGroups>)crmFundGroups, Expression.Lambda<Func<CrmFundGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass5_.model.GroupName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass5_.model.ParentId = CS_0024_003C_003E8__locals0.vm.ParentId.GetValueOrDefault();
				_003C_003Ec__DisplayClass5_.model.GroupVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.GroupVerificationWorkFlowId;
				_003C_003Ec__DisplayClass5_.model.UserId = userId;
				_003C_003Ec__DisplayClass5_.model.Year1 = year;
				_003C_003Ec__DisplayClass5_.model.Month1 = month;
				_003C_003Ec__DisplayClass5_.model.RegisterDate = dateTime;
				_003C_003Ec__DisplayClass5_.model.RegisterDatePersian = text2;
				_003C_003Ec__DisplayClass5_.model.AppType = appType;
				if (_003C_003Ec__DisplayClass5_.model.FundGroupId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass5_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass5_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmFundGroups_Lang> crmFundGroups_Lang = _dbTbl.CrmFundGroups_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmFundGroups_Lang), "c");
							CrmFundGroups_Lang crmFundGroups_Lang2 = Queryable.FirstOrDefault<CrmFundGroups_Lang>((IQueryable<CrmFundGroups_Lang>)crmFundGroups_Lang, Expression.Lambda<Func<CrmFundGroups_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmFundGroups_Lang2 != null)
							{
								crmFundGroups_Lang2.GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmFundGroups_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmFundGroups_Lang2 = new CrmFundGroups_Lang();
							crmFundGroups_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmFundGroups_Lang2.FundGroupId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FundGroupId;
							crmFundGroups_Lang2.GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmFundGroups_Lang.Add(crmFundGroups_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass5_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass5_.model.FirstRegisterDate = dateTime;
					_003C_003Ec__DisplayClass5_.model.FirstRegisterDatePersian = text2;
					_003C_003Ec__DisplayClass5_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass5_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.CrmFundGroups.Add(_003C_003Ec__DisplayClass5_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					if (_003C_003Ec__DisplayClass5_.model.FundGroupId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmFundGroups_Lang crmFundGroups_Lang3 = new CrmFundGroups_Lang();
							crmFundGroups_Lang3.LanguageID = lang.LanguageID;
							crmFundGroups_Lang3.FundGroupId = _003C_003Ec__DisplayClass5_.model.FundGroupId;
							crmFundGroups_Lang3.GroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmFundGroups_Lang.Add(crmFundGroups_Lang3);
							_dbTbl.SaveChanges();
						}
						CS_0024_003C_003E8__locals0.vm.FundGroupId = _003C_003Ec__DisplayClass5_.model.FundGroupId;
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
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

	public List<TreeViewItemModel> GetFundGroupNodeTree(List<CRMspSelectFundGroupsTree_Result> lstGroups, int? fGroupId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectFundGroupsTree_Result> list2 = Enumerable.ToList<CRMspSelectFundGroupsTree_Result>(Enumerable.Where<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)lstGroups, (Func<CRMspSelectFundGroupsTree_Result, bool>)((CRMspSelectFundGroupsTree_Result m) => m.ParentId == fGroupId)));
			if (Enumerable.Any<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list2))
			{
				foreach (CRMspSelectFundGroupsTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FundGroupId.ToString()));
					treeViewItemModel.Id = item.FundGroupId.ToString();
					treeViewItemModel.Text = item.GroupName;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> fundGroupNodeTree = GetFundGroupNodeTree(lstGroups, item.FundGroupId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(fundGroupNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetFundGroupTree(int currFgId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectFundGroupsTree_Result> list2 = Enumerable.ToList<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)_db.CRMspSelectFundGroupsTree(currFgId, lCID, result));
			if (Enumerable.Any<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list2))
			{
				List<CRMspSelectFundGroupsTree_Result> list3 = Enumerable.ToList<CRMspSelectFundGroupsTree_Result>(Enumerable.Where<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list2, (Func<CRMspSelectFundGroupsTree_Result, bool>)((CRMspSelectFundGroupsTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list3))
				{
					foreach (CRMspSelectFundGroupsTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FundGroupId.ToString()));
						treeViewItemModel.Id = item.FundGroupId.ToString();
						treeViewItemModel.Text = item.GroupName;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> fundGroupNodeTree = GetFundGroupNodeTree(list2, item.FundGroupId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(fundGroupNodeTree);
						list.Add(treeViewItemModel);
					}
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
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialFundGroupTree(int currFgId)
	{
		try
		{
			base.ViewBag.FundGroupTree = GetFundGroupTree(currFgId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetFundGroupInfo(int gId)
	{
		CRMspSelectFundGroupsWithGroupId_Result cRMspSelectFundGroupsWithGroupId_Result = new CRMspSelectFundGroupsWithGroupId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspSelectFundGroupsWithGroupId_Result = Enumerable.FirstOrDefault<CRMspSelectFundGroupsWithGroupId_Result>((IEnumerable<CRMspSelectFundGroupsWithGroupId_Result>)_db.CRMspSelectFundGroupsWithGroupId(gId, lCID, result));
			if (cRMspSelectFundGroupsWithGroupId_Result != null)
			{
				if (string.IsNullOrEmpty(cRMspSelectFundGroupsWithGroupId_Result.AppType))
				{
					cRMspSelectFundGroupsWithGroupId_Result.AppType = Configuration.AppType;
				}
				cRMspSelectFundGroupsWithGroupId_Result.AppType = " (" + Labels.AppType + ":" + Configuration.GetAppType(cRMspSelectFundGroupsWithGroupId_Result.AppType) + ")";
				CRMspSelectFundGroupsWithGroupId_Result cRMspSelectFundGroupsWithGroupId_Result2 = cRMspSelectFundGroupsWithGroupId_Result;
				_ = cRMspSelectFundGroupsWithGroupId_Result.FirstRegisterDate;
				cRMspSelectFundGroupsWithGroupId_Result2.FirstRegisterDatePersian = cRMspSelectFundGroupsWithGroupId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectFundGroupsWithGroupId_Result.FirstRegisterUser = cRMspSelectFundGroupsWithGroupId_Result.FirstRegisterUser + " (" + cRMspSelectFundGroupsWithGroupId_Result.FirstRegisterDatePersian + ")";
				CRMspSelectFundGroupsWithGroupId_Result cRMspSelectFundGroupsWithGroupId_Result3 = cRMspSelectFundGroupsWithGroupId_Result;
				_ = cRMspSelectFundGroupsWithGroupId_Result.RegisterDate;
				cRMspSelectFundGroupsWithGroupId_Result3.RegisterDatePersian = cRMspSelectFundGroupsWithGroupId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectFundGroupsWithGroupId_Result.EditUser = cRMspSelectFundGroupsWithGroupId_Result.EditUser + cRMspSelectFundGroupsWithGroupId_Result.AppType + " (" + cRMspSelectFundGroupsWithGroupId_Result.RegisterDatePersian + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(cRMspSelectFundGroupsWithGroupId_Result, JsonRequestBehavior.AllowGet);
	}

	public void GetVerificationWorkFlows()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			foreach (WSspSelectVerificationWorkFlowWithObjectType_Result item in _db.WSspSelectVerificationWorkFlowWithObjectType(130, lCID, result))
			{
				list.Add(new SelectListItem
				{
					Value = item.VerificationWorkFlowId.ToString(),
					Text = item.VerificationWorkFlowTitle
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationWorkFlows = list;
	}

	public ActionResult GetVerificationWorkFlowOfFundGroup(int groupId)
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
		_003C_003Ec__DisplayClass12_.groupId = groupId;
		DbSet<CrmFundGroups> crmFundGroups = _dbTbl.CrmFundGroups;
		ParameterExpression val = Expression.Parameter(typeof(CrmFundGroups), "c");
		CrmFundGroups crmFundGroups2 = Queryable.FirstOrDefault<CrmFundGroups>(Queryable.Where<CrmFundGroups>((IQueryable<CrmFundGroups>)crmFundGroups, Expression.Lambda<Func<CrmFundGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		int num = 0;
		if (crmFundGroups2 != null)
		{
			num = crmFundGroups2.GroupVerificationWorkFlowId.GetValueOrDefault();
		}
		return Json(num, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
