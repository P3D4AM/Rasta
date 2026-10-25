using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyMetadata))]
public class CrmSurvey
{
	public int SurveyId { get; set; }

	public int? surDefSendSettingId { get; set; }

	public int surSystemPartId { get; set; }

	public string surTitle { get; set; }

	public string surDesc { get; set; }

	public bool? surInactive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public bool? surReplyAfterLogin { get; set; }

	public string surCIds { get; set; }

	public string surCenterInfoJs { get; set; }

	public virtual CrmSurveySendSetting CrmSurveySendSetting { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual ICollection<CrmSurvey_Lang> CrmSurvey_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategory> CrmSurveyAnswerCategory { get; set; }

	public virtual ICollection<CrmSurveyAnswers> CrmSurveyAnswers { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmSurveyQuestions> CrmSurveyQuestions { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurvey()
	{
		CrmSurvey_Lang = (ICollection<CrmSurvey_Lang>)new HashSet<CrmSurvey_Lang>();
		CrmSurveyAnswerCategory = (ICollection<CrmSurveyAnswerCategory>)new HashSet<CrmSurveyAnswerCategory>();
		CrmSurveyAnswers = (ICollection<CrmSurveyAnswers>)new HashSet<CrmSurveyAnswers>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmSurveyQuestions = (ICollection<CrmSurveyQuestions>)new HashSet<CrmSurveyQuestions>();
	}
}
