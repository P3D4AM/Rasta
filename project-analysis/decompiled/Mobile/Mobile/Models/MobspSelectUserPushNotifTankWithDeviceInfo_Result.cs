namespace Mobile.Models;

public class MobspSelectUserPushNotifTankWithDeviceInfo_Result
{
	public int UserPushNotifTankId { get; set; }

	public int upTypeId { get; set; }

	public int upUserId { get; set; }

	public string upTitle { get; set; }

	public string upBody { get; set; }

	public string upExtraData { get; set; }

	public int? upPriority { get; set; }

	public string DeviceInfo { get; set; }

	public string MobAppDevSetting { get; set; }
}
