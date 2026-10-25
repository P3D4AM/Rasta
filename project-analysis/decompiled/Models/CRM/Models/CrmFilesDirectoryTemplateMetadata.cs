using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFilesDirectoryTemplateMetadata
{
	public long FileDirectoryTemplateID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "fdtTitle")]
	public string Title { get; set; }

	public string CopyFromPath { get; set; }

	public int UserId { get; set; }

	public int TypeId { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }

	public int? FileDirectoryTypeId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
