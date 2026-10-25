using System;

namespace CRMIdealApi.ApiModels;

public class UpdateCompanyMoneyBagViewModel : PublicParameters
{
	public int ApiCompanyMoneyBagId { get; set; }

	public int? ApiCmpMnBgCompanyId { get; set; }

	public int? ApiCmpMnBgSystemPartId { get; set; }

	public int? ApiCmpMnBgSystemPartObjectId { get; set; }

	public DateTime? ApiCmpMnBgDate { get; set; }

	public string ApiCmpMnBgDatePersian { get; set; }

	public decimal? ApiCmpMnBgAmount { get; set; }

	public string ApiCmpMnBgDesc { get; set; }

	public string ApiCmpMnBgBankTransactionCode { get; set; }

	public string ApiCmpMnBgLinkAccMoneyBagIdStr { get; set; }

	public string ApiCmpMnBgLinkAccMoneyBagType { get; set; }

	public DateTime? ApiCmpMnBgLinkAccFirstTransferDate { get; set; }

	public string ApiCmpMnBgLinkAccFirstTransferDatePersian { get; set; }

	public DateTime? ApiCmpMnBgLinkAccLastTransferDate { get; set; }

	public string ApiCmpMnBgLinkAccLastTransferDatePersian { get; set; }

	public string ApiCmpMnBgLinkAccData { get; set; }

	public DateTime? ApiCmpMnBgExpireDate { get; set; }

	public string ApiCmpMnBgExpireDatePersian { get; set; }
}
