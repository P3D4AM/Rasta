using System;

namespace CRM.Models;

public class CRMspSelectCompanyProvince_Result
{
	public int ProvinceID { get; set; }

	public int CountryId { get; set; }

	public string ProvinceCode { get; set; }

	public string Province { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }
}
