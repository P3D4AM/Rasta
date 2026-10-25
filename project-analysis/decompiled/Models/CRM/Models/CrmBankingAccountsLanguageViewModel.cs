using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmBankingAccountsLanguageViewModel
{
	[Key]
	public int BankingAccountID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountBranch")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int BranchId { get; set; }

	public int? MasterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int AccTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountType")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountOwner")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountOwner { get; set; }

	public int? CrmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountBank")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? BankId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountShabaNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountShabaNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountCardNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountCardNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AccountDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountIsDefault")]
	public bool? IsDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingAccountIsDefaultII")]
	public bool? IsDefaultII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblMobHRMVisible")]
	public bool? MobHRMVisible { get; set; }

	public string AccountTitle_Lang { get; set; }

	public string AccountDesc_Lang { get; set; }
}
