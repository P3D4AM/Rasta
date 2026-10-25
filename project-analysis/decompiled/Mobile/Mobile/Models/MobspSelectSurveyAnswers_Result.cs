namespace Mobile.Models;

public class MobspSelectSurveyAnswers_Result
{
	public int SurveyAnswerId { get; set; }

	public int SurveyAnswerSurveyId { get; set; }

	public int SurveyAnswerQuestionId { get; set; }

	public string SurveyAnswer { get; set; }

	public string SurveyAnswerCategoryIds { get; set; }

	public int? SurveyAnswerDefCategoryId { get; set; }

	public int? OrderView { get; set; }
}
