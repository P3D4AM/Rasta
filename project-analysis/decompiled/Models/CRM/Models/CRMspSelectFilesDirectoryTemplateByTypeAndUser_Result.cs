namespace CRM.Models;

public class CRMspSelectFilesDirectoryTemplateByTypeAndUser_Result
{
	public long FileDirectoryTemplateID { get; set; }

	public string Title { get; set; }

	public string CopyFromPath { get; set; }

	public int UserId { get; set; }

	public int TypeId { get; set; }

	public int? FileDirectoryTypeId { get; set; }

	public int? ObjectId { get; set; }

	public string AppType { get; set; }
}
