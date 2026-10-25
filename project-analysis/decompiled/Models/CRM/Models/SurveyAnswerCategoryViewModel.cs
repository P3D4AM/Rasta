using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SurveyAnswerCategoryViewModel
{
	[Key]
	public int SurveyAnswerCategoryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswerCategoryQuestionId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string SurveyAnswerCategoryTitle { get; set; }

	public string SurveyAnswerCategoryTitle_Lang { get; set; }

	public int SurveyAnswerCategorySurveyId { get; set; }

	public string SurveyAnswerCategorySurvey { get; set; }

	public int SurveyAnswerCategoryQuestionId { get; set; }

	public string SurveyAnswerCategoryQuestion { get; set; }

	public int? OrderView { get; set; }

	public bool CategoryValueBool { get; set; }
}
