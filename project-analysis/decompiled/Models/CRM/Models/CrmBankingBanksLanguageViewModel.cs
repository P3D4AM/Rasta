using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmBankingBanksLanguageViewModel
{
	[Key]
	public int BankingBankID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBankCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Code { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBankName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBankDesc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankDesc { get; set; }

	public string BankName_Lang { get; set; }

	public string BankDesc_Lang { get; set; }
}
