using System;

namespace CRM.Models;

public class CRMspKnlgSearch_Result
{
	public int KnowledgeTankId { get; set; }

	public string knlgTitle { get; set; }

	public string knlgSigns { get; set; }

	public string knlgKnowledge { get; set; }

	public int? knlgPriorityId { get; set; }

	public int knlgGroupId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string knowledgeTankGroupTitle { get; set; }

	public string knowledgeTankPriorityTitle { get; set; }

	public string RegisterUser { get; set; }

	public string EditedUser { get; set; }

	public bool? knlgFOCmpCanSee { get; set; }
}
