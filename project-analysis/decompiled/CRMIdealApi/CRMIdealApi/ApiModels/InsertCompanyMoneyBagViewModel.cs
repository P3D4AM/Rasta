using System;

namespace CRMIdealApi.ApiModels;

public class InsertCompanyMoneyBagViewModel : PublicParameters
{
	public int CompanyId { get; set; }

	public DateTime Date { get; set; }

	public decimal Amount { get; set; }

	public string Desc { get; set; }

	public string BankTransactionCode { get; set; }

	public string ApiCmpMnBgLinkAccMoneyBagIdStr { get; set; }

	public string ApiCmpMnBgLinkAccMoneyBagType { get; set; }

	public DateTime? ApiCmpMnBgLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiCmpMnBgLinkAccLastTransferDate { get; set; }

	public string ApiCmpMnBgLinkAccData { get; set; }

	public DateTime? ApiCmpMnBgExpireDate { get; set; }

	public string Desc_Lang { get; set; }
}
