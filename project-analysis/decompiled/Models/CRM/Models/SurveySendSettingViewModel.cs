using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SurveySendSettingViewModel
{
	[Key]
	public int SurveySendSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SurveySendSettingTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string surssTitle { get; set; }

	public string surssTitle_Lang { get; set; }

	public bool? surssSmsSendByWeb { get; set; }

	public int? surssSmsProviderId { get; set; }

	public string surssSmsProvider { get; set; }

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string surssSmsSendNumber { get; set; }

	public bool? surssSmsSendByGSM { get; set; }

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string surssSmsSendGSMNmber { get; set; }

	public bool? surssSendByEmail { get; set; }

	public int? surssEmailSendUserInfoId { get; set; }

	public string surssEmailSendUserInfo { get; set; }

	public DateTime? surssSendStartDate { get; set; }

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string surssSendStartDatePersian { get; set; }

	public DateTime? surssSendEndDate { get; set; }

	public string surssSendEndDatePersian { get; set; }

	public int? OrderView { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
