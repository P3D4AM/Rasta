using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectProductFromSep_Result
{
	public int? ItemID { get; set; }

	public int? Type { get; set; }

	public string Code { get; set; }

	public string Title { get; set; }

	public string BarCode { get; set; }

	public double? MinimumAmount { get; set; }

	public double? MaximumAmount { get; set; }

	public DateTime? CreationDate { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public int? ProductId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
