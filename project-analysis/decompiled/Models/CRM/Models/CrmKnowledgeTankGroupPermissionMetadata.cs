using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmKnowledgeTankGroupPermissionMetadata
{
	[Key]
	public int KnowledgeTankGroupPermissionId { get; set; }

	public int KnowledgeTankGroupId { get; set; }

	public int UserRollId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
