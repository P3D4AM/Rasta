using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmsysDBObjectsMetadata
{
	[Key]
	public int DBObjectId { get; set; }

	public string DBObjectName { get; set; }

	public string FieldName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FieldTitle")]
	public string FieldTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "NotNull")]
	public bool? NotNull { get; set; }

	public int? OrderView { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
