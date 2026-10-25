using System;

namespace CRMIdealApi.ApiModels;

public class UpdateProductPriceGroupViewModel : PublicParameters
{
	public int? ApiProductPriceGroupID { get; set; }

	public string ApiProductPriceGroupName { get; set; }

	public string ApiProductPriceGroupDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public bool? ApiSHPDefaultPriceGroup { get; set; }

	public bool? ApiSHPPriceGroupVisible { get; set; }

	public string ApiLinkAccPrdPriceGroupIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
