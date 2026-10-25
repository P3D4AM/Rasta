using System;

namespace CRM.Models;

public class WSspSelectPreOrderWithAccLinkField_Result
{
	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordCompanyId { get; set; }

	public int? PreOrderOprID { get; set; }

	public string pordSubject { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }
}
