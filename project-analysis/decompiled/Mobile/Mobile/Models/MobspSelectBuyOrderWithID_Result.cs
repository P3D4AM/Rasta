using System;

namespace Mobile.Models;

public class MobspSelectBuyOrderWithID_Result
{
	public int BuyOrderID { get; set; }

	public int BuyOrderOprId { get; set; }

	public int PreBuyOrderId { get; set; }

	public int PreBuyOrderVerifierId { get; set; }

	public string bordTitle { get; set; }

	public long bordNumber { get; set; }

	public string bordOrderNumber { get; set; }

	public string bordDate { get; set; }

	public string bordOrderDate { get; set; }

	public DateTime? bordOrderDateTime { get; set; }

	public int bordCompanyId { get; set; }

	public int bordCompanyPersonId { get; set; }

	public int bordProjectId { get; set; }

	public string bordSubject { get; set; }

	public int bordItemCount { get; set; }

	public decimal bordItemsAmount { get; set; }

	public decimal bordDiscount { get; set; }

	public decimal bordSumAmount { get; set; }

	public decimal bordTax { get; set; }

	public decimal bordTaxIndex { get; set; }

	public bool bordCalculateTax { get; set; }

	public decimal bordTotalAmount { get; set; }

	public string bordTotalAmountStr { get; set; }

	public bool bordIsVerified { get; set; }

	public int bordStatusId { get; set; }

	public bool bordIsFixed { get; set; }

	public int bordPrintFormatId { get; set; }

	public string bordImportDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int bordVerifierId { get; set; }

	public DateTime? bordVerifiedRegisterDate { get; set; }

	public string bordVerifiedRegisterDatePersian { get; set; }

	public int bordFirstRegisterUserId { get; set; }

	public int bordSettlementTypeId { get; set; }

	public string bordDay { get; set; }

	public string bordTime { get; set; }

	public decimal bordTransportation { get; set; }

	public int bordReferUserId { get; set; }

	public decimal bordRound { get; set; }

	public decimal bordDiscountPercent { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public DateTime? bordDateTime { get; set; }

	public DateTime? bordImportDateTime { get; set; }

	public string bordcmpTitle { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int bordCompanyNumber { get; set; }

	public string bordCompany { get; set; }

	public string bordCompanyTel { get; set; }

	public string bordCompanyAddress { get; set; }

	public string bordCompanyPerson { get; set; }

	public string bordCompanyPersonMobile { get; set; }

	public string bordCompanyPersonEmail { get; set; }

	public string bordCompanyPersonEmailII { get; set; }

	public string bordProject { get; set; }

	public string BuyOrderOpr { get; set; }

	public string bordStatus { get; set; }

	public string bordPrintFormat { get; set; }

	public string RegisterUser { get; set; }

	public string bordVerifier { get; set; }

	public string bordFirstRegisterUser { get; set; }

	public string bordReferUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string bordEditAfterFixInfoJs { get; set; }
}
