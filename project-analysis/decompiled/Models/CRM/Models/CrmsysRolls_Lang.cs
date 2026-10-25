using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysRolls_LangMetadata))]
public class CrmsysRolls_Lang
{
	public int CrmsysRollsLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string RollName { get; set; }

	public string Description { get; set; }

	public virtual CrmsysRolls CrmsysRolls { get; set; }

	public virtual Languages Languages { get; set; }
}
