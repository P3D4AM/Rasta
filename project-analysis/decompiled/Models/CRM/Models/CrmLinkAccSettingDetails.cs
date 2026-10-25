using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccSettingDetailsMetadata))]
public class CrmLinkAccSettingDetails
{
	public int LinkAccSettingDetailId { get; set; }

	public int LinkAccSettingId { get; set; }

	public int? ObjectId { get; set; }

	public string PartField { get; set; }

	public string PartValue { get; set; }

	public string Description { get; set; }

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

	public virtual CrmLinkAccSetting CrmLinkAccSetting { get; set; }

	public virtual ICollection<CrmLinkAccSettingDetails_Lang> CrmLinkAccSettingDetails_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkAccSettingDetails()
	{
		CrmLinkAccSettingDetails_Lang = (ICollection<CrmLinkAccSettingDetails_Lang>)new HashSet<CrmLinkAccSettingDetails_Lang>();
	}
}
