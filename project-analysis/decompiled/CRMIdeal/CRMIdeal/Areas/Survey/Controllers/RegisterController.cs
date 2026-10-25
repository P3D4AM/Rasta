using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Survey.Controllers;

public class RegisterController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_spI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _db_spII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private const int UserId_Site = -10;

	public ActionResult Index(string token = "", string tokenI = "")
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

	[HttpPost]
	public string Index(int sysPartId = 0, int sysPartObjId = 0, int? replyCompanyId = null, int? replyUserId = null, int historyId = 0, int surveyId = 0, string jsAnswerValues = "", string jsCategoryDetailValues = "")
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
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
							_db_spI.CRMspInsertSurveyAnswerValue(sysPartId, sysPartObjId, replyCompanyId, replyUserId, historyId, surveyId, item.questionId, answerId, item.textValue, -10, value2, value3, value, text2, appType, lCID, result, objectParameter, (result2 == 0) ? null : new int?(result2));
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
						_db_spI.CRMspInsertSurveyAnswerCategoryDetailValue(replyCompanyId, replyUserId, historyId, item2.questionId, item2.answerId, item2.categoryDetailId, -10, value2, value3, value, text2, appType, lCID, result, insertedId, (result2 == 0) ? null : new int?(result2));
					}
				}
			}
			_db_spI.CRMspUpdateSurveyHistoryReplyDates(historyId, value, text2, value2, value3, -10, value, text2);
			if (string.IsNullOrWhiteSpace(text))
			{
				_db_spII.ScorespInsertAndCalcSurveyScores(historyId, surveyId, null, null, -10, value2, value3, value, text2, appType, lCID, result, true, (result2 == 0) ? null : new int?(result2), true);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		return text;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_db_spI.Dispose();
		base.Dispose(disposing);
	}
}
