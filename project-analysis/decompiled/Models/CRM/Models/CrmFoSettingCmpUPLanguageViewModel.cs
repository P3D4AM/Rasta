using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingCmpUPLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefUsernameType")]
	public int? CmpDefUsernameType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCmpDefPasswordType")]
	public int? CmpDefPasswordType { get; set; }
}
