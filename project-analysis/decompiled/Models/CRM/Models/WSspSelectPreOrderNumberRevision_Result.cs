using System;

namespace CRM.Models;

public class WSspSelectPreOrderNumberRevision_Result
{
	public int PreOrderID { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordReferUser { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public long? pordNumberRevision { get; set; }

	public string pordNumRef { get; set; }
}
