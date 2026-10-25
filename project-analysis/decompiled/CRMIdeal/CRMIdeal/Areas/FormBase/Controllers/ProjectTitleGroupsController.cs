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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class ProjectTitleGroupsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int currLangID;

		public CrmProjectTitleGroupsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__0;

		public Func<Languages, bool> _003C_003E9__11;

		public Func<Languages, bool> _003C_003E9__37;

		internal bool _003CInsertEdit_003Eb__0(Languages c)
		{
			return c.LanguageID != currLangID;
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

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__37(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals1;

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

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int projectTitleGroupId;

		public int defLangID;

		public int currLangID;

		public Func<Languages, bool> _003C_003E9__10;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__7;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__8;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__9;

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineProjectTitleGroup")]
	public ActionResult Index()
	{
		return View();
	}

	public List<CRMspSelectProjectTitleGroups_Result> ListProjectTitleGroups()
	{
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectProjectTitleGroups_Result> list = new List<CRMspSelectProjectTitleGroups_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectProjectTitleGroups_Result>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)_dbI.CRMspSelectProjectTitleGroups(lCID, result));
			foreach (CRMspSelectProjectTitleGroups_Result item in list)
			{
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
				item.ProjectTitleGroupColor = Public.TColorToHex(item.ProjectTitleGroupColor);
				if (string.IsNullOrWhiteSpace(item.ProjectTitleGroupSubjectDefaultContext))
				{
					continue;
				}
				string text5 = "";
				List<PrjTitleGroupSubjectDefaultContextViewModel> list2 = new JavaScriptSerializer().Deserialize<List<PrjTitleGroupSubjectDefaultContextViewModel>>(item.ProjectTitleGroupSubjectDefaultContext);
				if (list2 != null && Enumerable.Any<PrjTitleGroupSubjectDefaultContextViewModel>((IEnumerable<PrjTitleGroupSubjectDefaultContextViewModel>)list2))
				{
					foreach (PrjTitleGroupSubjectDefaultContextViewModel item2 in list2)
					{
						if (!string.IsNullOrWhiteSpace(item2.SubjectDefaultContext))
						{
							text5 = text5 + item2.SubjectDefaultContext + ",";
						}
					}
					if (text5.EndsWith(","))
					{
						text5 = text5.TrimEnd(new char[1] { ',' });
					}
				}
				item.ProjectTitleGroupSubjectDefaultContext = text5;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult ProjectTitleGroups_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListProjectTitleGroups()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult ProjectTitleGroupsList()
	{
		return Json(ListProjectTitleGroups(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActDelete(int projectTitleGroupId)
	{
		string result = "";
		try
		{
			if (projectTitleGroupId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteProjectTitleGroups(projectTitleGroupId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "1";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectTitleGroups");
					}
					else if (mct_I_Result != null && mct_I_Result.Result == 0)
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetUserDepartments()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2)), (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserDepartmentsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int projectTitleGroupId = 0)
	{
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.projectTitleGroupId = projectTitleGroupId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmProjectTitleGroups_Lang> crmProjectTitleGroups_Lang = _dbTbl.CrmProjectTitleGroups_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmProjectTitleGroups_Lang), "c");
		List<CrmProjectTitleGroups_Lang> list = Enumerable.ToList<CrmProjectTitleGroups_Lang>((IEnumerable<CrmProjectTitleGroups_Lang>)Queryable.Where<CrmProjectTitleGroups_Lang>((IQueryable<CrmProjectTitleGroups_Lang>)crmProjectTitleGroups_Lang, Expression.Lambda<Func<CrmProjectTitleGroups_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetUserDepartments();
		CrmProjectTitleGroupsLanguageViewModel model = new CrmProjectTitleGroupsLanguageViewModel();
		_ = DateTime.Now;
		CrmProjectTitleGroups crmProjectTitleGroups = new CrmProjectTitleGroups();
		try
		{
			if (CS_0024_003C_003E8__locals0.projectTitleGroupId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmProjectTitleGroups = new CrmProjectTitleGroups();
				crmProjectTitleGroups.ProjectTitleGroupId = 0;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmProjectTitleGroups> crmProjectTitleGroups2 = _dbTbl.CrmProjectTitleGroups;
				val = Expression.Parameter(typeof(CrmProjectTitleGroups), "m");
				crmProjectTitleGroups = Queryable.FirstOrDefault<CrmProjectTitleGroups>((IQueryable<CrmProjectTitleGroups>)crmProjectTitleGroups2, Expression.Lambda<Func<CrmProjectTitleGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmProjectTitleGroups == null)
				{
					crmProjectTitleGroups = new CrmProjectTitleGroups();
					crmProjectTitleGroups.ProjectTitleGroupId = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectTitleGroups_Lang>)list, (Func<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>)((CrmProjectTitleGroups_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ProjectTitleGroup,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmProjectTitleGroups.ProjectTitleGroup,
				LanguageId = CS_0024_003C_003E8__locals0.defLangID
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectTitleGroups_Lang>)list, (Func<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>)((CrmProjectTitleGroups_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ProjectTitleGroupDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmProjectTitleGroups.ProjectTitleGroupDesc,
				LanguageId = CS_0024_003C_003E8__locals0.defLangID
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectTitleGroups_Lang>)list, (Func<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>)((CrmProjectTitleGroups_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ProjectTitleGroupAgreementDesc,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmProjectTitleGroups.ProjectTitleGroupAgreementDesc,
				LanguageId = CS_0024_003C_003E8__locals0.defLangID
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectTitleGroups_Lang>)list, (Func<CrmProjectTitleGroups_Lang, CommonMultiLanguageViewModel>)((CrmProjectTitleGroups_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.ProjectTitleGroupSubjectDefaultContext,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmProjectTitleGroups.ProjectTitleGroupSubjectDefaultContext,
				LanguageId = CS_0024_003C_003E8__locals0.defLangID
			});
			List<ProjectTitleGroupSubjectDefaultContextViewModel> list6 = new List<ProjectTitleGroupSubjectDefaultContextViewModel>();
			if (list5 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5))
			{
				CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID));
				if (commonMultiLanguageViewModel != null)
				{
					string text = commonMultiLanguageViewModel.Value ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<ProjectTitleGroupSubjectDefaultContextViewModel> list7 = new JavaScriptSerializer().Deserialize<List<ProjectTitleGroupSubjectDefaultContextViewModel>>(text);
						if (list7 != null && Enumerable.Any<ProjectTitleGroupSubjectDefaultContextViewModel>((IEnumerable<ProjectTitleGroupSubjectDefaultContextViewModel>)list7))
						{
							for (int i = 0; i < list7.Count; i++)
							{
								ProjectTitleGroupSubjectDefaultContextViewModel projectTitleGroupSubjectDefaultContextViewModel = new ProjectTitleGroupSubjectDefaultContextViewModel();
								string value = list7[i].SubjectDefaultContext ?? "";
								List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
								foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID));
									if (commonMultiLanguageViewModel2 == null)
									{
										continue;
									}
									string text2 = commonMultiLanguageViewModel2.Value ?? "";
									if (!string.IsNullOrWhiteSpace(text2))
									{
										List<PrjTitleGroupSubjectDefaultContextViewModel> list9 = new JavaScriptSerializer().Deserialize<List<PrjTitleGroupSubjectDefaultContextViewModel>>(text2);
										if (list9 != null && Enumerable.Any<PrjTitleGroupSubjectDefaultContextViewModel>((IEnumerable<PrjTitleGroupSubjectDefaultContextViewModel>)list9))
										{
											if (list9.Count == list7.Count)
											{
												string value2 = list9[i].SubjectDefaultContext ?? "";
												list8.Add(new CommonMultiLanguageViewModel
												{
													Value = value2,
													LanguageId = lang.LanguageID
												});
											}
											else
											{
												list8.Add(new CommonMultiLanguageViewModel
												{
													Value = value,
													LanguageId = lang.LanguageID
												});
											}
										}
									}
									else
									{
										list8.Add(new CommonMultiLanguageViewModel
										{
											Value = value,
											LanguageId = lang.LanguageID
										});
									}
								}
								list8.Add(new CommonMultiLanguageViewModel
								{
									Value = value,
									LanguageId = CS_0024_003C_003E8__locals0.defLangID
								});
								projectTitleGroupSubjectDefaultContextViewModel.SubjectDefaultContextId = i + 1;
								projectTitleGroupSubjectDefaultContextViewModel.SubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
								projectTitleGroupSubjectDefaultContextViewModel.SubjectDefaultContext_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
								list6.Add(projectTitleGroupSubjectDefaultContextViewModel);
							}
						}
					}
				}
			}
			model = new CrmProjectTitleGroupsLanguageViewModel
			{
				ProjectTitleGroupId = crmProjectTitleGroups.ProjectTitleGroupId,
				ProjectTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ProjectTitleGroup_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ProjectTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ProjectTitleGroupDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ProjectTitleGroupUserDepartmentId = crmProjectTitleGroups.ProjectTitleGroupUserDepartmentId.GetValueOrDefault(),
				ProjectTitleGroupAgreementActive = crmProjectTitleGroups.ProjectTitleGroupAgreementActive,
				ProjectTitleGroupAgreementDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ProjectTitleGroupAgreementDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ProjectTitleGroupSubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				ProjectTitleGroupSubjectDefaultContext_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				ProjectTitleGroupSubjectDefaultContextJson = JsonConvert.SerializeObject(Enumerable.ToList<ProjectTitleGroupSubjectDefaultContextViewModel>((IEnumerable<ProjectTitleGroupSubjectDefaultContextViewModel>)list6)),
				ProjectTitleGroupTicketCountCurrentWithStop = crmProjectTitleGroups.ProjectTitleGroupTicketCountCurrentWithStop,
				ProjectTitleGroupTicketAllowInCurrentCount = crmProjectTitleGroups.ProjectTitleGroupTicketAllowInCurrentCount,
				ProjectTitleGroupColor = Public.TColorToHex(crmProjectTitleGroups.ProjectTitleGroupColor)
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmProjectTitleGroupsLanguageViewModel model)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetUserDepartments();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ProjectTitleGroup_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ProjectTitleGroup_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ProjectTitleGroup,
				LanguageId = CS_0024_003C_003E8__locals0.currLangID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupDesc,
				LanguageId = CS_0024_003C_003E8__locals0.currLangID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupAgreementDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupAgreementDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupAgreementDesc,
				LanguageId = CS_0024_003C_003E8__locals0.currLangID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupSubjectDefaultContextJson))
			{
				List<ProjectTitleGroupSubjectDefaultContextViewModel> list5 = new JavaScriptSerializer().Deserialize<List<ProjectTitleGroupSubjectDefaultContextViewModel>>(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupSubjectDefaultContextJson);
				if (list5 != null && Enumerable.Any<ProjectTitleGroupSubjectDefaultContextViewModel>((IEnumerable<ProjectTitleGroupSubjectDefaultContextViewModel>)list5))
				{
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					foreach (ProjectTitleGroupSubjectDefaultContextViewModel item2 in list5)
					{
						List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(item2.SubjectDefaultContext_Lang))
						{
							list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item2.SubjectDefaultContext_Lang);
						}
						else
						{
							foreach (Languages item3 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.currLangID))))
							{
								list7.Add(new CommonMultiLanguageViewModel
								{
									Value = item2.SubjectDefaultContext,
									LanguageId = item3.LanguageID
								});
							}
						}
						list7.Add(new CommonMultiLanguageViewModel
						{
							Value = item2.SubjectDefaultContext,
							LanguageId = CS_0024_003C_003E8__locals0.currLangID
						});
						list6.AddRange(list7);
					}
					foreach (Languages lang2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
					{
						List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)));
						if (list8 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
						{
							continue;
						}
						List<PrjTitleGroupSubjectDefaultContextViewModel> list9 = new List<PrjTitleGroupSubjectDefaultContextViewModel>();
						foreach (CommonMultiLanguageViewModel item4 in list8)
						{
							PrjTitleGroupSubjectDefaultContextViewModel item = new PrjTitleGroupSubjectDefaultContextViewModel
							{
								SubjectDefaultContext = (item4.Value ?? "")
							};
							list9.Add(item);
						}
						string value = JsonConvert.SerializeObject(Enumerable.ToList<PrjTitleGroupSubjectDefaultContextViewModel>((IEnumerable<PrjTitleGroupSubjectDefaultContextViewModel>)list9));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = value,
							LanguageId = lang2.LanguageID
						});
					}
				}
			}
			if (CS_0024_003C_003E8__locals0.model.ProjectTitleGroup == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.ProjectTitleGroupTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.ProjectTitleGroup, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.ProjectTitleGroupTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					if (CS_0024_003C_003E8__locals0.model.ProjectTitleGroupId > 0)
					{
						DbSet<CrmProjectTitleGroups> crmProjectTitleGroups = _dbTbl.CrmProjectTitleGroups;
						ParameterExpression val = Expression.Parameter(typeof(CrmProjectTitleGroups), "m");
						CrmProjectTitleGroups crmProjectTitleGroups2 = Queryable.FirstOrDefault<CrmProjectTitleGroups>((IQueryable<CrmProjectTitleGroups>)crmProjectTitleGroups, Expression.Lambda<Func<CrmProjectTitleGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmProjectTitleGroups2 != null)
						{
							crmProjectTitleGroups2.UserId = UserLogin.CurrentUser.UserId;
							crmProjectTitleGroups2.RegisterDate = now;
							crmProjectTitleGroups2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmProjectTitleGroups2.AppType = Configuration.AppType;
							crmProjectTitleGroups2.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmProjectTitleGroups2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmProjectTitleGroups2.ProjectTitleGroupUserDepartmentId = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupUserDepartmentId;
							crmProjectTitleGroups2.ProjectTitleGroup = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmProjectTitleGroups2.ProjectTitleGroupDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmProjectTitleGroups2.ProjectTitleGroupAgreementActive = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupAgreementActive;
							crmProjectTitleGroups2.ProjectTitleGroupAgreementDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmProjectTitleGroups2.ProjectTitleGroupSubjectDefaultContext = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmProjectTitleGroups2.ProjectTitleGroupColor = Public.HexToColor(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupColor);
							if (VersionBuyer.TicketPlus)
							{
								crmProjectTitleGroups2.ProjectTitleGroupTicketCountCurrentWithStop = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupTicketCountCurrentWithStop;
								crmProjectTitleGroups2.ProjectTitleGroupTicketAllowInCurrentCount = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupTicketAllowInCurrentCount;
							}
							_dbTbl.Entry(crmProjectTitleGroups2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator2 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass10_2();
									CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals2.lang = enumerator2.Current;
									DbSet<CrmProjectTitleGroups_Lang> crmProjectTitleGroups_Lang = _dbTbl.CrmProjectTitleGroups_Lang;
									val = Expression.Parameter(typeof(CrmProjectTitleGroups_Lang), "c");
									CrmProjectTitleGroups_Lang crmProjectTitleGroups_Lang2 = Queryable.FirstOrDefault<CrmProjectTitleGroups_Lang>((IQueryable<CrmProjectTitleGroups_Lang>)crmProjectTitleGroups_Lang, Expression.Lambda<Func<CrmProjectTitleGroups_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmProjectTitleGroups_Lang2 != null)
									{
										crmProjectTitleGroups_Lang2.ProjectTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										crmProjectTitleGroups_Lang2.ProjectTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										crmProjectTitleGroups_Lang2.ProjectTitleGroupAgreementDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										crmProjectTitleGroups_Lang2.ProjectTitleGroupSubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmProjectTitleGroups_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									CrmProjectTitleGroups_Lang entity = new CrmProjectTitleGroups_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID,
										ProjectTitleGroupId = crmProjectTitleGroups2.ProjectTitleGroupId,
										ProjectTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
										ProjectTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
										ProjectTitleGroupAgreementDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
										ProjectTitleGroupSubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmProjectTitleGroups_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectTitleGroups");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						CrmProjectTitleGroups crmProjectTitleGroups3 = new CrmProjectTitleGroups();
						crmProjectTitleGroups3.UserId = UserLogin.CurrentUser.UserId;
						crmProjectTitleGroups3.RegisterDate = now;
						crmProjectTitleGroups3.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmProjectTitleGroups3.AppType = Configuration.AppType;
						crmProjectTitleGroups3.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmProjectTitleGroups3.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmProjectTitleGroups3.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						crmProjectTitleGroups3.FirstRegisterDate = now;
						crmProjectTitleGroups3.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmProjectTitleGroups3.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						crmProjectTitleGroups3.GUId = Guid.NewGuid();
						crmProjectTitleGroups3.ProjectTitleGroupUserDepartmentId = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupUserDepartmentId;
						crmProjectTitleGroups3.ProjectTitleGroup = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmProjectTitleGroups3.ProjectTitleGroupDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmProjectTitleGroups3.ProjectTitleGroupAgreementActive = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupAgreementActive;
						crmProjectTitleGroups3.ProjectTitleGroupAgreementDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmProjectTitleGroups3.ProjectTitleGroupSubjectDefaultContext = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmProjectTitleGroups3.ProjectTitleGroupColor = Public.HexToColor(CS_0024_003C_003E8__locals0.model.ProjectTitleGroupColor);
						if (VersionBuyer.TicketPlus)
						{
							crmProjectTitleGroups3.ProjectTitleGroupTicketCountCurrentWithStop = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupTicketCountCurrentWithStop;
							crmProjectTitleGroups3.ProjectTitleGroupTicketAllowInCurrentCount = CS_0024_003C_003E8__locals0.model.ProjectTitleGroupTicketAllowInCurrentCount;
						}
						_dbTbl.CrmProjectTitleGroups.Add(crmProjectTitleGroups3);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmProjectTitleGroups_Lang entity2 = new CrmProjectTitleGroups_Lang
							{
								LanguageID = lang.LanguageID,
								ProjectTitleGroupId = crmProjectTitleGroups3.ProjectTitleGroupId,
								ProjectTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
								ProjectTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
								ProjectTitleGroupAgreementDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
								ProjectTitleGroupSubjectDefaultContext = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmProjectTitleGroups_Lang.Add(entity2);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectTitleGroups");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					new FilesManager();
					new FacadeFTP(Configuration.FacadeFtpFo);
					string pathFtpFo = Configuration.PathFtpFo;
					string userNameFtpFo = Configuration.UserNameFtpFo;
					string passwordFtpFo = Configuration.PasswordFtpFo;
					bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
					if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
					{
						try
						{
							if (list2 != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list2);
							}
							if (list3 != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list3);
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
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
		_dbI.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
