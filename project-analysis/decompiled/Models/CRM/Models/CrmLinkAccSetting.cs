using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccSettingMetadata))]
public class CrmLinkAccSetting
{
	public int LinkAccSettingId { get; set; }

	public string PartTitle { get; set; }

	public string PartField { get; set; }

	public string PartValue { get; set; }

	public string ObjectType { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

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

	public string PreUsedHint { get; set; }

	public int? OrderView { get; set; }

	public int? LinkAccSystemId { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	public virtual ICollection<CrmLinkAccSetting_Lang> CrmLinkAccSetting_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmLinkAccSettingDetails> CrmLinkAccSettingDetails { get; set; }

	public virtual CrmLinkAccSystems CrmLinkAccSystems { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkAccSetting()
	{
		CrmLinkAccSetting_Lang = (ICollection<CrmLinkAccSetting_Lang>)new HashSet<CrmLinkAccSetting_Lang>();
		CrmLinkAccSettingDetails = (ICollection<CrmLinkAccSettingDetails>)new HashSet<CrmLinkAccSettingDetails>();
	}
}
