using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswersMetadata))]
public class CrmSurveyAnswers
{
	public int SurveyAnswerId { get; set; }

	public int SurveyAnswerSurveyId { get; set; }

	public int SurveyAnswerQuestionId { get; set; }

	public string SurveyAnswer { get; set; }

	public string SurveyAnswerCategoryIds { get; set; }

	public int? SurveyAnswerDefCategoryId { get; set; }

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

	public virtual CrmSurvey CrmSurvey { get; set; }

	public virtual CrmSurveyAnswerCategory CrmSurveyAnswerCategory { get; set; }

	public virtual CrmSurveyQuestions CrmSurveyQuestions { get; set; }

	public virtual ICollection<CrmSurveyAnswers_Lang> CrmSurveyAnswers_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurveyAnswers()
	{
		CrmSurveyAnswers_Lang = (ICollection<CrmSurveyAnswers_Lang>)new HashSet<CrmSurveyAnswers_Lang>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
	}
}
