using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderImportFromExcelFieldsMetadata))]
public class WSOrderImportFromExcelFields
{
	public int Id { get; set; }

	public int? OrderNum { get; set; }

	public int? GroupNum { get; set; }

	public string FieldName { get; set; }

	public string FieldCaption { get; set; }

	public bool? IsActive { get; set; }

	public bool? NotNull { get; set; }

	public bool? Selector { get; set; }

	public bool? HaveSearch { get; set; }

	public string AppType { get; set; }

	public string SPInsertParamName { get; set; }

	public string FieldType { get; set; }

	public int? FieldSize { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSOrderImportFromExcelFields_Lang> WSOrderImportFromExcelFields_Lang { get; set; }

	public virtual Users Users { get; set; }

	public WSOrderImportFromExcelFields()
	{
		WSOrderImportFromExcelFields_Lang = (ICollection<WSOrderImportFromExcelFields_Lang>)new HashSet<WSOrderImportFromExcelFields_Lang>();
	}
}
