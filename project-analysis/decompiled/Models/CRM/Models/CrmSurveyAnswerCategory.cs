using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerCategoryMetadata))]
public class CrmSurveyAnswerCategory
{
	public int SurveyAnswerCategoryId { get; set; }

	public int SurveyAnswerCategorySurveyId { get; set; }

	public string SurveyAnswerCategoryTitle { get; set; }

	public int SurveyAnswerCategoryQuestionId { get; set; }

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

	public virtual CrmSurveyQuestions CrmSurveyQuestions { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategory_Lang> CrmSurveyAnswerCategory_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetails> CrmSurveyAnswerCategoryDetails { get; set; }

	public virtual ICollection<CrmSurveyAnswers> CrmSurveyAnswers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurveyAnswerCategory()
	{
		CrmSurveyAnswerCategory_Lang = (ICollection<CrmSurveyAnswerCategory_Lang>)new HashSet<CrmSurveyAnswerCategory_Lang>();
		CrmSurveyAnswerCategoryDetails = (ICollection<CrmSurveyAnswerCategoryDetails>)new HashSet<CrmSurveyAnswerCategoryDetails>();
		CrmSurveyAnswers = (ICollection<CrmSurveyAnswers>)new HashSet<CrmSurveyAnswers>();
	}
}
