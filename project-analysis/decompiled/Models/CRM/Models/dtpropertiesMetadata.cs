namespace CRM.Models;

public class dtpropertiesMetadata
{
	public int id { get; set; }

	public int? objectid { get; set; }

	public string property { get; set; }

	public string value { get; set; }

	public string uvalue { get; set; }

	public byte[] lvalue { get; set; }

	public int version { get; set; }

	public string AppType { get; set; }
}
