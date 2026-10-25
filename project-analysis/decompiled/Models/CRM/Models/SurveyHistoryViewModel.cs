using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class SurveyHistoryViewModel
{
	[Key]
	public int SurveyHistoryId { get; set; }

	public int surhSurveyId { get; set; }

	public string surhSurvey { get; set; }

	public int? surhDefSendSettingId { get; set; }

	public string surhDefSendSetting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveyAnswerCategoryDetailSurvey")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int surhSystemPartId { get; set; }

	public int surhSystemPartObjectId { get; set; }

	public int? surhCmpId { get; set; }

	public int? surhPrsId { get; set; }

	public string surhToMobileNumber { get; set; }

	public string surhToEmail { get; set; }

	public DateTime? surhRepliedDate { get; set; }

	public string surhRepliedDatePersian { get; set; }

	public DateTime? surhReplyExpireDate { get; set; }

	public string surhReplyExpireDatePersian { get; set; }

	public DateTime? surhSendDate { get; set; }

	public string surhSendDatePersian { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int RowNumber { get; set; }

	public bool isExpired { get; set; }

	public bool isAnswered { get; set; }

	public string surhSendSmsBody { get; set; }

	public string surhSendEmailSubject { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string surhSendEmailBody { get; set; }

	public int? SelectedMode { get; set; }

	public int? surhCId { get; set; }

	public string surhCenterName { get; set; }
}
