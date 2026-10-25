using System;

namespace CRM.Models;

public class CrmLinkedTypeMetadata
{
	public int LinkedTypeID { get; set; }

	public short TypeOrder { get; set; }

	public string LinkTypeName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
