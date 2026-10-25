using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectBuyOrderOpr_Result
{
	public int ApiBuyOrderOprID { get; set; }

	public string ApiName { get; set; }

	public string ApiDocOprName { get; set; }

	public int? ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }
}
