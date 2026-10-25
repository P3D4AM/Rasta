using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SurveyQuestionViewModel
{
	[Key]
	public int SurveyQuestionId { get; set; }

	public int SurveyQuestionSurveyId { get; set; }

	public string SurveyQuestionSurvey { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyQuestionTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string SurveyQuestion { get; set; }

	public string SurveyQuestion_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyQuestionTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SurveyQuestionTypeId { get; set; }

	public int? OrderView { get; set; }

	public string SurveyAnswerValueStr { get; set; }
}
