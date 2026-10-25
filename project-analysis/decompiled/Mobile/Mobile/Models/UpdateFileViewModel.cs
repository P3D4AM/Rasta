namespace Mobile.Models;

public class UpdateFileViewModel
{
	public int FileDirectoryId { get; set; }

	public int FileDirectoryTypeId { get; set; }

	public string Title { get; set; }

	public string RegisterDatePersian { get; set; }

	public string DocDate { get; set; }

	public string DocDay { get; set; }

	public string DocTime { get; set; }

	public int? LanguageId { get; set; }

	public string FileDesc { get; set; }
}
