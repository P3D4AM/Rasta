namespace Mobile.Models;

public class UpdateDocViewModel
{
	public int DocId { get; set; }

	public string DocParams { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
