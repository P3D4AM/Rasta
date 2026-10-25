namespace CRM.Models;

public class WSfnBrFindPrdIdNotHaveSerial_Result
{
	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public int PrdGroupID { get; set; }

	public int? FirstGroupId { get; set; }

	public string SecondGroupName { get; set; }

	public string FirstGroupName { get; set; }

	public string PrdNameAndGroup { get; set; }

	public string Barcode { get; set; }

	public string PrdAutoNumBarcode { get; set; }

	public string PrdAutoCharBarcode { get; set; }

	public string BarcodeKind { get; set; }
}
