using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintDocListRpt;

public class DocListLinkAccData
{
	public int ProductId { get; set; }

	public List<DocListStockLinkAccDataDetail> Details { get; set; }
}
