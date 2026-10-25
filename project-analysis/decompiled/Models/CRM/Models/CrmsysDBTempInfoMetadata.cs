using System;

namespace CRM.Models;

public class CrmsysDBTempInfoMetadata
{
	public long ID { get; set; }

	public int? UserId { get; set; }

	public Guid? GUId { get; set; }

	public int? TypeId { get; set; }

	public string TXT { get; set; }

	public string AppType { get; set; }
}
