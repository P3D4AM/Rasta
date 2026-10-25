using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectDocOprByoprType_Result
{
	public int ApiDocOprID { get; set; }

	public string ApiName { get; set; }

	public int? ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }
}
