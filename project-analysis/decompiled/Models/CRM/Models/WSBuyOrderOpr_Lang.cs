using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderOpr_LangMetadata))]
public class WSBuyOrderOpr_Lang
{
	public int WSBuyOrderOprLangID { get; set; }

	public int BuyOrderOprID { get; set; }

	public int LanguageID { get; set; }

	public string Name { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderOpr WSBuyOrderOpr { get; set; }
}
