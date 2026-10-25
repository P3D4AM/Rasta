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

public class KnowledgeTankGroupController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int knlgTankGroupId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int defLangID;

		public KnowledgeTankGroupLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__2;

		public Func<Languages, bool> _003C_003E9__10;

		internal bool _003CInsertEdit_003Eb__0(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int knlgTankGroupId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmKnowledgeTankDataEntry", ActionName = "actDefineKnowledgeTankGroup")]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult InsertEdit(int knlgTankGroupId = 0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.knlgTankGroupId = knlgTankGroupId;
		DateTime now = DateTime.Now;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmKnowledgeTankGroup crmKnowledgeTankGroup = new CrmKnowledgeTankGroup();
		if (CS_0024_003C_003E8__locals0.knlgTankGroupId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			crmKnowledgeTankGroup = new CrmKnowledgeTankGroup();
			crmKnowledgeTankGroup.KnowledgeTankGroupId = 0;
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
			crmKnowledgeTankGroup = _dbTbl.CrmKnowledgeTankGroup.Find(CS_0024_003C_003E8__locals0.knlgTankGroupId);
			if (crmKnowledgeTankGroup == null)
			{
				crmKnowledgeTankGroup = new CrmKnowledgeTankGroup();
				crmKnowledgeTankGroup.KnowledgeTankGroupId = 0;
			}
		}
		DbSet<CrmKnowledgeTankGroup_Lang> crmKnowledgeTankGroup_Lang = _dbTbl.CrmKnowledgeTankGroup_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmKnowledgeTankGroup_Lang), "c");
		List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmKnowledgeTankGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmKnowledgeTankGroup_Lang>)Enumerable.ToList<CrmKnowledgeTankGroup_Lang>((IEnumerable<CrmKnowledgeTankGroup_Lang>)Queryable.Where<CrmKnowledgeTankGroup_Lang>((IQueryable<CrmKnowledgeTankGroup_Lang>)crmKnowledgeTankGroup_Lang, Expression.Lambda<Func<CrmKnowledgeTankGroup_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmKnowledgeTankGroup_Lang, CommonMultiLanguageViewModel>)((CrmKnowledgeTankGroup_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.KnowledgeTankGroupTitle,
			LanguageId = item.LanguageID
		})));
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = crmKnowledgeTankGroup.KnowledgeTankGroupTitle,
			LanguageId = result
		});
		KnowledgeTankGroupLanguageViewModel model = new KnowledgeTankGroupLanguageViewModel
		{
			LanguageID = result,
			AppType = Configuration.AppType,
			UserId = UserLogin.CurrentUser.UserId,
			RegisterDate = now,
			RegisterDatePersian = now.ToString("yyyyMMdd"),
			FirstRegisterDate = crmKnowledgeTankGroup.FirstRegisterDate,
			FirstRegisterDatePersian = crmKnowledgeTankGroup.FirstRegisterDatePersian,
			KnowledgeTankGroupId = crmKnowledgeTankGroup.KnowledgeTankGroupId,
			KnowledgeTankGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			KnowledgeTankGroupTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			KnowledgeTankGroupFOCmpCanSee = crmKnowledgeTankGroup.KnowledgeTankGroupFOCmpCanSee.GetValueOrDefault()
		};
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(KnowledgeTankGroupLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
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
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupTitle))
			{
				text = text + Messages.CheckEmptyKnlgTitle + "|";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupTitle, list))
			{
				text = text + Messages.CheckKnlgTitleLang + "<br>";
				num++;
			}
			try
			{
				if (num == 0)
				{
					if (CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupId > 0)
					{
						CrmKnowledgeTankGroup crmKnowledgeTankGroup = _dbTbl.CrmKnowledgeTankGroup.Find(CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupId);
						if (crmKnowledgeTankGroup != null)
						{
							crmKnowledgeTankGroup.UserId = UserLogin.CurrentUser.UserId;
							DateTime dateTime = (crmKnowledgeTankGroup.RegisterDate = DateTime.Now);
							crmKnowledgeTankGroup.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							crmKnowledgeTankGroup.AppType = Configuration.AppType;
							crmKnowledgeTankGroup.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmKnowledgeTankGroup.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
							crmKnowledgeTankGroup.KnowledgeTankGroupTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmKnowledgeTankGroup.KnowledgeTankGroupFOCmpCanSee = CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupFOCmpCanSee;
							_dbTbl.Entry(crmKnowledgeTankGroup).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmKnowledgeTankGroup_Lang> crmKnowledgeTankGroup_Lang = _dbTbl.CrmKnowledgeTankGroup_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmKnowledgeTankGroup_Lang), "c");
									CrmKnowledgeTankGroup_Lang crmKnowledgeTankGroup_Lang2 = Queryable.FirstOrDefault<CrmKnowledgeTankGroup_Lang>((IQueryable<CrmKnowledgeTankGroup_Lang>)crmKnowledgeTankGroup_Lang, Expression.Lambda<Func<CrmKnowledgeTankGroup_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmKnowledgeTankGroup_Lang2 != null)
									{
										crmKnowledgeTankGroup_Lang2.KnowledgeTankGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmKnowledgeTankGroup_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									CrmKnowledgeTankGroup_Lang entity = new CrmKnowledgeTankGroup_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										KnowledgeTankGroupId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.KnowledgeTankGroupId,
										KnowledgeTankGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmKnowledgeTankGroup_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmKnowledgeTankGroup");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						DateTime now2 = DateTime.Now;
						CrmKnowledgeTankGroup crmKnowledgeTankGroup2 = new CrmKnowledgeTankGroup
						{
							UserId = UserLogin.CurrentUser.UserId,
							FirstRegisterUserId = UserLogin.CurrentUser.UserId,
							FirstRegisterDate = now2,
							FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
							RegisterDate = now2,
							RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
							AppType = Configuration.AppType,
							Year1 = short.Parse(Financial.Get().Id.ToString()),
							Month1 = short.Parse(now2.ToString("MM", new PersianCulture())),
							GUId = Guid.NewGuid(),
							LanguageID = CS_0024_003C_003E8__locals0.defLangID,
							KnowledgeTankGroupTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
							KnowledgeTankGroupFOCmpCanSee = CS_0024_003C_003E8__locals0.model.KnowledgeTankGroupFOCmpCanSee
						};
						_dbTbl.CrmKnowledgeTankGroup.Add(crmKnowledgeTankGroup2);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmKnowledgeTankGroup_Lang entity2 = new CrmKnowledgeTankGroup_Lang
							{
								LanguageID = lang.LanguageID,
								KnowledgeTankGroupId = crmKnowledgeTankGroup2.KnowledgeTankGroupId,
								KnowledgeTankGroupTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmKnowledgeTankGroup_Lang.Add(entity2);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmKnowledgeTankGroup");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
			catch (DbEntityValidationException e)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
				text = Messages.frmErrorMessage;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				text = Messages.frmErrorMessage + "<br/>" + ex.Message;
			}
		}
		base.ViewBag.Error = text;
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

	public List<CRMspknlgSelectKnowledgeTankGroup_Result> ListKnowledgeTankGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspknlgSelectKnowledgeTankGroup_Result> list = new List<CRMspknlgSelectKnowledgeTankGroup_Result>();
		try
		{
			foreach (CRMspknlgSelectKnowledgeTankGroup_Result item in Enumerable.ToList<CRMspknlgSelectKnowledgeTankGroup_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)_db.CRMspknlgSelectKnowledgeTankGroup(0, lCID, result)))
			{
				CRMspknlgSelectKnowledgeTankGroup_Result cRMspknlgSelectKnowledgeTankGroup_Result = new CRMspknlgSelectKnowledgeTankGroup_Result();
				cRMspknlgSelectKnowledgeTankGroup_Result.KnowledgeTankGroupId = item.KnowledgeTankGroupId;
				cRMspknlgSelectKnowledgeTankGroup_Result.KnowledgeTankGroupTitle = item.KnowledgeTankGroupTitle;
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				cRMspknlgSelectKnowledgeTankGroup_Result.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspknlgSelectKnowledgeTankGroup_Result.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspknlgSelectKnowledgeTankGroup_Result.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + cRMspknlgSelectKnowledgeTankGroup_Result.AppType + ")  (" + text4 + ")";
				cRMspknlgSelectKnowledgeTankGroup_Result.KnowledgeTankGroupFOCmpCanSee = item.KnowledgeTankGroupFOCmpCanSee.GetValueOrDefault();
				list.Add(cRMspknlgSelectKnowledgeTankGroup_Result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult KnowledgeTankGroup_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListKnowledgeTankGroup()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult KnowledgeTankGroupList()
	{
		return Json(ListKnowledgeTankGroup(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string KnowledgeTankGroupDelete(int knlgTankGroupId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.knlgTankGroupId = knlgTankGroupId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass9_.knlgTankGroupId > 0)
			{
				if (_dbTbl.CrmKnowledgeTankGroup.Find(_003C_003Ec__DisplayClass9_.knlgTankGroupId) != null)
				{
					try
					{
						if (_db.CRMspDeleteCrmKnowledgeTankGroup(_003C_003Ec__DisplayClass9_.knlgTankGroupId) > 0)
						{
							DbSet<CrmKnowledgeTankGroup> crmKnowledgeTankGroup = _dbTbl.CrmKnowledgeTankGroup;
							ParameterExpression val = Expression.Parameter(typeof(CrmKnowledgeTankGroup), "model");
							if (Queryable.FirstOrDefault<CrmKnowledgeTankGroup>((IQueryable<CrmKnowledgeTankGroup>)crmKnowledgeTankGroup, Expression.Lambda<Func<CrmKnowledgeTankGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
							{
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmKnowledgeTankGroup");
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
