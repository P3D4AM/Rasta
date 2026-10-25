using System;

namespace CRM.Models;

public class LkCountryInfoViewModel
{
	public int CountryID { get; set; }

	public string CountryCode { get; set; }

	public string Country { get; set; }

	public string CountryDescription { get; set; }

	public string LinkAccCountryIdStr { get; set; }

	public int RowNumber { get; set; }

	public bool Selected { get; set; }

	public Guid? GUId { get; set; }
}
