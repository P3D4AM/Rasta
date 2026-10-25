using System;

namespace CRM.Models;

public class CRMspSelectConversationTopics_Result
{
	public int ConversationTopicsID { get; set; }

	public short? TopicOrder { get; set; }

	public string Topic { get; set; }

	public string TopicDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? OrderView { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public bool? FODefault { get; set; }

	public bool? CheckUserDistanceCmp { get; set; }

	public double? UserDistanceCmpVal { get; set; }
}
