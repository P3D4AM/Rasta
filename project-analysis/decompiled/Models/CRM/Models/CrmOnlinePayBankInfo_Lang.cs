using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmOnlinePayBankInfo_LangMetadata))]
public class CrmOnlinePayBankInfo_Lang
{
	public int CrmOnlinePayBankInfoLangID { get; set; }

	public int OnlinePayBankInfoId { get; set; }

	public int LanguageID { get; set; }

	public string BankName { get; set; }

	public string BankAdditionalData { get; set; }

	public virtual CrmOnlinePayBankInfo CrmOnlinePayBankInfo { get; set; }

	public virtual Languages Languages { get; set; }
}
