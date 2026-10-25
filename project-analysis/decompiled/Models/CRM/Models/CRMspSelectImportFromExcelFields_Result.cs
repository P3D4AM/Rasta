namespace CRM.Models;

public class CRMspSelectImportFromExcelFields_Result
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
}
