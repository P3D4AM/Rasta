using System.Collections.Generic;

namespace CRM.Models;

public class TarazSaleComputePromotionViewModel
{
	public TarazSaleComputePromotionHeaderViewModel header { get; set; }

	public List<TarazSaleComputePromotionDetailViewModel> details { get; set; }
}
