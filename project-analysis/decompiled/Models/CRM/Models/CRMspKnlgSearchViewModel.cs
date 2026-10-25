using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspKnlgSearchViewModel
{
	[Key]
	public int KnowledgeTankId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgTitle")]
	public string knlgTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgSigns")]
	public string knlgSigns { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgKnowledge")]
	public string knlgKnowledge { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgPriorityId")]
	public int? knlgPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgPriorityId")]
	public string knowledgeTankPriorityTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgGroupId")]
	public int knlgGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgGroupId")]
	public string knowledgeTankGroupTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgFirstRegisterDate")]
	public DateTime FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgFirstRegisterDate")]
	public string FirstRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgUserId")]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgUserId")]
	public string UserIdtitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgRegisterDate")]
	public DateTime RegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgRegisterDate")]
	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgRegisterUser")]
	public string RegisterUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgEditedUser")]
	public string EditedUser { get; set; }

	public string AppType { get; set; }

	public bool? knlgFOCmpCanSee { get; set; }
}
