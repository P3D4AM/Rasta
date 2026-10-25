using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
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

namespace CRMIdeal.Areas.Survey.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public CRMspSelectSurveyWithId_Result sp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public CrmSurvey findedRecord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals1;

		internal bool _003CSurveyInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_1
	{
		public CRMspSelectSurveyQuestionWithId_Result sp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public SurveyQuestionViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__6;

		public Func<Languages, bool> _003C_003E9__15;

		internal bool _003CSurveyQuestionInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_1
	{
		public CrmSurveyQuestions findedRecord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass27_1 CS_0024_003C_003E8__locals1;

		internal bool _003CSurveyQuestionInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyQuestionInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public CRMspSelectSurveyAnswerWithId_Result sp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_1
	{
		public CrmSurveyAnswers findedRecord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass35_1 CS_0024_003C_003E8__locals1;

		internal bool _003CSurveyAnswerInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyAnswerInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyAnswerInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSurveyAnswerInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_spI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _db_spII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public List<SelectListItem> SelectSystemParts(int currLangId = 1065, int defLangId = 1065)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>(Enumerable.Where<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_db_spI.CRMspSelectActiveSystemParts(currLangId, defLangId, "1,10,11,12,13,20,30,40,50,51,60,61,62,70"), (Func<CRMspSelectActiveSystemParts_Result, bool>)((CRMspSelectActiveSystemParts_Result m) => m.Type == "CRM")));
			if (list2 != null)
			{
				foreach (CRMspSelectActiveSystemParts_Result item in list2)
				{
					SelectListItem selectListItem = new SelectListItem();
					selectListItem.Text = item.PartTitle;
					selectListItem.Value = item.SystemPartId.ToString();
					selectListItem.Selected = false;
					list.Add(selectListItem);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineSurvey")]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult _PartialSurvey(int surveyId = 0)
	{
		base.ViewBag.SurveyObj = SelectSurveyListTree(surveyId);
		return PartialView();
	}

	public SurveyViewModelObj SelectSurveyListTree(int surveyId = 0, bool showValues = false, int historyId = 0)
	{
		SurveyViewModelObj surveyViewModelObj = new SurveyViewModelObj();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectSurveyWithId_Result cRMspSelectSurveyWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(surveyId, lCID, result));
			if (cRMspSelectSurveyWithId_Result != null)
			{
				surveyViewModelObj.SurveyId = cRMspSelectSurveyWithId_Result.SurveyId;
				surveyViewModelObj.surDefSendSettingId = cRMspSelectSurveyWithId_Result.surDefSendSettingId.GetValueOrDefault();
				surveyViewModelObj.surDefSendSetting = cRMspSelectSurveyWithId_Result.surDefSendSettingTitle;
				surveyViewModelObj.surSystemPartId = cRMspSelectSurveyWithId_Result.surSystemPartId;
				surveyViewModelObj.surSystemPart = cRMspSelectSurveyWithId_Result.surSystemPart;
				surveyViewModelObj.surSystemPartTitle = cRMspSelectSurveyWithId_Result.surSystemPartTitle;
				surveyViewModelObj.surTitle = cRMspSelectSurveyWithId_Result.surTitle;
				surveyViewModelObj.surDesc = cRMspSelectSurveyWithId_Result.surDesc;
				surveyViewModelObj.surInactive = cRMspSelectSurveyWithId_Result.surInactive.GetValueOrDefault();
				surveyViewModelObj.OrderView = cRMspSelectSurveyWithId_Result.OrderView;
				surveyViewModelObj.surReplyAfterLogin = cRMspSelectSurveyWithId_Result.surReplyAfterLogin;
				surveyViewModelObj.FirstSurveyId = cRMspSelectSurveyWithId_Result.FirstSurveyId.GetValueOrDefault();
				surveyViewModelObj.PriorSurveyId = cRMspSelectSurveyWithId_Result.PriorSurveyId.GetValueOrDefault();
				surveyViewModelObj.NextSurveyId = cRMspSelectSurveyWithId_Result.NextSurveyId.GetValueOrDefault();
				surveyViewModelObj.LastSurveyId = cRMspSelectSurveyWithId_Result.LastSurveyId.GetValueOrDefault();
				surveyViewModelObj.lstQuestionsCount = 0;
				List<CRMspSelectSurveyQuestions_Result> list = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(cRMspSelectSurveyWithId_Result.SurveyId, lCID, result));
				if (list != null)
				{
					surveyViewModelObj.lstQuestionsCount = list.Count;
					List<SurveyQuestionViewModelObj> list2 = new List<SurveyQuestionViewModelObj>();
					foreach (CRMspSelectSurveyQuestions_Result item in list)
					{
						SurveyQuestionViewModelObj surveyQuestionViewModelObj = new SurveyQuestionViewModelObj();
						surveyQuestionViewModelObj.SurveyQuestionId = item.surveyQuestionId;
						surveyQuestionViewModelObj.SurveyQuestionSurveyId = item.SurveyQuestionSurveyId;
						surveyQuestionViewModelObj.SurveyQuestionSurvey = item.Survey;
						surveyQuestionViewModelObj.SurveyQuestion = item.SurveyQuestion;
						surveyQuestionViewModelObj.SurveyQuestionTypeId = item.SurveyQuestionTypeId;
						surveyQuestionViewModelObj.OrderView = item.OrderView;
						surveyQuestionViewModelObj.lstAnswersCount = 0;
						List<CRMspSelectSurveyAnswers_Result> list3 = Enumerable.ToList<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)_db.CRMspSelectSurveyAnswers(item.surveyQuestionId, lCID, result));
						if (list3 != null)
						{
							surveyQuestionViewModelObj.lstAnswersCount = list3.Count;
							List<SurveyAnswerViewModelObj> list4 = new List<SurveyAnswerViewModelObj>();
							foreach (CRMspSelectSurveyAnswers_Result item2 in list3)
							{
								SurveyAnswerViewModelObj surveyAnswerViewModelObj = new SurveyAnswerViewModelObj();
								surveyAnswerViewModelObj.SurveyAnswerId = item2.surveyAnswerId;
								surveyAnswerViewModelObj.SurveyAnswerSurveyId = item2.SurveyAnswerSurveyId;
								surveyAnswerViewModelObj.SurveyAnswerSurvey = item2.SurveyAnswerSurvey;
								surveyAnswerViewModelObj.SurveyAnswerQuestionId = item2.SurveyAnswerQuestionId;
								surveyAnswerViewModelObj.SurveyAnswerQuestion = item2.SurveyAnswerQuestion;
								surveyAnswerViewModelObj.SurveyAnswer = item2.SurveyAnswer;
								surveyAnswerViewModelObj.SurveyAnswerCategoryIds = item2.SurveyAnswerCategoryIds;
								surveyAnswerViewModelObj.SurveyAnswerCategoryIdsTitle = GetCategorys(item.surveyQuestionId, item2.SurveyAnswerCategoryIds);
								surveyAnswerViewModelObj.SurveyAnswerDefCategoryId = item2.SurveyAnswerDefCategoryId;
								surveyAnswerViewModelObj.SurveyAnswerDefCategory = item2.SurveyAnswerDefCategory;
								surveyAnswerViewModelObj.OrderView = item2.OrderView;
								list4.Add(surveyAnswerViewModelObj);
							}
							surveyQuestionViewModelObj.lstAnswers = list4;
						}
						list2.Add(surveyQuestionViewModelObj);
					}
					surveyViewModelObj.lstQuestions = list2;
				}
			}
			else
			{
				surveyViewModelObj.SurveyId = 0;
				surveyViewModelObj.surDefSendSettingId = 0;
				surveyViewModelObj.surSystemPartId = 0;
				surveyViewModelObj.surSystemPart = "";
				surveyViewModelObj.surSystemPartTitle = "";
				surveyViewModelObj.surTitle = "";
				surveyViewModelObj.surDesc = "";
				surveyViewModelObj.surInactive = false;
				surveyViewModelObj.surReplyAfterLogin = false;
				surveyViewModelObj.OrderView = 0;
				surveyViewModelObj.FirstSurveyId = 0;
				surveyViewModelObj.PriorSurveyId = 0;
				surveyViewModelObj.NextSurveyId = 0;
				surveyViewModelObj.LastSurveyId = 0;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return surveyViewModelObj;
	}

	public string SelectSurveyListTreeJs(int surveyId = 0, bool showValues = false, int historyId = 0)
	{
		return JsonConvert.SerializeObject(SelectSurveyListTree(surveyId, showValues, historyId));
	}

	[HttpPost]
	public string SelectSurveyListTreeJs_post(int surveyId = 0, bool showValues = false, int historyId = 0)
	{
		return JsonConvert.SerializeObject(SelectSurveyListTree(surveyId, showValues, historyId));
	}

	public List<CRMspSelectSurvey_Result> SelectSurvey(int currLangId = 1065, int defLangId = 1065, int cId = 0)
	{
		List<CRMspSelectSurvey_Result> result = new List<CRMspSelectSurvey_Result>();
		if (UserLogin.CurrentUser != null && cId == 0)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out cId);
		}
		try
		{
			result = Enumerable.ToList<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(currLangId, defLangId, cId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectSurveySendSetting()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectSurveySendSetting_Result> list2 = Enumerable.ToList<CRMspSelectSurveySendSetting_Result>((IEnumerable<CRMspSelectSurveySendSetting_Result>)_db.CRMspSelectSurveySendSetting(lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectSurveySendSetting_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Text = item2.surssTitle,
						Value = item2.SurveySendSettingId.ToString(),
						Selected = false
					};
					list.Add(item);
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
	public JsonResult SelectSurveySendSettingJs()
	{
		return Json(SelectSurveySendSetting(), JsonRequestBehavior.AllowGet);
	}

	public ActionResult Surveies_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		_ = UserLogin.CurrentUser.UserId;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		JsonResult jsonResult = Json(((IEnumerable)SelectSurvey(lCID, result, result2)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actInsert,actEdit")]
	public ActionResult SurveyInsertEdit(int surveyId = 0, int sysPartId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		SurveyViewModel surveyViewModel = new SurveyViewModel();
		if (surveyId > 0)
		{
			_003C_003Ec__DisplayClass15_1 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_1();
			if (!UserLogin.IsUserAccess("frmSurDefineSurvey", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			_003C_003Ec__DisplayClass15_.sp = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(surveyId, result, result));
			if (_003C_003Ec__DisplayClass15_.sp != null)
			{
				DbSet<CrmSurvey_Lang> crmSurvey_Lang = _dbTbl.CrmSurvey_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurvey_Lang), "c");
				List<CrmSurvey_Lang> list = Enumerable.ToList<CrmSurvey_Lang>((IEnumerable<CrmSurvey_Lang>)Queryable.Where<CrmSurvey_Lang>((IQueryable<CrmSurvey_Lang>)crmSurvey_Lang, Expression.Lambda<Func<CrmSurvey_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurvey_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurvey_Lang>)list, (Func<CrmSurvey_Lang, CommonMultiLanguageViewModel>)((CrmSurvey_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.surTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass15_.sp.surTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurvey_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurvey_Lang>)list, (Func<CrmSurvey_Lang, CommonMultiLanguageViewModel>)((CrmSurvey_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.surDesc,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass15_.sp.surDesc,
					LanguageId = result
				});
				surveyViewModel.SurveyId = _003C_003Ec__DisplayClass15_.sp.SurveyId;
				surveyViewModel.surDefSendSettingId = _003C_003Ec__DisplayClass15_.sp.surDefSendSettingId.GetValueOrDefault();
				surveyViewModel.surSystemPartId = _003C_003Ec__DisplayClass15_.sp.surSystemPartId;
				surveyViewModel.surSystemPart = _003C_003Ec__DisplayClass15_.sp.surSystemPart;
				surveyViewModel.surSystemPartTitle = _003C_003Ec__DisplayClass15_.sp.surSystemPartTitle;
				surveyViewModel.surTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveyViewModel.surTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveyViewModel.surDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveyViewModel.surDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveyViewModel.surInactive = _003C_003Ec__DisplayClass15_.sp.surInactive.GetValueOrDefault();
				surveyViewModel.surReplyAfterLogin = _003C_003Ec__DisplayClass15_.sp.surReplyAfterLogin;
				surveyViewModel.OrderView = _003C_003Ec__DisplayClass15_.sp.OrderView;
			}
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmSurDefineSurvey", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			surveyViewModel.surSystemPartId = sysPartId;
			base.ViewBag.IsBuying = VersionBuyer.Survey;
		}
		if (!surveyViewModel.OrderView.HasValue || surveyViewModel.OrderView <= 0)
		{
			List<CRMspSelectSurvey_Result> list4 = Enumerable.ToList<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(currLangID, result, result2));
			_ = Enumerable.FirstOrDefault<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)Enumerable.OrderByDescending<CRMspSelectSurvey_Result, int?>((IEnumerable<CRMspSelectSurvey_Result>)list4, (Func<CRMspSelectSurvey_Result, int?>)((CRMspSelectSurvey_Result m) => m.OrderView)))?.OrderView;
			int num = (Enumerable.Any<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)list4) ? Enumerable.Count<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)list4) : 0);
			surveyViewModel.OrderView = num + 10 + num * 9 - 5;
		}
		base.ViewBag.SendSettings = SelectSurveySendSetting();
		base.ViewBag.SysPartsList = SelectSystemParts(currLangID, result);
		return View(surveyViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SurveyInsertEdit(SurveyViewModel vm)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
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
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			if (!string.IsNullOrEmpty(vm.surTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.surTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.surTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.surDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.surDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.surDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(vm.surTitle))
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.SurveyTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(vm.surTitle, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.SurveyTitle) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				base.ViewBag.SendSettings = SelectSurveySendSetting();
				base.ViewBag.SysPartsList = SelectSystemParts(lCID, defLangID);
				return View(vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass16_1 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_1();
				if (vm.SurveyId <= 0 && !VersionBuyer.Survey)
				{
					DbSet<CrmSurvey> crmSurvey = _dbTbl.CrmSurvey;
					ParameterExpression val = Expression.Parameter(typeof(CrmSurvey), "c");
					if (Queryable.Any<CrmSurvey>((IQueryable<CrmSurvey>)crmSurvey, Expression.Lambda<Func<CrmSurvey, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)1, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						base.ViewBag.Error = "BV|" + string.Format(Messages.ImportExcelBuyModuleWithCount, "1");
						base.ViewBag.SendSettings = SelectSurveySendSetting();
						base.ViewBag.SysPartsList = SelectSystemParts(lCID, defLangID);
						return View(vm);
					}
				}
				_003C_003Ec__DisplayClass16_.findedRecord = _dbTbl.CrmSurvey.Find(vm.SurveyId);
				if (_003C_003Ec__DisplayClass16_.findedRecord != null)
				{
					_003C_003Ec__DisplayClass16_.findedRecord.surSystemPartId = vm.surSystemPartId;
					_003C_003Ec__DisplayClass16_.findedRecord.surDefSendSettingId = vm.surDefSendSettingId;
					_003C_003Ec__DisplayClass16_.findedRecord.surTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass16_.findedRecord.surDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass16_.findedRecord.surReplyAfterLogin = vm.surReplyAfterLogin;
					_003C_003Ec__DisplayClass16_.findedRecord.surInactive = vm.surInactive;
					if (!_003C_003Ec__DisplayClass16_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass16_.findedRecord.OrderView <= 0)
					{
						List<CRMspSelectSurvey_Result> list3 = Enumerable.ToList<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(lCID, defLangID, result));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)Enumerable.OrderByDescending<CRMspSelectSurvey_Result, int?>((IEnumerable<CRMspSelectSurvey_Result>)list3, (Func<CRMspSelectSurvey_Result, int?>)((CRMspSelectSurvey_Result m) => m.OrderView)))?.OrderView;
						int num = (Enumerable.Any<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)list3) ? Enumerable.Count<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)list3) : 0);
						_003C_003Ec__DisplayClass16_.findedRecord.OrderView = num + 10 + num * 9 - 5;
					}
					else if (vm.OrderView > 0)
					{
						_003C_003Ec__DisplayClass16_.findedRecord.OrderView = vm.OrderView;
					}
					_003C_003Ec__DisplayClass16_.findedRecord.Month1 = month;
					_003C_003Ec__DisplayClass16_.findedRecord.UserId = userId;
					_003C_003Ec__DisplayClass16_.findedRecord.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass16_.findedRecord.RegisterDatePersian = text;
					_003C_003Ec__DisplayClass16_.findedRecord.AppType = appType;
					_dbTbl.Entry(_003C_003Ec__DisplayClass16_.findedRecord).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass16_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass16_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass16_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmSurvey_Lang> crmSurvey_Lang = _dbTbl.CrmSurvey_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmSurvey_Lang), "c");
							CrmSurvey_Lang crmSurvey_Lang2 = Queryable.FirstOrDefault<CrmSurvey_Lang>((IQueryable<CrmSurvey_Lang>)crmSurvey_Lang, Expression.Lambda<Func<CrmSurvey_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmSurvey_Lang2 != null)
							{
								crmSurvey_Lang2.surTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmSurvey_Lang2.surDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmSurvey_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmSurvey_Lang2 = new CrmSurvey_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								SurveyId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.SurveyId,
								surTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								surDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmSurvey_Lang.Add(crmSurvey_Lang2);
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					List<SurveyCenterInfoJsViewModel> list4 = new List<SurveyCenterInfoJsViewModel>();
					list4.Add(new SurveyCenterInfoJsViewModel
					{
						CId = result
					});
					if (!vm.OrderView.HasValue || vm.OrderView <= 0)
					{
						List<CRMspSelectSurvey_Result> list5 = Enumerable.ToList<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(lCID, defLangID, result));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)Enumerable.OrderByDescending<CRMspSelectSurvey_Result, int?>((IEnumerable<CRMspSelectSurvey_Result>)list5, (Func<CRMspSelectSurvey_Result, int?>)((CRMspSelectSurvey_Result m) => m.OrderView)))?.OrderView;
						int num2 = (Enumerable.Any<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)list5) ? Enumerable.Count<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)list5) : 0);
						vm.OrderView = num2 + 10 + num2 * 9 - 5;
					}
					CrmSurvey crmSurvey2 = new CrmSurvey
					{
						surSystemPartId = vm.surSystemPartId,
						surDefSendSettingId = vm.surDefSendSettingId,
						surTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						surDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						surReplyAfterLogin = vm.surReplyAfterLogin,
						surInactive = vm.surInactive,
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
						LanguageID = defLangID,
						surCIds = result.ToString(),
						surCenterInfoJs = JsonConvert.SerializeObject(list4)
					};
					_dbTbl.CrmSurvey.Add(crmSurvey2);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmSurvey_Lang entity = new CrmSurvey_Lang
						{
							LanguageID = lang.LanguageID,
							SurveyId = crmSurvey2.SurveyId,
							surTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							surDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmSurvey_Lang.Add(entity);
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		base.ViewBag.SendSettings = SelectSurveySendSetting();
		base.ViewBag.SysPartsList = SelectSystemParts(lCID, defLangID);
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actDelete")]
	[AjaxOnly]
	public string DeleteSurvey(int surveyId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurDefineSurvey", "actDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (surveyId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurvey(surveyId));
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

	[AjaxOnly]
	public int UpdateSurveyInactive(int surveyId = 0, bool status = true)
	{
		int num = 0;
		try
		{
			_db.CRMspUpdateSurveyInactive(surveyId, status);
			return 1;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return 0;
		}
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
		try
		{
			List<CRMspSelectSurveyAnswerCategory_Result> list2 = SelectSurveyAnswerCategory(questionId);
			if (list2 != null)
			{
				foreach (CRMspSelectSurveyAnswerCategory_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Text = item2.SurveyAnswerCategoryTitle,
						Value = item2.SurveyAnswerCategoryId.ToString(),
						Selected = false
					};
					list.Add(item);
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
	public JsonResult SelectSurveyAnswerCategoryListItemJs(int questionId = 0)
	{
		return Json(SelectSurveyAnswerCategoryListItem(questionId), JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> SelectSurveyListItem(int currLangId = 1065, int defLangId = 1065, int cId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		if (UserLogin.CurrentUser != null && cId == 0)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out cId);
		}
		foreach (CRMspSelectSurvey_Result item2 in SelectSurvey(currLangId, defLangId, cId))
		{
			SelectListItem item = new SelectListItem
			{
				Value = item2.SurveyId.ToString(),
				Text = item2.surTitle,
				Selected = false
			};
			list.Add(item);
		}
		return list;
	}

	public List<CRMspSelectSurveyQuestions_Result> SelectSurveyQuestions(int surveyId = 0, int currLangId = 1065, int defLangId = 1065)
	{
		List<CRMspSelectSurveyQuestions_Result> result = new List<CRMspSelectSurveyQuestions_Result>();
		try
		{
			result = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(surveyId, currLangId, defLangId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> fnGetQuestionTypes()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list.Add(new SelectListItem
			{
				Value = "1",
				Text = Labels.RadioBox,
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Value = "2",
				Text = Labels.CheckBox,
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Value = "3",
				Text = Labels.TextArea,
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Value = "4",
				Text = Labels.Star,
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult SurveyQuestion_Read([DataSourceRequest] DataSourceRequest request, int surveyId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		_ = UserLogin.CurrentUser.UserId;
		JsonResult jsonResult = Json(((IEnumerable)SelectSurveyQuestions(surveyId, lCID, result)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actsurqInsert,actsurqEdit")]
	public ActionResult SurveyQuestionInsertEdit(int selectedSurveyId = 0, int questionId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		SurveyQuestionViewModel surveyQuestionViewModel = new SurveyQuestionViewModel();
		if (questionId > 0)
		{
			_003C_003Ec__DisplayClass26_1 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_1();
			_003C_003Ec__DisplayClass26_.sp = Enumerable.FirstOrDefault<CRMspSelectSurveyQuestionWithId_Result>((IEnumerable<CRMspSelectSurveyQuestionWithId_Result>)_db.CRMspSelectSurveyQuestionWithId(questionId, result, result));
			if (_003C_003Ec__DisplayClass26_.sp != null)
			{
				DbSet<CrmSurveyQuestions_Lang> crmSurveyQuestions_Lang = _dbTbl.CrmSurveyQuestions_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyQuestions_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurveyQuestions_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurveyQuestions_Lang>)Enumerable.ToList<CrmSurveyQuestions_Lang>((IEnumerable<CrmSurveyQuestions_Lang>)Queryable.Where<CrmSurveyQuestions_Lang>((IQueryable<CrmSurveyQuestions_Lang>)crmSurveyQuestions_Lang, Expression.Lambda<Func<CrmSurveyQuestions_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmSurveyQuestions_Lang, CommonMultiLanguageViewModel>)((CrmSurveyQuestions_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SurveyQuestion,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass26_.sp.SurveyQuestion,
					LanguageId = result
				});
				surveyQuestionViewModel.SurveyQuestionId = _003C_003Ec__DisplayClass26_.sp.surveyQuestionId;
				surveyQuestionViewModel.SurveyQuestionSurveyId = _003C_003Ec__DisplayClass26_.sp.SurveyQuestionSurveyId;
				surveyQuestionViewModel.SurveyQuestion = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveyQuestionViewModel.SurveyQuestion_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveyQuestionViewModel.SurveyQuestionTypeId = _003C_003Ec__DisplayClass26_.sp.SurveyQuestionTypeId;
				surveyQuestionViewModel.OrderView = _003C_003Ec__DisplayClass26_.sp.OrderView;
			}
		}
		if (!surveyQuestionViewModel.OrderView.HasValue || surveyQuestionViewModel.OrderView <= 0)
		{
			List<CRMspSelectSurveyQuestions_Result> list2 = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(selectedSurveyId, currLangID, result));
			_ = Enumerable.FirstOrDefault<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyQuestions_Result, int?>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list2, (Func<CRMspSelectSurveyQuestions_Result, int?>)((CRMspSelectSurveyQuestions_Result m) => m.OrderView)))?.OrderView;
			int num = (Enumerable.Any<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list2) : 0);
			surveyQuestionViewModel.OrderView = num + 10 + num * 9 - 5;
		}
		base.ViewBag.SelectedSurveyId = selectedSurveyId;
		base.ViewBag.SurveyList = SelectSurveyListItem(currLangID, result, result2);
		base.ViewBag.Questiontypes = fnGetQuestionTypes();
		return View(surveyQuestionViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyQuestionDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SurveyQuestionInsertEdit(SurveyQuestionViewModel vm)
	{
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime dateTime = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short year = short.Parse(Financial.Get().Id.ToString());
		short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.SurveyQuestion_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.SurveyQuestion_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.SurveyQuestion,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.vm.SurveyQuestion))
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.SurveyQuestionTitle) + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.SurveyQuestion, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.SurveyQuestionTitle) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				base.ViewBag.SurveyList = SelectSurveyListItem(lCID, CS_0024_003C_003E8__locals0.defLangID, result);
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass27_1 _003C_003Ec__DisplayClass27_ = new _003C_003Ec__DisplayClass27_1();
				_003C_003Ec__DisplayClass27_.findedRecord = _dbTbl.CrmSurveyQuestions.Find(CS_0024_003C_003E8__locals0.vm.SurveyQuestionId);
				DbSet<CrmSurveyAnswers> crmSurveyAnswers = _dbTbl.CrmSurveyAnswers;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswers), "x");
				int count = Enumerable.ToList<CrmSurveyAnswers>((IEnumerable<CrmSurveyAnswers>)Queryable.Where<CrmSurveyAnswers>((IQueryable<CrmSurveyAnswers>)crmSurveyAnswers, Expression.Lambda<Func<CrmSurveyAnswers, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass27_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).Count;
				if (_003C_003Ec__DisplayClass27_.findedRecord != null)
				{
					if (count > 0 && _003C_003Ec__DisplayClass27_.findedRecord.SurveyQuestionTypeId != 3 && CS_0024_003C_003E8__locals0.vm.SurveyQuestionTypeId == 3)
					{
						base.ViewBag.Error = "<br/> " + Messages.SurveyMsgErrorQuestionHaveAnswer;
					}
					else
					{
						_003C_003Ec__DisplayClass27_.findedRecord.SurveyQuestionSurveyId = CS_0024_003C_003E8__locals0.vm.SurveyQuestionSurveyId;
						_003C_003Ec__DisplayClass27_.findedRecord.SurveyQuestionId = CS_0024_003C_003E8__locals0.vm.SurveyQuestionId;
						_003C_003Ec__DisplayClass27_.findedRecord.SurveyQuestion = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						_003C_003Ec__DisplayClass27_.findedRecord.SurveyQuestionTypeId = CS_0024_003C_003E8__locals0.vm.SurveyQuestionTypeId;
						if (!_003C_003Ec__DisplayClass27_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass27_.findedRecord.OrderView <= 0)
						{
							List<CRMspSelectSurveyQuestions_Result> list2 = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(CS_0024_003C_003E8__locals0.vm.SurveyQuestionSurveyId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							_ = Enumerable.FirstOrDefault<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyQuestions_Result, int?>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list2, (Func<CRMspSelectSurveyQuestions_Result, int?>)((CRMspSelectSurveyQuestions_Result m) => m.OrderView)))?.OrderView;
							int num = (Enumerable.Any<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list2) : 0);
							_003C_003Ec__DisplayClass27_.findedRecord.OrderView = num + 10 + num * 9 - 5;
						}
						else if (CS_0024_003C_003E8__locals0.vm.OrderView > 0)
						{
							_003C_003Ec__DisplayClass27_.findedRecord.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
						}
						_003C_003Ec__DisplayClass27_.findedRecord.Month1 = month;
						_003C_003Ec__DisplayClass27_.findedRecord.UserId = userId;
						_003C_003Ec__DisplayClass27_.findedRecord.RegisterDate = dateTime;
						_003C_003Ec__DisplayClass27_.findedRecord.RegisterDatePersian = text;
						_003C_003Ec__DisplayClass27_.findedRecord.AppType = appType;
						_dbTbl.Entry(_003C_003Ec__DisplayClass27_.findedRecord).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass27_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass27_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass27_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmSurveyQuestions_Lang> crmSurveyQuestions_Lang = _dbTbl.CrmSurveyQuestions_Lang;
								val = Expression.Parameter(typeof(CrmSurveyQuestions_Lang), "c");
								CrmSurveyQuestions_Lang crmSurveyQuestions_Lang2 = Queryable.FirstOrDefault<CrmSurveyQuestions_Lang>((IQueryable<CrmSurveyQuestions_Lang>)crmSurveyQuestions_Lang, Expression.Lambda<Func<CrmSurveyQuestions_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass27_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmSurveyQuestions_Lang2 != null)
								{
									crmSurveyQuestions_Lang2.SurveyQuestion = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmSurveyQuestions_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmSurveyQuestions_Lang2 = new CrmSurveyQuestions_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									SurveyQuestionId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.SurveyQuestionId,
									SurveyQuestion = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmSurveyQuestions_Lang.Add(crmSurveyQuestions_Lang2);
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
				}
				else
				{
					if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue || CS_0024_003C_003E8__locals0.vm.OrderView <= 0)
					{
						List<CRMspSelectSurveyQuestions_Result> list3 = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(CS_0024_003C_003E8__locals0.vm.SurveyQuestionSurveyId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyQuestions_Result, int?>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list3, (Func<CRMspSelectSurveyQuestions_Result, int?>)((CRMspSelectSurveyQuestions_Result m) => m.OrderView)))?.OrderView;
						int num2 = (Enumerable.Any<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list3) ? Enumerable.Count<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)list3) : 0);
						CS_0024_003C_003E8__locals0.vm.OrderView = num2 + 10 + num2 * 9 - 5;
					}
					CrmSurveyQuestions crmSurveyQuestions = new CrmSurveyQuestions
					{
						SurveyQuestionSurveyId = CS_0024_003C_003E8__locals0.vm.SurveyQuestionSurveyId,
						SurveyQuestion = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
						SurveyQuestionTypeId = CS_0024_003C_003E8__locals0.vm.SurveyQuestionTypeId,
						OrderView = CS_0024_003C_003E8__locals0.vm.OrderView,
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
						LanguageID = CS_0024_003C_003E8__locals0.defLangID
					};
					_dbTbl.CrmSurveyQuestions.Add(crmSurveyQuestions);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmSurveyQuestions_Lang entity = new CrmSurveyQuestions_Lang
						{
							LanguageID = lang.LanguageID,
							SurveyQuestionId = crmSurveyQuestions.SurveyQuestionId,
							SurveyQuestion = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmSurveyQuestions_Lang.Add(entity);
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
		base.ViewBag.SurveyList = SelectSurveyListItem(lCID, CS_0024_003C_003E8__locals0.defLangID, result);
		base.ViewBag.Questiontypes = fnGetQuestionTypes();
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actsurqDelete")]
	[AjaxOnly]
	public string DeleteSurveyQuestion(int questionId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurDefineSurvey", "actsurqDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (questionId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurveyQuestion(questionId));
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

	public List<SelectListItem> SelectSurveyQuestionsListItem(int surveyId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		foreach (CRMspSelectSurveyQuestions_Result item2 in Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)SelectSurveyQuestions(surveyId, lCID, result)))
		{
			SelectListItem item = new SelectListItem
			{
				Value = item2.surveyQuestionId.ToString(),
				Text = item2.SurveyQuestion,
				Selected = false
			};
			list.Add(item);
		}
		return list;
	}

	public JsonResult SelectSurveyQuestionsListItemJs(int surveyId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		foreach (CRMspSelectSurveyQuestions_Result item2 in Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)SelectSurveyQuestions(surveyId, lCID, result)))
		{
			SelectListItem item = new SelectListItem
			{
				Value = item2.surveyQuestionId.ToString(),
				Text = item2.SurveyQuestion,
				Selected = false
			};
			list.Add(item);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectSurveyAnswers_Result> SelectSurveyAnswers(int questionId = 0, int currLangId = 1065, int defLangId = 1065)
	{
		List<CRMspSelectSurveyAnswers_Result> result = new List<CRMspSelectSurveyAnswers_Result>();
		try
		{
			result = Enumerable.ToList<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)_db.CRMspSelectSurveyAnswers(questionId, currLangId, defLangId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string GetCategorys(int questionId = 0, string ids = "")
	{
		string text = "";
		try
		{
			if (questionId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectSurveyAnswerCategory_Result> list = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(questionId, lCID, result));
				if (list != null && !string.IsNullOrWhiteSpace(ids))
				{
					List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)ids.Split(new char[1] { '|' }));
					foreach (CRMspSelectSurveyAnswerCategory_Result item in list)
					{
						if (list2.FindIndex((string x) => x == item.SurveyAnswerCategoryId.ToString()) >= 0)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += item.SurveyAnswerCategoryTitle;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public ActionResult SurveyAnswers_Read([DataSourceRequest] DataSourceRequest request, int questionId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		_ = UserLogin.CurrentUser.UserId;
		JsonResult jsonResult = Json(((IEnumerable)SelectSurveyAnswers(questionId, lCID, result)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actsuraInsert,actsuraEdit")]
	public ActionResult SurveyAnswerInsertEdit(int surveyId = 0, int questionId = 0, int answerId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		SurveyAnswerViewModel surveyAnswerViewModel = new SurveyAnswerViewModel();
		if (answerId > 0)
		{
			_003C_003Ec__DisplayClass34_1 _003C_003Ec__DisplayClass34_ = new _003C_003Ec__DisplayClass34_1();
			_003C_003Ec__DisplayClass34_.sp = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerWithId_Result>((IEnumerable<CRMspSelectSurveyAnswerWithId_Result>)_db.CRMspSelectSurveyAnswerWithId(answerId, result, result));
			if (_003C_003Ec__DisplayClass34_.sp != null)
			{
				surveyId = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerSurveyId;
				questionId = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerQuestionId;
				DbSet<CrmSurveyAnswers_Lang> crmSurveyAnswers_Lang = _dbTbl.CrmSurveyAnswers_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswers_Lang), "c");
				List<CommonMultiLanguageViewModel> list = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmSurveyAnswers_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmSurveyAnswers_Lang>)Enumerable.ToList<CrmSurveyAnswers_Lang>((IEnumerable<CrmSurveyAnswers_Lang>)Queryable.Where<CrmSurveyAnswers_Lang>((IQueryable<CrmSurveyAnswers_Lang>)crmSurveyAnswers_Lang, Expression.Lambda<Func<CrmSurveyAnswers_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass34_, typeof(_003C_003Ec__DisplayClass34_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))), (Func<CrmSurveyAnswers_Lang, CommonMultiLanguageViewModel>)((CrmSurveyAnswers_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.SurveyAnswer,
					LanguageId = item.LanguageID
				})));
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass34_.sp.SurveyAnswer,
					LanguageId = result
				});
				surveyAnswerViewModel.SurveyAnswerSurveyId = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerSurveyId;
				surveyAnswerViewModel.SurveyAnswerSurvey = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerSurvey;
				surveyAnswerViewModel.SurveyAnswerId = _003C_003Ec__DisplayClass34_.sp.surveyAnswerId;
				surveyAnswerViewModel.SurveyAnswerQuestionId = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerQuestionId;
				surveyAnswerViewModel.SurveyAnswerQuestion = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerQuestion;
				surveyAnswerViewModel.SurveyAnswer = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				surveyAnswerViewModel.SurveyAnswer_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				surveyAnswerViewModel.SurveyAnswerCategoryIds = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerCategoryIds;
				surveyAnswerViewModel.SurveyAnswerCategoryIdsTitle = GetCategorys(questionId, _003C_003Ec__DisplayClass34_.sp.SurveyAnswerCategoryIds);
				surveyAnswerViewModel.SurveyAnswerDefCategoryId = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerDefCategoryId;
				surveyAnswerViewModel.SurveyAnswerDefCategory = _003C_003Ec__DisplayClass34_.sp.SurveyAnswerDefCategory;
				surveyAnswerViewModel.OrderView = _003C_003Ec__DisplayClass34_.sp.OrderView;
			}
			else
			{
				surveyAnswerViewModel.SurveyAnswerSurveyId = surveyId;
				surveyAnswerViewModel.SurveyAnswerQuestionId = questionId;
			}
		}
		else
		{
			surveyAnswerViewModel.SurveyAnswerSurveyId = surveyId;
			surveyAnswerViewModel.SurveyAnswerQuestionId = questionId;
		}
		if (!surveyAnswerViewModel.OrderView.HasValue || surveyAnswerViewModel.OrderView <= 0)
		{
			List<CRMspSelectSurveyAnswers_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)_db.CRMspSelectSurveyAnswers(questionId, currLangID, result));
			_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswers_Result, int?>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list2, (Func<CRMspSelectSurveyAnswers_Result, int?>)((CRMspSelectSurveyAnswers_Result m) => m.OrderView)))?.OrderView;
			int num = (Enumerable.Any<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list2) : 0);
			surveyAnswerViewModel.OrderView = num + 10 + num * 9 - 5;
		}
		base.ViewBag.SurveyList = SelectSurveyListItem(currLangID, result, result2);
		base.ViewBag.SurveyAnswerCategoryList = SelectSurveyAnswerCategoryListItem(surveyAnswerViewModel.SurveyAnswerQuestionId);
		base.ViewBag.QuestionList = SelectSurveyQuestionsListItem(surveyId);
		return View(surveyAnswerViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSurDefineSurveyAnswersDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SurveyAnswerInsertEdit(SurveyAnswerViewModel vm)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
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
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			string text2 = "";
			if (!string.IsNullOrEmpty(vm.SurveyAnswer_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.SurveyAnswer_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.SurveyAnswer,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(vm.SurveyAnswer))
			{
				text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.SrvSurvey) + "<br/>";
			}
			else if (!checkMultiLanguage(vm.SurveyAnswer, list))
			{
				text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.SrvSurvey) + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
				base.ViewBag.SurveyList = SelectSurveyListItem(lCID, defLangID, result);
				base.ViewBag.QuestionList = SelectSurveyQuestionsListItem(vm.SurveyAnswerSurveyId);
				return View(vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass35_1 _003C_003Ec__DisplayClass35_ = new _003C_003Ec__DisplayClass35_1();
				_003C_003Ec__DisplayClass35_.findedRecord = _dbTbl.CrmSurveyAnswers.Find(vm.SurveyAnswerId);
				if (_003C_003Ec__DisplayClass35_.findedRecord != null)
				{
					_003C_003Ec__DisplayClass35_.findedRecord.SurveyAnswerSurveyId = vm.SurveyAnswerSurveyId;
					_003C_003Ec__DisplayClass35_.findedRecord.SurveyAnswerQuestionId = vm.SurveyAnswerQuestionId;
					_003C_003Ec__DisplayClass35_.findedRecord.SurveyAnswer = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					_003C_003Ec__DisplayClass35_.findedRecord.SurveyAnswerCategoryIds = vm.SurveyAnswerCategoryIds;
					_003C_003Ec__DisplayClass35_.findedRecord.SurveyAnswerDefCategoryId = vm.SurveyAnswerDefCategoryId;
					if (!_003C_003Ec__DisplayClass35_.findedRecord.OrderView.HasValue || _003C_003Ec__DisplayClass35_.findedRecord.OrderView <= 0)
					{
						List<CRMspSelectSurveyAnswers_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)_db.CRMspSelectSurveyAnswers(vm.SurveyAnswerQuestionId, lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswers_Result, int?>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list2, (Func<CRMspSelectSurveyAnswers_Result, int?>)((CRMspSelectSurveyAnswers_Result m) => m.OrderView)))?.OrderView;
						int num = (Enumerable.Any<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list2) ? Enumerable.Count<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list2) : 0);
						_003C_003Ec__DisplayClass35_.findedRecord.OrderView = num + 10 + num * 9 - 5;
					}
					else if (vm.OrderView > 0)
					{
						_003C_003Ec__DisplayClass35_.findedRecord.OrderView = vm.OrderView;
					}
					_003C_003Ec__DisplayClass35_.findedRecord.Month1 = month;
					_003C_003Ec__DisplayClass35_.findedRecord.UserId = userId;
					_003C_003Ec__DisplayClass35_.findedRecord.RegisterDate = dateTime;
					_003C_003Ec__DisplayClass35_.findedRecord.RegisterDatePersian = text;
					_003C_003Ec__DisplayClass35_.findedRecord.AppType = appType;
					_dbTbl.Entry(_003C_003Ec__DisplayClass35_.findedRecord).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass35_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass35_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass35_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmSurveyAnswers_Lang> crmSurveyAnswers_Lang = _dbTbl.CrmSurveyAnswers_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmSurveyAnswers_Lang), "c");
							CrmSurveyAnswers_Lang crmSurveyAnswers_Lang2 = Queryable.FirstOrDefault<CrmSurveyAnswers_Lang>((IQueryable<CrmSurveyAnswers_Lang>)crmSurveyAnswers_Lang, Expression.Lambda<Func<CrmSurveyAnswers_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass35_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass35_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmSurveyAnswers_Lang2 != null)
							{
								crmSurveyAnswers_Lang2.SurveyAnswer = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmSurveyAnswers_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmSurveyAnswers_Lang2 = new CrmSurveyAnswers_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								SurveyAnswerId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.findedRecord.SurveyAnswerId,
								SurveyAnswer = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmSurveyAnswers_Lang.Add(crmSurveyAnswers_Lang2);
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
						List<CRMspSelectSurveyAnswers_Result> list3 = Enumerable.ToList<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)_db.CRMspSelectSurveyAnswers(vm.SurveyAnswerQuestionId, lCID, defLangID));
						_ = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)Enumerable.OrderByDescending<CRMspSelectSurveyAnswers_Result, int?>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list3, (Func<CRMspSelectSurveyAnswers_Result, int?>)((CRMspSelectSurveyAnswers_Result m) => m.OrderView)))?.OrderView;
						int num2 = (Enumerable.Any<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list3) ? Enumerable.Count<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)list3) : 0);
						vm.OrderView = num2 + 10 + num2 * 9 - 5;
					}
					CrmSurveyAnswers crmSurveyAnswers = new CrmSurveyAnswers
					{
						SurveyAnswerSurveyId = vm.SurveyAnswerSurveyId,
						SurveyAnswerQuestionId = vm.SurveyAnswerQuestionId,
						SurveyAnswer = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						SurveyAnswerCategoryIds = vm.SurveyAnswerCategoryIds,
						SurveyAnswerDefCategoryId = vm.SurveyAnswerDefCategoryId,
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
					_dbTbl.CrmSurveyAnswers.Add(crmSurveyAnswers);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmSurveyAnswers_Lang entity = new CrmSurveyAnswers_Lang
						{
							LanguageID = lang.LanguageID,
							SurveyAnswerId = crmSurveyAnswers.SurveyAnswerId,
							SurveyAnswer = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmSurveyAnswers_Lang.Add(entity);
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
		base.ViewBag.SurveyList = SelectSurveyListItem(lCID, defLangID, result);
		base.ViewBag.SurveyAnswerCategoryList = SelectSurveyAnswerCategoryListItem(vm.SurveyAnswerQuestionId);
		base.ViewBag.QuestionList = SelectSurveyQuestionsListItem(vm.SurveyAnswerSurveyId);
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actsuraDelete")]
	[AjaxOnly]
	public string DeleteSurveyAnswer(int answerId = 0)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmSurDefineSurvey", "actsuraDelete", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (answerId != 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteSurveyAnswer(answerId));
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

	public ActionResult CategoryItems(string type, string param, string extra = "")
	{
		base.ViewBag.Parameters = param;
		base.ViewBag.Type = type;
		base.ViewBag.Extra = extra;
		return View();
	}

	[AjaxOnly]
	public JsonResult ListCategorysForSurveyAnswer(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			int result2 = 0;
			int.TryParse(parameters, out result2);
			string[] array = extra.Split(new char[1] { '|' });
			List<CRMspSelectSurveyAnswerCategory_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(result2, lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectSurveyAnswerCategory_Result item in list2)
				{
					CommonMultiSelectorViewModel item2 = new CommonMultiSelectorViewModel
					{
						Id = item.SurveyAnswerCategoryId,
						Name = item.SurveyAnswerCategoryTitle,
						Selected = Array.Exists(array, (string element) => element == item.SurveyAnswerCategoryId.ToString())
					};
					list.Add(item2);
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
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult SurveyAnswerValues(string token = "", string tokenI = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int result2 = 0;
		int result3 = 0;
		int result4 = 0;
		int result5 = 0;
		int result6 = 0;
		int result7 = 0;
		bool flag = false;
		string text2 = "";
		if (!string.IsNullOrWhiteSpace(token))
		{
			text2 = DeCode(token);
		}
		if (!string.IsNullOrWhiteSpace(tokenI))
		{
			text2 = tokenI.Replace("AB", "").Replace("AC", "").Replace("AD", "")
				.Replace("AE", "")
				.Replace("AF", "")
				.Replace("AG", "");
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			string[] array = text2.Split(new char[1] { '|' });
			int.TryParse(array[0], out result2);
			int.TryParse(array[1], out result3);
			int.TryParse(array[2], out result4);
			int.TryParse(array[3], out result5);
			int.TryParse(array[4], out result6);
			int.TryParse(array[5], out result7);
			int result8 = 0;
			flag = false;
			if (Enumerable.Count<string>((IEnumerable<string>)array) >= 7)
			{
				int.TryParse(array[6], out result8);
				if (result8 == 1)
				{
					flag = true;
				}
			}
		}
		if (result4 <= 0 && result5 <= 0)
		{
			text = Labels.SurveyPreview;
		}
		else
		{
			CRMspSelectSurveyHistoryWithId_Result cRMspSelectSurveyHistoryWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyHistoryWithId_Result>((IEnumerable<CRMspSelectSurveyHistoryWithId_Result>)_db.CRMspSelectSurveyHistoryWithId(result6, lCID, result));
			if (cRMspSelectSurveyHistoryWithId_Result == null)
			{
				text = Messages.SurveyMsgNotFound;
			}
			else if (!string.IsNullOrWhiteSpace(cRMspSelectSurveyHistoryWithId_Result.surhReplyExpireDatePersian) && DateTime.Compare(cRMspSelectSurveyHistoryWithId_Result.surhReplyExpireDate ?? DateTime.Now, DateTime.Now) < 0)
			{
				text = Messages.msgErrorLinkExpired;
			}
			else if (!string.IsNullOrWhiteSpace(cRMspSelectSurveyHistoryWithId_Result.surhRepliedDatePersian))
			{
				text = Labels.SrvSurveyReplied;
			}
		}
		base.ViewBag.SysPartId = result2;
		base.ViewBag.sysPartObjId = result3;
		if (result4 > 0)
		{
			base.ViewBag.ReplyCompanyId = result4;
		}
		if (result5 > 0)
		{
			base.ViewBag.ReplyUserId = result5;
		}
		base.ViewBag.HistoryId = result6;
		base.ViewBag.SurveyId = result7;
		base.ViewBag.ShowValues = flag;
		base.ViewBag.Message = text;
		return View();
	}

	public ActionResult _PartialSurveyAnswerValues(int surveyId = 0, string message = "", bool showValues = false, int historyId = 0, int sysPartId = 0, int sysPartObjId = 0, int? replyCompanyId = null, int? replyUserId = null)
	{
		base.ViewBag.SurveyObj = SelectSurveyValueListTree(surveyId, showValues, historyId, sysPartId, sysPartObjId, replyCompanyId, replyUserId);
		base.ViewBag.Message = message;
		return PartialView();
	}

	public SurveyViewModelObj SelectSurveyValueListTree(int surveyId = 0, bool showValues = false, int historyId = 0, int sysPartId = 0, int sysPartObjId = 0, int? replyCompanyId = null, int? replyUserId = null)
	{
		SurveyViewModelObj surveyViewModelObj = new SurveyViewModelObj();
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
			CRMspSelectSurveyWithId_Result cRMspSelectSurveyWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(surveyId, lCID, result));
			if (cRMspSelectSurveyWithId_Result != null)
			{
				surveyViewModelObj.SurveyId = cRMspSelectSurveyWithId_Result.SurveyId;
				surveyViewModelObj.surDefSendSettingId = cRMspSelectSurveyWithId_Result.surDefSendSettingId.GetValueOrDefault();
				surveyViewModelObj.surDefSendSetting = cRMspSelectSurveyWithId_Result.surDefSendSettingTitle;
				surveyViewModelObj.surSystemPartId = cRMspSelectSurveyWithId_Result.surSystemPartId;
				surveyViewModelObj.surSystemPart = cRMspSelectSurveyWithId_Result.surSystemPart;
				surveyViewModelObj.surSystemPartTitle = cRMspSelectSurveyWithId_Result.surSystemPartTitle;
				surveyViewModelObj.surTitle = cRMspSelectSurveyWithId_Result.surTitle;
				surveyViewModelObj.surDesc = cRMspSelectSurveyWithId_Result.surDesc;
				surveyViewModelObj.surInactive = cRMspSelectSurveyWithId_Result.surInactive.GetValueOrDefault();
				surveyViewModelObj.OrderView = cRMspSelectSurveyWithId_Result.OrderView;
				surveyViewModelObj.FirstSurveyId = cRMspSelectSurveyWithId_Result.FirstSurveyId.GetValueOrDefault();
				surveyViewModelObj.PriorSurveyId = cRMspSelectSurveyWithId_Result.PriorSurveyId.GetValueOrDefault();
				surveyViewModelObj.NextSurveyId = cRMspSelectSurveyWithId_Result.NextSurveyId.GetValueOrDefault();
				surveyViewModelObj.LastSurveyId = cRMspSelectSurveyWithId_Result.LastSurveyId.GetValueOrDefault();
				surveyViewModelObj.surReplyAfterLogin = cRMspSelectSurveyWithId_Result.surReplyAfterLogin;
				surveyViewModelObj.SurveyAnswerShowValues = showValues;
				List<CRMspSelectSurveyAnswerValue_Result> list = new List<CRMspSelectSurveyAnswerValue_Result>();
				if (showValues)
				{
					list = Enumerable.ToList<CRMspSelectSurveyAnswerValue_Result>((IEnumerable<CRMspSelectSurveyAnswerValue_Result>)_db_spI.CRMspSelectSurveyAnswerValue(surveyId, historyId, replyUserId, replyCompanyId, sysPartId, sysPartObjId, lCID, result, result2));
				}
				surveyViewModelObj.lstQuestionsCount = 0;
				List<CRMspSelectSurveyQuestions_Result> list2 = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(cRMspSelectSurveyWithId_Result.SurveyId, lCID, result));
				if (list2 != null)
				{
					surveyViewModelObj.lstQuestionsCount = list2.Count;
					List<SurveyQuestionViewModelObj> list3 = new List<SurveyQuestionViewModelObj>();
					foreach (CRMspSelectSurveyQuestions_Result item in list2)
					{
						SurveyQuestionViewModelObj question = new SurveyQuestionViewModelObj();
						question.SurveyQuestionId = item.surveyQuestionId;
						question.SurveyQuestionSurveyId = item.SurveyQuestionSurveyId;
						question.SurveyQuestionSurvey = item.Survey;
						question.SurveyQuestion = item.SurveyQuestion;
						question.SurveyQuestionTypeId = item.SurveyQuestionTypeId;
						question.OrderView = item.OrderView;
						CRMspSelectSurveyAnswerValue_Result cRMspSelectSurveyAnswerValue_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerValue_Result>((IEnumerable<CRMspSelectSurveyAnswerValue_Result>)list, (Func<CRMspSelectSurveyAnswerValue_Result, bool>)((CRMspSelectSurveyAnswerValue_Result x) => x.suravQuestionId == question.SurveyQuestionId));
						if (showValues && item.SurveyQuestionTypeId == 3 && cRMspSelectSurveyAnswerValue_Result != null)
						{
							question.SurveyAnswerValueStr = cRMspSelectSurveyAnswerValue_Result.suravTextValue;
						}
						question.lstAnswersCount = 0;
						List<CRMspSelectSurveyAnswers_Result> list4 = Enumerable.ToList<CRMspSelectSurveyAnswers_Result>((IEnumerable<CRMspSelectSurveyAnswers_Result>)_db.CRMspSelectSurveyAnswers(item.surveyQuestionId, lCID, result));
						if (list4 != null)
						{
							question.lstAnswersCount = list4.Count;
							List<SurveyAnswerViewModelObj> list5 = new List<SurveyAnswerViewModelObj>();
							foreach (CRMspSelectSurveyAnswers_Result answeritem in list4)
							{
								SurveyAnswerViewModelObj surveyAnswerViewModelObj = new SurveyAnswerViewModelObj();
								surveyAnswerViewModelObj.SurveyAnswerId = answeritem.surveyAnswerId;
								surveyAnswerViewModelObj.SurveyAnswerSurveyId = answeritem.SurveyAnswerSurveyId;
								surveyAnswerViewModelObj.SurveyAnswerSurvey = answeritem.SurveyAnswerSurvey;
								surveyAnswerViewModelObj.SurveyAnswerQuestionId = answeritem.SurveyAnswerQuestionId;
								surveyAnswerViewModelObj.SurveyAnswerQuestion = answeritem.SurveyAnswerQuestion;
								surveyAnswerViewModelObj.SurveyAnswer = answeritem.SurveyAnswer;
								surveyAnswerViewModelObj.SurveyAnswerCategoryIds = answeritem.SurveyAnswerCategoryIds;
								surveyAnswerViewModelObj.SurveyAnswerCategoryIdsTitle = GetCategorys(item.surveyQuestionId, answeritem.SurveyAnswerCategoryIds);
								surveyAnswerViewModelObj.SurveyAnswerDefCategoryId = answeritem.SurveyAnswerDefCategoryId;
								surveyAnswerViewModelObj.SurveyAnswerDefCategory = answeritem.SurveyAnswerDefCategory;
								surveyAnswerViewModelObj.OrderView = answeritem.OrderView;
								if (showValues && list != null && list.Count > 0)
								{
									cRMspSelectSurveyAnswerValue_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyAnswerValue_Result>((IEnumerable<CRMspSelectSurveyAnswerValue_Result>)list, (Func<CRMspSelectSurveyAnswerValue_Result, bool>)((CRMspSelectSurveyAnswerValue_Result x) => x.suravQuestionId == question.SurveyQuestionId && x.suravAnswerId == answeritem.surveyAnswerId));
									if (cRMspSelectSurveyAnswerValue_Result != null && (question.SurveyQuestionTypeId == 1 || question.SurveyQuestionTypeId == 2 || question.SurveyQuestionTypeId == 4))
									{
										surveyAnswerViewModelObj.SurveyAnswerValueBool = true;
									}
								}
								list5.Add(surveyAnswerViewModelObj);
							}
							question.lstAnswers = list5;
						}
						question.lstCategorysCount = 0;
						List<CRMspSelectSurveyAnswerCategory_Result> list6 = Enumerable.ToList<CRMspSelectSurveyAnswerCategory_Result>((IEnumerable<CRMspSelectSurveyAnswerCategory_Result>)_db.CRMspSelectSurveyAnswerCategory(item.surveyQuestionId, lCID, result));
						if (list6 != null)
						{
							question.lstCategorysCount = list6.Count;
							List<SurveyAnswerCategoryViewModelObj> list7 = new List<SurveyAnswerCategoryViewModelObj>();
							foreach (CRMspSelectSurveyAnswerCategory_Result item2 in list6)
							{
								SurveyAnswerCategoryViewModelObj surveyAnswerCategoryViewModelObj = new SurveyAnswerCategoryViewModelObj();
								surveyAnswerCategoryViewModelObj.SurveyAnswerCategoryId = item2.SurveyAnswerCategoryId;
								surveyAnswerCategoryViewModelObj.SurveyAnswerCategoryTitle = item2.SurveyAnswerCategoryTitle;
								surveyAnswerCategoryViewModelObj.SurveyAnswerCategorySurveyId = item2.SurveyAnswerCategorySurveyId;
								surveyAnswerCategoryViewModelObj.SurveyAnswerCategorySurvey = item2.SurveyAnswerCategorySurvey;
								surveyAnswerCategoryViewModelObj.SurveyAnswerCategoryQuestionId = item2.SurveyAnswerCategoryQuestionId;
								surveyAnswerCategoryViewModelObj.SurveyAnswerCategoryQuestion = item2.SurveyAnswerCategoryQuestion;
								surveyAnswerCategoryViewModelObj.OrderView = item2.OrderView;
								surveyAnswerCategoryViewModelObj.lstCategoryDetailsCount = 0;
								List<CRMspSelectSurveyAnswerCategoryDetails_Result> list8 = Enumerable.ToList<CRMspSelectSurveyAnswerCategoryDetails_Result>((IEnumerable<CRMspSelectSurveyAnswerCategoryDetails_Result>)_db.CRMspSelectSurveyAnswerCategoryDetails(item2.SurveyAnswerCategoryId, lCID, result));
								if (list8 != null)
								{
									surveyAnswerCategoryViewModelObj.lstCategoryDetailsCount = list8.Count;
									List<SurveyAnswerCategoryDetailsViewModelObj> list9 = new List<SurveyAnswerCategoryDetailsViewModelObj>();
									foreach (CRMspSelectSurveyAnswerCategoryDetails_Result item3 in list8)
									{
										SurveyAnswerCategoryDetailsViewModelObj surveyAnswerCategoryDetailsViewModelObj = new SurveyAnswerCategoryDetailsViewModelObj();
										surveyAnswerCategoryDetailsViewModelObj.SurveyAnswerCategoryDetailId = item3.SurveyAnswerCategoryDetailId;
										surveyAnswerCategoryDetailsViewModelObj.suracdSurveyId = surveyAnswerCategoryViewModelObj.SurveyAnswerCategorySurveyId;
										surveyAnswerCategoryDetailsViewModelObj.suracdQuestionId = surveyAnswerCategoryViewModelObj.SurveyAnswerCategoryQuestionId;
										surveyAnswerCategoryDetailsViewModelObj.suracdCategoryId = item3.suracdCategoryId;
										surveyAnswerCategoryDetailsViewModelObj.suracdCategory = item3.suracdCategory;
										surveyAnswerCategoryDetailsViewModelObj.suracdDetailTitle = item3.suracdDetailTitle;
										surveyAnswerCategoryDetailsViewModelObj.suracdInactive = item3.suracdInactive.GetValueOrDefault();
										surveyAnswerCategoryDetailsViewModelObj.OrderView = item3.OrderView;
										list9.Add(surveyAnswerCategoryDetailsViewModelObj);
									}
									surveyAnswerCategoryViewModelObj.lstCategoryDetails = list9;
								}
								list7.Add(surveyAnswerCategoryViewModelObj);
							}
							question.lstCategorys = list7;
						}
						list3.Add(question);
					}
					surveyViewModelObj.lstQuestions = list3;
				}
			}
			else
			{
				surveyViewModelObj.SurveyId = 0;
				surveyViewModelObj.surDefSendSettingId = 0;
				surveyViewModelObj.surSystemPartId = 0;
				surveyViewModelObj.surSystemPart = "";
				surveyViewModelObj.surSystemPartTitle = "";
				surveyViewModelObj.surTitle = "";
				surveyViewModelObj.surDesc = "";
				surveyViewModelObj.surInactive = false;
				surveyViewModelObj.OrderView = 0;
				surveyViewModelObj.FirstSurveyId = 0;
				surveyViewModelObj.PriorSurveyId = 0;
				surveyViewModelObj.NextSurveyId = 0;
				surveyViewModelObj.LastSurveyId = 0;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return surveyViewModelObj;
	}

	[AjaxOnly]
	public string InsertEditSurveyValues(int sysPartId = 0, int sysPartObjId = 0, int? replyCompanyId = null, int? replyUserId = null, int historyId = 0, int surveyId = 0, string jsAnswerValues = "", string jsCategoryDetailValues = "")
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string text2 = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(jsAnswerValues))
			{
				List<SurveyAnswerValuesViewModel> list = new JavaScriptSerializer().Deserialize<List<SurveyAnswerValuesViewModel>>(jsAnswerValues);
				if (Enumerable.Any<SurveyAnswerValuesViewModel>((IEnumerable<SurveyAnswerValuesViewModel>)list))
				{
					list = Enumerable.ToList<SurveyAnswerValuesViewModel>(Enumerable.Where<SurveyAnswerValuesViewModel>((IEnumerable<SurveyAnswerValuesViewModel>)list, (Func<SurveyAnswerValuesViewModel, bool>)((SurveyAnswerValuesViewModel m) => m.questionId > 0 || string.IsNullOrWhiteSpace(m.textValue))));
					foreach (SurveyAnswerValuesViewModel item in list)
					{
						int? answerId = null;
						if (item.answerId > 0 || !string.IsNullOrWhiteSpace(item.textValue))
						{
							if (item.answerId > 0 && item.questionTypeId != 3)
							{
								answerId = item.answerId;
							}
							ObjectParameter objectParameter = new ObjectParameter("InsertedId", -1);
							_db_spI.CRMspInsertSurveyAnswerValue(sysPartId, sysPartObjId, replyCompanyId, replyUserId, historyId, surveyId, item.questionId, answerId, item.textValue, userId, value2, value3, value, text2, appType, lCID, result, objectParameter, result2);
							if (objectParameter != null && int.Parse(objectParameter.Value.ToString()) <= 0)
							{
								text += Messages.SurveyMsgErrorAnswerValue;
							}
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(jsCategoryDetailValues))
			{
				List<SurveyCategoryDetailValuesViewModel> list2 = new JavaScriptSerializer().Deserialize<List<SurveyCategoryDetailValuesViewModel>>(jsCategoryDetailValues);
				if (Enumerable.Any<SurveyCategoryDetailValuesViewModel>((IEnumerable<SurveyCategoryDetailValuesViewModel>)list2))
				{
					list2 = Enumerable.ToList<SurveyCategoryDetailValuesViewModel>(Enumerable.Where<SurveyCategoryDetailValuesViewModel>((IEnumerable<SurveyCategoryDetailValuesViewModel>)list2, (Func<SurveyCategoryDetailValuesViewModel, bool>)((SurveyCategoryDetailValuesViewModel m) => m.categoryDetailId > 0)));
					foreach (SurveyCategoryDetailValuesViewModel item2 in list2)
					{
						ObjectParameter insertedId = new ObjectParameter("InsertedId", -1);
						_db_spI.CRMspInsertSurveyAnswerCategoryDetailValue(replyCompanyId, replyUserId, historyId, item2.questionId, item2.answerId, item2.categoryDetailId, userId, value2, value3, value, text2, appType, lCID, result, insertedId, result2);
					}
				}
			}
			_db_spI.CRMspUpdateSurveyHistoryReplyDates(historyId, value, text2, value2, value3, userId, value, text2);
			if (string.IsNullOrWhiteSpace(text))
			{
				_db_spII.ScorespInsertAndCalcSurveyScores(historyId, surveyId, null, null, userId, value2, value3, value, text2, appType, lCID, result, true, result2, true);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmSurDefineSurvey", ActionName = "actShowSurveyValues")]
	public ActionResult ShowSurveyValues(int surveyId = 0)
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
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectSurvey_Result> list2 = Enumerable.ToList<CRMspSelectSurvey_Result>((IEnumerable<CRMspSelectSurvey_Result>)_db.CRMspSelectSurvey(lCID, result, result2));
			if (list2 != null && list2.Count > 0)
			{
				foreach (CRMspSelectSurvey_Result item in list2)
				{
					list.Add(new SelectListItem
					{
						Text = item.surTitle,
						Value = item.SurveyId.ToString(),
						Selected = (item.SurveyId == surveyId)
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SurveysList = list;
		base.ViewBag.SurveyId = surveyId;
		base.ViewBag.SystemParts = SelectSystemParts(lCID, result);
		return View();
	}

	public JsonResult SelectSurveyHistorys(int surveyId = 0, int systemPartId = 0)
	{
		List<CRMspSelectSurveyHistoryWithSurveyId_Result> list = new List<CRMspSelectSurveyHistoryWithSurveyId_Result>();
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
			list = Enumerable.ToList<CRMspSelectSurveyHistoryWithSurveyId_Result>((IEnumerable<CRMspSelectSurveyHistoryWithSurveyId_Result>)_db_spI.CRMspSelectSurveyHistoryWithSurveyId(surveyId, systemPartId, lCID, result, result2));
			if (list != null && list.Count > 0)
			{
				foreach (CRMspSelectSurveyHistoryWithSurveyId_Result item in list)
				{
					if (item.surhSendDate.HasValue)
					{
						item.surhSendDatePersian = item.surhSendDate?.ToString("yyyy/MM/dd", new PersianCulture());
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd", new PersianCulture());
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartSurveyAnswerValues_Old(int surveyId = 0, int systemPartId = 0, int historyId = 0)
	{
		List<CRMspChartSurveyAnswerValues_Result> data = new List<CRMspChartSurveyAnswerValues_Result>();
		try
		{
			if (surveyId > 0 && systemPartId > 0 && historyId > 0)
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
				data = Enumerable.ToList<CRMspChartSurveyAnswerValues_Result>((IEnumerable<CRMspChartSurveyAnswerValues_Result>)_db_spI.CRMspChartSurveyAnswerValues(surveyId, systemPartId, historyId, lCID, result, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ChartSurveyAnswerValues(int surveyId = 0)
	{
		SurveyAnswerValuesCntChartViewModel surveyAnswerValuesCntChartViewModel = new SurveyAnswerValuesCntChartViewModel();
		surveyAnswerValuesCntChartViewModel.Questions = new List<SurveyQuestionAnswerValuesCntChartViewModel>();
		try
		{
			if (surveyId > 0)
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
				List<CRMspSelectSurveyQuestions_Result> list = Enumerable.ToList<CRMspSelectSurveyQuestions_Result>((IEnumerable<CRMspSelectSurveyQuestions_Result>)_db.CRMspSelectSurveyQuestions(surveyId, lCID, result));
				if (list != null)
				{
					foreach (CRMspSelectSurveyQuestions_Result item in list)
					{
						SurveyQuestionAnswerValuesCntChartViewModel surveyQuestionAnswerValuesCntChartViewModel = new SurveyQuestionAnswerValuesCntChartViewModel();
						surveyQuestionAnswerValuesCntChartViewModel.SurveyQuestionId = item.surveyQuestionId;
						surveyQuestionAnswerValuesCntChartViewModel.SurveyQuestion = item.SurveyQuestion;
						surveyQuestionAnswerValuesCntChartViewModel.SurveyQuestionTypeId = item.SurveyQuestionTypeId;
						surveyQuestionAnswerValuesCntChartViewModel.SurveyAnswerValuesCount = new List<CRMspSelectSurveyAnswerValuesCount_Result>();
						List<CRMspSelectSurveyAnswerValuesCount_Result> list2 = Enumerable.ToList<CRMspSelectSurveyAnswerValuesCount_Result>((IEnumerable<CRMspSelectSurveyAnswerValuesCount_Result>)_db_spI.CRMspSelectSurveyAnswerValuesCount(item.surveyQuestionId, lCID, result, result2));
						if (list2 != null)
						{
							surveyQuestionAnswerValuesCntChartViewModel.SurveyAnswerValuesCount = list2;
						}
						surveyAnswerValuesCntChartViewModel.Questions.Add(surveyQuestionAnswerValuesCntChartViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(surveyAnswerValuesCntChartViewModel, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectSurveyAnswerValueWithQuesId(int surveyId = 0, int systemPartId = 0, int historyId = 0, int questionId = 0)
	{
		List<CRMspSelectSurveyAnswerValueWithQuesId_Result> data = new List<CRMspSelectSurveyAnswerValueWithQuesId_Result>();
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
			data = Enumerable.ToList<CRMspSelectSurveyAnswerValueWithQuesId_Result>((IEnumerable<CRMspSelectSurveyAnswerValueWithQuesId_Result>)_db_spI.CRMspSelectSurveyAnswerValueWithQuesId(surveyId, systemPartId, historyId, questionId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectSurveyAnswerTextValues(int surveyId = 0, int historyId = 0)
	{
		List<CRMspSelectSurveyAnswerTextValues_Result> list = new List<CRMspSelectSurveyAnswerTextValues_Result>();
		try
		{
			if (surveyId > 0)
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
				list = Enumerable.ToList<CRMspSelectSurveyAnswerTextValues_Result>((IEnumerable<CRMspSelectSurveyAnswerTextValues_Result>)_db_spI.CRMspSelectSurveyAnswerTextValues(surveyId, historyId, lCID, result, result2));
				if (list != null)
				{
					foreach (CRMspSelectSurveyAnswerTextValues_Result item in list)
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult ShowSurveyValueDetails(int surveyId = 0, int questionId = 0, int historyId = 0, int systemPartId = 0)
	{
		List<CRMspSelectSurveyAnswerValueWithQuesId_Result> list = new List<CRMspSelectSurveyAnswerValueWithQuesId_Result>();
		if (questionId > 0)
		{
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
				list = Enumerable.ToList<CRMspSelectSurveyAnswerValueWithQuesId_Result>((IEnumerable<CRMspSelectSurveyAnswerValueWithQuesId_Result>)_db_spI.CRMspSelectSurveyAnswerValueWithQuesId(surveyId, systemPartId, historyId, questionId, lCID, result, result2));
				if (list != null)
				{
					foreach (CRMspSelectSurveyAnswerValueWithQuesId_Result item in list)
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		base.ViewBag.QuestionValuesList = list;
		return View();
	}

	public string ShowSurveyValueDetailsJs(int surveyId = 0, int questionId = 0, int historyId = 0, int systemPartId = 0)
	{
		List<CRMspSelectSurveyAnswerValueWithQuesId_Result> list = new List<CRMspSelectSurveyAnswerValueWithQuesId_Result>();
		if (questionId > 0)
		{
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
				list = Enumerable.ToList<CRMspSelectSurveyAnswerValueWithQuesId_Result>((IEnumerable<CRMspSelectSurveyAnswerValueWithQuesId_Result>)_db_spI.CRMspSelectSurveyAnswerValueWithQuesId(surveyId, systemPartId, historyId, questionId, lCID, result, result2));
				if (list != null)
				{
					foreach (CRMspSelectSurveyAnswerValueWithQuesId_Result item in list)
					{
						item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd");
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return JsonConvert.SerializeObject(list);
	}

	public JsonResult MakeSurveyLink(string token = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		if (!string.IsNullOrWhiteSpace(token))
		{
			int result2 = 0;
			int.TryParse(token.Split(new char[1] { '|' })[5], out result2);
			Uri url = base.HttpContext.Request.Url;
			string text = url.Scheme + "://" + url.Authority;
			string text2 = "";
			for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)url.Segments) - 1; i++)
			{
				text += url.Segments[i];
			}
			text = text + "SurveyAnswerValues?token=" + Code(token);
			list.Add(new SelectListItem
			{
				Text = Labels.InternalLink,
				Value = text,
				Selected = false
			});
			CRMspSelectSurveyWithId_Result cRMspSelectSurveyWithId_Result = Enumerable.FirstOrDefault<CRMspSelectSurveyWithId_Result>((IEnumerable<CRMspSelectSurveyWithId_Result>)_db.CRMspSelectSurveyWithId(result2, lCID, result));
			if (cRMspSelectSurveyWithId_Result != null)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)_db.CRMspSelectCrmsysSetting(lCID, result));
				if (cRMspSelectSurveyWithId_Result.surReplyAfterLogin.GetValueOrDefault())
				{
					if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCrmsysSetting_Result.FOUrl))
					{
						text2 = cRMspSelectCrmsysSetting_Result.FOUrl.Trim();
						if (!text2.Contains("http"))
						{
							text2 = url.Scheme + "://" + text2;
						}
						if (text2.EndsWith("/"))
						{
							text2 = text2.Substring(0, text2.Length - 1);
						}
						text2 = text2 + "/Survey/Home?token=" + Code(token);
					}
					else
					{
						text2 = text;
					}
				}
				else if (cRMspSelectCrmsysSetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCrmsysSetting_Result.CrmIPStatic))
				{
					text2 = cRMspSelectCrmsysSetting_Result.CrmIPStatic.Trim();
					if (!text2.Contains("http"))
					{
						text2 = url.Scheme + "://" + text2;
					}
					if (text2.EndsWith("/"))
					{
						text2 = text2.Substring(0, text2.Length - 1);
					}
					text2 = text2 + "/Survey/Register/Index?token=" + Code(token);
				}
				else
				{
					text2 = text;
				}
			}
			else
			{
				text2 = text;
			}
			list.Add(new SelectListItem
			{
				Text = Labels.ExternalLink + "(" + Labels.ExternalLinkDescForSendAllOutUsers + ")",
				Value = text2,
				Selected = false
			});
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult MakeSurveyShortLink(string surveyLink, int surveyId, string surhReplyExpireDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		short.Parse(Financial.Get().Id.ToString());
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		string appType = Configuration.AppType;
		Uri uri = new Uri(surveyLink);
		string text = uri.Scheme + "://" + uri.Authority;
		ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
		DateTime? expireDate = null;
		if (!string.IsNullOrEmpty(surhReplyExpireDate))
		{
			try
			{
				expireDate = DateTime.Parse(surhReplyExpireDate + " 00:00:00");
			}
			catch (Exception)
			{
				expireDate = null;
			}
		}
		_dbII.CRMspInsertShortLink(surveyLink, 160, surveyId, null, null, null, null, expireDate, null, userId, now, registerDatePersian, appType, lCID, text, objectParameter);
		string text2 = objectParameter.Value?.ToString();
		string data = text + "/s/" + text2 + " ";
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public string Code(string val = "")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(val))
		{
			try
			{
				result = CodeDecode.CoddingUTF8(val);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public string DeCode(string val = "")
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(val))
		{
			try
			{
				result = CodeDecode.DeCoddingUTF8(val);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	public JsonResult SelectCompanyById(int id = 0)
	{
		CRMspSelectCompanyById_Result data = new CRMspSelectCompanyById_Result();
		try
		{
			if (id > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				data = CRMIdeal.Classes.Helper.Company.GetCompanyById(id);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectUsersById(int id = 0)
	{
		CRMspSelectUsersById_Result data = new CRMspSelectUsersById_Result();
		try
		{
			if (id > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				data = CRMIdeal.Classes.Helper.User.SelectUsersById(id);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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
		_db_spI.Dispose();
		base.Dispose(disposing);
	}
}
