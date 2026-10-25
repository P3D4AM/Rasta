using System.Collections.Generic;

namespace CRM.Models.ReportModel.WareHouseStockPrintRpt;

public class WareHouseStockLinkAccData
{
	public int ProductId { get; set; }

	public List<WareHouseStockLinkAccDataDetail> Details { get; set; }
}
