using System;

namespace CRM.Models;

public class WSspDocIndicatorSelectOrder_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public bool? ordIsVerified { get; set; }

	public int? ordVerifierId { get; set; }

	public string ordVerifier { get; set; }

	public DateTime? ordVerifiedRegisterDate { get; set; }

	public string ordVerifiedRegisterDatePersian { get; set; }

	public string ordSpecialWord { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordReferUser { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string ordNote { get; set; }

	public decimal? ordTransportation { get; set; }

	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string ordDeliveryTime { get; set; }

	public int? ordDeliveryTermId { get; set; }

	public string ordDeliveryTerm { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordDeliveryDay { get; set; }

	public string ordDeliveryEndDay { get; set; }

	public int ordCompanyId { get; set; }

	public string ordCompany { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public string ordCompanyPerson { get; set; }

	public string ordCompanyPersonIds { get; set; }

	public string ordCompanyPersons { get; set; }

	public int? ordProjectId { get; set; }

	public string ordNumRef { get; set; }

	public long? ordDailyCounter { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public int? ordCurrencyUnitIdI { get; set; }

	public string ordCurrencyUnitI { get; set; }

	public double? ordCurrencyUnitIRate { get; set; }

	public int? OrderItemID { get; set; }

	public int? ordIPrdId { get; set; }

	public string ordIPrdName { get; set; }

	public string ordIPrdCode { get; set; }

	public double? ordIQuantity { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountI { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public decimal? ordIDiscountIPercent { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public decimal? ordIRound { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public string ordIPrdUnit { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public double? ordIPrdWeight { get; set; }

	public string ordProject { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public string DocIds { get; set; }

	public string DocItemIds { get; set; }

	public int? ordIPrdUnitIdII { get; set; }

	public string ordIPrdUnitII { get; set; }

	public double? ordIPrdUnitIIRateResult { get; set; }
}
