using System;

namespace CRM.Models;

public class CRMspSelectSurveyAnswerTextValues_Result
{
	public int SurveyAnswerValueId { get; set; }

	public int suravSystemPartId { get; set; }

	public string suravSystemPart { get; set; }

	public int suravSystemPartObjectId { get; set; }

	public int? suravReplyCompanyId { get; set; }

	public string cmpName { get; set; }

	public int? suravReplyUserId { get; set; }

	public string suravReplyUser { get; set; }

	public int suravHistoryId { get; set; }

	public int suravSurveyId { get; set; }

	public string suravSurvey { get; set; }

	public int suravQuestionId { get; set; }

	public string suravQuestion { get; set; }

	public int? suravAnswerId { get; set; }

	public string suravAnswer { get; set; }

	public string suravTextValue { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
