using System.Collections.Generic;

namespace Mobile.Models.ViewModel.OtherSystem.Hamrahan;

public class HamrahanViewModel
{
	public class HamrahanGetTokenResponseViewModel
	{
		public bool? isSuccess { get; set; }

		public string message { get; set; }

		public string token { get; set; }
	}

	public class HamrahanProductQtyViewModel
	{
		public int company { get; set; }

		public int userID { get; set; }

		public int refSaleCenter { get; set; }

		public int refSaleMethod { get; set; }

		public int kindOfService { get; set; }

		public int refProcess { get; set; }

		public string documentDate { get; set; }

		public string codeObject { get; set; }

		public double qty { get; set; }

		public int rnValuta { get; set; }

		public int refGroupCustomer { get; set; }

		public int refCustomer { get; set; }
	}

	public class HamrahanProductQtyInfoViewModel
	{
		public int? rnPhysical { get; set; }

		public string namePhysical { get; set; }

		public int? rnObject { get; set; }

		public int? rnScruple { get; set; }

		public string nameScruple { get; set; }

		public string codeObject { get; set; }

		public string nameObject { get; set; }

		public double? cellarValue { get; set; }

		public decimal? rsvValue { get; set; }

		public decimal? rate { get; set; }

		public List<HamrahanLinkInfoViewModel> links { get; set; }
	}

	public class HamrahanLinkInfoViewModel
	{
		public string href { get; set; }

		public string rel { get; set; }

		public string method { get; set; }
	}
}
