using System;

namespace CRM.Models;

public class LkWSDocInfoViewModel
{
	public long RowNumber { get; set; }

	public int DocID { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string SenderName { get; set; }

	public string FactorNumber { get; set; }

	public string Description { get; set; }

	public string SendAddress { get; set; }

	public string DriverName { get; set; }

	public string DriverTel { get; set; }

	public string FreightName { get; set; }

	public string BijakNumber { get; set; }

	public string CarNumber { get; set; }

	public string cmpTitle { get; set; }

	public int? DocLinkAccCodeId { get; set; }

	public string DocLinkAccCode { get; set; }

	public int? DocLinkAccDocId { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public int? DocLinkAccVoucherId { get; set; }

	public string DocLinkAccVoucherNumber { get; set; }

	public string DocLinkAccDocIdStr { get; set; }

	public string DocLinkAccDocType { get; set; }

	public string DocLinkAccData { get; set; }

	public int CompanyId { get; set; }

	public string cmpName { get; set; }

	public string cmpLinkAccCode { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public int? WHId { get; set; }

	public string WrhsName { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsLinkAccWhIdStr { get; set; }

	public int? WHIdI { get; set; }

	public string WrhsNameI { get; set; }

	public string WrhsLinkAccWhCodeI { get; set; }

	public string WrhsLinkAccWhIdStrI { get; set; }

	public string ListItemRecords { get; set; }
}
