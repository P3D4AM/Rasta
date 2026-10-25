using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderOpr_Result
{
	public int ApiOrderOprID { get; set; }

	public string ApiName { get; set; }

	public int? ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiDocOprId { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiDocOpr { get; set; }

	public string ApiFirstRegisterUser { get; set; }
}
