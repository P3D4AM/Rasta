using System;

namespace CRM.Models;

public class CrmAddressingTypeMetadata
{
	public int AddTypeID { get; set; }

	public string AddressingType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
