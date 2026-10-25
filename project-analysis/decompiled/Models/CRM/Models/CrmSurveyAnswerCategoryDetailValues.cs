using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerCategoryDetailValuesMetadata))]
public class CrmSurveyAnswerCategoryDetailValues
{
	public int SurveyAnswerCategoryDetailValueId { get; set; }

	public int? suracdvReplyCompanyId { get; set; }

	public int? suracdvReplyUserId { get; set; }

	public int suracdvHistoryId { get; set; }

	public int suracdvQuestionId { get; set; }

	public int suracdvAnswerId { get; set; }

	public int suracdvAnswerCategoryDetailId { get; set; }

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

	public int? suracdvCId { get; set; }

	public virtual CrmSurveyAnswerCategoryDetails CrmSurveyAnswerCategoryDetails { get; set; }

	public virtual CrmSurveyHistory CrmSurveyHistory { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmSurveyAnswers CrmSurveyAnswers { get; set; }

	public virtual CrmSurveyQuestions CrmSurveyQuestions { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
