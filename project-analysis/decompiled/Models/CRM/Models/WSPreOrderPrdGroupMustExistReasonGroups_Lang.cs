using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderPrdGroupMustExistReasonGroups_LangMetadata))]
public class WSPreOrderPrdGroupMustExistReasonGroups_Lang
{
	public int WSPreOrderPrdGroupMustExistReasonGroupsLangID { get; set; }

	public int PrdGroupMustExistReasonGroupId { get; set; }

	public int LanguageID { get; set; }

	public string PrdGroupMustExistReasonGroupTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderPrdGroupMustExistReasonGroups WSPreOrderPrdGroupMustExistReasonGroups { get; set; }
}
