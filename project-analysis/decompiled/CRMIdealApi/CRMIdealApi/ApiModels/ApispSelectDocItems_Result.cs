using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectDocItems_Result
{
	public int ApiDocItemID { get; set; }

	public int ApiDocId { get; set; }

	public int ApiPrdId { get; set; }

	public string ApiPrd { get; set; }

	public double? ApiQuantity { get; set; }

	public int? ApiCostId { get; set; }

	public decimal? ApiCost { get; set; }

	public string ApiDescription { get; set; }

	public short? ApiIsFix { get; set; }

	public int? ApiWHId { get; set; }

	public string ApiWH { get; set; }

	public bool? ApiNotVisible { get; set; }

	public double? ApiFCR { get; set; }

	public double? ApiFCRI { get; set; }

	public string ApiTracing { get; set; }

	public int ApiFPId { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiDocILinkAccItemId { get; set; }

	public string ApiPrdLinkAccPrdCode { get; set; }

	public string ApiDocILinkAccItemIdStr { get; set; }

	public DateTime? ApiDocILinkAccFirstTransferDate { get; set; }

	public DateTime? ApiDocILinkAccLastTransferDate { get; set; }

	public string ApiDocILinkAccData { get; set; }
}
