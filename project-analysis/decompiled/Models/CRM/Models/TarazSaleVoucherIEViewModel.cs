using System.Collections.Generic;

namespace CRM.Models;

public class TarazSaleVoucherIEViewModel
{
	public TarazSaleVoucherHeaderViewModel header { get; set; }

	public TarazSaleVoucherOrderViewModel other { get; set; }

	public List<TarazSaleVoucherDetailViewModel> details { get; set; }

	public List<TarazSaleVoucherPromotionViewModel> promotions { get; set; }

	public List<TarazSaleVoucherElementViewModel> elements { get; set; }
}
