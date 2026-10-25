using System;

namespace Mobile.Models;

public class MobspDySearchCompanyConversations_Result
{
	public int ConversationId { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsDate { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public string cnvsTopic { get; set; }

	public int? cnvsPersonId { get; set; }

	public string cnvsPerson { get; set; }

	public int? cnvsUserId { get; set; }

	public string cnvsUser { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string cnvsReferUser { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public string TxtHelp { get; set; }
}
