using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPreOrderStatus_Result
{
	public int ApiPreOrderStatusId { get; set; }

	public string ApiPreOrderStatus { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
