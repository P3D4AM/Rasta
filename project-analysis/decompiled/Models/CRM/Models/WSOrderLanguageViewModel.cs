using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderLanguageViewModel
{
	[Key]
	public int OrderID { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "OrderOprID")]
	public int? OrderOprID { get; set; }

	public int? PreOrderId { get; set; }

	public int? PreOrderVerifierId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordNumber")]
	public long ordNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ordCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCompanyPersonId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ordCompanyPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCompanyPersonId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ordCompanyPersonIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordProjectId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ordProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSubject")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordSubject { get; set; }

	public int? ordItemCount { get; set; }

	public decimal? ordItemsAmount { get; set; }

	public decimal? ordInstallAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDiscount")]
	public decimal? ordDiscount { get; set; }

	public decimal? ordSumAmount { get; set; }

	public decimal? ordTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTaxIndex")]
	public decimal? ordTaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCalculateTax")]
	public bool? ordCalculateTax { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public bool? ordIsVerified { get; set; }

	public DateTime? ordVerifiedRegisterDate { get; set; }

	public string ordVerifiedRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordStatusId")]
	public int? ordStatusId { get; set; }

	public bool? ordIsFixed { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordGuarantyId")]
	public int? ordGuarantyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSpecialWord")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordSpecialWord { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDescriptionI")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordDescriptionI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDescriptionII")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordDescriptionII { get; set; }

	public int? ordDescriptionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPrintFormatId")]
	public int? ordPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordRLogoId")]
	public int? ordRLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordLLogoId")]
	public int? ordLLogoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSigningI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordSigningI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSigningII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordSigningII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSigningIII")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordSigningIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordAccountNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordAccountNumberI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordAccountShabaNumberI")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordAccountShabaNumberI { get; set; }

	public string ordAccountNumberII { get; set; }

	public string ordAccountShabaNumberII { get; set; }

	public int? ordSignatureId { get; set; }

	public string ordImportDate { get; set; }

	public int? ordFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordVerifierId")]
	public int? ordVerifierId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSettlementTypeId")]
	public int? ordSettlementTypeId { get; set; }

	public string ordDay { get; set; }

	public string ordTime { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTransportation")]
	public decimal? ordTransportation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ordReferUserId { get; set; }

	[Range(typeof(decimal), "0", "100", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotInRange")]
	public decimal? ordDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDiscountTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordDiscountTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordRound")]
	public decimal? ordRound { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordNote")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordNote { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordcmpTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordcmpTitle { get; set; }

	public DateTime? ordDateTime { get; set; }

	public DateTime? ordImportDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDeliveryTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ordDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSerial")]
	public string ordSerial { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordVerifierRequestId")]
	public int? ordVerifierRequestId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ordCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDeliveryTermId")]
	public int? ordDeliveryTermId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDeliveryEndDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDeliveryEndTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ordDeliveryEndTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefWHId")]
	public int? ordDefWHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefPrdPriceGroupId")]
	public int? ordDefPrdPriceGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSellerId")]
	public int? ordSellerId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordEmailUsersInfoId")]
	public int? ordEmailUsersInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordEmailUserDefaultSettingId")]
	public int? ordEmailUserDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordVerificationWorkFlowId")]
	public int? ordVerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSaleCenterId")]
	public int? ordSaleCenterId { get; set; }

	public string ordSaleCenterName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDefPayTypeId")]
	public int? ordDefPayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDailyCounter")]
	public long? ordDailyCounter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordDeadlineDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ordDeadlineDatePersian { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspSettingId")]
	public int? ordTspSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdIrtaxid")]
	public string TspOrdIrtaxid { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdFt")]
	public int? TspOrdFt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdBillid")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdBillid { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdSetm")]
	public int? TspOrdSetm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdTax17")]
	public decimal? TspOrdTax17 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdCdcn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdCdcn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdCdcd")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string TspOrdCdcdPersian { get; set; }

	public DateTime? TspOrdCdcd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdInsp")]
	public decimal? TspOrdInsp { get; set; }

	public int? ordDefaultSettingId { get; set; }

	public string ordDeliveryDay { get; set; }

	public string ordDeliveryEndDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCurrencyUnitIdI")]
	public int? ordCurrencyUnitIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCurrencyUnitIRate")]
	public double? ordCurrencyUnitIRate { get; set; }

	public string ordTitle_Lang { get; set; }

	public string ordSubject_Lang { get; set; }

	public string ordSpecialWord_Lang { get; set; }

	public string ordDescriptionI_Lang { get; set; }

	public string ordDescriptionII_Lang { get; set; }

	public string ordSigningI_Lang { get; set; }

	public string ordSigningII_Lang { get; set; }

	public string ordSigningIII_Lang { get; set; }

	public string ordDiscountTitle_Lang { get; set; }

	public string ordNote_Lang { get; set; }

	public string ordcmpTitle_Lang { get; set; }

	public string ordTotalAmountStr_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordGroupId")]
	public int? ordGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdSbc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdSbc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdScln")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdScln { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdScc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdScc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordTspOrdCrn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOrdCrn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordSaleAreaId")]
	public int? ordSaleAreaId { get; set; }

	public int? ordRefOrderId { get; set; }

	public long? ordRefOrderNumber { get; set; }

	public int? ordReturnsCnt { get; set; }
}
