using System;

namespace CRM.Models;

public class WSspReturnDocPrdSerial_Result
{
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

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public int DocNumber { get; set; }

	public int DocId { get; set; }

	public string Docdate { get; set; }

	public int? RootId { get; set; }

	public string Tracing { get; set; }
}
