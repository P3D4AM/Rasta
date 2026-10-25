using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspSelectPrintFormatByTypeIdViewModel
{
	[Key]
	public int PrintFormatID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatTypeId")]
	public int PrintFormatTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatTypeId")]
	public string PrintFormatTypeIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatTitle")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatFileName")]
	public string FileName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatFileName")]
	public string FileNameWeb { get; set; }

	public string AppType { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
