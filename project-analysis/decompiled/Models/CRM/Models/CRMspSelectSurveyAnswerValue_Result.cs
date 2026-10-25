using System;

namespace CRM.Models;

public class CRMspSelectSurveyAnswerValue_Result
{
	public int SurveyAnswerValueId { get; set; }

	public int suravSystemPartId { get; set; }

	public int suravSystemPartObjectId { get; set; }

	public int? suravReplyCompanyId { get; set; }

	public string suravReplyCompany { get; set; }

	public int? suravReplyUserId { get; set; }

	public string suravReplyUser { get; set; }

	public int suravHistoryId { get; set; }

	public int suravSurveyId { get; set; }

	public int suravQuestionId { get; set; }

	public int? suravAnswerId { get; set; }

	public string suravTextValue { get; set; }

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
