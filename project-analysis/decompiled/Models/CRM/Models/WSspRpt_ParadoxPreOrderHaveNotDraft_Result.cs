using System;

namespace CRM.Models;

public class WSspRpt_ParadoxPreOrderHaveNotDraft_Result
{
	public int PreOrderID { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public long pordNumber { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public int? pordTypeId { get; set; }

	public string PreOrderType { get; set; }

	public int? pordCompanyId { get; set; }

	public string Company { get; set; }
}
