using System;

namespace Mobile.Models;

public class FOMobspSelectCompanyProjectValidityPrd_Result
{
	public long? RowNumber { get; set; }

	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public int? ordIOrderView { get; set; }

	public int? ordIValidity { get; set; }

	public string ordIPrdNickname { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string OrderOpr { get; set; }

	public int? PrdGroupID { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdSGroupName { get; set; }

	public string PrdSGroupCode { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGroupName { get; set; }

	public string PrdFGroupCode { get; set; }

	public bool? PrdValidityControlFOPrjTitleGroup { get; set; }

	public string PrdValidityControlFOPrjTitleGroupIds { get; set; }

	public string PrdValidityControlFODeActivePrjTitleGroupDesc { get; set; }
}
