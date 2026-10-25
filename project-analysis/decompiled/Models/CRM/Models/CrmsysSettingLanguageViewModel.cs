using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmsysSettingLanguageViewModel
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CoName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CoName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CoLoGo")]
	public byte[] CoLoGo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Address")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Address { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Telephone")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Telephone { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Fax")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Fax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Email")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Email { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WebSite")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WebSite { get; set; }

	public string ServerIP { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SantralPreNumber")]
	public string SantralPreNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProvincePreCode")]
	public string ProvincePreCode { get; set; }

	public string CallerIDServerIP { get; set; }

	public bool? ServiceSIP { get; set; }

	public bool? ServiceSGIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RegistrationNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EconomicCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "NationalCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string NationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "QuickAddress")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string QuickAddress { get; set; }

	public string LockSerial { get; set; }

	public string LockCounter { get; set; }

	public string LockNU { get; set; }

	public bool? LockControl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AppFilePath")]
	public string AppFilePath { get; set; }

	public Guid? GUId { get; set; }

	public bool? ServiceCIIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PublicNotice")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PublicNotice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ZipCode { get; set; }

	public bool? ServiceFADeAc { get; set; }

	public string RecordingVoiceServerIP { get; set; }

	public bool? ServiceRIP { get; set; }

	public bool? CantSaveDupPrsMob { get; set; }

	public bool? CantSaveDupPrsEmail { get; set; }

	public bool? MustFullcnvsRemindDate { get; set; }

	public string CallerIDVersion { get; set; }

	public string CallerIDOldVersion { get; set; }

	public string SMSServiceVersion { get; set; }

	public string SMSServiceOldVersion { get; set; }

	public bool? ServiceBuyOrdIP { get; set; }

	public bool? ServiceEmailIP { get; set; }

	public bool? ServiceLetterIP { get; set; }

	public string AppType { get; set; }

	public bool? DisablefrmcmpSearchOnType { get; set; }

	public string SMSGSMServiceVersion { get; set; }

	public string SMSGSMServiceOldVersion { get; set; }

	public int? LanguageID { get; set; }

	public int? DefaultLanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string CoName_Lang { get; set; }

	public string Address_Lang { get; set; }

	public string PublicNotice_Lang { get; set; }

	public string QuickAddress_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FOUrl")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FOUrl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdBarcodeFormula")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdBarcodeFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InvStockFromLink")]
	public bool? InvStockFromLink { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpAccFromLink")]
	public bool? CmpAccFromLink { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdPriceFromLink")]
	public bool? PrdPriceFromLink { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobAccessCmpDistance")]
	public double? MobAccessCmpDistance { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DefCmpCityId")]
	public int? DefCmpCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DefAnswerCnvsTopicId")]
	public int? DefAnswerCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DefCallCnvsTopicId")]
	public int? DefCallCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CanUseDupTracing")]
	public bool? CanUseDupTracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "NotShowMenuNotModule")]
	public bool? NotShowMenuNotModule { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MuBuySaleWhTitle")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string MuBuySaleWhTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SysSettingSaleOrderLbl")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SaleOrderLbl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SysSettingSaleReturnOrderLbl")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SaleReturnOrderLbl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrjPostFixTooltip")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjPostFixTooltip { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrjPostFixRegEx")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjPostFixRegEx { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmpQuickRegDefCmpKind")]
	public int? CmpQuickRegDefCmpKind { get; set; }

	public string MuBuySaleWhTitle_Lang { get; set; }

	public string SaleOrderLbl_Lang { get; set; }

	public string SaleReturnOrderLbl_Lang { get; set; }

	public string PrjPostFixTooltip_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormCartablesLbl")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DyFormCartablesLbl { get; set; }

	public string DyFormCartablesLbl_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmIPStatic")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CrmIPStatic { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddTracingCodeFromSerial")]
	public bool? AddTracingCodeFromSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MustFullTracingCode")]
	public bool? MustFullTracingCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullDiscountPerWithRateInAdd")]
	public bool? FullDiscountPerWithRateInAdd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmSysInternalDomain")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CrmSysInternalDomain { get; set; }

	public string CoLatitude { get; set; }

	public string CoLongitude { get; set; }

	public int? CoZoom { get; set; }

	public double? UserLoginAccessDistance { get; set; }

	public bool? CheckLocForScanQR { get; set; }

	public bool? CheckLocForScanQRInMission { get; set; }

	public string PwaServerUrl { get; set; }

	public string LoginAuthUrl { get; set; }

	public int? UserLoginAccessTimeDiffInMission { get; set; }

	public bool? SmartTimeAttendance { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmSysTaxableOrderOprIds")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TaxableOrderOprIds { get; set; }

	public string TaxableOrderOrdJson { get; set; }

	public bool? SendSMSOrdFOLinkAfterVerify { get; set; }

	public int? SendSMSOrdFOLinkAfterVerifyType { get; set; }

	public bool? SendSMSOrdFOLinkAfterVerifyGSM { get; set; }

	public int? SendSMSOrdFOLinkAfterVerifyGSMSetId { get; set; }

	public bool? SendSMSOrdFOLinkAfterVerifyWeb { get; set; }

	public int? SendSMSOrdFOLinkAfterVerifyWebProviderId { get; set; }

	public string SendSMSOrdFOLinkAfterVerifyNumber { get; set; }

	public string SendSMSOrdFOLinkAfterVerifyBodyPatternFormula { get; set; }

	public string SendSMSOrdFOLinkAfterVerifyBodyPatternFormula_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupDefVerifierRequestId")]
	public int? stsupDefVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupDefVerificationWorkFlowId")]
	public int? stsupDefVerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmSysPriceRoundType")]
	public int? PriceRoundType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmSysSettingApiDomain")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ApiDomain { get; set; }

	public bool? SendSMSPordFOLinkAfterVerify { get; set; }

	public int? SendSMSPordFOLinkAfterVerifyType { get; set; }

	public bool? SendSMSPordFOLinkAfterVerifyGSM { get; set; }

	public int? SendSMSPordFOLinkAfterVerifyGSMSetId { get; set; }

	public bool? SendSMSPordFOLinkAfterVerifyWeb { get; set; }

	public int? SendSMSPordFOLinkAfterVerifyWebProviderId { get; set; }

	public string SendSMSPordFOLinkAfterVerifyNumber { get; set; }

	public string SendSMSPordFOLinkAfterVerifyBodyPatternFormula { get; set; }

	public string SendSMSPordFOLinkAfterVerifyBodyPatternFormula_Lang { get; set; }

	public string CoLocations { get; set; }

	public int? CityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmSysSettingAIDomain")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AIDomain { get; set; }

	public bool? TimeAttendanceRecIsTemp { get; set; }

	public string TimeAttendanceRecTempVerifyUserIds { get; set; }

	public string TimeAttendanceRecTempVerifyRollId { get; set; }

	public DateTime? TimeAttendanceRecTempExpirDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobSmsSend")]
	public bool? IsActiveJobSmsSend { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobSmsReceive")]
	public bool? IsActiveJobSmsReceive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobEmailSend")]
	public bool? IsActiveJobEmailSend { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobEmailReceive")]
	public bool? IsActiveJobEmailReceive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobSendCongratulate")]
	public bool? IsActiveJobSendCongratulate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobControlTicketAlert")]
	public bool? IsActiveJobControlTicketAlert { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IsActiveJobTicketAutoClose")]
	public bool? IsActiveJobTicketAutoClose { get; set; }
}
