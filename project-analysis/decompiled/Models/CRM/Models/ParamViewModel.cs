using System;

namespace CRM.Models;

public class ParamViewModel
{
	public string KeyName { get; set; }

	public string KeyValue { get; set; }

	public int? GUId { get; set; }

	public DateTime? GDT { get; set; }

	public string ST { get; set; }

	public int? SUId { get; set; }

	public string SIP { get; set; }

	public DateTime? SRDT { get; set; }

	public DateTime? SSDT { get; set; }

	public int? CId { get; set; }

	public double? Lat { get; set; }

	public double? Lng { get; set; }

	public double? Zoom { get; set; }

	public int? Mode { get; set; }

	public string SDomain { get; set; }
}
