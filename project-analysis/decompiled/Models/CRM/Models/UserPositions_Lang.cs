using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserPositions_LangMetadata))]
public class UserPositions_Lang
{
	public int UserPositionLangID { get; set; }

	public int PositionId { get; set; }

	public int LanguageID { get; set; }

	public string PositionName { get; set; }

	public string PositionManager { get; set; }

	public string PositionAddress { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserPositions UserPositions { get; set; }
}
