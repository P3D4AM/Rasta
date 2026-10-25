namespace Mobile.Models;

public class UpdateDocItemViewModel
{
	public int DocItemId { get; set; }

	public string DocItemParams { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
