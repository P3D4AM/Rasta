using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyMoneyBagLanguageViewModel
{
	[Key]
	public int CompanyMoneyBagId { get; set; }

	public int CmpMnBgCompanyId { get; set; }

	public int? CmpMnBgSystemPartId { get; set; }

	public int? CmpMnBgSystemPartObjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpMnBgNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public long CmpMnBgNumber { get; set; }

	public DateTime CmpMnBgDate { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "CmpMnBgDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string CmpMnBgDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpMnBgAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal CmpMnBgAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpMnBgDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpMnBgDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpMnBgBankTransactionCode")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
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

	public string CmpMnBgDesc_Lang { get; set; }

	public DateTime? CmpMnBgExpireDate { get; set; }

	public string CmpMnBgExpireDatePersian { get; set; }
}
