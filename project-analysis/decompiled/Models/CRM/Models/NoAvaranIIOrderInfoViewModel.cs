using System;

namespace CRM.Models;

public class NoAvaranIIOrderInfoViewModel
{
	public string Seq { get; set; }

	public string Type { get; set; }

	public string Store { get; set; }

	public string Shop_Code { get; set; }

	public string Out_Quan { get; set; }

	public string Factor_Q { get; set; }

	public string Code { get; set; }

	public string Factor_C { get; set; }

	public string Factor_P { get; set; }

	public string Doc_No { get; set; }

	public string Doc_Date { get; set; }

	public string Sharh { get; set; }

	public string Doc_DatePersian { get; set; }

	public DateTime Doc_DateTime { get; set; }

	public string Doc_Time { get; set; }

	public int Doc_Day { get; set; }

	public int OrderId { get; set; }

	public int RowNumber { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public long? ordNumber { get; set; }

	public decimal? ordTotalAmount { get; set; }
}
