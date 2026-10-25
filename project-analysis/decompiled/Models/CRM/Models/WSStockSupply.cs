using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSStockSupplyMetadata))]
public class WSStockSupply
{
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

	public int? stsupCId { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual ICollection<WSStockSupply_Lang> WSStockSupply_Lang { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public WSStockSupply()
	{
		WSStockSupply_Lang = (ICollection<WSStockSupply_Lang>)new HashSet<WSStockSupply_Lang>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
	}
}
