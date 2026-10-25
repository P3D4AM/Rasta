using System;

namespace CRM.Models;

public class CRMspSelectTelegBotSetting_Result
{
	public int TelegBotSettingId { get; set; }

	public string Token { get; set; }

	public string Caption { get; set; }

	public string UserName { get; set; }

	public string Description { get; set; }

	public string About { get; set; }

	public byte[] Picture { get; set; }

	public string WelcomeMessage { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string LanguageCollation { get; set; }

	public bool? IsActive { get; set; }
}
