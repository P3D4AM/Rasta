using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderPaymentTypesLanguageViewModel
{
	[Key]
	public int OrderPaymentTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayType { get; set; }

	public string ordpayTypeDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeDeActive")]
	public bool? DeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeIsActivePayOnline")]
	public bool? ordpayTypeIsActivePayOnline { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeIsActiveAddFile")]
	public bool? ordpayTypeIsActiveAddFile { get; set; }

	public string ordpayTypePordFileTypeJson { get; set; }

	public string ordpayTypePordFileTypeJsonByName { get; set; }

	public string ordpayTypeOrdFileTypeJson { get; set; }

	public string ordpayTypeOrdFileTypeJsonByName { get; set; }

	public string ordpayType_Lang { get; set; }

	public string ordpayTypeDescription_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeIsChq")]
	public bool? ordpayTypeIsChq { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeTspIinn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdpayTypeIinn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeTspAcn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdpayTypeAcn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeTspTrmn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdpayTypeTrmn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeTspPmt")]
	public int? TspOrdpayTypePmt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeIsPos")]
	public bool? ordPayTypeIsPos { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypePosTerminal")]
	public string ordPayTypePosTerminal { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypePosUserName")]
	public string ordPayTypePosUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypePosPassword")]
	public string ordPayTypePosPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypePosURL")]
	public string ordPayTypePosURL { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeBankingBank")]
	public int? ordpayTypeBankingBankID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeBankingBranch")]
	public int? ordpayTypeBankingBranchID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeBankingAccount")]
	public int? ordpayTypeBankingAccountID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeCash")]
	public int? ordpayTypeCashId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeGroupI")]
	public int? ordpayTypeGroupIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeGroupII")]
	public int? ordpayTypeGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeKind")]
	public int? ordpayTypeKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeMode")]
	public int? ordpayTypeMode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderPaymentTypeUserAccessAll")]
	public bool? ordpayTypeUserAccessAll { get; set; }
}
