using System.Collections.Generic;

namespace CRM.Models;

public class SurveyViewModelObj : SurveyViewModel
{
	public int lstQuestionsCount { get; set; }

	public List<SurveyQuestionViewModelObj> lstQuestions { get; set; }
}
