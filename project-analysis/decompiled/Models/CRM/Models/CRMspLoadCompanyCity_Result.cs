using System;

namespace CRM.Models;

public class CRMspLoadCompanyCity_Result
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
}
