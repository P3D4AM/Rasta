using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFund_LangMetadata))]
public class CrmFund_Lang
{
	public int CrmFundLangID { get; set; }

	public int FundId { get; set; }

	public int LanguageID { get; set; }

	public string FundDesc { get; set; }

	public virtual CrmFund CrmFund { get; set; }

	public virtual Languages Languages { get; set; }
}
