using System;

namespace CRM.Models;

public class WSspSelectOrderIndicatorWithItemsSerial_Result
{
	public int OrderItemSerialID { get; set; }

	public int OrderItemId { get; set; }

	public string PrdName { get; set; }

	public int SerialId { get; set; }

	public string Description { get; set; }

	public int? WHId { get; set; }

	public string WrhsName { get; set; }

	public string OISSerial { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public string DISDescription { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }

	public int? DocNumber { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? DocID { get; set; }
}
