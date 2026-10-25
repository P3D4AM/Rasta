using System;

namespace CRM.Models;

public class WSfnReturnDraftItemSerials_Result
{
	public int DocItemSerialID { get; set; }

	public string Serial { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public int? DocNumber { get; set; }

	public string DocDate { get; set; }

	public string Description { get; set; }
}
