using System.Collections.Generic;

namespace Mobile.Models.ViewModel.OtherSystem.Arpa;

public class ArpaViewModel
{
	public class ArpaProductQuantityResponseViewModel
	{
		public List<ArpaProductQuantityInfoViewModel> data { get; set; }

		public string error { get; set; }
	}

	public class ArpaProductQuantityInfoViewModel
	{
		public string ItemID { get; set; }

		public string ItemCode { get; set; }

		public string ItemName { get; set; }

		public decimal? Qty { get; set; }

		public string StockAreaID { get; set; }

		public string StockAreaName { get; set; }

		public string StockAreaCode { get; set; }
	}
}
