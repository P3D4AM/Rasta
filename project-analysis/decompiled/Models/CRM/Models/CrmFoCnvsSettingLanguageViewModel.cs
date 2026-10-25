using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoCnvsSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDefaultTopicId")]
	public int? CnvsDefaultTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsStatusGroup")]
	public int? CnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsStatusFODefault")]
	public int? CnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsStatusGroupReferUser")]
	public int? CnvsReferUserId { get; set; }

	public string CnvsReferMultiUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCnvsDescTooltip")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsDescTooltip { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingCanInsCnvs")]
	public bool? FoCanInsCnvs { get; set; }

	public string CnvsDescTooltip_Lang { get; set; }
}
