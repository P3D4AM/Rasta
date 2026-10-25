namespace CRM.Models;

public class SurveyAnswerValuesViewModel
{
	public int surveyId { get; set; }

	public int questionId { get; set; }

	public int questionTypeId { get; set; }

	public int answerId { get; set; }

	public string textValue { get; set; }
}
