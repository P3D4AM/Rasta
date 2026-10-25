using System;

namespace CRM.Models;

public class WSspSelectStockSupplyById_Result
{
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

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string CompanyPersonMobile { get; set; }

	public string CompanyPersonEmail { get; set; }

	public string CompanyPersonEmailII { get; set; }

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

	public int? stsupPrintFormatId { get; set; }

	public string stsupPrintFormat { get; set; }

	public string stsupNote { get; set; }

	public int? stsupItemCount { get; set; }

	public double? stsupItemsQty { get; set; }

	public int? stsupPreOrderId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
