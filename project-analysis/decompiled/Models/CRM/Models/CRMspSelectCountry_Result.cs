using System;

namespace CRM.Models;

public class CRMspSelectCountry_Result
{
	public int CountryID { get; set; }

	public string CountryCode { get; set; }

	public string Country { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string CountryDescription { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string LinkAccCountryIdStr { get; set; }

	public string LinkAccData { get; set; }
}
