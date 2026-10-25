using System;

namespace Mobile.Models;

public class MobspReturnOrderItemSerial_Result
{
	public int? TotoalPages { get; set; }

	public int DocItemSerialID { get; set; }

	public int ItemId { get; set; }

	public string Serial { get; set; }

	public int? StatusId { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? SerialId { get; set; }

	public bool? IsAutoBarcode { get; set; }

	public int? tblTmpBarcodeId { get; set; }

	public Guid? GUId { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public string AppType { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public string Tracing { get; set; }
}
