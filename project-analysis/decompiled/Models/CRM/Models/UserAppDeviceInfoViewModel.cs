namespace CRM.Models;

public class UserAppDeviceInfoViewModel
{
	public string DeviceId { get; set; }

	public int DeviceType { get; set; }

	public string AppName { get; set; }

	public bool CrmNotifDeactivInHrm { get; set; }
}
