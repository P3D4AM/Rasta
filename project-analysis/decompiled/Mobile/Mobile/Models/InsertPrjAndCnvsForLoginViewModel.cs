namespace Mobile.Models;

public class InsertPrjAndCnvsForLoginViewModel
{
	public int CompanyId { get; set; }

	public int PersonId { get; set; }

	public int UserId { get; set; }

	public string Project { get; set; }

	public string Conversation { get; set; }

	public int ConversationId { get; set; }

	public int ProjectId { get; set; }

	public string Type { get; set; }

	public string ErrorMessage { get; set; }

	public int LangId { get; set; }

	public int? CenterId { get; set; }
}
