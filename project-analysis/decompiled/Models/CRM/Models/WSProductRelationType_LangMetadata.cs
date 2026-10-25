using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductRelationType_LangMetadata
{
	[Key]
	public int WSProductRelationTypeLangID { get; set; }

	public string RelationTypeName { get; set; }
}
