using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class UserMoneyBagMetadata
{
	[Key]
	public int UserMoneyBagId { get; set; }

	public int UMnBgUserId { get; set; }

	public int UMnBgUserMoneyBagChergeTypeId { get; set; }

	public long UMnBgNumber { get; set; }

	public DateTime UMnBgDate { get; set; }

	public string UMnBgDatePersian { get; set; }

	public decimal UMnBgAmount { get; set; }

	public DateTime? UMnBgExpireDate { get; set; }

	public string UMnBgExpireDatePersian { get; set; }

	public int? UMnBgDiscountStrategyId { get; set; }

	public int? UMnBgSystemPartId { get; set; }

	public int? UMnBgSystemPartObjectId { get; set; }

	public string UMnBgBankTransactionCode { get; set; }

	public string UMnBgDesc { get; set; }

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
}
