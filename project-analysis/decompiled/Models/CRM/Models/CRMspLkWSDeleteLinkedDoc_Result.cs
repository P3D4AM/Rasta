using System;

namespace CRM.Models;

public class CRMspLkWSDeleteLinkedDoc_Result
{
	public int DocID { get; set; }

	public int OprId { get; set; }

	public string Opr { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public int WHId { get; set; }

	public string WHName { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? WHIdI { get; set; }

	public string WHNameI { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public int? DocLinkAccCodeId { get; set; }

	public string DocLinkAccCode { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public int? DocLinkAccVoucherId { get; set; }

	public string DocLinkAccVoucherNumber { get; set; }

	public string DocLinkAccDocIdStr { get; set; }

	public string DocLinkAccDocType { get; set; }
}
