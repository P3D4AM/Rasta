using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveySendSettingMetadata))]
public class CrmSurveySendSetting
{
	public int SurveySendSettingId { get; set; }

	public string surssTitle { get; set; }

	public bool? surssSmsSendByWeb { get; set; }

	public int? surssSmsProviderId { get; set; }

	public string surssSmsSendNumber { get; set; }

	public bool? surssSmsSendByGSM { get; set; }

	public string surssSmsSendGSMNmber { get; set; }

	public bool? surssSendByEmail { get; set; }

	public int? surssEmailSendUserInfoId { get; set; }

	public DateTime? surssSendStartDate { get; set; }

	public string surssSendStartDatePersian { get; set; }

	public DateTime? surssSendEndDate { get; set; }

	public string surssSendEndDatePersian { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual ICollection<CrmSurvey> CrmSurvey { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmSurveySendSetting_Lang> CrmSurveySendSetting_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsProviders SmsProviders { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurveySendSetting()
	{
		CrmSurvey = (ICollection<CrmSurvey>)new HashSet<CrmSurvey>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmSurveySendSetting_Lang = (ICollection<CrmSurveySendSetting_Lang>)new HashSet<CrmSurveySendSetting_Lang>();
	}
}
