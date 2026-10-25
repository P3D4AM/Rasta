using System.Collections.Generic;

namespace CRM.Models;

public class SurveyAnswerCategoryViewModelObj : SurveyAnswerCategoryViewModel
{
	public int lstCategoryDetailsCount { get; set; }

	public List<SurveyAnswerCategoryDetailsViewModelObj> lstCategoryDetails { get; set; }
}
