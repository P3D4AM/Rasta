using System;

namespace CRM.Models;

public class CRMspSelectSurveyAnswerCategory_Result
{
	public int SurveyAnswerCategoryId { get; set; }

	public string SurveyAnswerCategoryTitle { get; set; }

	public int SurveyAnswerCategorySurveyId { get; set; }

	public string SurveyAnswerCategorySurvey { get; set; }

	public int SurveyAnswerCategoryQuestionId { get; set; }

	public string SurveyAnswerCategoryQuestion { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
