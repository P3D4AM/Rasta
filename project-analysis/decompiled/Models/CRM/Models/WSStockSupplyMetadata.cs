using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSStockSupplyMetadata
{
	[Key]
	public int StockSupplyId { get; set; }

	public int StockSupplyOprId { get; set; }

	public int stsupReferUserId { get; set; }

	public long stsupNumber { get; set; }

	public DateTime stsupDateTime { get; set; }

	public string stsupDate { get; set; }

	public int? stsupCompanyId { get; set; }

	public int? stsupCompanyPersonId { get; set; }

	public int? stsupProjectId { get; set; }

	public bool? stsupIsFixed { get; set; }

	public bool? stsupIsCanceled { get; set; }

	public bool? stsupIsVerified { get; set; }

	public int? stsupVerifierRequestId { get; set; }

	public int? stsupVerifierId { get; set; }

	public DateTime? stsupVerifiedRegisterDate { get; set; }

	public string stsupVerifiedRegisterDatePersian { get; set; }

	public int? stsupVerificationWorkFlowId { get; set; }

	public int? stsupPrintFormatId { get; set; }

	public string stsupNote { get; set; }

	public int? stsupItemCount { get; set; }

	public double? stsupItemsQty { get; set; }

	public int? stsupPreOrderId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
