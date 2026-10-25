using System;

namespace Mobile.Models;

public class OrdIdKeyValueViewModel
{
	public int Id { get; set; }

	public int Type { get; set; }

	public string Tag { get; set; }

	public double Value { get; set; }

	public string ValueStr { get; set; }

	public DateTime? ValidityExpireDate { get; set; }

	public string ValidityExpireDatePersian { get; set; }

	public decimal? PrdAutoCalcRate { get; set; }
}
