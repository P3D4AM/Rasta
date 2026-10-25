using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmKnowledgeTankGroup_LangMetadata))]
public class CrmKnowledgeTankGroup_Lang
{
	public int CrmKnowledgeTankGroupLangID { get; set; }

	public int KnowledgeTankGroupId { get; set; }

	public int LanguageID { get; set; }

	public string KnowledgeTankGroupTitle { get; set; }

	public string KnowledgeTankGroupDesc { get; set; }

	public virtual CrmKnowledgeTankGroup CrmKnowledgeTankGroup { get; set; }

	public virtual Languages Languages { get; set; }
}
