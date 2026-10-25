using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models.ViewModel.AI;

public class AIUserCreditLanguageViewModel : PublicParameters
{
	[Display(ResourceType = typeof(Labels), Name = "Description")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int UserCreditId { get; set; }

	public int CreditUserId { get; set; }

	public int CreditToken { get; set; }

	public int? ExpiryDay { get; set; }

	public string Description_Lang { get; set; }
}
