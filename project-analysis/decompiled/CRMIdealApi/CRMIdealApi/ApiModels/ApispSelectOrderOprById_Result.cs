using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderOprById_Result
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

	public long? ApiDailyCounter { get; set; }

	public int? ApiTspInty { get; set; }

	public int? ApiTspInp { get; set; }

	public int? ApiTspIns { get; set; }

	public bool? ApiVerifyAfterIssue { get; set; }

	public int? ApiTspIntyI { get; set; }

	public int? ApiTspInpI { get; set; }

	public int? ApiTspInsI { get; set; }

	public bool? ApiTaxable { get; set; }
}
