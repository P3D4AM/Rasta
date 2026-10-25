using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductFirstGroup_Result
{
	public int ApiPrdFirstGroupID { get; set; }

	public string ApiFGCode { get; set; }

	public string ApiFGName { get; set; }

	public string ApiFGDescription { get; set; }

	public int ApiFPId { get; set; }

	public string ApiFGNameEn { get; set; }

	public bool? ApiFGInactiveInSale { get; set; }

	public bool? ApiFGInactiveInBuy { get; set; }

	public bool? ApiPrdGroupMustExistInPreOrder { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiFGLinkAccGroupId { get; set; }

	public string ApiFGLinkAccGroupCode { get; set; }

	public string ApiFGLinkAccGroupIdStr { get; set; }

	public string ApiFGLinkAccGroupName { get; set; }

	public DateTime? ApiFGLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiFGLinkAccLastTransferDate { get; set; }

	public string ApiFGLinkAccData { get; set; }

	public int? ApiFGOrderView { get; set; }

	public bool? ApiFGSHPIsActive { get; set; }

	public string ApiTspFGIndentify { get; set; }

	public string ApiTspFGName { get; set; }

	public string ApiFGSHPName { get; set; }
}
