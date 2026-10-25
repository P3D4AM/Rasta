using System;

namespace CRM.Models;

public class CRMspSelectLinkAccSettingUsers_Result
{
	public int LinkAccSettingUserId { get; set; }

	public int CrmUserId { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string CrmUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
