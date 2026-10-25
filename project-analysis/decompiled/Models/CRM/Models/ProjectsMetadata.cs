using System;

namespace CRM.Models;

public class ProjectsMetadata
{
	public int Id { get; set; }

	public short Code { get; set; }

	public string Name { get; set; }

	public string Title { get; set; }

	public string Value { get; set; }

	public string Version { get; set; }

	public string OldVersion { get; set; }

	public string Company { get; set; }

	public string AboutCompany { get; set; }

	public string Type { get; set; }

	public string Description { get; set; }

	public string LogoPath { get; set; }

	public byte[] LogoPic { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
