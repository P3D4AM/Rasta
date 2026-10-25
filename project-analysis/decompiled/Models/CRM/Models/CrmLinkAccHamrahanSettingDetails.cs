using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccHamrahanSettingDetailsMetadata))]
public class CrmLinkAccHamrahanSettingDetails
{
	public int LinkAccHamrahanSettingDetailId { get; set; }

	public int LinkAccHamrahanSettingId { get; set; }

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

	public virtual CrmLinkAccHamrahanSetting CrmLinkAccHamrahanSetting { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSettingDetails_Lang> CrmLinkAccHamrahanSettingDetails_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkAccHamrahanSettingDetails()
	{
		CrmLinkAccHamrahanSettingDetails_Lang = (ICollection<CrmLinkAccHamrahanSettingDetails_Lang>)new HashSet<CrmLinkAccHamrahanSettingDetails_Lang>();
	}
}
