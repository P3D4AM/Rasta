using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysDBTempInfoTypeMetadata))]
public class CrmsysDBTempInfoType
{
	public int TypeId { get; set; }

	public string TypeName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmsysDBTempInfo> CrmsysDBTempInfo { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public CrmsysDBTempInfoType()
	{
		CrmsysDBTempInfo = (ICollection<CrmsysDBTempInfo>)new HashSet<CrmsysDBTempInfo>();
	}
}
