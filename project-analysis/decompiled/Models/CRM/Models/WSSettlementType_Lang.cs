using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSSettlementType_LangMetadata))]
public class WSSettlementType_Lang
{
	public int WSSettlementTypeLangID { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public int LanguageID { get; set; }

	public int Id { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSSettlementType WSSettlementType { get; set; }
}
