using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProvince_Result
{
	public int ProvinceID { get; set; }

	public int CountryId { get; set; }

	public string Country { get; set; }

	public string CountryCode { get; set; }

	public string ProvinceCode { get; set; }

	public string Province { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
