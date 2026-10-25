using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFileDirectoryTypeViewModel
{
	[Key]
	public int FileDirectoryTypeID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FileDirectoryType")]
	public string FileDirectoryType { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
