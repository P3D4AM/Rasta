using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectLinkAccSettingDB_Result
{
	public int ApiLinkAccSettingDBId { get; set; }

	public int ApiLinkAccSystemId { get; set; }

	public string ApiLinkAccSettingDbName { get; set; }

	public bool? ApiIsActive { get; set; }

	public string ApiLinkAccSettingServerName { get; set; }

	public string ApiLinkAccSettingDbTitle { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
