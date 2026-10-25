using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderStatus_Result
{
	public int ApiOrderStatusId { get; set; }

	public string ApiOrderStatus { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }
}
