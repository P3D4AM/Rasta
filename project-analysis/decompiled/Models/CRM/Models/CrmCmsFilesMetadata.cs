using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsFilesMetadata
{
	[Key]
	public int FileId { get; set; }

	public int ObjectTypeId { get; set; }

	public int ObjectId { get; set; }

	public string Title { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
