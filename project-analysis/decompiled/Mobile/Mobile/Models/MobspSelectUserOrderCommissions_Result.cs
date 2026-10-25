using System;

namespace Mobile.Models;

public class MobspSelectUserOrderCommissions_Result
{
	public string CommUser { get; set; }

	public string CmpReferUser { get; set; }

	public string CmpProject { get; set; }

	public int? ordProjectId { get; set; }

	public string CmpCity { get; set; }

	public string cmpActivityType { get; set; }

	public string cmpGroup { get; set; }

	public string cmpSubGroup { get; set; }

	public string cmpGroupII { get; set; }

	public string cmpGroupIII { get; set; }

	public string cmpGroupIV { get; set; }

	public string cmpType { get; set; }

	public string cmpPresentation { get; set; }

	public string cmpWebSite { get; set; }

	public string cmpSpecialPoint { get; set; }

	public string cmpDescription { get; set; }

	public string cmpFirstRegisterUser { get; set; }

	public DateTime? cmpFirstRegisterDate { get; set; }

	public string cmpEconomicCode { get; set; }

	public DateTime? cmpEffectiveDateTime { get; set; }

	public string OrdCmp { get; set; }

	public string OrdPerson { get; set; }

	public string OrderOpr { get; set; }

	public int? OrderOprID { get; set; }

	public string OrdDate { get; set; }

	public DateTime? OrdDateTime { get; set; }

	public string ordItemSumPrice { get; set; }

	public string ordItemSumDiscount { get; set; }

	public string ordItemsAmount { get; set; }

	public string ordDiscount { get; set; }

	public string ordSumAmount { get; set; }

	public string ordAllDiscount { get; set; }

	public string ordAllDiscountPercent { get; set; }

	public string ordTax { get; set; }

	public string ordTotalAmount { get; set; }

	public string ordPayAmount { get; set; }

	public string ordPayDocDetails { get; set; }

	public string ordPayRemain { get; set; }

	public string YearMonthCommDate { get; set; }

	public string CommDatePersianFN { get; set; }

	public int OrderCommissionId { get; set; }

	public DateTime CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int CommOrderId { get; set; }

	public int CommCmpId { get; set; }

	public int? CommUserId { get; set; }

	public decimal? CommBaseAmountDec { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public decimal CommBaseAmount { get; set; }

	public string CommBaseAmountFormated { get; set; }

	public double? CommRate { get; set; }

	public string CommRateDesc { get; set; }

	public decimal CommAmount { get; set; }

	public string CommAmountFormated { get; set; }

	public DateTime? CommEffectiveDateTime { get; set; }

	public string CommEffectiveDatePersian { get; set; }

	public int? CommPayTypeId { get; set; }

	public string CommPayType { get; set; }

	public int? CommStatusId { get; set; }

	public string CommDesc { get; set; }

	public bool? CommIsVerified { get; set; }

	public int? CommVerifierUserId { get; set; }

	public string CommVerifierUser { get; set; }

	public DateTime? CommVerifiedDateTime { get; set; }

	public string CommVerifiedDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public bool? CommIsPaid { get; set; }

	public DateTime? CommIsPaidDateTime { get; set; }

	public string CommIsPaidDatePersian { get; set; }

	public int? CommIsPaidPayRollUserCycleId { get; set; }

	public int? CommIsPaidUserId { get; set; }

	public string CommIsPaidUser { get; set; }

	public string PaidPayRollUserCycle { get; set; }

	public string rptUser { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string SUMCommAmount { get; set; }

	public string SUMordSumAmount { get; set; }

	public long? ordNumber { get; set; }

	public long? ordDailyCounter { get; set; }

	public string ordNumRef { get; set; }

	public string ordIProductNames { get; set; }

	public long? RowNumber { get; set; }

	public int? CommUserIdI { get; set; }

	public string CommUserI { get; set; }

	public decimal? CommAmountI { get; set; }

	public int? CommUserIdII { get; set; }

	public string CommUserII { get; set; }

	public decimal? CommAmountII { get; set; }

	public int? CommUserIdIII { get; set; }

	public string CommUserIII { get; set; }

	public decimal? CommAmountIII { get; set; }

	public int? CommUserIdIByPayType { get; set; }

	public string CommUserIByPayType { get; set; }

	public decimal? CommAmountIByPayType { get; set; }

	public int? CommUserIdIIByPayType { get; set; }

	public string CommUserIIByPayType { get; set; }

	public decimal? CommAmountIIByPayType { get; set; }

	public int? CommUserIdIIIByPayType { get; set; }

	public string CommUserIIIByPayType { get; set; }

	public decimal? CommAmountIIIByPayType { get; set; }

	public decimal? SUMCommBaseAmountDecInOrd { get; set; }

	public decimal? SUMCommAmountInOrd { get; set; }

	public decimal? SUMCommBaseAmountDecInOrdByTerm { get; set; }

	public decimal? SUMCommAmountInOrdByTerm { get; set; }

	public int? AllPage { get; set; }

	public long? ManualRowNumber { get; set; }

	public string CommKindTitle { get; set; }

	public string CommTypeTitle { get; set; }

	public string CommTypeCmp { get; set; }

	public string CommPrsMobile { get; set; }

	public string CommCmpTel { get; set; }

	public bool? CommIsPreVerified { get; set; }

	public int? CommPreVerifierUserId { get; set; }

	public string CommPreVerifierUser { get; set; }

	public DateTime? CommPreVerifiedDate { get; set; }

	public string CommPreVerifiedDatePersian { get; set; }
}
