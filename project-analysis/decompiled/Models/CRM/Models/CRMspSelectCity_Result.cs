using System;

namespace CRM.Models;

public class CRMspSelectCity_Result
{
	public int CityID { get; set; }

	public int ProvinceId { get; set; }

	public string CityCode { get; set; }

	public string City { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string LinkAccCityIdStr { get; set; }

	public string ProvinceName { get; set; }

	public string LinkAccData { get; set; }
}
