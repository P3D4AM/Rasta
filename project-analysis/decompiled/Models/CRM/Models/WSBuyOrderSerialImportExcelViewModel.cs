namespace CRM.Models;

public class WSBuyOrderSerialImportExcelViewModel
{
	public int RowNumber { get; set; }

	public string ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public string Serial { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }

	public string Desc { get; set; }

	public bool Selected { get; set; }

	public bool HasConflict { get; set; }

	public string ConflictDesc { get; set; }
}
