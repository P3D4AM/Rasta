using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSPreOrderTypes_LangMetadata
{
	[Key]
	public int WSPreOrderTypeLangID { get; set; }

	public int PreOrderTypeId { get; set; }

	public int LanguageID { get; set; }

	public string PreOrderType { get; set; }
}
