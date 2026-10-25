using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductSecondGroup_Result
{
	public int ApiPrdSecondGroupID { get; set; }

	public int? ApiPrdCount { get; set; }

	public int ApiFirstGroupId { get; set; }

	public string ApiFirstGroup { get; set; }

	public string ApiSGCode { get; set; }

	public string ApiSGName { get; set; }

	public string ApiSGDescription { get; set; }

	public int ApiFPId { get; set; }

	public string ApiSGNameEn { get; set; }

	public bool? ApiSGInactiveInSale { get; set; }

	public bool? ApiSGInactiveInBuy { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? SGLinkAccGroupId { get; set; }

	public string SGLinkAccGroupCode { get; set; }

	public string SGLinkAccGroupIdStr { get; set; }

	public string SGLinkAccGroupName { get; set; }

	public string SGLinkAccGroups { get; set; }

	public DateTime? SGLinkAccFirstTransferDate { get; set; }

	public DateTime? SGLinkAccLastTransferDate { get; set; }

	public string SGLinkAccData { get; set; }

	public int? ApiSGOrderView { get; set; }

	public bool? ApiSGSHPIsActive { get; set; }

	public string ApiTspSGIndentify { get; set; }

	public string ApiTspSGName { get; set; }

	public string ApiSGCompanyGroupIIRateJson { get; set; }

	public string ApiSGSHPName { get; set; }
}
