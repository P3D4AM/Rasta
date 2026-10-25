using System;

namespace CRM.Models;

public class WSspRpt_PrintStockSupply_Result
{
	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int StockSupplyId { get; set; }

	public int StockSupplyOprId { get; set; }

	public string StockSupplyOpr { get; set; }

	public int stsupReferUserId { get; set; }

	public string stsupReferUser { get; set; }

	public long stsupNumber { get; set; }

	public DateTime stsupDateTime { get; set; }

	public string stsupDate { get; set; }

	public int? stsupCompanyId { get; set; }

	public int? stsupCompanyPersonId { get; set; }

	public int? stsupProjectId { get; set; }

	public string CmpTitle { get; set; }

	public string Company { get; set; }

	public string CompanyTel { get; set; }

	public string CompanyFax { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyCountry { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyZipcode { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public string CompanySpecialPoint { get; set; }

	public string cmpMainPerson { get; set; }

	public string cmpGroup { get; set; }

	public string cmpSubGroup { get; set; }

	public string cmpGroupII { get; set; }

	public string cmpGroupIII { get; set; }

	public string cmpGroupIV { get; set; }

	public string cmpNameOfficial { get; set; }

	public string cmpNameEng { get; set; }

	public string cmpOfficialTel { get; set; }

	public string CompanyOfficialCountry { get; set; }

	public string CompanyOfficialProvince { get; set; }

	public string CompanyOfficialCity { get; set; }

	public string cmpOfficialAddress { get; set; }

	public string cmpOfficialZipCode { get; set; }

	public string cmpOfficialDesc { get; set; }

	public string cmpDescription { get; set; }

	public string Person { get; set; }

	public string PersonJob { get; set; }

	public string PersonDepartment { get; set; }

	public string PersonTel { get; set; }

	public string PersonFax { get; set; }

	public string PersonMobile { get; set; }

	public string prsFatherName { get; set; }

	public string prsIdentityNumber { get; set; }

	public string prsNationalCode { get; set; }

	public string prsBirthPlace { get; set; }

	public string prsBirthDate { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	public string prsEmail { get; set; }

	public string prsEmailII { get; set; }

	public string ProjectTitle { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

	public string prjInquiryNum { get; set; }

	public long? prjNumR { get; set; }

	public string prjNumRef { get; set; }

	public string prjStartDate { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public string prjGroup { get; set; }

	public bool? stsupIsFixed { get; set; }

	public bool? stsupIsCanceled { get; set; }

	public string stsupIsCanceledTitle { get; set; }

	public bool? stsupIsVerified { get; set; }

	public int? stsupVerifierRequestId { get; set; }

	public string stsupVerifierRequest { get; set; }

	public int? stsupVerifierId { get; set; }

	public string stsupVerifier { get; set; }

	public DateTime? stsupVerifiedRegisterDate { get; set; }

	public string stsupVerifiedRegisterDatePersian { get; set; }

	public int? stsupVerificationWorkFlowId { get; set; }

	public string stsupVerificationWorkFlow { get; set; }

	public int? stsupPrintFormatId { get; set; }

	public string stsupPrintFormat { get; set; }

	public string stsupNote { get; set; }

	public int? stsupItemCount { get; set; }

	public double? stsupItemsQty { get; set; }

	public int? stsupPreOrderId { get; set; }

	public long? pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int StockSupplyItemId { get; set; }

	public int stsupIPrdId { get; set; }

	public string stsupIPrdName { get; set; }

	public string stsupIPrdCode { get; set; }

	public string stsupIPrdLatinName { get; set; }

	public string stsupIPrdFGName { get; set; }

	public string stsupIPrdSGName { get; set; }

	public double stsupIQuantity { get; set; }

	public string stsupIDescription { get; set; }

	public string stsupIQuantityDesc { get; set; }

	public int? stsupIPrdUnitId { get; set; }

	public string stsupIPrdUnit { get; set; }

	public int? stsupIOrderView { get; set; }

	public double? stsupIFCR { get; set; }

	public double? stsupIFCRI { get; set; }

	public int? stsupIWHId { get; set; }

	public string stsupIWrhsName { get; set; }

	public string stsupITracing { get; set; }

	public int? stsupIPrdUnitIdI { get; set; }

	public string stsupIPrdUnitI { get; set; }

	public double? stsupIPrdUnitIRateResult { get; set; }

	public double? stsupIPrdUnitIRate { get; set; }

	public int? stsupIPrdColorId { get; set; }

	public string stsupIPrdColor { get; set; }

	public string stsupIPrdNickname { get; set; }

	public int? stsupIPreOrderId { get; set; }

	public int? stsupIPreOrderItemId { get; set; }

	public double? pordIQuantity { get; set; }

	public string stsupIBuyOrderIds { get; set; }

	public string stsupIBuyOrderItemIds { get; set; }

	public double SumBordIQuantity { get; set; }

	public string stsupILinkAccWHIdStr { get; set; }

	public byte[] stsupIPrdFirstPic { get; set; }

	public int? stsupCId { get; set; }

	public string stsupCenterName { get; set; }

	public string stsupCenterCode { get; set; }

	public double? stsupIPrdWeight { get; set; }

	public decimal? stsupICost { get; set; }

	public double? PrdUnitIRate { get; set; }

	public int? stsupIPrdUnitIdII { get; set; }

	public string stsupIPrdUnitII { get; set; }

	public double? stsupIPrdUnitIIRateResult { get; set; }

	public double? PrdUnitIIRate { get; set; }
}
