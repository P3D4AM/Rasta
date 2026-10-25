using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFundGroups_LangMetadata))]
public class CrmFundGroups_Lang
{
	public int CrmFundGroupLangID { get; set; }

	public int FundGroupId { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }

	public virtual CrmFundGroups CrmFundGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
