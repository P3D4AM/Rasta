using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectSettlementType_Result
{
	public int ApiId { get; set; }

	public short? ApiCode { get; set; }

	public string ApiName { get; set; }

	public string ApiDescription { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
