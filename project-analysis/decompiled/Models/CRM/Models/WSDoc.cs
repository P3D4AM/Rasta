using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDocMetadata))]
public class WSDoc
{
	public int DocID { get; set; }

	public int OprId { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public int? SenderId { get; set; }

	public string SenderName { get; set; }

	public string FactorNumber { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int WHId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string OrderIds { get; set; }

	public Guid? GUId { get; set; }

	public int? BuyOrderId { get; set; }

	public string SendAddress { get; set; }

	public string DriverName { get; set; }

	public string DriverTel { get; set; }

	public string FreightName { get; set; }

	public string BijakNumber { get; set; }

	public string CarNumber { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? WHIdI { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public string cmpTitle { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? DocLinkAccCodeId { get; set; }

	public string DocLinkAccCode { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public int? DocLinkAccVoucherId { get; set; }

	public string DocLinkAccVoucherNumber { get; set; }

	public string DocNumRef { get; set; }

	public string DocLinkAccDocIdStr { get; set; }

	public string DocLinkAccDocType { get; set; }

	public bool? IsVerified { get; set; }

	public int? VerifierId { get; set; }

	public DateTime? VerifiedRegisterDate { get; set; }

	public string VerifiedRegisterDatePersian { get; set; }

	public int? VerifierRequestId { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? PreOrderId { get; set; }

	public DateTime? DocLinkAccFirstTransferDate { get; set; }

	public DateTime? DocLinkAccLastTransferDate { get; set; }

	public string DocLinkAccData { get; set; }

	public string EditAfterFixInfoJs { get; set; }

	public int? DocCId { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrder WSBuyOrder { get; set; }

	public virtual ICollection<WSDoc_Lang> WSDoc_Lang { get; set; }

	public virtual WSDocOpr WSDocOpr { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual WsWareHouse WsWareHouse1 { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public WSDoc()
	{
		WSDoc_Lang = (ICollection<WSDoc_Lang>)new HashSet<WSDoc_Lang>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
	}
}
