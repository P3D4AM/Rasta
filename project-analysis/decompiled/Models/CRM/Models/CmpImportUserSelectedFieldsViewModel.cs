namespace CRM.Models;

public class CmpImportUserSelectedFieldsViewModel
{
	public int Id { get; set; }

	public int OrderNum { get; set; }

	public int GroupNum { get; set; }

	public string FieldName { get; set; }

	public string FieldCaption { get; set; }

	public bool IsActive { get; set; }

	public bool Selector { get; set; }

	public bool HaveSearch { get; set; }

	public int FieldWidth { get; set; }

	public string FieldType { get; set; }

	public string repChar { get; set; }

	public int repBA { get; set; }
}
