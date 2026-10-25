using System;

namespace CRM.Models;

public class CRMspSelectSurveyAnswerCategoryDetailValues_Result
{
	public int SurveyAnswerCategoryDetailValueId { get; set; }

	public int? suracdvReplyCompanyId { get; set; }

	public int? suracdvReplyUserId { get; set; }

	public int suracdvHistoryId { get; set; }

	public int suracdvQuestionId { get; set; }

	public int suracdvAnswerId { get; set; }

	public int suracdvAnswerCategoryDetailId { get; set; }

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

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
