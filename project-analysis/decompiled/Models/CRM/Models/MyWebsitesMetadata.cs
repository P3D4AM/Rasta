using System;

namespace CRM.Models;

public class MyWebsitesMetadata
{
	public int Id { get; set; }

	public string Website { get; set; }

	public int? ViewOrder { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
