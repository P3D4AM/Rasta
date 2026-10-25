using System.Collections.Generic;

namespace CRM.Models;

public class TarazSaleVoucherInsertResultViewModel
{
	public TarazSaleVoucherHeaderInsertResultViewModel header { get; set; }

	public List<TarazSaleVoucherDetailsInsertResultViewModel> details { get; set; }

	public string _id { get; set; }
}
