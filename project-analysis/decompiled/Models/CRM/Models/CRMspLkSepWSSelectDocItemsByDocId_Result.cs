using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectDocItemsByDocId_Result
{
	public int DocItemID { get; set; }

	public int DocId { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public double? Quantity { get; set; }

	public int? CostId { get; set; }

	public decimal? Cost { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public string WrhsName { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public bool? NotVisible { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public int? DocILinkAccItemId { get; set; }

	public string DocILinkAccItemIdStr { get; set; }

	public string Tracing { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public double? QuantityTotal { get; set; }

	public int? PrdUnitIdI { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIRateResult { get; set; }

	public string PrdNickname { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public bool? PrdQtyNoFCR { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public int? SepDocId { get; set; }

	public int? SepDocNumber { get; set; }

	public int? SepDocItemId { get; set; }

	public decimal? SepDocItemQuantity { get; set; }

	public int? SepDocItemRef { get; set; }

	public string SepDocItemTitle { get; set; }

	public string SepDocItemCode { get; set; }

	public DateTime? DocILinkAccFirstTransferDate { get; set; }

	public DateTime? DocILinkAccLastTransferDate { get; set; }

	public string DocILinkAccFirstTransferDateStr { get; set; }

	public string DocILinkAccLastTransferDateStr { get; set; }
}
