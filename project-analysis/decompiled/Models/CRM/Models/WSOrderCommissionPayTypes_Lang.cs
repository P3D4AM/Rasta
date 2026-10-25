using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderCommissionPayTypes_LangMetadata))]
public class WSOrderCommissionPayTypes_Lang
{
	public int WSOrderCommissionPayTypeLangID { get; set; }

	public int OrderCommissionPayTypeId { get; set; }

	public int LanguageID { get; set; }

	public string CommPayTypeTitle { get; set; }

	public string CommPayTypeDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderCommissionPayTypes WSOrderCommissionPayTypes { get; set; }
}
