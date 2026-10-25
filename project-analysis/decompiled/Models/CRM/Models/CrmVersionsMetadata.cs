using System;

namespace CRM.Models;

public class CrmVersionsMetadata
{
	public int ID { get; set; }

	public string Version { get; set; }

	public string ReleaseDatePersian { get; set; }

	public DateTime ReleaseDate { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
