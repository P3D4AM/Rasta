using System;

namespace CRM.Models;

public class IssueOrderFromDocViewModel
{
	public int DocId { get; set; }

	public string OrderDate { get; set; }

	public DateTime? OrderDateTime { get; set; }

	public int OrderOprId { get; set; }

	public int OrderReferUserId { get; set; }

	public int OrderPrintFormatID { get; set; }

	public int? OrderDefaultSettingId { get; set; }

	public int? OrderSettlementTypeId { get; set; }

	public string OrderNote { get; set; }

	public string OrderNote_Lang { get; set; }

	public int OrderProjectId { get; set; }

	public string DocItemList { get; set; }
}
