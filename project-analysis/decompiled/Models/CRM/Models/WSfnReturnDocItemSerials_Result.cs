using System;

namespace CRM.Models;

public class WSfnReturnDocItemSerials_Result
{
	public int DocItemSerialID { get; set; }

	public string Serial { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public int? DocNumber { get; set; }

	public string DocDate { get; set; }

	public int? DocId { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }
}
