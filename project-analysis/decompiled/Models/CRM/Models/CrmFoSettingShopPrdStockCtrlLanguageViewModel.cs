using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingShopPrdStockCtrlLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	public int? PrdStockControlType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdStockControlDefWhId")]
	public int? PrdStockControlDefWhId { get; set; }
}
