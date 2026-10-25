using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmProjectFieldValueTypeMetadata
{
	[Key]
	public int ProjectFieldValueTypeId { get; set; }

	public int ValueType { get; set; }

	public int LanguageID { get; set; }

	public string ValueTypeTitle { get; set; }
}
