using System;

namespace CRM.Models;

public class WSspSelectCompanyPreOrderForDistributePayment_Result
{
	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public long pordNumber { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public decimal? sumpOrdPayAmount { get; set; }

	public decimal? RemainpOrdAmount { get; set; }

	public string PreOrderOpr { get; set; }

	public string PreOrderStatus { get; set; }

	public int? pordStatusId { get; set; }

	public int? PreOrderOprID { get; set; }

	public int PreOrderID { get; set; }
}
