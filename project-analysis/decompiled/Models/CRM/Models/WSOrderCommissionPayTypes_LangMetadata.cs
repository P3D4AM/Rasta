using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

internal class WSOrderCommissionPayTypes_LangMetadata
{
	[Key]
	public int WSOrderCommissionPayTypeLangID { get; set; }

	public int OrderCommissionPayTypeId { get; set; }

	public int LanguageID { get; set; }

	public string CommPayTypeTitle { get; set; }

	public string CommPayTypeDescription { get; set; }
}
