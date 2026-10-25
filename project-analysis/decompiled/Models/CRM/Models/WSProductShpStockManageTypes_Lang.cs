using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductShpStockManageTypes_LangMetadata))]
public class WSProductShpStockManageTypes_Lang
{
	public int WSProductShpStockManageTypesLangID { get; set; }

	public int ProductShpStockManageTypeId { get; set; }

	public string ProductShpStockManageType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductShpStockManageTypes WSProductShpStockManageTypes { get; set; }
}
