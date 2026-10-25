using System.Collections.Generic;

namespace CRM.Models;

public class SurveyQuestionViewModelObj : SurveyQuestionViewModel
{
	public int lstAnswersCount { get; set; }

	public List<SurveyAnswerViewModelObj> lstAnswers { get; set; }

	public int lstCategorysCount { get; set; }

	public List<SurveyAnswerCategoryViewModelObj> lstCategorys { get; set; }

	public int lstChartCnt { get; set; }

	public List<SurveyQuestionChartViewModel> lstChart { get; set; }
}
