using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectFieldValueTypeMetadata))]
public class CrmProjectFieldValueType
{
	public int ProjectFieldValueTypeId { get; set; }

	public int ValueType { get; set; }

	public int LanguageID { get; set; }

	public string ValueTypeTitle { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public virtual Languages Languages { get; set; }
}
