using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SurveyAnswerCategoryDetailsViewModel
{
	[Key]
	public int SurveyAnswerCategoryDetailId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswerCategoryDetailSurvey")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int suracdSurveyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswerCategoryDetailQuestionTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int suracdQuestionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswerCategoryDetailCategory")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int suracdCategoryId { get; set; }

	public string suracdCategory { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswerCategoryDetailTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string suracdDetailTitle { get; set; }

	public string suracdDetailTitle_Lang { get; set; }

	public bool suracdInactive { get; set; }

	public int? OrderView { get; set; }

	public bool CategoryDetailValueBool { get; set; }
}
