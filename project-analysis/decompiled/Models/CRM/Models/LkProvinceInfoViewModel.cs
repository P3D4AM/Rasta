using System;

namespace CRM.Models;

public class LkProvinceInfoViewModel
{
	public int ProvinceID { get; set; }

	public int CountryId { get; set; }

	public string ProvinceCode { get; set; }

	public string Province { get; set; }

	public string Description { get; set; }

	public string LinkAccProvinceIdStr { get; set; }

	public string CountryName { get; set; }

	public int RowNumber { get; set; }

	public bool Selected { get; set; }

	public Guid? GUId { get; set; }
}
