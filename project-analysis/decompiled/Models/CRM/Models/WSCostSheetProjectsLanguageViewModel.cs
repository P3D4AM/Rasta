using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetProjectsLanguageViewModel
{
	[Key]
	public int CostSheetProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjDesc")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshPrjDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ctshPrjCompanyId { get; set; }

	public string ctshPrjCompany { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjCmpPersonId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ctshPrjCmpPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjCmpProjectId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ctshPrjCmpProjectId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string ctshPrjTitle_Lang { get; set; }

	public string ctshPrjDesc_Lang { get; set; }
}
