using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderOpr_LangMetadata))]
public class WSOrderOpr_Lang
{
	public int WSOrderOprLangID { get; set; }

	public int OrderOprID { get; set; }

	public int LanguageID { get; set; }

	public string Name { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderOpr WSOrderOpr { get; set; }
}
