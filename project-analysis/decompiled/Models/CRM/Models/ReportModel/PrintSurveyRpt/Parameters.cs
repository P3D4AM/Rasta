using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintSurveyRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public int SurveyId { get; set; }

	public string SurveyTitle { get; set; }

	public CRMspSelectSurveyWithId_Result SurveyDetails { get; set; }

	public List<SurveyQuestionViewModel> NotUsed_ListQuestions { get; set; }

	public List<SurveyAnswerViewModel> NotUsed_ListAnswers { get; set; }

	public List<SurveyAnswerCategoryViewModel> NotUsed_ListAnswerCategories { get; set; }

	public List<CRMspSelectSurveyAnswerCategoryDetails_Result> NotUsed_ListAnswerCategoryDetails { get; set; }
}
