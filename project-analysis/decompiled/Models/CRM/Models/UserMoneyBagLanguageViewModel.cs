using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UserMoneyBagLanguageViewModel
{
	[Key]
	public int UserMoneyBagId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int UMnBgUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgUserMoneyBagChergeTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int UMnBgUserMoneyBagChergeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public long UMnBgNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UMnBgDatePersian { get; set; }

	public DateTime UMnBgDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal UMnBgAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgExpireDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UMnBgExpireDatePersian { get; set; }

	public DateTime? UMnBgExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgDiscountStrategyId")]
	public int? UMnBgDiscountStrategyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgSystemPartId")]
	public int? UMnBgSystemPartId { get; set; }

	public int? UMnBgSystemPartObjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgBankTransactionCode")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UMnBgBankTransactionCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UMnBgDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UMnBgDesc { get; set; }

	public string UMnBgDesc_Lang { get; set; }
}
