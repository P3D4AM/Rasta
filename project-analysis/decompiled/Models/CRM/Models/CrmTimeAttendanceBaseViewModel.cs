using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmTimeAttendanceBaseViewModel
{
	[Key]
	public int TimeAttendanceBaseId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbDay")]
	public int tmbDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbDay")]
	public string tmbDayTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbEntryBase")]
	public string tmbEntryBase { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbEntryAllowMin")]
	public int tmbEntryAllowMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbExitBase")]
	public string tmbExitBase { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbExitAllowMin")]
	public int tmbExitAllowMin { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
