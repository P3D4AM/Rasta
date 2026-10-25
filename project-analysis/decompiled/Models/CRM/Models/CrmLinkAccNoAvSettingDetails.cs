using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccNoAvSettingDetailsMetadata))]
public class CrmLinkAccNoAvSettingDetails
{
	public int LinkAccNoAvSettingDetailId { get; set; }

	public int LinkAccNoAvSettingId { get; set; }

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

	public virtual CrmLinkAccNoAvSetting CrmLinkAccNoAvSetting { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSettingDetails_Lang> CrmLinkAccNoAvSettingDetails_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkAccNoAvSettingDetails()
	{
		CrmLinkAccNoAvSettingDetails_Lang = (ICollection<CrmLinkAccNoAvSettingDetails_Lang>)new HashSet<CrmLinkAccNoAvSettingDetails_Lang>();
	}
}
