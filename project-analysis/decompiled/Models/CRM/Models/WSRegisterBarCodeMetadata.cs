using System;

namespace CRM.Models;

public class WSRegisterBarCodeMetadata
{
	public int ID { get; set; }

	public int? DocId { get; set; }

	public string BarCode { get; set; }

	public int? DocItemId { get; set; }

	public int? PrdId { get; set; }

	public string PrdName { get; set; }

	public string Description { get; set; }

	public int? BarcodeMode { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public int WHId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? Opr { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
