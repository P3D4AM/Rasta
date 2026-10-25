using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Survey.Controllers;

public class CategoryController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_1
	{
		public CRMspSelectSurveyAnswerCategoryDetailsWithId_Result sp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public CrmSurveyAnswerCategoryDetails findedRecord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals1;

		internal bool _003CCategoryDetailInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCategoryDetailInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCategoryDetailInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCategoryDetailInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CRMspSelectSurveyAnswerCategoryWithId_Result sp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CrmSurveyAnswerCategory findedRecord;
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

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actDefineSurveyAnswerCategory")]
	public ActionResult Index(int surveyId = 0, string surveyName = "", int questionId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		if (string.IsNullOrWhiteSpace(surveyName) && surveyId > 0)
		{
			CRMspSelectSurveyWithId_Result cRMspSelectSurveyWithId_Result = SelectSurveyWithId(surveyId);
			if (cRMspSelectSurveyWithId_Result != null)
			{
				surveyName = cRMspSelectSurveyWithId_Result.surTitle;
			}
		}
		base.ViewBag.SurveyName = surveyName;
		base.ViewBag.SurveyId = surveyId;
		base.ViewBag.QuestionId = questionId;
		return View();
	}

	public ActionResult SurveyAnswerCategory_Read([DataSourceRequest] DataSourceRequest request, int questionId = 0)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectSurveyAnswerCategory(questionId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategory", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int surveyId = 0, int questionId = 0, int categoryId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		SurveyAnswerCategoryViewModel surveyAnswerCategoryViewModel = new SurveyAnswerCategoryViewModel();
		if (categoryId > 0)
		{
			_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
			_003C_003Ec__DisplayClass4_.sp = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryWithId_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryWithId_Result>)_db.CRMspSelectSurveyAnswerCategoryWithId(categoryId, result, result));
			if (_003C_003Ec__DisplayClass4_.sp != null)
			{
				DbSet<CrmSurveyAnswerCategory_Lang> crmSurveyAnswerCategory_Lang = _dbTbl.CrmSurveyAnswerCategory_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswerCategory_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurveyAnswerCategory_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurveyAnswerCategory_Lang>)Enumerable.ToList<CrmSurveyAnswerCategory_Lang>((IEnumerable<CrmSurveyAnswerCategory_Lang>)Queryable.Where<CrmSurveyAnswerCategory_Lang>((IQueryable<CrmSurveyAnswerCategory_Lang>)crmSurveyAnswerCategory_Lang, Expression.Lambda<Func<CrmSurveyAnswerCategory_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmSurveyAnswerCategory_Lang, CommonMultiLanguageViewModel>)((CrmSurveyAnswerCategory_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SurveyAnswerCategoryTitle,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass4_.sp.SurveyAnswerCategoryTitle,
					LanguageId = result
				});
				surveyAnswerCategoryViewModel.SurveyAnswerCategoryId = _003C_003Ec__DisplayClass4_.sp.SurveyAnswerCategoryId;
				surveyAnswerCategoryViewModel.SurveyAnswerCategoryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveyAnswerCategoryViewModel.SurveyAnswerCategoryTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveyAnswerCategoryViewModel.SurveyAnswerCategorySurveyId = _003C_003Ec__DisplayClass4_.sp.SurveyAnswerCategorySurveyId;
				surveyAnswerCategoryViewModel.SurveyAnswerCategorySurvey = _003C_003Ec__DisplayClass4_.sp.SurveyAnswerCategorySurvey;
				surveyAnswerCategoryViewModel.SurveyAnswerCategoryQuestionId = _003C_003Ec__DisplayClass4_.sp.SurveyAnswerCategoryQuestionId;
				surveyAnswerCategoryViewModel.SurveyAnswerCategoryQuestion = _003C_003Ec__DisplayClass4_.sp.SurveyAnswerCategoryQuestion;
				surveyAnswerCategoryViewModel.OrderView = _003C_003Ec__DisplayClass4_.sp.OrderView;
			}
		}
		else
		{
			surveyAnswerCategoryViewModel.SurveyAnswerCategorySurveyId = surveyId;
			surveyAnswerCategoryViewModel.SurveyAnswerCategoryQuestionId = questionId;
		}
		if (!surveyAnswerCategoryViewModel.OrderView.HasValue || surveyAnswerCategoryViewModel.OrderView <= 0)
		{
			List<CRMspSelectSurveyAnswerCategory_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(surveyAnswerCategoryViewModel.SurveyAnswerCategoryQuestionId, currLangID, result));
			_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswerCategory_Result, int?>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list2, (Func<CRMspSelectSurveyAnswerCategory_Result, int?>)((CRMspSelectSurveyAnswerCategory_Result m) => m.OrderView)))?.OrderView;
			int num = (Enumerable.Any<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list2) : 0);
			surveyAnswerCategoryViewModel.OrderView = num + 10 + num * 9 - 5;
		}
		base.ViewBag.lstSurveys = SelectSurveyListItem(currLangID, result);
		base.ViewBag.lstQuestions = SelectSurveyQuestionsListItem(surveyAnswerCategoryViewModel.SurveyAnswerCategorySurveyId);
		return View(surveyAnswerCategoryViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategoryDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(SurveyAnswerCategoryViewModel vm)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short year = short.Parse(Financial.Get().Id.ToString());
		short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			if (!string.IsNullOrEmpty(vm.SurveyAnswerCategoryTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.SurveyAnswerCategoryTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.SurveyAnswerCategoryTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(vm.SurveyAnswerCategoryTitle))
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.SurveyAnswerCategoryTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(vm.SurveyAnswerCategoryTitle, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.SurveyAnswerCategoryTitle) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				base.ViewBag.lstSurveys = SelectSurveyListItem(lCID, defLangID);
				base.ViewBag.lstQuestions = SelectSurveyQuestionsListItem(vm.SurveyAnswerCategorySurveyId);
				return View(vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
				_003C_003Ec__DisplayClass5_.findedRecord = _dbTbl.CrmSurveyAnswerCategory.Find(vm.SurveyAnswerCategoryId);
				if (_003C_003Ec__DisplayClass5_.findedRecord != null)
				{
					_003C_003Ec__DisplayClass5_.findedRecord.SurveyAnswerCategoryTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass5_.findedRecord.SurveyAnswerCategorySurveyId = vm.SurveyAnswerCategorySurveyId;
					_003C_003Ec__DisplayClass5_.findedRecord.SurveyAnswerCategoryQuestionId = vm.SurveyAnswerCategoryQuestionId;
					if (!_003C_003Ec__DisplayClass5_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass5_.findedRecord.OrderView <= 0)
					{
						List<CRMspSelectSurveyAnswerCategory_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(vm.SurveyAnswerCategoryQuestionId, lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswerCategory_Result, int?>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list2, (Func<CRMspSelectSurveyAnswerCategory_Result, int?>)((CRMspSelectSurveyAnswerCategory_Result m) => m.OrderView)))?.OrderView;
						int num = (Enumerable.Any<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list2) : 0);
						_003C_003Ec__DisplayClass5_.findedRecord.OrderView = num + 10 + num * 9 - 5;
					}
					else if (vm.OrderView > 0)
					{
						_003C_003Ec__DisplayClass5_.findedRecord.OrderView = vm.OrderView;
					}
					_003C_003Ec__DisplayClass5_.findedRecord.Month1 = month;
					_003C_003Ec__DisplayClass5_.findedRecord.UserId = userId;
					_003C_003Ec__DisplayClass5_.findedRecord.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass5_.findedRecord.RegisterDatePersian = text;
					_003C_003Ec__DisplayClass5_.findedRecord.AppType = appType;
					_dbTbl.Entry(_003C_003Ec__DisplayClass5_.findedRecord).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass5_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmSurveyAnswerCategory_Lang> crmSurveyAnswerCategory_Lang = _dbTbl.CrmSurveyAnswerCategory_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswerCategory_Lang), "c");
							CrmSurveyAnswerCategory_Lang crmSurveyAnswerCategory_Lang2 = Queryable.FirstOrDefault<CrmSurveyAnswerCategory_Lang>((IQueryable<CrmSurveyAnswerCategory_Lang>)crmSurveyAnswerCategory_Lang, Expression.Lambda<Func<CrmSurveyAnswerCategory_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmSurveyAnswerCategory_Lang2 != null)
							{
								crmSurveyAnswerCategory_Lang2.SurveyAnswerCategoryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmSurveyAnswerCategory_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmSurveyAnswerCategory_Lang2 = new CrmSurveyAnswerCategory_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								SurveyAnswerCategoryId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.SurveyAnswerCategoryId,
								SurveyAnswerCategoryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmSurveyAnswerCategory_Lang.Add(crmSurveyAnswerCategory_Lang2);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					if (!vm.OrderView.HasValue || vm.OrderView <= 0)
					{
						List<CRMspSelectSurveyAnswerCategory_Result> list3 = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(vm.SurveyAnswerCategoryQuestionId, lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswerCategory_Result, int?>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list3, (Func<CRMspSelectSurveyAnswerCategory_Result, int?>)((CRMspSelectSurveyAnswerCategory_Result m) => m.OrderView)))?.OrderView;
						int num2 = (Enumerable.Any<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list3) ? Enumerable.Count<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)list3) : 0);
						vm.OrderView = num2 + 10 + num2 * 9 - 5;
					}
					CrmSurveyAnswerCategory crmSurveyAnswerCategory = new CrmSurveyAnswerCategory
					{
						SurveyAnswerCategoryTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						SurveyAnswerCategorySurveyId = vm.SurveyAnswerCategorySurveyId,
						SurveyAnswerCategoryQuestionId = vm.SurveyAnswerCategoryQuestionId,
						OrderView = vm.OrderView,
						GUId = Guid.NewGuid(),
						FirstRegisterUserId = userId,
						FirstRegisterDate = dateTime,
						FirstRegisterDatePersian = text,
						Year1 = year,
						Month1 = month,
						UserId = userId,
						RegisterDate = dateTime,
						RegisterDatePersian = text,
						AppType = appType,
						LanguageID = defLangID
					};
					_dbTbl.CrmSurveyAnswerCategory.Add(crmSurveyAnswerCategory);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmSurveyAnswerCategory_Lang entity = new CrmSurveyAnswerCategory_Lang
						{
							LanguageID = lang.LanguageID,
							SurveyAnswerCategoryId = crmSurveyAnswerCategory.SurveyAnswerCategoryId,
							SurveyAnswerCategoryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmSurveyAnswerCategory_Lang.Add(entity);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstSurveys = SelectSurveyListItem(lCID, defLangID);
		base.ViewBag.lstQuestions = SelectSurveyQuestionsListItem(vm.SurveyAnswerCategorySurveyId);
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategory", ActionName = "actDelete")]
	[AjaxOnly]
	public string DeleteAnswerCategory(int categoryId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurDefineSurveyAnswerCategory", "actDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (categoryId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurveyAnswerCategory(categoryId));
				result = ((mct_Result == null || mct_Result.Result <= 0) ? "-2" : Messages.frmDeleteSuccessMessage);
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public CRMspSelectSurveyWithId_Result SelectSurveyWithId(int surveyId = 0)
	{
		CRMspSelectSurveyWithId_Result result = new CRMspSelectSurveyWithId_Result();
		if (surveyId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				result = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(surveyId, lCID, result2));
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public List<CRMspSelectSurveyAnswerCategory_Result> SelectSurveyAnswerCategory(int questionId = 0)
	{
		List<CRMspSelectSurveyAnswerCategory_Result> result = new List<CRMspSelectSurveyAnswerCategory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(questionId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectSurveyAnswerCategoryListItem(int questionId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectSurveyAnswerCategory_Result> list2 = SelectSurveyAnswerCategory(questionId);
		if (list2 != null)
		{
			foreach (CRMspSelectSurveyAnswerCategory_Result item in list2)
			{
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.Text = item.SurveyAnswerCategoryTitle;
				selectListItem.Value = item.SurveyAnswerCategoryId.ToString();
				selectListItem.Selected = false;
				list.Add(selectListItem);
			}
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult SelectSurveyAnswerCategoryListItemJs(int questionId = 0)
	{
		return Json(SelectSurveyAnswerCategoryListItem(questionId), JsonRequestBehavior.AllowGet);
	}

	public CRMspSelectSurveyAnswerCategoryWithId_Result SelectSurveyAnswerCategoryWithId(int categoryId = 0)
	{
		CRMspSelectSurveyAnswerCategoryWithId_Result result = new CRMspSelectSurveyAnswerCategoryWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryWithId_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryWithId_Result>)_db.CRMspSelectSurveyAnswerCategoryWithId(categoryId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectSurveyListItem(int currLangId = 1065, int defLangId = 1065)
	{
		return new HomeController().SelectSurveyListItem(currLangId, defLangId);
	}

	public JsonResult SelectSurveyListItemJs(int currLangId = 1065, int defLangId = 1065)
	{
		HomeController homeController = new HomeController();
		return Json(homeController.SelectSurveyListItem(currLangId, defLangId), JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> SelectSurveyQuestionsListItem(int surveyId = 0)
	{
		return new HomeController().SelectSurveyQuestionsListItem(surveyId);
	}

	[AjaxOnly]
	public JsonResult SelectSurveyQuestionsListItemJs(int surveyId = 0)
	{
		HomeController homeController = new HomeController();
		return Json(homeController.SelectSurveyQuestionsListItem(surveyId), JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectSurveyAnswerCategoryDetails_Result> SelectSurveyAnswerCategoryDetails(int categoryId = 0)
	{
		List<CRMspSelectSurveyAnswerCategoryDetails_Result> result = new List<CRMspSelectSurveyAnswerCategoryDetails_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)_db.CRMspSelectSurveyAnswerCategoryDetails(categoryId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public CRMspSelectSurveyAnswerCategoryDetailsWithId_Result SelectSurveyAnswerCategoryDetailWithId(int categoryDetailId = 0)
	{
		CRMspSelectSurveyAnswerCategoryDetailsWithId_Result result = new CRMspSelectSurveyAnswerCategoryDetailsWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryDetailsWithId_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetailsWithId_Result>)_db.CRMspSelectSurveyAnswerCategoryDetailsWithId(categoryDetailId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategory", ActionName = "actDefineSurveyAnswerCategoryDetail")]
	public ActionResult CategoryDetailsIndex(int surveyId = 0, string surveyName = "", int questionId = 0, int categoryId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.SurveyName = surveyName;
		base.ViewBag.SurveyId = surveyId;
		base.ViewBag.QuestionId = questionId;
		base.ViewBag.CategoryId = categoryId;
		return View();
	}

	public ActionResult SurveyAnswerCategoryDetails_Read([DataSourceRequest] DataSourceRequest request, int categoryId = 0)
	{
		JsonResult jsonResult = Json(((IEnumerable)SelectSurveyAnswerCategoryDetails(categoryId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategoryDetails", ActionName = "actInsert,actEdit")]
	public ActionResult CategoryDetailInsertEdit(int surveyId = 0, int questionId = 0, int categoryId = 0, int categoryDetailId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		SurveyAnswerCategoryDetailsViewModel surveyAnswerCategoryDetailsViewModel = new SurveyAnswerCategoryDetailsViewModel();
		if (categoryDetailId > 0)
		{
			_003C_003Ec__DisplayClass20_1 _003C_003Ec__DisplayClass20_ = new _003C_003Ec__DisplayClass20_1();
			_003C_003Ec__DisplayClass20_.sp = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryDetailsWithId_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetailsWithId_Result>)_db.CRMspSelectSurveyAnswerCategoryDetailsWithId(categoryDetailId, result, result));
			if (_003C_003Ec__DisplayClass20_.sp != null)
			{
				DbSet<CrmSurveyAnswerCategoryDetails_Lang> crmSurveyAnswerCategoryDetails_Lang = _dbTbl.CrmSurveyAnswerCategoryDetails_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswerCategoryDetails_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurveyAnswerCategoryDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurveyAnswerCategoryDetails_Lang>)Enumerable.ToList<CrmSurveyAnswerCategoryDetails_Lang>((IEnumerable<CrmSurveyAnswerCategoryDetails_Lang>)Queryable.Where<CrmSurveyAnswerCategoryDetails_Lang>((IQueryable<CrmSurveyAnswerCategoryDetails_Lang>)crmSurveyAnswerCategoryDetails_Lang, Expression.Lambda<Func<CrmSurveyAnswerCategoryDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass20_, typeof(_003C_003Ec__DisplayClass20_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmSurveyAnswerCategoryDetails_Lang, CommonMultiLanguageViewModel>)((CrmSurveyAnswerCategoryDetails_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.suracdDetailTitle,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass20_.sp.suracdDetailTitle,
					LanguageId = result
				});
				surveyAnswerCategoryDetailsViewModel.SurveyAnswerCategoryDetailId = _003C_003Ec__DisplayClass20_.sp.SurveyAnswerCategoryDetailId;
				surveyAnswerCategoryDetailsViewModel.suracdCategoryId = _003C_003Ec__DisplayClass20_.sp.suracdCategoryId;
				surveyAnswerCategoryDetailsViewModel.suracdCategory = _003C_003Ec__DisplayClass20_.sp.suracdCategory;
				surveyAnswerCategoryDetailsViewModel.suracdDetailTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveyAnswerCategoryDetailsViewModel.suracdDetailTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveyAnswerCategoryDetailsViewModel.suracdInactive = _003C_003Ec__DisplayClass20_.sp.suracdInactive.GetValueOrDefault();
				surveyAnswerCategoryDetailsViewModel.OrderView = _003C_003Ec__DisplayClass20_.sp.OrderView;
			}
		}
		else
		{
			surveyAnswerCategoryDetailsViewModel.suracdSurveyId = surveyId;
			surveyAnswerCategoryDetailsViewModel.suracdQuestionId = questionId;
			surveyAnswerCategoryDetailsViewModel.suracdCategoryId = categoryId;
		}
		if (!surveyAnswerCategoryDetailsViewModel.OrderView.HasValue || surveyAnswerCategoryDetailsViewModel.OrderView <= 0)
		{
			List<CRMspSelectSurveyAnswerCategoryDetails_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)_db.CRMspSelectSurveyAnswerCategoryDetails(surveyAnswerCategoryDetailsViewModel.suracdCategoryId, currLangID, result));
			_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswerCategoryDetails_Result, int?>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list2, (Func<CRMspSelectSurveyAnswerCategoryDetails_Result, int?>)((CRMspSelectSurveyAnswerCategoryDetails_Result m) => m.OrderView)))?.OrderView;
			int num = (Enumerable.Any<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list2) : 0);
			surveyAnswerCategoryDetailsViewModel.OrderView = num + 10 + num * 9 - 5;
		}
		base.ViewBag.lstSurveys = SelectSurveyListItem(currLangID, result);
		base.ViewBag.lstQuestions = SelectSurveyQuestionsListItem(surveyId);
		base.ViewBag.lstCategory = SelectSurveyAnswerCategoryListItem(questionId);
		return View(surveyAnswerCategoryDetailsViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategoryDetailsDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult CategoryDetailInsertEdit(SurveyAnswerCategoryDetailsViewModel vm, int surveyId = 0, int questionId = 0)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short year = short.Parse(Financial.Get().Id.ToString());
		short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			if (!string.IsNullOrEmpty(vm.suracdDetailTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.suracdDetailTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.suracdDetailTitle,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(vm.suracdDetailTitle))
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.SurveyAnswerCategoryDetailTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(vm.suracdDetailTitle, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.SurveyAnswerCategoryDetailTitle) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				base.ViewBag.lstSurveys = SelectSurveyListItem(lCID, defLangID);
				base.ViewBag.lstQuestions = SelectSurveyQuestionsListItem(surveyId);
				base.ViewBag.lstCategory = SelectSurveyAnswerCategoryListItem(questionId);
				return View(vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass21_1 _003C_003Ec__DisplayClass21_ = new _003C_003Ec__DisplayClass21_1();
				_003C_003Ec__DisplayClass21_.findedRecord = _dbTbl.CrmSurveyAnswerCategoryDetails.Find(vm.SurveyAnswerCategoryDetailId);
				if (_003C_003Ec__DisplayClass21_.findedRecord != null)
				{
					_003C_003Ec__DisplayClass21_.findedRecord.suracdCategoryId = vm.suracdCategoryId;
					_003C_003Ec__DisplayClass21_.findedRecord.suracdDetailTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass21_.findedRecord.suracdInactive = vm.suracdInactive;
					if (!_003C_003Ec__DisplayClass21_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass21_.findedRecord.OrderView <= 0)
					{
						List<CRMspSelectSurveyAnswerCategoryDetails_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)_db.CRMspSelectSurveyAnswerCategoryDetails(vm.suracdCategoryId, lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswerCategoryDetails_Result, int?>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list2, (Func<CRMspSelectSurveyAnswerCategoryDetails_Result, int?>)((CRMspSelectSurveyAnswerCategoryDetails_Result m) => m.OrderView)))?.OrderView;
						int num = (Enumerable.Any<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list2) : 0);
						_003C_003Ec__DisplayClass21_.findedRecord.OrderView = num + 10 + num * 9 - 5;
					}
					else if (vm.OrderView > 0)
					{
						_003C_003Ec__DisplayClass21_.findedRecord.OrderView = vm.OrderView;
					}
					_003C_003Ec__DisplayClass21_.findedRecord.Month1 = month;
					_003C_003Ec__DisplayClass21_.findedRecord.UserId = userId;
					_003C_003Ec__DisplayClass21_.findedRecord.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass21_.findedRecord.RegisterDatePersian = text;
					_003C_003Ec__DisplayClass21_.findedRecord.AppType = appType;
					_dbTbl.Entry(_003C_003Ec__DisplayClass21_.findedRecord).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass21_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass21_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass21_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmSurveyAnswerCategoryDetails_Lang> crmSurveyAnswerCategoryDetails_Lang = _dbTbl.CrmSurveyAnswerCategoryDetails_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswerCategoryDetails_Lang), "c");
							CrmSurveyAnswerCategoryDetails_Lang crmSurveyAnswerCategoryDetails_Lang2 = Queryable.FirstOrDefault<CrmSurveyAnswerCategoryDetails_Lang>((IQueryable<CrmSurveyAnswerCategoryDetails_Lang>)crmSurveyAnswerCategoryDetails_Lang, Expression.Lambda<Func<CrmSurveyAnswerCategoryDetails_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass21_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmSurveyAnswerCategoryDetails_Lang2 != null)
							{
								crmSurveyAnswerCategoryDetails_Lang2.suracdDetailTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmSurveyAnswerCategoryDetails_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmSurveyAnswerCategoryDetails_Lang2 = new CrmSurveyAnswerCategoryDetails_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								SurveyAnswerCategoryDetailId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.SurveyAnswerCategoryDetailId,
								suracdDetailTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmSurveyAnswerCategoryDetails_Lang.Add(crmSurveyAnswerCategoryDetails_Lang2);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					if (!vm.OrderView.HasValue || vm.OrderView <= 0)
					{
						List<CRMspSelectSurveyAnswerCategoryDetails_Result> list3 = Enumerable.ToList<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)_db.CRMspSelectSurveyAnswerCategoryDetails(vm.suracdCategoryId, lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswerCategoryDetails_Result, int?>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list3, (Func<CRMspSelectSurveyAnswerCategoryDetails_Result, int?>)((CRMspSelectSurveyAnswerCategoryDetails_Result m) => m.OrderView)))?.OrderView;
						int num2 = (Enumerable.Any<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list3) ? Enumerable.Count<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)list3) : 0);
						vm.OrderView = num2 + 10 + num2 * 9 - 5;
					}
					CrmSurveyAnswerCategoryDetails crmSurveyAnswerCategoryDetails = new CrmSurveyAnswerCategoryDetails
					{
						suracdCategoryId = vm.suracdCategoryId,
						suracdDetailTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						suracdInactive = vm.suracdInactive,
						OrderView = vm.OrderView,
						GUId = Guid.NewGuid(),
						FirstRegisterUserId = userId,
						FirstRegisterDate = dateTime,
						FirstRegisterDatePersian = text,
						Year1 = year,
						Month1 = month,
						UserId = userId,
						RegisterDate = dateTime,
						RegisterDatePersian = text,
						AppType = appType,
						LanguageID = defLangID
					};
					_dbTbl.CrmSurveyAnswerCategoryDetails.Add(crmSurveyAnswerCategoryDetails);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmSurveyAnswerCategoryDetails_Lang entity = new CrmSurveyAnswerCategoryDetails_Lang
						{
							LanguageID = lang.LanguageID,
							SurveyAnswerCategoryDetailId = crmSurveyAnswerCategoryDetails.SurveyAnswerCategoryDetailId,
							suracdDetailTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmSurveyAnswerCategoryDetails_Lang.Add(entity);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstSurveys = SelectSurveyListItem(lCID, defLangID);
		base.ViewBag.lstQuestions = SelectSurveyQuestionsListItem(questionId);
		base.ViewBag.lstCategory = SelectSurveyAnswerCategoryListItem(questionId);
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswerCategoryDetails", ActionName = "actDelete")]
	[AjaxOnly]
	public string DeleteAnswerCategoryDetail(int CategoryDetailId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurDefineSurveyAnswerCategoryDetails", "actDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (CategoryDetailId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurveyAnswerCategoryDetail(CategoryDetailId));
				result = ((mct_Result == null || mct_Result.Result <= 0) ? "-2" : Messages.frmDeleteSuccessMessage);
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
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
