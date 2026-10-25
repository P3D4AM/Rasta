using System;

namespace CRM.Models;

public class InsertConversationFromReportViewModel
{
	public int CnvsReferUserId { get; set; }

	public int CnvsTopicId { get; set; }

	public string CnvsRemindDate { get; set; }

	public DateTime? CnvsRemindDateTime { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsDesc_Lang { get; set; }
}
