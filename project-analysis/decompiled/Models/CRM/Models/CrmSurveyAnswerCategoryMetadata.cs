using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyAnswerCategoryMetadata
{
	[Key]
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
}
