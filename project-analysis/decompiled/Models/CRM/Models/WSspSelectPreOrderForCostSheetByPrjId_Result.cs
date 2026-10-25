using System;

namespace CRM.Models;

public class WSspSelectPreOrderForCostSheetByPrjId_Result
{
	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public string prjInquiryNum { get; set; }

	public string prjNumRef { get; set; }

	public long? prjNumR { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public bool? pordIsVerified { get; set; }

	public int? pordVerifierId { get; set; }

	public string pordVerifier { get; set; }

	public DateTime? pordVerifiedRegisterDate { get; set; }

	public string pordVerifiedRegisterDatePersian { get; set; }

	public int? pordStatusId { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordReferUser { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public long? pordNumberRevision { get; set; }

	public string pordNumRef { get; set; }

	public string pordCostSheetIds { get; set; }

	public string pordCostSheets { get; set; }

	public int? pordParentPreOrderId { get; set; }
}
