using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SurveyViewModel
{
	[Key]
	public int SurveyId { get; set; }

	public int surDefSendSettingId { get; set; }

	public string surDefSendSetting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveySysPart")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int surSystemPartId { get; set; }

	public string surSystemPart { get; set; }

	public string surSystemPartTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string surTitle { get; set; }

	public string surTitle_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyDesc")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string surDesc { get; set; }

	public string surDesc_Lang { get; set; }

	public bool surInactive { get; set; }

	public int? OrderView { get; set; }

	public int FirstSurveyId { get; set; }

	public int PriorSurveyId { get; set; }

	public int NextSurveyId { get; set; }

	public int LastSurveyId { get; set; }

	public bool SurveyAnswerShowValues { get; set; }

	public bool? surReplyAfterLogin { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
