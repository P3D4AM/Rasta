using System;

namespace CRM.Models;

public class CrmsysRollPermissionMetadata
{
	public int ID { get; set; }

	public int RollId { get; set; }

	public int FormId { get; set; }

	public int? FormActionId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
