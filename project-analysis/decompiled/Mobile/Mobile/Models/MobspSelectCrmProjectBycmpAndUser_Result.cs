using System;

namespace Mobile.Models;

public class MobspSelectCrmProjectBycmpAndUser_Result
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string prjTitle { get; set; }

	public bool? prjIsFinished { get; set; }

	public long? OrderView { get; set; }

	public string ProjectTitle { get; set; }

	public string prjPostFix { get; set; }

	public string prjTitleGroup { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public string prjRemindDate { get; set; }

	public int? prjcmpQuickRegisterDefSettingId { get; set; }

	public int? prjCId { get; set; }
}
