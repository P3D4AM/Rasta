using System;

namespace CRM.Models;

public class WSspSelectPreOrderIndicatorByDBTempInfo_Result
{
	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public string pordNumRef { get; set; }

	public int? pordTypeId { get; set; }

	public string PreOrderType { get; set; }

	public int? pordCompanyId { get; set; }
}
