using System;

namespace CRM.Models;

public class CRMspSelectSurveyWithId_Result
{
	public int SurveyId { get; set; }

	public int? surDefSendSettingId { get; set; }

	public string surDefSendSettingTitle { get; set; }

	public int surSystemPartId { get; set; }

	public string surSystemPart { get; set; }

	public string surSystemPartTitle { get; set; }

	public string surTitle { get; set; }

	public string surDesc { get; set; }

	public bool? surInactive { get; set; }

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

	public int? FirstSurveyId { get; set; }

	public int? PriorSurveyId { get; set; }

	public int? NextSurveyId { get; set; }

	public int? LastSurveyId { get; set; }

	public bool? surReplyAfterLogin { get; set; }

	public string surCIds { get; set; }

	public string surCenterNames { get; set; }

	public string surCenterInfoJs { get; set; }
}
