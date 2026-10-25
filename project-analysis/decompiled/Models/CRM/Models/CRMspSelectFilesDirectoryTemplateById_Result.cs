using System;

namespace CRM.Models;

public class CRMspSelectFilesDirectoryTemplateById_Result
{
	public long FileDirectoryTemplateID { get; set; }

	public string Title { get; set; }

	public string CopyFromPath { get; set; }

	public int UserId { get; set; }

	public int TypeId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? FileDirectoryTypeId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? LanguageID { get; set; }

	public int? ObjectId { get; set; }

	public int? ObjectIdI { get; set; }

	public int? ObjectIdII { get; set; }
}
