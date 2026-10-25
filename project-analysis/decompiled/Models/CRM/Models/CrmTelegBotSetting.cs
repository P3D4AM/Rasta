using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmTelegBotSettingMetadata))]
public class CrmTelegBotSetting
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

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
