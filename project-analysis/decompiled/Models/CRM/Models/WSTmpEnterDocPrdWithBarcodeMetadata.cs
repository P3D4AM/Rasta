using System;

namespace CRM.Models;

public class WSTmpEnterDocPrdWithBarcodeMetadata
{
	public long Id { get; set; }

	public string Barcode { get; set; }

	public int? PrdId { get; set; }

	public int? DocOprId { get; set; }

	public int? WhId { get; set; }

	public string AutoSerial { get; set; }

	public bool? IsAutoBarcode { get; set; }

	public bool? Selector { get; set; }

	public bool? InsertedOk { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string RegisterTime { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
