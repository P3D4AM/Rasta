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

public class FileDirectoryTypeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int fileDirectoryTypeId;

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

		public CrmFileDirectoryTypeLanguageViewModel model;

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
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int fileDirectoryTypeId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult Index(int position = 0, int typeOpr = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmMain";
			text2 = "actDefinecmpFileType";
			break;
		case 1:
			text = "frmFileDataEntry";
			text2 = "actDefineFileType";
			break;
		case 2:
			text = "frmDefineConversation";
			text2 = "actDefineFileType";
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
		string text3 = "";
		try
		{
			if (typeOpr != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMspSelectFileDirectoryTypeOpr_Result cRMspSelectFileDirectoryTypeOpr_Result = Enumerable.FirstOrDefault<CRMspSelectFileDirectoryTypeOpr_Result>((IEnumerable<CRMspSelectFileDirectoryTypeOpr_Result>)Enumerable.ToList<CRMspSelectFileDirectoryTypeOpr_Result>((IEnumerable<CRMspSelectFileDirectoryTypeOpr_Result>)_db.CRMspSelectFileDirectoryTypeOpr(lCID, result)), (Func<CRMspSelectFileDirectoryTypeOpr_Result, bool>)((CRMspSelectFileDirectoryTypeOpr_Result m) => m.FileDirectoryTypeOprId == typeOpr));
				text3 = ((cRMspSelectFileDirectoryTypeOpr_Result == null) ? "" : ((!string.IsNullOrEmpty(cRMspSelectFileDirectoryTypeOpr_Result.FileDirectoryTypeOpr)) ? cRMspSelectFileDirectoryTypeOpr_Result.FileDirectoryTypeOpr : ""));
			}
			else
			{
				text3 = "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TypeOpr = typeOpr;
		base.ViewBag.FileDirectoryTypeOpr = text3;
		return View();
	}

	public ActionResult InsertEdit(int typeOprId, int fileDirectoryTypeId = 0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.fileDirectoryTypeId = fileDirectoryTypeId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmFileDirectoryType_Lang> crmFileDirectoryType_Lang = _dbTbl.CrmFileDirectoryType_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmFileDirectoryType_Lang), "c");
		List<CrmFileDirectoryType_Lang> list = Enumerable.ToList<CrmFileDirectoryType_Lang>((IEnumerable<CrmFileDirectoryType_Lang>)Queryable.Where<CrmFileDirectoryType_Lang>((IQueryable<CrmFileDirectoryType_Lang>)crmFileDirectoryType_Lang, Expression.Lambda<Func<CrmFileDirectoryType_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		CrmFileDirectoryType crmFileDirectoryType = new CrmFileDirectoryType();
		if (CS_0024_003C_003E8__locals0.fileDirectoryTypeId == 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			crmFileDirectoryType = new CrmFileDirectoryType();
			crmFileDirectoryType.FileDirectoryTypeOprId = typeOprId;
			crmFileDirectoryType.FileDirectoryTypeID = 0;
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
			crmFileDirectoryType = _dbTbl.CrmFileDirectoryType.Find(CS_0024_003C_003E8__locals0.fileDirectoryTypeId);
			if (crmFileDirectoryType == null)
			{
				crmFileDirectoryType = new CrmFileDirectoryType();
				crmFileDirectoryType.FileDirectoryTypeOprId = typeOprId;
				crmFileDirectoryType.FileDirectoryTypeID = 0;
			}
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFileDirectoryType_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFileDirectoryType_Lang>)list, (Func<CrmFileDirectoryType_Lang, CommonMultiLanguageViewModel>)((CrmFileDirectoryType_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.FileDirectoryType,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = crmFileDirectoryType.FileDirectoryType,
			LanguageId = result
		});
		CrmFileDirectoryTypeLanguageViewModel model = new CrmFileDirectoryTypeLanguageViewModel
		{
			AppType = crmFileDirectoryType.AppType,
			LanguageID = crmFileDirectoryType.LanguageID,
			UserId = crmFileDirectoryType.UserId,
			GUId = crmFileDirectoryType.GUId,
			FirstRegisterDate = crmFileDirectoryType.FirstRegisterDate,
			RegisterDate = crmFileDirectoryType.RegisterDate,
			RegisterDatePersian = crmFileDirectoryType.RegisterDatePersian,
			Month1 = crmFileDirectoryType.Month1,
			Year1 = crmFileDirectoryType.Year1,
			FirstRegisterDatePersian = crmFileDirectoryType.FirstRegisterDatePersian,
			FirstRegisterUserId = crmFileDirectoryType.FirstRegisterUserId,
			FileDirectoryTypeOprId = crmFileDirectoryType.FileDirectoryTypeOprId,
			FileDirectoryTypeID = crmFileDirectoryType.FileDirectoryTypeID,
			OrderView = crmFileDirectoryType.OrderView,
			FileDirectoryType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			FileDirectoryType_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
		};
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmFileDirectoryTypeLanguageViewModel model)
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
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.FileDirectoryType_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.FileDirectoryType_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.FileDirectoryType,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.model.FileDirectoryType == null)
			{
				text = text + Messages.CheckEmptyFileDirectoryType + "|";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.FileDirectoryType, list))
			{
				text = text + Messages.CheckFileDirectoryTypeLang + "<br>";
				num++;
			}
			DateTime now = DateTime.Now;
			if (num == 0)
			{
				try
				{
					if (CS_0024_003C_003E8__locals0.model.FileDirectoryTypeID > 0)
					{
						CrmFileDirectoryType crmFileDirectoryType = _dbTbl.CrmFileDirectoryType.Find(CS_0024_003C_003E8__locals0.model.FileDirectoryTypeID);
						if (crmFileDirectoryType != null)
						{
							crmFileDirectoryType.UserId = UserLogin.CurrentUser.UserId;
							crmFileDirectoryType.RegisterDate = now;
							crmFileDirectoryType.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmFileDirectoryType.AppType = Configuration.AppType;
							crmFileDirectoryType.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmFileDirectoryType.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmFileDirectoryType.FileDirectoryType = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							_dbTbl.Entry(crmFileDirectoryType).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<CrmFileDirectoryType_Lang> crmFileDirectoryType_Lang = _dbTbl.CrmFileDirectoryType_Lang;
									ParameterExpression val = Expression.Parameter(typeof(CrmFileDirectoryType_Lang), "c");
									CrmFileDirectoryType_Lang crmFileDirectoryType_Lang2 = Queryable.FirstOrDefault<CrmFileDirectoryType_Lang>((IQueryable<CrmFileDirectoryType_Lang>)crmFileDirectoryType_Lang, Expression.Lambda<Func<CrmFileDirectoryType_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmFileDirectoryType_Lang2 != null)
									{
										crmFileDirectoryType_Lang2.FileDirectoryType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmFileDirectoryType_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									CrmFileDirectoryType_Lang entity = new CrmFileDirectoryType_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										FileDirectoryTypeID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FileDirectoryTypeID,
										FileDirectoryType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmFileDirectoryType_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFileDirectoryType");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						CrmFileDirectoryType crmFileDirectoryType2 = new CrmFileDirectoryType();
						crmFileDirectoryType2.UserId = UserLogin.CurrentUser.UserId;
						crmFileDirectoryType2.RegisterDate = now;
						crmFileDirectoryType2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFileDirectoryType2.AppType = Configuration.AppType;
						crmFileDirectoryType2.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmFileDirectoryType2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmFileDirectoryType2.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						crmFileDirectoryType2.FirstRegisterDate = now;
						crmFileDirectoryType2.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmFileDirectoryType2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						crmFileDirectoryType2.GUId = Guid.NewGuid();
						crmFileDirectoryType2.FileDirectoryTypeOprId = CS_0024_003C_003E8__locals0.model.FileDirectoryTypeOprId;
						crmFileDirectoryType2.FileDirectoryType = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_dbTbl.CrmFileDirectoryType.Add(crmFileDirectoryType2);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmFileDirectoryType_Lang entity2 = new CrmFileDirectoryType_Lang
							{
								LanguageID = lang.LanguageID,
								FileDirectoryTypeID = crmFileDirectoryType2.FileDirectoryTypeID,
								FileDirectoryType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmFileDirectoryType_Lang.Add(entity2);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFileDirectoryType");
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

	public List<CrmFileDirectoryTypeViewModel> ListFileDirectoryType(int typeOprId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmFileDirectoryTypeViewModel> list = new List<CrmFileDirectoryTypeViewModel>();
		try
		{
			if (typeOprId > 0)
			{
				foreach (CRMspSelectFileDirectoryTypeByOprId_Result item in Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>(Enumerable.Where<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)_db.CRMspSelectFileDirectoryTypeByOprId(typeOprId, lCID, result), (Func<CRMspSelectFileDirectoryTypeByOprId_Result, bool>)((CRMspSelectFileDirectoryTypeByOprId_Result m) => m.FileDirectoryTypeID > 0))))
				{
					CrmFileDirectoryTypeViewModel crmFileDirectoryTypeViewModel = new CrmFileDirectoryTypeViewModel();
					crmFileDirectoryTypeViewModel.FileDirectoryTypeID = item.FileDirectoryTypeID;
					crmFileDirectoryTypeViewModel.FileDirectoryType = item.FileDirectoryType;
					if (string.IsNullOrEmpty(item.AppType))
					{
						item.AppType = Configuration.AppType;
					}
					crmFileDirectoryTypeViewModel.AppType = Configuration.GetAppType(item.AppType);
					string text = item.FirstRegisterUser ?? "";
					string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					crmFileDirectoryTypeViewModel.FirstRegisterDatePersian = text + " (" + text2 + ")";
					string text3 = item.EditUser ?? "";
					string text4 = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					crmFileDirectoryTypeViewModel.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + crmFileDirectoryTypeViewModel.AppType + ")  (" + text4 + ")";
					list.Add(crmFileDirectoryTypeViewModel);
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
	public ActionResult FileDirectoryType_Read([DataSourceRequest] DataSourceRequest request, int typeOprId)
	{
		return Json(((IEnumerable)ListFileDirectoryType(typeOprId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult FileDirectoryTypeList(int typeOprId)
	{
		return Json(ListFileDirectoryType(typeOprId), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string FileDirectoryTypeDelete(int fileDirectoryTypeId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.fileDirectoryTypeId = fileDirectoryTypeId;
		string text = "";
		try
		{
			if (_003C_003Ec__DisplayClass8_.fileDirectoryTypeId > 0)
			{
				if (_dbTbl.CrmFileDirectoryType.Find(_003C_003Ec__DisplayClass8_.fileDirectoryTypeId) != null)
				{
					try
					{
						if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.CRMspDeleteCrmFileDirectoryType(_003C_003Ec__DisplayClass8_.fileDirectoryTypeId)).GetValueOrDefault() > 0)
						{
							DbSet<CrmFileDirectoryType> crmFileDirectoryType = _dbTbl.CrmFileDirectoryType;
							ParameterExpression val = Expression.Parameter(typeof(CrmFileDirectoryType), "model");
							if (Queryable.FirstOrDefault<CrmFileDirectoryType>((IQueryable<CrmFileDirectoryType>)crmFileDirectoryType, Expression.Lambda<Func<CrmFileDirectoryType, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null)
							{
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmFileDirectoryType");
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
				return Messages.msgErrorNotFoundFileDirectoryType;
			}
			return Messages.msgErrorNotFoundFileDirectoryType;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
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
