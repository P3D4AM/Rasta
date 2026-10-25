using System;

namespace CRM.Models;

public class CRMspSelectCompanyMoneyBagByCmpIds_Result
{
	public int CompanyMoneyBagId { get; set; }

	public int CmpMnBgCompanyId { get; set; }

	public string CmpMnBgCompany { get; set; }

	public int? CmpMnBgSystemPartId { get; set; }

	public string CmpMnBgSystemPart { get; set; }

	public string CmpMnBgType { get; set; }

	public int? CmpMnBgSystemPartObjectId { get; set; }

	public string CmpMnBgSystemPartFullName { get; set; }

	public long CmpMnBgNumber { get; set; }

	public DateTime CmpMnBgDate { get; set; }

	public string CmpMnBgDatePersian { get; set; }

	public decimal CmpMnBgAmount { get; set; }

	public string CmpMnBgDesc { get; set; }

	public string CmpMnBgBankTransactionCode { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string CmpMnBgLinkAccMoneyBagIdStr { get; set; }

	public string CmpMnBgLinkAccMoneyBagType { get; set; }

	public DateTime? CmpMnBgLinkAccFirstTransferDate { get; set; }

	public DateTime? CmpMnBgLinkAccLastTransferDate { get; set; }

	public string CmpMnBgLinkAccData { get; set; }

	public DateTime? CmpMnBgExpireDate { get; set; }

	public string CmpMnBgExpireDatePersian { get; set; }
}
