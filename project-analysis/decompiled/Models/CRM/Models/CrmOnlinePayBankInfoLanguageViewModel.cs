using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmOnlinePayBankInfoLanguageViewModel
{
	public int OnlinePayBankInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkCurrencyRate")]
	public int? BankCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkLoginAccount")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankLoginAccount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkAdditionalData")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankAdditionalData { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkIPGPageUrl")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankIPGPageUrl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkPGWSaleServiceUrl")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankPGWSaleServiceUrl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkPGWConfirmServiceUrl")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankPGWConfirmServiceUrl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkReversalServiceUrl")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankReversalServiceUrl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkSalePaymentCallback")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BankSalePaymentCallback { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkOrderView")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkIsActiveInShopApp")]
	public bool? IsActiveInShopApp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkOrderView")]
	public int? OrderView { get; set; }

	public int? BankingBankID { get; set; }

	public string BankLoginPassword { get; set; }

	public string BankTerminalCode { get; set; }

	public string BankAcceptorCode { get; set; }

	[AllowHtml]
	public string BankSignKey { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkOrdPayTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? BankOrdPayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingBnkPordPayTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? BankPordPayTypeId { get; set; }

	public string BankName_Lang { get; set; }

	public string BankAdditionalData_Lang { get; set; }

	public int? BankOnlinePayType { get; set; }
}
