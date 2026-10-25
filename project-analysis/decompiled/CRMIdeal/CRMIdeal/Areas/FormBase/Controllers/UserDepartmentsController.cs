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

public class UserDepartmentsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int departmentId;

		public int userId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int departmentId;

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
		public UserDepartmentLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__11;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int departmentId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actluDepartment")]
	public ActionResult Index(int position = 0)
	{
		string text = "";
		string text2 = "";
		if (position == 0)
		{
			text = "frmMain";
			text2 = "actluDepartment";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			return View();
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	public ActionResult InsertEdit(int departmentId = 0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.departmentId = departmentId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<UserDepartments_Lang> userDepartments_Lang = _dbTbl.UserDepartments_Lang;
		ParameterExpression val = Expression.Parameter(typeof(UserDepartments_Lang), "c");
		List<UserDepartments_Lang> list = Enumerable.ToList<UserDepartments_Lang>((IEnumerable<UserDepartments_Lang>)Queryable.Where<UserDepartments_Lang>((IQueryable<UserDepartments_Lang>)userDepartments_Lang, Expression.Lambda<Func<UserDepartments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetUsers();
		GetLeaveVerificationWorkFlows();
		GetMissionVerificationWorkFlows();
		DateTime now = DateTime.Now;
		UserDepartments userDepartments = new UserDepartments();
		if (CS_0024_003C_003E8__locals0.departmentId == 0)
		{
			if (!UserLogin.IsUserAccess("frmUserDepartments", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			userDepartments = new UserDepartments();
			userDepartments.DepartmentID = 0;
			userDepartments.RegisterDate = now;
			userDepartments.FirstRegisterDate = now;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmUserDepartments", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<UserDepartments> userDepartments2 = _dbTbl.UserDepartments;
			val = Expression.Parameter(typeof(UserDepartments), "m");
			userDepartments = Queryable.FirstOrDefault<UserDepartments>((IQueryable<UserDepartments>)userDepartments2, Expression.Lambda<Func<UserDepartments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (userDepartments == null)
			{
				userDepartments = new UserDepartments();
				userDepartments.DepartmentID = 0;
				userDepartments.RegisterDate = now;
				userDepartments.FirstRegisterDate = now;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<UserDepartments_Lang, CommonMultiLanguageViewModel>((IEnumerable<UserDepartments_Lang>)list, (Func<UserDepartments_Lang, CommonMultiLanguageViewModel>)((UserDepartments_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Department,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = userDepartments.Department,
			LanguageId = result
		});
		UserDepartmentLanguageViewModel model = new UserDepartmentLanguageViewModel
		{
			AppType = userDepartments.AppType,
			LanguageID = userDepartments.LanguageID,
			UserId = userDepartments.UserId,
			GUId = userDepartments.GUId,
			FirstRegisterDate = userDepartments.FirstRegisterDate,
			RegisterDate = userDepartments.RegisterDate,
			RegisterDatePersian = userDepartments.RegisterDatePersian,
			Month1 = userDepartments.Month1,
			Year1 = userDepartments.Year1,
			FirstRegisterDatePersian = userDepartments.FirstRegisterDatePersian,
			FirstRegisterUserId = userDepartments.FirstRegisterUserId,
			DepartmentID = userDepartments.DepartmentID,
			DefaultTicketUserId = userDepartments.DefaultTicketUserId,
			Department = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			Department_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			LeaveVerificationWorkFlowId = userDepartments.LeaveVerificationWorkFlowId,
			MissionVerificationWorkFlowId = userDepartments.MissionVerificationWorkFlowId
		};
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmUserDepartmentsDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(UserDepartmentLanguageViewModel model)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetUsers();
		GetLeaveVerificationWorkFlows();
		GetMissionVerificationWorkFlows();
		if (base.ModelState.IsValid)
		{
			int? cId = null;
			if (UserLogin.CurrentUser != null)
			{
				cId = UserLogin.CurrentUser.UserLastCId;
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Department_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Department_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.Department,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.model.Department == null)
			{
				text = text + Messages.CheckEmptyDepartment + "|";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.Department, list))
			{
				text = text + Messages.CheckDepartmentLang + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					if (CS_0024_003C_003E8__locals0.model.DepartmentID > 0)
					{
						DbSet<UserDepartments> userDepartments = _dbTbl.UserDepartments;
						ParameterExpression val = Expression.Parameter(typeof(UserDepartments), "m");
						UserDepartments userDepartments2 = Queryable.FirstOrDefault<UserDepartments>((IQueryable<UserDepartments>)userDepartments, Expression.Lambda<Func<UserDepartments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (userDepartments2 != null)
						{
							userDepartments2.UserId = UserLogin.CurrentUser.UserId;
							userDepartments2.RegisterDate = now;
							userDepartments2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							userDepartments2.AppType = Configuration.AppType;
							userDepartments2.Year1 = short.Parse(Financial.Get().Id.ToString());
							userDepartments2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							userDepartments2.DefaultTicketUserId = CS_0024_003C_003E8__locals0.model.DefaultTicketUserId;
							userDepartments2.Department = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							userDepartments2.LeaveVerificationWorkFlowId = CS_0024_003C_003E8__locals0.model.LeaveVerificationWorkFlowId;
							userDepartments2.MissionVerificationWorkFlowId = CS_0024_003C_003E8__locals0.model.MissionVerificationWorkFlowId;
							_dbTbl.Entry(userDepartments2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<UserDepartments_Lang> userDepartments_Lang = _dbTbl.UserDepartments_Lang;
									val = Expression.Parameter(typeof(UserDepartments_Lang), "c");
									UserDepartments_Lang userDepartments_Lang2 = Queryable.FirstOrDefault<UserDepartments_Lang>((IQueryable<UserDepartments_Lang>)userDepartments_Lang, Expression.Lambda<Func<UserDepartments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (userDepartments_Lang2 != null)
									{
										userDepartments_Lang2.Department = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(userDepartments_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									UserDepartments_Lang entity = new UserDepartments_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										DepartmentID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.DepartmentID,
										Department = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.UserDepartments_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserDepartments");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						UserDepartments userDepartments3 = new UserDepartments();
						userDepartments3.UserId = UserLogin.CurrentUser.UserId;
						userDepartments3.RegisterDate = now;
						userDepartments3.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						userDepartments3.AppType = Configuration.AppType;
						userDepartments3.Year1 = short.Parse(Financial.Get().Id.ToString());
						userDepartments3.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						userDepartments3.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						userDepartments3.FirstRegisterDate = now;
						userDepartments3.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						userDepartments3.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						userDepartments3.GUId = Guid.NewGuid();
						userDepartments3.DefaultTicketUserId = CS_0024_003C_003E8__locals0.model.DefaultTicketUserId;
						userDepartments3.LeaveVerificationWorkFlowId = CS_0024_003C_003E8__locals0.model.LeaveVerificationWorkFlowId;
						userDepartments3.MissionVerificationWorkFlowId = CS_0024_003C_003E8__locals0.model.MissionVerificationWorkFlowId;
						userDepartments3.Department = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						userDepartments3.CId = cId;
						_dbTbl.UserDepartments.Add(userDepartments3);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							UserDepartments_Lang entity2 = new UserDepartments_Lang
							{
								LanguageID = lang.LanguageID,
								DepartmentID = userDepartments3.DepartmentID,
								Department = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.UserDepartments_Lang.Add(entity2);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserDepartments");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
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
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public List<CRMspSelectUserDepartments_Result> ListUserDepartments()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectUserDepartments_Result> list = new List<CRMspSelectUserDepartments_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
			foreach (CRMspSelectUserDepartments_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
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
	public ActionResult UserDepartment_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListUserDepartments()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult UserDepartmentsList()
	{
		return Json(ListUserDepartments(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmUserDepartments", ActionName = "actDelete")]
	public string ActDelete(int departmentId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.departmentId = departmentId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass8_.departmentId > 0)
			{
				DbSet<UserDepartments> userDepartments = _dbTbl.UserDepartments;
				ParameterExpression val = Expression.Parameter(typeof(UserDepartments), "m");
				if (Queryable.FirstOrDefault<UserDepartments>((IQueryable<UserDepartments>)userDepartments, Expression.Lambda<Func<UserDepartments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteUserDepartments(_003C_003Ec__DisplayClass8_.departmentId));
						int result = 0;
						if (mct_Result != null)
						{
							int.TryParse(mct_Result.Result.ToString(), out result);
						}
						if (result > 0)
						{
							DbSet<UserDepartments> userDepartments2 = _dbTbl.UserDepartments;
							val = Expression.Parameter(typeof(UserDepartments), "model");
							if (Queryable.FirstOrDefault<UserDepartments>((IQueryable<UserDepartments>)userDepartments2, Expression.Lambda<Func<UserDepartments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
							{
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserDepartments");
								return "1";
							}
						}
						return Messages.RedundancyMessage;
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						return Messages.msgErrorRunFunction;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				return Messages.ErrorNotFound;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public JsonResult GetUsers()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)Enumerable.ToList<CRMspSelectActiveUsers_Result>(Enumerable.Where<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2), (Func<CRMspSelectActiveUsers_Result, bool>)((CRMspSelectActiveUsers_Result m) => m.UserId > 0))), (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = ((!string.IsNullOrEmpty(item.FName)) ? item.FName : "") + ((!string.IsNullOrEmpty(item.LName)) ? (" " + item.LName) : ""),
				Value = item.UserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetLeaveVerificationWorkFlows()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>(Enumerable.Where<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(90, lCID, result), (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, bool>)((WSspSelectVerificationWorkFlowWithObjectType_Result m) => m.IsActive && m.UserId > 0))), (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = (item.VerificationWorkFlowTitle ?? ""),
				Value = item.VerificationWorkFlowId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LeaveVerificationWorkFlowList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetMissionVerificationWorkFlows()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>(Enumerable.Where<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(100, lCID, result), (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, bool>)((WSspSelectVerificationWorkFlowWithObjectType_Result m) => m.IsActive && m.UserId > 0))), (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = (item.VerificationWorkFlowTitle ?? ""),
				Value = item.VerificationWorkFlowId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.MissionVerificationWorkFlowList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmUserDepartments", ActionName = "actSetTicketReferUsers")]
	public ActionResult TicketReferUsers(int departmentId, int defaultTicketUserId = 0)
	{
		base.ViewBag.DepartmentId = departmentId;
		GetUsersList(departmentId, defaultTicketUserId);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersList(int departmentId, int defaultTicketUserId)
	{
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
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
			List<CRMspSelectUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
			if (list2 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2))
			{
				foreach (CRMspSelectUsers_Result u in (defaultTicketUserId > 0) ? Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.IsActive.GetValueOrDefault() && m.UserId > 0 && m.UserId != defaultTicketUserId))) : Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.IsActive.GetValueOrDefault() && m.UserId > 0))))
				{
					CommonMultiSelectorViewModel commonMultiSelectorViewModel = new CommonMultiSelectorViewModel();
					if (Enumerable.FirstOrDefault<CRMspSelectUserDepartmentTicketReferUsersByDepartmentId_Result>((IEnumerable<CRMspSelectUserDepartmentTicketReferUsersByDepartmentId_Result>)Enumerable.ToList<CRMspSelectUserDepartmentTicketReferUsersByDepartmentId_Result>((IEnumerable<CRMspSelectUserDepartmentTicketReferUsersByDepartmentId_Result>)_db.CRMspSelectUserDepartmentTicketReferUsersByDepartmentId(departmentId, lCID, result, result2)), (Func<CRMspSelectUserDepartmentTicketReferUsersByDepartmentId_Result, bool>)((CRMspSelectUserDepartmentTicketReferUsersByDepartmentId_Result model) => model.ReferUserId == u.UserId)) != null)
					{
						commonMultiSelectorViewModel.Name = ((!string.IsNullOrWhiteSpace(u.LName)) ? u.LName : "") + ((!string.IsNullOrWhiteSpace(u.FName)) ? (" " + u.FName) : "");
						commonMultiSelectorViewModel.Selected = true;
						commonMultiSelectorViewModel.Id = u.UserId;
					}
					else
					{
						commonMultiSelectorViewModel.Name = ((!string.IsNullOrEmpty(u.FName)) ? u.FName : "") + ((!string.IsNullOrEmpty(u.LName)) ? (" " + u.LName) : "");
						commonMultiSelectorViewModel.Selected = false;
						commonMultiSelectorViewModel.Id = u.UserId;
					}
					list.Add(commonMultiSelectorViewModel);
				}
			}
			base.ViewBag.UsersList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string SetTicketReferUsers(int mode, int departmentId, int userId)
	{
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.departmentId = departmentId;
		_003C_003Ec__DisplayClass14_.userId = userId;
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (_003C_003Ec__DisplayClass14_.departmentId > 0 && _003C_003Ec__DisplayClass14_.userId > 0)
			{
				int userId2 = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string text2 = value3.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				if (mode == 1)
				{
					UserDepartmentTicketReferUsers userDepartmentTicketReferUsers = new UserDepartmentTicketReferUsers();
					userDepartmentTicketReferUsers.DepartmentId = _003C_003Ec__DisplayClass14_.departmentId;
					userDepartmentTicketReferUsers.ReferUserId = _003C_003Ec__DisplayClass14_.userId;
					userDepartmentTicketReferUsers.LanguageID = result;
					userDepartmentTicketReferUsers.GUId = Guid.NewGuid();
					userDepartmentTicketReferUsers.AppType = appType;
					userDepartmentTicketReferUsers.UserId = userId2;
					userDepartmentTicketReferUsers.Year1 = value;
					userDepartmentTicketReferUsers.Month1 = value2;
					userDepartmentTicketReferUsers.RegisterDate = value3;
					userDepartmentTicketReferUsers.RegisterDatePersian = text2;
					userDepartmentTicketReferUsers.FirstRegisterUserId = userId2;
					userDepartmentTicketReferUsers.FirstRegisterDate = value3;
					userDepartmentTicketReferUsers.FirstRegisterDatePersian = text2;
					_dbTbl.UserDepartmentTicketReferUsers.Add(userDepartmentTicketReferUsers);
					_dbTbl.SaveChanges();
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserDepartmentTicketReferUsers");
					return "1|" + Messages.msgSuccessAction;
				}
				DbSet<UserDepartmentTicketReferUsers> userDepartmentTicketReferUsers2 = _dbTbl.UserDepartmentTicketReferUsers;
				ParameterExpression val = Expression.Parameter(typeof(UserDepartmentTicketReferUsers), "m");
				UserDepartmentTicketReferUsers userDepartmentTicketReferUsers3 = Queryable.FirstOrDefault<UserDepartmentTicketReferUsers>((IQueryable<UserDepartmentTicketReferUsers>)userDepartmentTicketReferUsers2, Expression.Lambda<Func<UserDepartmentTicketReferUsers, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (userDepartmentTicketReferUsers3 != null)
				{
					_dbTbl.UserDepartmentTicketReferUsers.Remove(userDepartmentTicketReferUsers3);
					_dbTbl.SaveChanges();
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserDepartmentTicketReferUsers");
					return "1|" + Messages.msgSuccessAction;
				}
				return "-1|" + Messages.ErrorNotFound;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
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
