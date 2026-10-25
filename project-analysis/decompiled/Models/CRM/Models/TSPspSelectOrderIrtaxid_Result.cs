using System;

namespace CRM.Models;

public class TSPspSelectOrderIrtaxid_Result
{
	public int OrderID { get; set; }

	public long ordNumber { get; set; }

	public string OrdInfo { get; set; }

	public string OrdOpr { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string TspOrdIdentify { get; set; }
}
