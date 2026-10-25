using System;

namespace CRM.Models;

public class CRMspSelectSurveyHistoryWithSurveyId_Result
{
	public int SurveyHistoryId { get; set; }

	public int surhSurveyId { get; set; }

	public string surhSurvey { get; set; }

	public int? surhDefSendSettingId { get; set; }

	public string surhDefSendSetting { get; set; }

	public int surhSystemPartId { get; set; }

	public string surhSystemPart { get; set; }

	public int surhSystemPartObjectId { get; set; }

	public int? surhCmpId { get; set; }

	public string cmpName { get; set; }

	public int? surhPrsId { get; set; }

	public string surhPrs { get; set; }

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

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
