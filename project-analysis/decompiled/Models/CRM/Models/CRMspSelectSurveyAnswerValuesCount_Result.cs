namespace CRM.Models;

public class CRMspSelectSurveyAnswerValuesCount_Result
{
	public int? Cnt { get; set; }

	public int SurveyAnswerId { get; set; }

	public int SurveyAnswerQuestionId { get; set; }

	public string SurveyAnswerQuestion { get; set; }

	public string SurveyAnswer { get; set; }

	public string SurveyAnswerCategoryIds { get; set; }

	public int? SurveyAnswerDefCategoryId { get; set; }

	public string SurveyAnswerDefCategory { get; set; }

	public int? OrderView { get; set; }
}
