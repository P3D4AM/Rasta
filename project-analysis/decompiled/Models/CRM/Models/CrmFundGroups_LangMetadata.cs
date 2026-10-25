using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmFundGroups_LangMetadata
{
	[Key]
	public int CrmFundGroupLangID { get; set; }

	public int FundGroupId { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }
}
