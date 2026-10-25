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
using CRM.General.Utilities;
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

public class FooterController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int footerId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public CrmCmsFooterLanguageViewModel vm;

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
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CrmCmsFooter model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1;

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
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int footerId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsManageFooter")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsManageFooter")]
	public JsonResult GetFooter(int footerCurrentId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentFooterViewModel currentFooterViewModel = new CurrentFooterViewModel();
		try
		{
			List<CRMspCmsSelectFooter_Result> list = Enumerable.ToList<CRMspCmsSelectFooter_Result>((IEnumerable<CRMspCmsSelectFooter_Result>)_db.CRMspCmsSelectFooter(0, lCID, result));
			if (Enumerable.Any<CRMspCmsSelectFooter_Result>((IEnumerable<CRMspCmsSelectFooter_Result>)list))
			{
				currentFooterViewModel.IsFind = true;
				currentFooterViewModel.Message = "";
				currentFooterViewModel.FooterNextId = -1;
				currentFooterViewModel.FooterPreviousId = -1;
				currentFooterViewModel.FooterFirstId = -1;
				currentFooterViewModel.FooterLastId = -1;
				if (list.Count == 1)
				{
					currentFooterViewModel.FooterFirstId = -1;
					currentFooterViewModel.FooterLastId = -1;
				}
				else
				{
					currentFooterViewModel.FooterFirstId = Enumerable.FirstOrDefault<CRMspCmsSelectFooter_Result>((IEnumerable<CRMspCmsSelectFooter_Result>)list).FooterId;
					currentFooterViewModel.FooterLastId = Enumerable.LastOrDefault<CRMspCmsSelectFooter_Result>((IEnumerable<CRMspCmsSelectFooter_Result>)list).FooterId;
				}
				CRMspCmsSelectFooter_Result cRMspCmsSelectFooter_Result = ((footerCurrentId <= 0) ? Enumerable.LastOrDefault<CRMspCmsSelectFooter_Result>((IEnumerable<CRMspCmsSelectFooter_Result>)list) : list.Find((CRMspCmsSelectFooter_Result c) => c.FooterId == footerCurrentId));
				if (cRMspCmsSelectFooter_Result != null)
				{
					_ = cRMspCmsSelectFooter_Result.FirstRegisterDate;
					cRMspCmsSelectFooter_Result.FirstRegisterDatePersian = cRMspCmsSelectFooter_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					cRMspCmsSelectFooter_Result.FirstRegisterUser += ((!string.IsNullOrEmpty(cRMspCmsSelectFooter_Result.FirstRegisterDatePersian)) ? (" (" + cRMspCmsSelectFooter_Result.FirstRegisterDatePersian + ")") : "");
					_ = cRMspCmsSelectFooter_Result.RegisterDate;
					cRMspCmsSelectFooter_Result.RegisterDatePersian = cRMspCmsSelectFooter_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					if (string.IsNullOrEmpty(cRMspCmsSelectFooter_Result.AppType))
					{
						cRMspCmsSelectFooter_Result.AppType = Configuration.AppType;
					}
					cRMspCmsSelectFooter_Result.AppType = Configuration.GetAppType(cRMspCmsSelectFooter_Result.AppType);
					cRMspCmsSelectFooter_Result.EditUser = cRMspCmsSelectFooter_Result.EditUser + "(" + Labels.AppType + ":" + cRMspCmsSelectFooter_Result.AppType + ")" + ((!string.IsNullOrEmpty(cRMspCmsSelectFooter_Result.RegisterDatePersian)) ? (" (" + cRMspCmsSelectFooter_Result.RegisterDatePersian + ")") : "");
					currentFooterViewModel.Footer = cRMspCmsSelectFooter_Result;
					currentFooterViewModel.FooterCurrentId = cRMspCmsSelectFooter_Result.FooterId;
					if (list.Count == 1)
					{
						currentFooterViewModel.FooterNextId = -1;
						currentFooterViewModel.FooterPreviousId = -1;
					}
					else
					{
						CRMspCmsSelectFooter_Result next = Lists.GetNext(list, cRMspCmsSelectFooter_Result);
						if (next != null)
						{
							currentFooterViewModel.FooterNextId = next.FooterId;
						}
						CRMspCmsSelectFooter_Result previous = Lists.GetPrevious(list, cRMspCmsSelectFooter_Result);
						if (previous != null)
						{
							currentFooterViewModel.FooterPreviousId = previous.FooterId;
						}
					}
				}
				else
				{
					currentFooterViewModel.IsFind = false;
					currentFooterViewModel.Message = Messages.ErrorNotFound;
					currentFooterViewModel.Footer = null;
					currentFooterViewModel.FooterCurrentId = -1;
					currentFooterViewModel.FooterNextId = -1;
					currentFooterViewModel.FooterPreviousId = -1;
					currentFooterViewModel.FooterFirstId = -1;
					currentFooterViewModel.FooterLastId = -1;
				}
			}
			else
			{
				currentFooterViewModel.IsFind = false;
				currentFooterViewModel.Message = Messages.ErrorNotFound;
				currentFooterViewModel.Footer = null;
				currentFooterViewModel.FooterCurrentId = -1;
				currentFooterViewModel.FooterNextId = -1;
				currentFooterViewModel.FooterPreviousId = -1;
				currentFooterViewModel.FooterFirstId = -1;
				currentFooterViewModel.FooterLastId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentFooterViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentFooterViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentFooterViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmCmsManageFooter", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int footerId = 0)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.footerId = footerId;
		CrmCmsFooterLanguageViewModel model = new CrmCmsFooterLanguageViewModel();
		try
		{
			CrmCmsFooter crmCmsFooter = new CrmCmsFooter();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass4_.footerId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsManageFooter", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsFooter_Lang> crmCmsFooter_Lang = _dbTbl.CrmCmsFooter_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsFooter_Lang), "c");
				List<CrmCmsFooter_Lang> list = Enumerable.ToList<CrmCmsFooter_Lang>((IEnumerable<CrmCmsFooter_Lang>)Queryable.Where<CrmCmsFooter_Lang>((IQueryable<CrmCmsFooter_Lang>)crmCmsFooter_Lang, Expression.Lambda<Func<CrmCmsFooter_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsFooter> crmCmsFooter2 = _dbTbl.CrmCmsFooter;
				val = Expression.Parameter(typeof(CrmCmsFooter), "c");
				crmCmsFooter = Queryable.FirstOrDefault<CrmCmsFooter>((IQueryable<CrmCmsFooter>)crmCmsFooter2, Expression.Lambda<Func<CrmCmsFooter, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsFooter == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsFooter_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsFooter_Lang>)list, (Func<CrmCmsFooter_Lang, CommonMultiLanguageViewModel>)((CrmCmsFooter_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FooterBody,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsFooter.FooterBody,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsFooter_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsFooter_Lang>)list, (Func<CrmCmsFooter_Lang, CommonMultiLanguageViewModel>)((CrmCmsFooter_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FooterTitle,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsFooter.FooterTitle,
					LanguageId = result
				});
				model = new CrmCmsFooterLanguageViewModel
				{
					FooterId = crmCmsFooter.FooterId,
					FooterBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					FooterBody_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					FooterTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					FooterTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					FooterStyle = crmCmsFooter.FooterStyle,
					FooterScript = crmCmsFooter.FooterScript,
					IsActive = crmCmsFooter.IsActive,
					FooterSystemPartIds = crmCmsFooter.FooterSystemPartIds
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsManageFooter", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				_ = DateTime.Now;
				model = new CrmCmsFooterLanguageViewModel
				{
					IsActive = true
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsManageFooterDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsFooterLanguageViewModel vm)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
			_003C_003Ec__DisplayClass5_.model = new CrmCmsFooter();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FooterBody_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FooterBody_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.FooterBody,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FooterTitle_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FooterTitle_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.FooterTitle,
				LanguageId = lCID
			});
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FooterTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsFooterTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.FooterTitle, list2))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsFooterTitle) + "<br>";
				num++;
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FooterBody))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CmsFooterBody) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.FooterBody, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CmsFooterBody) + "<br>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass5_.model = new CrmCmsFooter();
				if (CS_0024_003C_003E8__locals0.vm.FooterId > 0)
				{
					DbSet<CrmCmsFooter> crmCmsFooter = _dbTbl.CrmCmsFooter;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsFooter), "c");
					_003C_003Ec__DisplayClass5_.model = Queryable.FirstOrDefault<CrmCmsFooter>((IQueryable<CrmCmsFooter>)crmCmsFooter, Expression.Lambda<Func<CrmCmsFooter, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass5_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass5_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass5_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass5_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass5_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass5_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass5_.model.FooterBody = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass5_.model.FooterTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass5_.model.FooterStyle = CS_0024_003C_003E8__locals0.vm.FooterStyle;
				_003C_003Ec__DisplayClass5_.model.FooterScript = CS_0024_003C_003E8__locals0.vm.FooterScript;
				_003C_003Ec__DisplayClass5_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass5_.model.FooterSystemPartIds = CS_0024_003C_003E8__locals0.vm.FooterSystemPartIds;
				if (_003C_003Ec__DisplayClass5_.model.FooterId > 0)
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
							DbSet<CrmCmsFooter_Lang> crmCmsFooter_Lang = _dbTbl.CrmCmsFooter_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsFooter_Lang), "c");
							CrmCmsFooter_Lang crmCmsFooter_Lang2 = Queryable.FirstOrDefault<CrmCmsFooter_Lang>((IQueryable<CrmCmsFooter_Lang>)crmCmsFooter_Lang, Expression.Lambda<Func<CrmCmsFooter_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsFooter_Lang2 != null)
							{
								crmCmsFooter_Lang2.FooterBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmCmsFooter_Lang2.FooterTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsFooter_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsFooter_Lang2 = new CrmCmsFooter_Lang();
							crmCmsFooter_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsFooter_Lang2.FooterId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FooterId;
							crmCmsFooter_Lang2.FooterBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsFooter_Lang2.FooterTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsFooter_Lang.Add(crmCmsFooter_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass5_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass5_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass5_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass5_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass5_.model.GUId = System.Guid.NewGuid();
					_dbTbl.CrmCmsFooter.Add(_003C_003Ec__DisplayClass5_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsFooter_Lang crmCmsFooter_Lang3 = new CrmCmsFooter_Lang();
						crmCmsFooter_Lang3.LanguageID = lang.LanguageID;
						crmCmsFooter_Lang3.FooterId = _003C_003Ec__DisplayClass5_.model.FooterId;
						crmCmsFooter_Lang3.FooterBody = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmCmsFooter_Lang3.FooterTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsFooter_Lang.Add(crmCmsFooter_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.FooterId = _003C_003Ec__DisplayClass5_.model.FooterId;
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
						if (list != null)
						{
							Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				base.ViewBag.Successfull = text;
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
	[DynamicAuthorize(ControllerName = "frmCmsManageFooter", ActionName = "actDelete")]
	public string DeleteFooter(int footerId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.footerId = footerId;
		string result = "";
		try
		{
			DbSet<CrmCmsFooter> crmCmsFooter = _dbTbl.CrmCmsFooter;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsFooter), "c");
			if (Queryable.FirstOrDefault<CrmCmsFooter>((IQueryable<CrmCmsFooter>)crmCmsFooter, Expression.Lambda<Func<CrmCmsFooter, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteFooter(_003C_003Ec__DisplayClass7_.footerId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
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
			result = Messages.frmErrorMessage;
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
