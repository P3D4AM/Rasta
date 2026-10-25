using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCashes_LangMetadata))]
public class CrmCashes_Lang
{
	public int CrmCashLangID { get; set; }

	public int CashId { get; set; }

	public int LanguageID { get; set; }

	public string CashTitle { get; set; }

	public virtual CrmCashes CrmCashes { get; set; }

	public virtual Languages Languages { get; set; }
}
