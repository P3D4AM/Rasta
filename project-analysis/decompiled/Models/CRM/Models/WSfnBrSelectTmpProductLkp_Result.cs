namespace CRM.Models;

public class WSfnBrSelectTmpProductLkp_Result
{
	public string BarcodeKind { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public int GroupID { get; set; }

	public string Barcode { get; set; }

	public string AutoNumBarcode { get; set; }

	public string AutoCharBarcode { get; set; }

	public int? FirstGroupId { get; set; }

	public string SecondGroupName { get; set; }

	public string FirstGroupName { get; set; }

	public string PrdNameAndGroup { get; set; }
}
