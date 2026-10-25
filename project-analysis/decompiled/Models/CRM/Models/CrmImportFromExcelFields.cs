using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmImportFromExcelFieldsMetadata))]
public class CrmImportFromExcelFields
{
	public int Id { get; set; }

	public int? OrderNum { get; set; }

	public int? GroupNum { get; set; }

	public string FieldName { get; set; }

	public string FieldCaption { get; set; }

	public bool? IsActive { get; set; }

	public bool? Selector { get; set; }

	public bool? HaveSearch { get; set; }

	public int? FieldWidth { get; set; }

	public string FieldType { get; set; }

	public virtual ICollection<CrmImportFromExcelFields_Lang> CrmImportFromExcelFields_Lang { get; set; }

	public CrmImportFromExcelFields()
	{
		CrmImportFromExcelFields_Lang = (ICollection<CrmImportFromExcelFields_Lang>)new HashSet<CrmImportFromExcelFields_Lang>();
	}
}
