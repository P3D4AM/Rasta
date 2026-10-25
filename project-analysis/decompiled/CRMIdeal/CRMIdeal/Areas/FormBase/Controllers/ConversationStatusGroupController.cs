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

public class ConversationStatusGroupController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int sgroupId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int groupId;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public CrmConversationStatusGroupLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__19;

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

		internal bool _003CInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int sgroupId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult Index(int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmMain";
			text2 = "actDefinecnvsStatusGroups";
			break;
		case 1:
			text2 = "actDefineGroups";
			text = "frmDefinecnvsStatusDataEntry";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
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
		DbSet<CrmConversationStatusGroups_Lang> crmConversationStatusGroups_Lang = _dbTbl.CrmConversationStatusGroups_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusGroups_Lang), "c");
		List<CrmConversationStatusGroups_Lang> list = Enumerable.ToList<CrmConversationStatusGroups_Lang>((IEnumerable<CrmConversationStatusGroups_Lang>)Queryable.Where<CrmConversationStatusGroups_Lang>((IQueryable<CrmConversationStatusGroups_Lang>)crmConversationStatusGroups_Lang, Expression.Lambda<Func<CrmConversationStatusGroups_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetUsers();
		DateTime now = DateTime.Now;
		CrmConversationStatusGroups crmConversationStatusGroups = new CrmConversationStatusGroups();
		if (CS_0024_003C_003E8__locals0.groupId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDefinecnvsStatusGroup", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			crmConversationStatusGroups = new CrmConversationStatusGroups();
			crmConversationStatusGroups.ConversationStatusGroupID = 0;
			crmConversationStatusGroups.RegisterDate = now;
			crmConversationStatusGroups.FirstRegisterDate = now;
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefinecnvsStatusGroup", "actEdit", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			DbSet<CrmConversationStatusGroups> crmConversationStatusGroups2 = _dbTbl.CrmConversationStatusGroups;
			val = Expression.Parameter(typeof(CrmConversationStatusGroups), "m");
			crmConversationStatusGroups = Queryable.FirstOrDefault<CrmConversationStatusGroups>((IQueryable<CrmConversationStatusGroups>)crmConversationStatusGroups2, Expression.Lambda<Func<CrmConversationStatusGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmConversationStatusGroups == null)
			{
				crmConversationStatusGroups = new CrmConversationStatusGroups();
				crmConversationStatusGroups.ConversationStatusGroupID = 0;
				crmConversationStatusGroups.RegisterDate = now;
				crmConversationStatusGroups.FirstRegisterDate = now;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusGroups_Lang>)list, (Func<CrmConversationStatusGroups_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusGroups_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.ConversationStatusGroup,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmConversationStatusGroups.ConversationStatusGroup,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusGroups_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusGroups_Lang>)list, (Func<CrmConversationStatusGroups_Lang, CommonMultiLanguageViewModel>)((CrmConversationStatusGroups_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.ConversationStatusGroupDesc,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = crmConversationStatusGroups.ConversationStatusGroupDesc,
			LanguageId = result
		});
		CrmConversationStatusGroupLanguageViewModel model = new CrmConversationStatusGroupLanguageViewModel
		{
			AppType = crmConversationStatusGroups.AppType,
			LanguageID = crmConversationStatusGroups.LanguageID,
			UserId = crmConversationStatusGroups.UserId,
			GUId = crmConversationStatusGroups.GUId,
			FirstRegisterDate = crmConversationStatusGroups.FirstRegisterDate,
			RegisterDate = crmConversationStatusGroups.RegisterDate,
			RegisterDatePersian = crmConversationStatusGroups.RegisterDatePersian,
			Month1 = crmConversationStatusGroups.Month1,
			Year1 = crmConversationStatusGroups.Year1,
			FirstRegisterDatePersian = crmConversationStatusGroups.FirstRegisterDatePersian,
			FirstRegisterUserId = crmConversationStatusGroups.FirstRegisterUserId,
			ConversationStatusGroupID = crmConversationStatusGroups.ConversationStatusGroupID,
			FOCnvsReferUserId = crmConversationStatusGroups.FOCnvsReferUserId,
			FOCnvsReferMultiUser = crmConversationStatusGroups.FOCnvsReferMultiUser,
			ConversationStatusGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			ConversationStatusGroup_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			ConversationStatusGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			ConversationStatusGroupDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			NoRegCnvsOlderStatus = crmConversationStatusGroups.NoRegCnvsOlderStatus,
			DeActive = crmConversationStatusGroups.DeActive,
			ConversationStatusGroupColor = crmConversationStatusGroups.ConversationStatusGroupColor
		};
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefinecnvsStatusGroupDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmConversationStatusGroupLanguageViewModel model)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
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
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ConversationStatusGroup_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ConversationStatusGroup_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ConversationStatusGroup,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ConversationStatusGroupDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ConversationStatusGroupDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.ConversationStatusGroupDesc,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.model.ConversationStatusGroup == null)
			{
				text = text + Messages.CheckEmptyCnvsStatusGroup + "|";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.ConversationStatusGroup, list))
			{
				text = text + Messages.CheckCnvsStatusGroupLang + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					if (CS_0024_003C_003E8__locals0.model.ConversationStatusGroupID > 0)
					{
						DbSet<CrmConversationStatusGroups> crmConversationStatusGroups = _dbTbl.CrmConversationStatusGroups;
						ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusGroups), "m");
						CrmConversationStatusGroups crmConversationStatusGroups2 = Queryable.FirstOrDefault<CrmConversationStatusGroups>((IQueryable<CrmConversationStatusGroups>)crmConversationStatusGroups, Expression.Lambda<Func<CrmConversationStatusGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmConversationStatusGroups2 != null)
						{
							crmConversationStatusGroups2.UserId = UserLogin.CurrentUser.UserId;
							crmConversationStatusGroups2.RegisterDate = now;
							crmConversationStatusGroups2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmConversationStatusGroups2.AppType = Configuration.AppType;
							crmConversationStatusGroups2.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmConversationStatusGroups2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmConversationStatusGroups2.FOCnvsReferUserId = CS_0024_003C_003E8__locals0.model.FOCnvsReferUserId;
							crmConversationStatusGroups2.ConversationStatusGroup = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmConversationStatusGroups2.ConversationStatusGroupDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmConversationStatusGroups2.NoRegCnvsOlderStatus = CS_0024_003C_003E8__locals0.model.NoRegCnvsOlderStatus;
							crmConversationStatusGroups2.DeActive = CS_0024_003C_003E8__locals0.model.DeActive;
							crmConversationStatusGroups2.ConversationStatusGroupColor = CS_0024_003C_003E8__locals0.model.ConversationStatusGroupColor;
							_dbTbl.Entry(crmConversationStatusGroups2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmConversationStatusGroups_Lang> crmConversationStatusGroups_Lang = _dbTbl.CrmConversationStatusGroups_Lang;
									val = Expression.Parameter(typeof(CrmConversationStatusGroups_Lang), "c");
									CrmConversationStatusGroups_Lang crmConversationStatusGroups_Lang2 = Queryable.FirstOrDefault<CrmConversationStatusGroups_Lang>((IQueryable<CrmConversationStatusGroups_Lang>)crmConversationStatusGroups_Lang, Expression.Lambda<Func<CrmConversationStatusGroups_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmConversationStatusGroups_Lang2 != null)
									{
										crmConversationStatusGroups_Lang2.ConversationStatusGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										crmConversationStatusGroups_Lang2.ConversationStatusGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmConversationStatusGroups_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									CrmConversationStatusGroups_Lang entity = new CrmConversationStatusGroups_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										ConversationStatusGroupID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ConversationStatusGroupID,
										ConversationStatusGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										ConversationStatusGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmConversationStatusGroups_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusGroups");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						CrmConversationStatusGroups crmConversationStatusGroups3 = new CrmConversationStatusGroups();
						crmConversationStatusGroups3.UserId = UserLogin.CurrentUser.UserId;
						crmConversationStatusGroups3.RegisterDate = now;
						crmConversationStatusGroups3.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmConversationStatusGroups3.AppType = Configuration.AppType;
						crmConversationStatusGroups3.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmConversationStatusGroups3.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmConversationStatusGroups3.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						crmConversationStatusGroups3.FirstRegisterDate = now;
						crmConversationStatusGroups3.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmConversationStatusGroups3.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						crmConversationStatusGroups3.GUId = Guid.NewGuid();
						crmConversationStatusGroups3.FOCnvsReferUserId = CS_0024_003C_003E8__locals0.model.FOCnvsReferUserId;
						crmConversationStatusGroups3.ConversationStatusGroup = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmConversationStatusGroups3.ConversationStatusGroupDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmConversationStatusGroups3.NoRegCnvsOlderStatus = CS_0024_003C_003E8__locals0.model.NoRegCnvsOlderStatus;
						crmConversationStatusGroups3.DeActive = CS_0024_003C_003E8__locals0.model.DeActive;
						crmConversationStatusGroups3.ConversationStatusGroupColor = CS_0024_003C_003E8__locals0.model.ConversationStatusGroupColor;
						_dbTbl.CrmConversationStatusGroups.Add(crmConversationStatusGroups3);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmConversationStatusGroups_Lang entity2 = new CrmConversationStatusGroups_Lang
							{
								LanguageID = lang.LanguageID,
								ConversationStatusGroupID = crmConversationStatusGroups3.ConversationStatusGroupID,
								ConversationStatusGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
								ConversationStatusGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmConversationStatusGroups_Lang.Add(entity2);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusGroups");
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

	public List<CRMspSelectConversationStatusGroups_Result> ListCrmConversationStatusGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectConversationStatusGroups_Result> list = new List<CRMspSelectConversationStatusGroups_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>(Enumerable.Where<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result), (Func<CRMspSelectConversationStatusGroups_Result, bool>)((CRMspSelectConversationStatusGroups_Result m) => m.ConversationStatusGroupID > 0)));
			foreach (CRMspSelectConversationStatusGroups_Result item in list)
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
	public ActionResult ConversationStatusGroup_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListCrmConversationStatusGroups()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult CrmConversationStatusGroupsList()
	{
		return Json(ListCrmConversationStatusGroups(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefinecnvsStatusGroup", ActionName = "actDelete")]
	public string ActDelete(int sgroupId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.sgroupId = sgroupId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass8_.sgroupId > 0)
			{
				DbSet<CrmConversationStatusGroups> crmConversationStatusGroups = _dbTbl.CrmConversationStatusGroups;
				ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusGroups), "m");
				if (Queryable.FirstOrDefault<CrmConversationStatusGroups>((IQueryable<CrmConversationStatusGroups>)crmConversationStatusGroups, Expression.Lambda<Func<CrmConversationStatusGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						if (_db.CRMspDeleteCrmConversationStatusGroups(_003C_003Ec__DisplayClass8_.sgroupId) > 0)
						{
							DbSet<CrmConversationStatusGroups> crmConversationStatusGroups2 = _dbTbl.CrmConversationStatusGroups;
							val = Expression.Parameter(typeof(CrmConversationStatusGroups), "model");
							if (Queryable.FirstOrDefault<CrmConversationStatusGroups>((IQueryable<CrmConversationStatusGroups>)crmConversationStatusGroups2, Expression.Lambda<Func<CrmConversationStatusGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
							{
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusGroups");
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
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
			if (list2 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2))
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUsers_Result, SelectListItem>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.IsActive.GetValueOrDefault() && m.UserId > 0))), (Func<CRMspSelectUsers_Result, SelectListItem>)((CRMspSelectUsers_Result item) => new SelectListItem
				{
					Text = ((!string.IsNullOrWhiteSpace(item.LName)) ? item.LName : "") + ((!string.IsNullOrWhiteSpace(item.FName)) ? (" " + item.FName) : ""),
					Value = item.UserId.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefinecnvsStatusGroup", ActionName = "actSetCnvsReferMultiUser")]
	public ActionResult CnvsReferMultiUsers(int sgroupId, int fOCnvsReferUserId = 0, string fOCnvsReferMultiUser = "")
	{
		base.ViewBag.CnvsStatusGroupId = sgroupId;
		base.ViewBag.FOCnvsReferMultiUser = fOCnvsReferMultiUser;
		base.ViewBag.fOCnvsReferUserId = fOCnvsReferUserId;
		GetUsersList(sgroupId, fOCnvsReferUserId, fOCnvsReferMultiUser);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersList(int sgroupId, int fOCnvsReferUserId, string fOCnvsReferMultiUser = "")
	{
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
			if (list2 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2))
			{
				foreach (CRMspSelectUsers_Result item in (fOCnvsReferUserId > 0) ? Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.IsActive.GetValueOrDefault() && m.UserId > 0 && m.UserId != fOCnvsReferUserId))) : Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.IsActive.GetValueOrDefault() && m.UserId > 0))))
				{
					CommonMultiSelectorViewModel commonMultiSelectorViewModel = new CommonMultiSelectorViewModel();
					bool flag = false;
					if (!string.IsNullOrEmpty(fOCnvsReferMultiUser))
					{
						string[] array = fOCnvsReferMultiUser.Split(new char[1] { ',' });
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							string[] array2 = array;
							foreach (string text in array2)
							{
								if (!string.IsNullOrEmpty(text) && item.UserId == int.Parse(text))
								{
									flag = true;
								}
							}
						}
					}
					if (flag)
					{
						commonMultiSelectorViewModel.Name = ((!string.IsNullOrWhiteSpace(item.LName)) ? item.LName : "") + ((!string.IsNullOrWhiteSpace(item.FName)) ? (" " + item.FName) : "");
						commonMultiSelectorViewModel.Selected = true;
						commonMultiSelectorViewModel.Id = item.UserId;
					}
					else
					{
						commonMultiSelectorViewModel.Name = ((!string.IsNullOrEmpty(item.FName)) ? item.FName : "") + ((!string.IsNullOrEmpty(item.LName)) ? (" " + item.LName) : "");
						commonMultiSelectorViewModel.Selected = false;
						commonMultiSelectorViewModel.Id = item.UserId;
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
	public string SetCnvsReferMultiUser(int sgroupId, string fOCnvsReferMultiUser = "")
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
		_003C_003Ec__DisplayClass12_.sgroupId = sgroupId;
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
			if (_003C_003Ec__DisplayClass12_.sgroupId > 0)
			{
				_ = UserLogin.CurrentUser.UserId;
				short.Parse(Financial.Get().Id.ToString());
				short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime dateTime = now;
				dateTime.ToString("yyyyMMdd", new PersianCulture());
				_ = Configuration.AppType;
				DbSet<CrmConversationStatusGroups> crmConversationStatusGroups = _dbTbl.CrmConversationStatusGroups;
				ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusGroups), "m");
				CrmConversationStatusGroups crmConversationStatusGroups2 = Queryable.FirstOrDefault<CrmConversationStatusGroups>((IQueryable<CrmConversationStatusGroups>)crmConversationStatusGroups, Expression.Lambda<Func<CrmConversationStatusGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmConversationStatusGroups2 != null)
				{
					crmConversationStatusGroups2.FOCnvsReferMultiUser = fOCnvsReferMultiUser;
					_dbTbl.Entry(crmConversationStatusGroups2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusGroups");
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
