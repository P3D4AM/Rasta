namespace Mobile.Models;

public class FOInsertConversation
{
	public string CnvsDesc { get; set; }

	public int CnvsPersonId { get; set; }

	public int? CnvsPriorityId { get; set; }

	public int CnvsProjectId { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
