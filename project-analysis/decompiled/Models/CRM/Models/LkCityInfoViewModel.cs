using System;

namespace CRM.Models;

public class LkCityInfoViewModel
{
	public int CityID { get; set; }

	public int ProvinceId { get; set; }

	public string CityCode { get; set; }

	public string City { get; set; }

	public string Description { get; set; }

	public string LinkAccCityIdStr { get; set; }

	public string ProvinceName { get; set; }

	public int RowNumber { get; set; }

	public bool Selected { get; set; }

	public Guid? GUId { get; set; }
}
