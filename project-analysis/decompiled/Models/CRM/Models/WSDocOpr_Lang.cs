using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDocOpr_LangMetadata))]
public class WSDocOpr_Lang
{
	public int WSDocOprLangID { get; set; }

	public int DocOprID { get; set; }

	public int LanguageID { get; set; }

	public string Name { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDocOpr WSDocOpr { get; set; }
}
