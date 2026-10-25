using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserMoneyBag_LangMetadata))]
public class UserMoneyBag_Lang
{
	public int UserMoneyBagLangID { get; set; }

	public int UserMoneyBagId { get; set; }

	public int LanguageID { get; set; }

	public string UMnBgDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserMoneyBag UserMoneyBag { get; set; }
}
