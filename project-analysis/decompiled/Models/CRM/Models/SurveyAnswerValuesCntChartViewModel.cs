using System.Collections.Generic;

namespace CRM.Models;

public class SurveyAnswerValuesCntChartViewModel
{
	public int SurveyId { get; set; }

	public List<SurveyQuestionAnswerValuesCntChartViewModel> Questions { get; set; }
}
