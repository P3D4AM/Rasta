using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCrmsysSetting_Result
{
	public int ID { get; set; }

	public string CoName { get; set; }

	public byte[] CoLoGo { get; set; }

	public string Address { get; set; }

	public string Telephone { get; set; }

	public string Fax { get; set; }

	public string Email { get; set; }

	public string WebSite { get; set; }

	public string ServerIP { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string SantralPreNumber { get; set; }

	public string CallerIDServerIP { get; set; }

	public bool? ServiceSIP { get; set; }

	public bool? ServiceSGIP { get; set; }

	public string RegistrationNumber { get; set; }

	public string EconomicCode { get; set; }

	public string NationalCode { get; set; }

	public string QuickAddress { get; set; }

	public string LockSerial { get; set; }

	public string LockCounter { get; set; }

	public string LockNU { get; set; }

	public bool? LockControl { get; set; }

	public string AppFilePath { get; set; }

	public Guid? GUId { get; set; }

	public bool? ServiceCIIP { get; set; }

	public string PublicNotice { get; set; }

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

	public string FOUrl { get; set; }

	public string PrdBarcodeFormula { get; set; }

	public bool? cmpQDefPrintAfterSave { get; set; }

	public bool? CantSaveDupTel { get; set; }

	public bool? CantSaveDupFax { get; set; }

	public bool? CantSaveDupZipCode { get; set; }

	public bool? CantSaveDupPrsNationalCode { get; set; }

	public bool? CantSaveDupCmpNationalCode { get; set; }

	public bool? CantSaveDupCmpEconomicCode { get; set; }

	public string LinkAccVersion { get; set; }

	public string LinkAccOldVersion { get; set; }

	public int? LinkAccSystemId { get; set; }

	public bool? MustFullPrsNationalCode { get; set; }

	public bool? MustFullCmpMainPrsNationalCode { get; set; }

	public bool? CantSaveDupCmpMainPrsNationalCode { get; set; }

	public bool? InvStockFromLink { get; set; }

	public bool? CmpAccFromLink { get; set; }

	public bool? PrdPriceFromLink { get; set; }

	public bool? IsActivePrjNumRByAllPrj { get; set; }

	public bool? IsActivePrjNumRByCmpPrj { get; set; }

	public bool? IsActivePordNumberByType { get; set; }

	public double? MobAccessCmpDistance { get; set; }

	public int? CmpImpUsedCount { get; set; }

	public int? OrdImpUsedCount { get; set; }

	public int? DefCmpCityId { get; set; }

	public string DefCmpCity { get; set; }

	public int? DefAnswerCnvsTopicId { get; set; }

	public string DefAnswerCnvsTopic { get; set; }

	public int? DefCallCnvsTopicId { get; set; }

	public string DefCallCnvsTopic { get; set; }

	public bool? CanUseDupTracing { get; set; }

	public bool? NotShowMenuNotModule { get; set; }

	public string MuBuySaleWhTitle { get; set; }

	public string SaleOrderLbl { get; set; }

	public string SaleReturnOrderLbl { get; set; }

	public string PrjPostFixTooltip { get; set; }

	public string PrjPostFixRegEx { get; set; }

	public int? CmpQuickRegDefCmpKind { get; set; }

	public string CrmIPStatic { get; set; }

	public bool? AddTracingCodeFromSerial { get; set; }

	public bool? MustFullTracingCode { get; set; }

	public int? cmpQDefCountryId { get; set; }

	public string cmpQDefProjectTitle { get; set; }

	public int? cmpQDefProjectGroupId { get; set; }

	public int? cmpQDefcnvsTopicId { get; set; }

	public bool? cmpQNotNullProjectGroup { get; set; }

	public bool? cmpQNotNullProjectGrade { get; set; }

	public bool? cmpQNotNullProjectPriority { get; set; }

	public bool? FullDiscountPerWithRateInAdd { get; set; }

	public string DyFormCartablesLbl { get; set; }

	public string CrmSysInternalDomain { get; set; }

	public bool? SmartTimeAttendance { get; set; }

	public string CoLatitude { get; set; }

	public string CoLongitude { get; set; }

	public int? CoZoom { get; set; }

	public double? UserLoginAccessDistance { get; set; }

	public bool? CheckLocForScanQR { get; set; }

	public int? MobNumLen { get; set; }

	public bool? MobNumLenNoCheck { get; set; }

	public int? TspPrdSendMethod { get; set; }

	public bool? CheckLocForScanQRInMission { get; set; }

	public string PwaServerUrl { get; set; }

	public int? UserLoginAccessTimeDiffInMission { get; set; }

	public bool? SendSMSOrdFOLinkAfterVerify { get; set; }

	public int? SendSMSOrdFOLinkAfterVerifyType { get; set; }

	public string CoLogoMobAppPath { get; set; }

	public string CoNameMobApp { get; set; }

	public string CoLogoMobHRMAppPath { get; set; }

	public string CoNameMobHRMApp { get; set; }

	public int? stsupDefVerifierRequestId { get; set; }

	public int? stsupDefVerificationWorkFlowId { get; set; }

	public string ApiDomain { get; set; }

	public int? PriceRoundType { get; set; }

	public string LoginAuthTypes { get; set; }

	public int? LoginAuthTypesDef { get; set; }

	public string ActiveDirectoryDomain { get; set; }

	public string OrderSetting { get; set; }
}
