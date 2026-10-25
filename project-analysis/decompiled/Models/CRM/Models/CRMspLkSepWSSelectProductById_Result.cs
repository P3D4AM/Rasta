using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectProductById_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdSGroupName { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGroupName { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public int? PrdKind { get; set; }

	public int? SepItemId { get; set; }

	public int? SepItemType { get; set; }

	public string SepItemTitle { get; set; }

	public string SepItemCode { get; set; }

	public DateTime? PrdLinkAccFirstTransferDate { get; set; }

	public DateTime? PrdLinkAccLastTransferDate { get; set; }

	public string PrdLinkAccFirstTransferDateStr { get; set; }

	public string PrdLinkAccLastTransferDateStr { get; set; }
}
