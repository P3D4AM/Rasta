using System;

namespace Mobile.Models;

public class MobspknlgSelectKnowledgeTankByIds_Result
{
	public int KnowledgeTankId { get; set; }

	public string knlgTitle { get; set; }

	public string knlgSigns { get; set; }

	public string knlgKnowledge { get; set; }

	public int? knlgPriorityId { get; set; }

	public int knlgGroupId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string knlgGroup { get; set; }

	public string knlgPriority { get; set; }

	public string RegisterUser { get; set; }

	public string EditedUser { get; set; }
}
