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

namespace CRMIdeal.Areas.Emails.Controllers;

public class DefaultBodyTextController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int defTextId;

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
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public EmailDefaultBodyTextLanguageViewModel vm;

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
		public EmailDefaultBodyText model;
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

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmMain";
			text2 = "actemEmailAddNewDefaultBodyText";
			break;
		case 1:
			text = "frmEmailSelectDefaultBodyText";
			text2 = "actAddNewDefaultBodyText";
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

	[AjaxOnly]
	public ActionResult EmailDefaultBodyText_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<EmailspSelectEmailDefaultBodyText_Result> list = new List<EmailspSelectEmailDefaultBodyText_Result>();
		try
		{
			list = Enumerable.ToList<EmailspSelectEmailDefaultBodyText_Result>((IEnumerable<EmailspSelectEmailDefaultBodyText_Result>)_db.EmailspSelectEmailDefaultBodyText(UserLogin.CurrentUser.UserId, lCID, result));
			foreach (EmailspSelectEmailDefaultBodyText_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmEmailDefaultBodyText", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int defTextId = 0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.defTextId = defTextId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		EmailDefaultBodyTextLanguageViewModel emailDefaultBodyTextLanguageViewModel = new EmailDefaultBodyTextLanguageViewModel();
		if (CS_0024_003C_003E8__locals0.defTextId > 0)
		{
			if (!UserLogin.IsUserAccess("frmEmailDefaultBodyText", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			new BaseInfo();
			DbSet<EmailDefaultBodyText_Lang> emailDefaultBodyText_Lang = _dbTbl.EmailDefaultBodyText_Lang;
			ParameterExpression val = Expression.Parameter(typeof(EmailDefaultBodyText_Lang), "c");
			List<EmailDefaultBodyText_Lang> list = Enumerable.ToList<EmailDefaultBodyText_Lang>((IEnumerable<EmailDefaultBodyText_Lang>)Queryable.Where<EmailDefaultBodyText_Lang>((IQueryable<EmailDefaultBodyText_Lang>)emailDefaultBodyText_Lang, Expression.Lambda<Func<EmailDefaultBodyText_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<EmailDefaultBodyText> emailDefaultBodyText = _dbTbl.EmailDefaultBodyText;
			val = Expression.Parameter(typeof(EmailDefaultBodyText), "c");
			EmailDefaultBodyText emailDefaultBodyText2 = Queryable.FirstOrDefault<EmailDefaultBodyText>((IQueryable<EmailDefaultBodyText>)emailDefaultBodyText, Expression.Lambda<Func<EmailDefaultBodyText, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (emailDefaultBodyText2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<EmailDefaultBodyText_Lang, CommonMultiLanguageViewModel>((IEnumerable<EmailDefaultBodyText_Lang>)list, (Func<EmailDefaultBodyText_Lang, CommonMultiLanguageViewModel>)((EmailDefaultBodyText_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Title,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = emailDefaultBodyText2.Title,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<EmailDefaultBodyText_Lang, CommonMultiLanguageViewModel>((IEnumerable<EmailDefaultBodyText_Lang>)list, (Func<EmailDefaultBodyText_Lang, CommonMultiLanguageViewModel>)((EmailDefaultBodyText_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Body,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = emailDefaultBodyText2.Body,
				LanguageId = result
			});
			emailDefaultBodyTextLanguageViewModel = new EmailDefaultBodyTextLanguageViewModel
			{
				EmailDefaultBodyTextId = emailDefaultBodyText2.EmailDefaultBodyTextId,
				Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Body = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Body_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmEmailDefaultBodyText", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			_ = DateTime.Now;
			emailDefaultBodyTextLanguageViewModel = new EmailDefaultBodyTextLanguageViewModel
			{
				EmailDefaultBodyTextId = 0
			};
		}
		return View(emailDefaultBodyTextLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmEmailDefaultBodyTextDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(EmailDefaultBodyTextLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Title_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Title,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Body_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Body_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Body,
			LanguageId = lCID
		});
		try
		{
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
				_ = CRMIdeal.Cache.Setting.Language.Get().Count;
				string text = "";
				int num = 0;
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Body))
				{
					text = text + string.Format(Messages.ErrorEmpty, Labels.EmailDefBodyText) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Body, list2))
				{
					text = text + string.Format(Messages.CheckFieldInLang, Labels.EmailDefBodyText) + "<br>";
					num++;
				}
				if (num > 0)
				{
					base.ViewBag.Error = text;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				_003C_003Ec__DisplayClass5_.model = new EmailDefaultBodyText();
				if (CS_0024_003C_003E8__locals0.vm.EmailDefaultBodyTextId > 0)
				{
					DbSet<EmailDefaultBodyText> emailDefaultBodyText = _dbTbl.EmailDefaultBodyText;
					ParameterExpression val = Expression.Parameter(typeof(EmailDefaultBodyText), "c");
					_003C_003Ec__DisplayClass5_.model = Queryable.FirstOrDefault<EmailDefaultBodyText>((IQueryable<EmailDefaultBodyText>)emailDefaultBodyText, Expression.Lambda<Func<EmailDefaultBodyText, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass5_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass5_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass5_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass5_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass5_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass5_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass5_.model.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass5_.model.Body = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				if (_003C_003Ec__DisplayClass5_.model.EmailDefaultBodyTextId > 0)
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
							DbSet<EmailDefaultBodyText_Lang> emailDefaultBodyText_Lang = _dbTbl.EmailDefaultBodyText_Lang;
							ParameterExpression val = Expression.Parameter(typeof(EmailDefaultBodyText_Lang), "c");
							EmailDefaultBodyText_Lang emailDefaultBodyText_Lang2 = Queryable.FirstOrDefault<EmailDefaultBodyText_Lang>((IQueryable<EmailDefaultBodyText_Lang>)emailDefaultBodyText_Lang, Expression.Lambda<Func<EmailDefaultBodyText_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (emailDefaultBodyText_Lang2 != null)
							{
								emailDefaultBodyText_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								emailDefaultBodyText_Lang2.Body = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(emailDefaultBodyText_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							emailDefaultBodyText_Lang2 = new EmailDefaultBodyText_Lang();
							emailDefaultBodyText_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							emailDefaultBodyText_Lang2.EmailDefaultBodyTextId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.EmailDefaultBodyTextId;
							emailDefaultBodyText_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							emailDefaultBodyText_Lang2.Body = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.EmailDefaultBodyText_Lang.Add(emailDefaultBodyText_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass5_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass5_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass5_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass5_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass5_.model.GUId = Guid.NewGuid();
					_dbTbl.EmailDefaultBodyText.Add(_003C_003Ec__DisplayClass5_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						EmailDefaultBodyText_Lang emailDefaultBodyText_Lang3 = new EmailDefaultBodyText_Lang();
						emailDefaultBodyText_Lang3.LanguageID = lang.LanguageID;
						emailDefaultBodyText_Lang3.EmailDefaultBodyTextId = _003C_003Ec__DisplayClass5_.model.EmailDefaultBodyTextId;
						emailDefaultBodyText_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						emailDefaultBodyText_Lang3.Body = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.EmailDefaultBodyText_Lang.Add(emailDefaultBodyText_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.EmailDefaultBodyTextId = _003C_003Ec__DisplayClass5_.model.EmailDefaultBodyTextId;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
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
	[DynamicAuthorize(ControllerName = "frmEmailDefaultBodyText", ActionName = "actDelete")]
	public string ActDelete(int defTextId)
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
			if (!UserLogin.IsUserAccess("frmEmailDefaultBodyText", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (defTextId > 0)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.EmailspDeleteEmailDefaultBodyText(defTextId));
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
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult Select(int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmGenerateAutoCmpUP";
			text2 = "actSelectDefaultBodyText";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			return View();
		case -1:
			return View();
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
