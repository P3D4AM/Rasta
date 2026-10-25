using System;

namespace CRM.Models;

public class CRMspLkSepSelectCompanyById_Result
{
	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpName { get; set; }

	public string CompanyName { get; set; }

	public string cmpCode { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCustomerId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public int? cmpMainPersonId { get; set; }

	public string cmpMainPerson { get; set; }

	public int? SepPartyId { get; set; }

	public int? SepPartyDLRef { get; set; }

	public string SepPartyFullName { get; set; }

	public string SepPartyDLCode { get; set; }

	public DateTime? cmpLinkAccFirstTransferDate { get; set; }

	public DateTime? cmpLinkAccLastTransferDate { get; set; }

	public string cmpLinkAccFirstTransferDateStr { get; set; }

	public string cmpLinkAccLastTransferDateStr { get; set; }
}
