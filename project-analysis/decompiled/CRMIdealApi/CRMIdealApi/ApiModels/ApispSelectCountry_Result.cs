using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCountry_Result
{
	public int CountryID { get; set; }

	public string CountryCode { get; set; }

	public string Country { get; set; }

	public string CountryDescription { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
