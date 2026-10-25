using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyCampaignLanguageViewModel
{
	[Key]
	public int CompanyCampaignId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CompanyCampaignParent")]
	public int ParentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CompanyCampaignName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CampaignName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CompanyCampaignOrderView")]
	public int? OrderView { get; set; }

	public string CampaignName_Lang { get; set; }
}
