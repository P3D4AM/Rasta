using System;

namespace Mobile.Models;

public class MobspSelectCompanyAppDeviceInfo_Result
{
	public int CompanyAppDeviceInfoId { get; set; }

	public int? CompanyId { get; set; }

	public string DeviceId { get; set; }

	public int? DeviceType { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
