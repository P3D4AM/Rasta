using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyQuestionsMetadata))]
public class CrmSurveyQuestions
{
	public int SurveyQuestionId { get; set; }

	public int SurveyQuestionSurveyId { get; set; }

	public string SurveyQuestion { get; set; }

	public int SurveyQuestionTypeId { get; set; }

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

	public virtual ICollection<CrmSurveyAnswerCategory> CrmSurveyAnswerCategory { get; set; }

	public virtual ICollection<CrmSurveyAnswers> CrmSurveyAnswers { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyQuestions_Lang> CrmSurveyQuestions_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurveyQuestions()
	{
		CrmSurveyAnswerCategory = (ICollection<CrmSurveyAnswerCategory>)new HashSet<CrmSurveyAnswerCategory>();
		CrmSurveyAnswers = (ICollection<CrmSurveyAnswers>)new HashSet<CrmSurveyAnswers>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyQuestions_Lang = (ICollection<CrmSurveyQuestions_Lang>)new HashSet<CrmSurveyQuestions_Lang>();
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
	}
}
