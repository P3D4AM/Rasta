using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCashes_LangMetadata
{
	[Key]
	public int CrmCashLangID { get; set; }

	public int CashId { get; set; }

	public int LanguageID { get; set; }

	public string CashTitle { get; set; }
}
