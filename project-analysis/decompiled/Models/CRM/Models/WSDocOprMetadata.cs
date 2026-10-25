using System;

namespace CRM.Models;

public class WSDocOprMetadata
{
	public int DocOprID { get; set; }

	public string Name { get; set; }

	public Guid? GUId { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public string AppType { get; set; }
}
