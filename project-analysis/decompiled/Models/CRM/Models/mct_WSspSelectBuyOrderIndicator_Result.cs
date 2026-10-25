using System;

namespace CRM.Models;

public class mct_WSspSelectBuyOrderIndicator_Result
{
	public int? BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string bOprName { get; set; }

	public long? bordNumber { get; set; }

	public string bordDate { get; set; }

	public string bordOrderNumber { get; set; }

	public string bordOrderDate { get; set; }

	public int? bordCompanyId { get; set; }

	public string Company { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public string Person { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanycmpAddress { get; set; }

	public string cmpZipCode { get; set; }

	public string CompanyTel { get; set; }

	public string cmpFax { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public string Project { get; set; }

	public int? bordProjectId { get; set; }

	public string bordSubject { get; set; }

	public int? bordItemCount { get; set; }

	public decimal? bordDiscount { get; set; }

	public decimal? bordSumAmount { get; set; }

	public decimal? bordTax { get; set; }

	public decimal? bordRound { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public bool? bordIsVerified { get; set; }

	public int? bordStatusId { get; set; }

	public int? PreBuyOrderId { get; set; }

	public string Status { get; set; }

	public bool? bordIsFixed { get; set; }

	public int? UserId { get; set; }

	public string UserName { get; set; }

	public string ReferUserName { get; set; }

	public short? Month1 { get; set; }

	public decimal? PaySumOrder { get; set; }

	public decimal? PayRemainOrder { get; set; }

	public decimal? PayRemainAllOrder { get; set; }

	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public double? SumItemPriceAmount { get; set; }

	public int? bordLinkAccCodeId { get; set; }

	public string bordLinkAccCode { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? bordLinkAccVoucherId { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public double? bordItemsQty { get; set; }

	public decimal? bordItemsDiscount { get; set; }

	public decimal? bordItemsTax { get; set; }

	public decimal? bordItemsPriceWithDiscount { get; set; }

	public decimal? bordItemsPriceWithoutDiscount { get; set; }

	public int? bordVerificationWorkFlowId { get; set; }

	public string bordVerificationWorkFlow { get; set; }

	public string LastVerificationWorkFlowStep { get; set; }

	public string LastVerifyUser { get; set; }

	public DateTime? LastVerifyDateTime { get; set; }

	public string bordLinkAccData { get; set; }

	public string bordLinkAccBuyOrderIdStr { get; set; }

	public int? bordSuppUserId { get; set; }

	public string bordSuppUser { get; set; }

	public string bordNote { get; set; }

	public int? bordReqCmpId { get; set; }

	public string bordReqCmp { get; set; }

	public int? bordReqPrsId { get; set; }

	public string bordReqPrs { get; set; }

	public int? bordReqPrjId { get; set; }

	public string bordReqPrjTitle { get; set; }

	public string bordReqPrjPostFix { get; set; }

	public int? bordFacilityCmpId { get; set; }

	public string bordFacilityCmp { get; set; }

	public int? bordFacilityPrsId { get; set; }

	public string bordFacilityPrs { get; set; }

	public int? bordFacilityPrjId { get; set; }

	public string bordFacilityPrjTitle { get; set; }

	public string bordFacilityPrjPostFix { get; set; }

	public string bordCurrencyUnit { get; set; }

	public int? bordCurrencyUnitId { get; set; }
}
