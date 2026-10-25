using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysCIDeviceTypeMetadata))]
public class CrmsysCIDeviceType
{
	public int CIDeviceTypeId { get; set; }

	public int CIDeviceTypeMode { get; set; }

	public string CIDeviceType { get; set; }

	public string CIDesc { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmsysCISetting> CrmsysCISetting { get; set; }

	public virtual Users Users { get; set; }

	public CrmsysCIDeviceType()
	{
		CrmsysCISetting = (ICollection<CrmsysCISetting>)new HashSet<CrmsysCISetting>();
	}
}
