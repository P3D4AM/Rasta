using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyHistoryMetadata))]
public class CrmSurveyHistory
{
	public int SurveyHistoryId { get; set; }

	public int surhSurveyId { get; set; }

	public int? surhDefSendSettingId { get; set; }

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

	public int? surhCId { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmSurvey CrmSurvey { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual CrmSurveySendSetting CrmSurveySendSetting { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurveyHistory()
	{
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
	}
}
