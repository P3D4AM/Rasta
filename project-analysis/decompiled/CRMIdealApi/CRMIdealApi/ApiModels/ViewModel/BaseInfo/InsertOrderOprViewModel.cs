using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertOrderOprViewModel : PublicParametersWithOutCenter
{
	public string ApiName { get; set; }

	public int? ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiDocOprId { get; set; }

	public string ApiLinkAccOrderOprIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

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
