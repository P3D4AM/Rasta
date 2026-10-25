using System;

namespace CRM.Models;

public class CrmMobSettingMetadata
{
	public int MobSettingId { get; set; }

	public string AppName { get; set; }

	public string DefPrjTitle { get; set; }

	public string LoginPrjTitle { get; set; }

	public string CallPrjTitle { get; set; }

	public string CallAfterSendMessage { get; set; }

	public string InstallPrjTitle { get; set; }

	public string CheckPrjTitle { get; set; }

	public string EdtReqPrjTitle { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public string DefCnvsDesc { get; set; }
}
