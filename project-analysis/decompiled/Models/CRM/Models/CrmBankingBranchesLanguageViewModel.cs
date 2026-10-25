using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmBankingBranchesLanguageViewModel
{
	[Key]
	public int BankingBranchID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchBankId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? BankId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BranchName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BranchCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchAddress")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BranchAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchTel")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BranchTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchTelII")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BranchTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BankingBranchDesc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BranchDesc { get; set; }

	public string BranchName_Lang { get; set; }

	public string BranchAddress_Lang { get; set; }

	public string BranchDesc_Lang { get; set; }
}
