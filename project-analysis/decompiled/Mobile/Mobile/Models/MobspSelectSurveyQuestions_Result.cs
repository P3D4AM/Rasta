namespace Mobile.Models;

public class MobspSelectSurveyQuestions_Result
{
	public int SurveyQuestionId { get; set; }

	public int SurveyQuestionSurveyId { get; set; }

	public string SurveyQuestion { get; set; }

	public int SurveyQuestionTypeId { get; set; }

	public int? OrderView { get; set; }
}
