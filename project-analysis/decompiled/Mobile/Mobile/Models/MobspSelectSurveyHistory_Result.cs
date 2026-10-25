using System;

namespace Mobile.Models;

public class MobspSelectSurveyHistory_Result
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
}
