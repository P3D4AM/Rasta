namespace CRM.Models;

public class ArianSystemLocationListResponseViewModel
{
	public int? LocationID { get; set; }

	public int? FatherLocationID { get; set; }

	public string LocationCode { get; set; }

	public string FatherName { get; set; }

	public string LocationDesc { get; set; }

	public string PreNumber { get; set; }
}
