using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmOnlinePayBankInfo_LangMetadata
{
	[Key]
	public int CrmOnlinePayBankInfoLangID { get; set; }

	public int OnlinePayBankInfoId { get; set; }

	public int LanguageID { get; set; }

	public string BankName { get; set; }

	public string BankAdditionalData { get; set; }
}
