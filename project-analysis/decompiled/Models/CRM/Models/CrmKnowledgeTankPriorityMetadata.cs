using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmKnowledgeTankPriorityMetadata
{
	[Key]
	public int KnowledgeTankPriorityId { get; set; }

	public string KnowledgeTankPriorityTitle { get; set; }

	public string KnowledgeTankPriorityDesc { get; set; }

	public int? KnowledgeTankPriorityOrderView { get; set; }

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
}
