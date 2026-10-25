using System;

namespace Mobile.Models;

public class MobspSelectUserAppDeviceInfoByUserId_Result
{
	public int UserAppDeviceInfoId { get; set; }

	public int UserId { get; set; }

	public string DeviceId { get; set; }

	public int DeviceType { get; set; }

	public string AppName { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public string ImeiCode { get; set; }

	public string BaseInfoNeedUpdateDetail { get; set; }

	public DateTime? BaseInfoLastUpdate { get; set; }

	public string DeviceProperty { get; set; }

	public bool? DeviceDeactive { get; set; }
}
