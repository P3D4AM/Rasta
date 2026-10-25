using System.Collections.Generic;

namespace CRM.Models;

public class HolooInvoiceInfoIEViewModel
{
	public string id { get; set; }

	public int type { get; set; }

	public string customererpcode { get; set; }

	public string date { get; set; }

	public string time { get; set; }

	public decimal? discount { get; set; }

	public string comment { get; set; }

	public string tasviehdate { get; set; }

	public decimal? Nesiyeh { get; set; }

	public List<HolooInvoiceDetailInfoIEViewModel> detailinfo { get; set; }

	public string midManErpCode { get; set; }

	public double? commission { get; set; }
}
