using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductRelationType_LangMetadata))]
public class WSProductRelationType_Lang
{
	public int WSProductRelationTypeLangID { get; set; }

	public int ProductRelationTypeId { get; set; }

	public int LanguageID { get; set; }

	public string RelationTypeName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductRelationType WSProductRelationType { get; set; }
}
