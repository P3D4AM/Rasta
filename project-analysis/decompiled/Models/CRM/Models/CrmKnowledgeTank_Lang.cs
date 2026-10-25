using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmKnowledgeTank_LangMetadata))]
public class CrmKnowledgeTank_Lang
{
	public int CrmKnowledgeTankLangID { get; set; }

	public int KnowledgeTankId { get; set; }

	public int LanguageID { get; set; }

	public string knlgTitle { get; set; }

	public string knlgSigns { get; set; }

	public string knlgKnowledge { get; set; }

	public virtual CrmKnowledgeTank CrmKnowledgeTank { get; set; }

	public virtual Languages Languages { get; set; }
}
