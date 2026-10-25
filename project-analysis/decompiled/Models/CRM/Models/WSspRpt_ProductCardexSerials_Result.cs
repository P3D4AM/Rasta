using System;

namespace CRM.Models;

public class WSspRpt_ProductCardexSerials_Result
{
	public int ItemId { get; set; }

	public string Serial { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public int DocId { get; set; }

	public int DocItemId { get; set; }

	public int DocOprId { get; set; }

	public int? DocOprType { get; set; }

	public int? boCompanyId { get; set; }

	public int? OrderId { get; set; }

	public int? BuyOrderId { get; set; }

	public int DocItemSerialID { get; set; }

	public int? SerialId { get; set; }
}
