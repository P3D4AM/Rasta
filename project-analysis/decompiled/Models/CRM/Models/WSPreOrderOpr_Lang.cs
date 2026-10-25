using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderOpr_LangMetadata))]
public class WSPreOrderOpr_Lang
{
	public int WSPreOrderOprLangID { get; set; }

	public int PreOrderOprID { get; set; }

	public int? LanguageID { get; set; }

	public string PreOrderOpr { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderOpr WSPreOrderOpr { get; set; }
}
