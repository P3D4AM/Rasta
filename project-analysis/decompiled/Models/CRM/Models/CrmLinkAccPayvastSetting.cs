using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccPayvastSettingMetadata))]
public class CrmLinkAccPayvastSetting
{
	public int LinkAccPayvastSettingId { get; set; }

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

	public virtual ICollection<CrmLinkAccPayvastSetting_Lang> CrmLinkAccPayvastSetting_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSettingDetails> CrmLinkAccPayvastSettingDetails { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkAccPayvastSetting()
	{
		CrmLinkAccPayvastSetting_Lang = (ICollection<CrmLinkAccPayvastSetting_Lang>)new HashSet<CrmLinkAccPayvastSetting_Lang>();
		CrmLinkAccPayvastSettingDetails = (ICollection<CrmLinkAccPayvastSettingDetails>)new HashSet<CrmLinkAccPayvastSettingDetails>();
	}
}
