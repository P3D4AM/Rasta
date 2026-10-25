using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductShpStockManageTypes_LangMetadata
{
	[Key]
	public int WSProductShpStockManageTypesLangID { get; set; }

	public string ProductShpStockManageType { get; set; }
}
