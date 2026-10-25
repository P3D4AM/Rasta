using System;

namespace CRM.Models;

public class CRMspSelectConversationStatusByPrjId_Result
{
	public int ConversationStatusID { get; set; }

	public short? StatusOrder { get; set; }

	public string Status { get; set; }

	public int? ProgressPercent { get; set; }

	public int? GroupId { get; set; }

	public string ConversationStatusGroup { get; set; }

	public long? Row { get; set; }

	public int TotalConversations { get; set; }

	public int? LastCnvsId { get; set; }

	public string LastCnvsDate { get; set; }

	public DateTime? LastCnvsDateTime { get; set; }

	public int? LastCnvsReferUserId { get; set; }

	public string LastCnvsReferUser { get; set; }

	public string LastCnvsDesc { get; set; }

	public string LastCnvsFirstRegisterDatePersian { get; set; }

	public DateTime? LastCnvsFirstRegisterDate { get; set; }

	public int? LastCnvsPersonId { get; set; }

	public int? LastCnvsTopicId { get; set; }

	public int? PrjLastCnvsStatusId { get; set; }

	public string PrjLastCnvsStatus { get; set; }
}
