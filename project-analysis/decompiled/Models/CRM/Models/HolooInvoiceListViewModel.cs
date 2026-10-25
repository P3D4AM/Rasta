using System.Collections.Generic;

namespace CRM.Models;

public class HolooInvoiceListViewModel
{
	public long? Code { get; set; }

	public string Type { get; set; }

	public long? SanadCode { get; set; }

	public string CustomerName { get; set; }

	public string CustomerErpCode { get; set; }

	public string customerCodeC { get; set; }

	public string Date { get; set; }

	public string Time { get; set; }

	public decimal? SumNaghd { get; set; }

	public decimal? SumCard { get; set; }

	public decimal? SumNesiyeh { get; set; }

	public decimal? SumDiscount { get; set; }

	public decimal? SumCheck { get; set; }

	public decimal? SumLevy { get; set; }

	public decimal? SumScot { get; set; }

	public decimal? SumPrice { get; set; }

	public string comment { get; set; }

	public string tasviehdate { get; set; }

	public string ErpCode { get; set; }

	public List<HolooInvoiceDetailListViewModel> Detail { get; set; }

	public string DatePersian { get; set; }

	public int OrderId { get; set; }

	public int RowNumber { get; set; }
}
