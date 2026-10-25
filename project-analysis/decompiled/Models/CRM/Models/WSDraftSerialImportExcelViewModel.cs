namespace CRM.Models;

public class WSDraftSerialImportExcelViewModel
{
	public int RowNumber { get; set; }

	public string Serial { get; set; }

	public string Desc { get; set; }

	public bool Selected { get; set; }

	public bool HasConflict { get; set; }

	public string ConflictDesc { get; set; }

	public string ConflictErrorCode { get; set; }
}
