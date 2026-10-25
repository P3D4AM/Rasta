using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectDocByDocId_Result
{
	public int DocID { get; set; }

	public int OprId { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public int WHId { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? WHIdI { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? DocLinkAccCodeId { get; set; }

	public string DocLinkAccCode { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public int? DocLinkAccVoucherId { get; set; }

	public string DocLinkAccVoucherNumber { get; set; }

	public string DocLinkAccDocIdStr { get; set; }

	public string DocLinkAccDocType { get; set; }

	public string DocOpr { get; set; }

	public int? DocOprType { get; set; }

	public string WrhsName { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsNameI { get; set; }

	public int? WrhsLinkAccWhIdI { get; set; }

	public string WrhsLinkAccWhCodeI { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string CompanyName { get; set; }

	public string CompanyCode { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCustomerId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public int? SepDocId { get; set; }

	public int? SepDocNumber { get; set; }

	public DateTime? SepDocDate { get; set; }

	public string SepDocDatePersian { get; set; }

	public int? SepDocType { get; set; }

	public string SepDocTypeTitle { get; set; }

	public int? SepDocStockRef { get; set; }

	public string SepDocStockName { get; set; }

	public int? SepDocDestinationStockRef { get; set; }

	public string SepDocDestinationStockName { get; set; }

	public int? SepDocPartyRef { get; set; }

	public string SepDocPartyFullName { get; set; }

	public string SepDocPartyCode { get; set; }

	public int? SepVoucherId { get; set; }

	public int? SepVoucherNumber { get; set; }

	public DateTime? DocLinkAccFirstTransferDate { get; set; }

	public DateTime? DocLinkAccLastTransferDate { get; set; }

	public string DocLinkAccFirstTransferDateStr { get; set; }

	public string DocLinkAccLastTransferDateStr { get; set; }
}
