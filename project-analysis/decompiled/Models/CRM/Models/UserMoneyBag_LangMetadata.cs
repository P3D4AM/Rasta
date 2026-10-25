using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class UserMoneyBag_LangMetadata
{
	[Key]
	public int UserMoneyBagLangID { get; set; }

	public int UserMoneyBagId { get; set; }

	public int LanguageID { get; set; }

	public string UMnBgDesc { get; set; }
}
