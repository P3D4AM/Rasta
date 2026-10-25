using System;

namespace CRMIdealApi.ApiModels;

public class InsertProductSecondGroupViewModel : PublicParameters
{
	public int? ApiFirstGroupId { get; set; }

	public string ApiSGCode { get; set; }

	public string ApiSGName { get; set; }

	public string ApiSGDescription { get; set; }

	public string ApiSGNameEn { get; set; }

	public bool? ApiSGInactiveInSale { get; set; }

	public bool? ApiSGInactiveInBuy { get; set; }

	public int? ApiSGOrderView { get; set; }

	public bool? ApiSGSHPIsActive { get; set; }

	public string ApiSGCompanyGroupIIRateJson { get; set; }

	public string ApiSGSHPName { get; set; }

	public int? ApiSGLinkAccGroupId { get; set; }

	public string ApiSGLinkAccGroupCode { get; set; }

	public string ApiSGLinkAccGroupIdStr { get; set; }

	public string ApiSGLinkAccGroupName { get; set; }

	public string ApiSGLinkAccGroups { get; set; }

	public DateTime? ApiSGLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiSGLinkAccLastTransferDate { get; set; }

	public string ApiSGLinkAccData { get; set; }

	public string ApiFirstGroupCode { get; set; }

	public string ApiTspSGIndentify { get; set; }

	public string ApiTspSGName { get; set; }
}
