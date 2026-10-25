using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingFoOrdListShowTypeLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoOrdListShowTypeHeader")]
	public int? FoOrdListShowType { get; set; }
}
