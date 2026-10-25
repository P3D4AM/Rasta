using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SurveyAnswerViewModel
{
	[Key]
	public int SurveyAnswerId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SurveyAnswerSurveyId { get; set; }

	public string SurveyAnswerSurvey { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyQuestionTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SurveyAnswerQuestionId { get; set; }

	public string SurveyAnswerQuestion { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswer")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string SurveyAnswer { get; set; }

	public string SurveyAnswer_Lang { get; set; }

	public string SurveyAnswerCategoryIds { get; set; }

	public string SurveyAnswerCategoryIdsTitle { get; set; }

	public int? SurveyAnswerDefCategoryId { get; set; }

	public string SurveyAnswerDefCategory { get; set; }

	public int? OrderView { get; set; }

	public bool SurveyAnswerValueBool { get; set; }

	public int SurveyAnswerValueInt { get; set; }
}
