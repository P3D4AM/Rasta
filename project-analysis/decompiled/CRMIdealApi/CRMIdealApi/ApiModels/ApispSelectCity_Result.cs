using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCity_Result
{
	public int CityID { get; set; }

	public int ProvinceId { get; set; }

	public string Province { get; set; }

	public string ProvinceCode { get; set; }

	public string CityCode { get; set; }

	public string City { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? CountryID { get; set; }

	public string Country { get; set; }

	public string CountryCode { get; set; }
}
