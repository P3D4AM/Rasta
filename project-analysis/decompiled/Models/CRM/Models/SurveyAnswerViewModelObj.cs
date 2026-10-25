using System.Collections.Generic;

namespace CRM.Models;

public class SurveyAnswerViewModelObj : SurveyAnswerViewModel
{
	public List<SurveyAnswerValueWithQuesIdViewModel> lstCompanies { get; set; }
}
