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

public class LetterNumberCounterController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public SecLetterNumberCounterLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__9;

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

		internal bool _003CInsertEdit_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public SecLetterNumberCounter model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1;

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
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int letterNumberCounterId;

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

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmSendLetterDataEntry";
			text2 = "actDefineLetterNumberCounter";
			break;
		case 2:
			text = "frmReceiveLetterDataEntry";
			text2 = "actDefineLetterNumberCounter";
			break;
		case 3:
			text = "frmSendLetterDefaultSetting";
			text2 = "actDefineLetterNumberCounter";
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

	public List<SecspSelectLetterNumberCounter_Result> ListLetterNumberCounter()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SecspSelectLetterNumberCounter_Result> list = new List<SecspSelectLetterNumberCounter_Result>();
		try
		{
			list = Enumerable.ToList<SecspSelectLetterNumberCounter_Result>((IEnumerable<SecspSelectLetterNumberCounter_Result>)_dbI.SecspSelectLetterNumberCounter(lCID, result));
			foreach (SecspSelectLetterNumberCounter_Result item in list)
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
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult LetterNumberCounter_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListLetterNumberCounter()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult LetterNumberCounterList()
	{
		return Json(ListLetterNumberCounter(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActDelete(int letterNumberCounterId)
	{
		string result = "";
		try
		{
			if (letterNumberCounterId > 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.SecspDeleteLetterNumberCounter(letterNumberCounterId));
					if (mct_I_Result != null && mct_I_Result.Result > 0)
					{
						result = "1";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("SecLetterNumberCounter");
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
	public JsonResult GetLetterTypes()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<SecspSelectLetterTypes_Result, SelectListItem>((IEnumerable<SecspSelectLetterTypes_Result>)Enumerable.ToList<SecspSelectLetterTypes_Result>((IEnumerable<SecspSelectLetterTypes_Result>)_db.SecspSelectLetterTypes(lCID, result)), (Func<SecspSelectLetterTypes_Result, SelectListItem>)((SecspSelectLetterTypes_Result item) => new SelectListItem
			{
				Text = item.LetterTypeTitle,
				Value = item.LetterTypeId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LetterTypesList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int letterNumberCounterId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.letterNumberCounterId = letterNumberCounterId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<SecLetterNumberCounter_Lang> secLetterNumberCounter_Lang = _dbTbl.SecLetterNumberCounter_Lang;
		ParameterExpression val = Expression.Parameter(typeof(SecLetterNumberCounter_Lang), "c");
		List<SecLetterNumberCounter_Lang> list = Enumerable.ToList<SecLetterNumberCounter_Lang>((IEnumerable<SecLetterNumberCounter_Lang>)Queryable.Where<SecLetterNumberCounter_Lang>((IQueryable<SecLetterNumberCounter_Lang>)secLetterNumberCounter_Lang, Expression.Lambda<Func<SecLetterNumberCounter_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetLetterTypes();
		SecLetterNumberCounterLanguageViewModel model = new SecLetterNumberCounterLanguageViewModel();
		_ = DateTime.Now;
		SecLetterNumberCounter secLetterNumberCounter = new SecLetterNumberCounter();
		try
		{
			if (CS_0024_003C_003E8__locals0.letterNumberCounterId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				secLetterNumberCounter = new SecLetterNumberCounter();
				secLetterNumberCounter.LetterNumberCounterId = 0;
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
				DbSet<SecLetterNumberCounter> secLetterNumberCounter2 = _dbTbl.SecLetterNumberCounter;
				val = Expression.Parameter(typeof(SecLetterNumberCounter), "m");
				secLetterNumberCounter = Queryable.FirstOrDefault<SecLetterNumberCounter>((IQueryable<SecLetterNumberCounter>)secLetterNumberCounter2, Expression.Lambda<Func<SecLetterNumberCounter, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (secLetterNumberCounter == null)
				{
					secLetterNumberCounter = new SecLetterNumberCounter();
					secLetterNumberCounter.LetterNumberCounterId = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SecLetterNumberCounter_Lang, CommonMultiLanguageViewModel>((IEnumerable<SecLetterNumberCounter_Lang>)list, (Func<SecLetterNumberCounter_Lang, CommonMultiLanguageViewModel>)((SecLetterNumberCounter_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.LtrNumCntTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = secLetterNumberCounter.LtrNumCntTitle,
				LanguageId = result
			});
			model = new SecLetterNumberCounterLanguageViewModel
			{
				LetterNumberCounterId = secLetterNumberCounter.LetterNumberCounterId,
				LetterTypeId = secLetterNumberCounter.LetterTypeId,
				LtrNumCntTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				LtrNumCntTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				LtrNumCntBeginner = secLetterNumberCounter.LtrNumCntBeginner,
				LtrNumCntPreNumber = secLetterNumberCounter.LtrNumCntPreNumber
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
	public ActionResult InsertEdit(SecLetterNumberCounterLanguageViewModel vm)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetLetterTypes();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LtrNumCntTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LtrNumCntTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.LtrNumCntTitle,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.vm.LtrNumCntTitle == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.LtrNumCntTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.LtrNumCntTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.LtrNumCntTitle) + "<br>";
				num++;
			}
			if (num == 0)
			{
				_ = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
					_003C_003Ec__DisplayClass10_.model = new SecLetterNumberCounter();
					if (CS_0024_003C_003E8__locals0.vm.LetterNumberCounterId > 0)
					{
						DbSet<SecLetterNumberCounter> secLetterNumberCounter = _dbTbl.SecLetterNumberCounter;
						ParameterExpression val = Expression.Parameter(typeof(SecLetterNumberCounter), "c");
						_003C_003Ec__DisplayClass10_.model = Queryable.FirstOrDefault<SecLetterNumberCounter>((IQueryable<SecLetterNumberCounter>)secLetterNumberCounter, Expression.Lambda<Func<SecLetterNumberCounter, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass10_.model.UserId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass10_.model.RegisterDate = now;
					_003C_003Ec__DisplayClass10_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass10_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass10_.model.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass10_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass10_.model.LetterTypeId = CS_0024_003C_003E8__locals0.vm.LetterTypeId;
					_003C_003Ec__DisplayClass10_.model.LtrNumCntTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass10_.model.LtrNumCntBeginner = CS_0024_003C_003E8__locals0.vm.LtrNumCntBeginner;
					_003C_003Ec__DisplayClass10_.model.LtrNumCntPreNumber = CS_0024_003C_003E8__locals0.vm.LtrNumCntPreNumber;
					if (_003C_003Ec__DisplayClass10_.model.LetterNumberCounterId > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass10_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<SecLetterNumberCounter_Lang> secLetterNumberCounter_Lang = _dbTbl.SecLetterNumberCounter_Lang;
								ParameterExpression val = Expression.Parameter(typeof(SecLetterNumberCounter_Lang), "c");
								SecLetterNumberCounter_Lang secLetterNumberCounter_Lang2 = Queryable.FirstOrDefault<SecLetterNumberCounter_Lang>((IQueryable<SecLetterNumberCounter_Lang>)secLetterNumberCounter_Lang, Expression.Lambda<Func<SecLetterNumberCounter_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (secLetterNumberCounter_Lang2 != null)
								{
									secLetterNumberCounter_Lang2.LtrNumCntTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(secLetterNumberCounter_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								secLetterNumberCounter_Lang2 = new SecLetterNumberCounter_Lang();
								secLetterNumberCounter_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								secLetterNumberCounter_Lang2.LetterNumberCounterId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.LetterNumberCounterId;
								secLetterNumberCounter_Lang2.LtrNumCntTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.SecLetterNumberCounter_Lang.Add(secLetterNumberCounter_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("SecLetterNumberCounter");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass10_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass10_.model.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass10_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass10_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass10_.model.GUId = Guid.NewGuid();
						_dbTbl.SecLetterNumberCounter.Add(_003C_003Ec__DisplayClass10_.model);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							SecLetterNumberCounter_Lang secLetterNumberCounter_Lang3 = new SecLetterNumberCounter_Lang();
							secLetterNumberCounter_Lang3.LanguageID = lang.LanguageID;
							secLetterNumberCounter_Lang3.LetterNumberCounterId = _003C_003Ec__DisplayClass10_.model.LetterNumberCounterId;
							secLetterNumberCounter_Lang3.LtrNumCntTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.SecLetterNumberCounter_Lang.Add(secLetterNumberCounter_Lang3);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("SecLetterNumberCounter");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					CS_0024_003C_003E8__locals0.vm.LetterNumberCounterId = _003C_003Ec__DisplayClass10_.model.LetterNumberCounterId;
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
