using System.Collections.Generic;

namespace CRM.Models;

public class TarazSaleComputePromotionResultViewModel
{
	public List<TarazSaleComputePromotionsResultViewModel> promotions { get; set; }

	public List<TarazSaleComputePromotionElementsResultViewModel> elements { get; set; }

	public string _id { get; set; }
}
