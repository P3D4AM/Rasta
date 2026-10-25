using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccSystemsMetadata))]
public class CrmLinkAccSystems
{
	public int LinkAccSystemId { get; set; }

	public string SystemTitle { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<CrmLinkAccByViewSetting> CrmLinkAccByViewSetting { get; set; }

	public virtual ICollection<CrmLinkAccSetting> CrmLinkAccSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkAccSystems()
	{
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmLinkAccByViewSetting = (ICollection<CrmLinkAccByViewSetting>)new HashSet<CrmLinkAccByViewSetting>();
		CrmLinkAccSetting = (ICollection<CrmLinkAccSetting>)new HashSet<CrmLinkAccSetting>();
	}
}
