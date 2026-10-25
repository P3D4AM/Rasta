using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderPrdGroupMustExistReasons_LangMetadata))]
public class WSPreOrderPrdGroupMustExistReasons_Lang
{
	public int WSPreOrderPrdGroupMustExistReasonsLangID { get; set; }

	public int PrdGroupMustExistReasonId { get; set; }

	public int LanguageID { get; set; }

	public string Reason { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderPrdGroupMustExistReasons WSPreOrderPrdGroupMustExistReasons { get; set; }
}
