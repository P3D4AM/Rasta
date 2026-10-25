using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmAddressingTypeMetadata))]
public class CrmAddressingType
{
	public int AddTypeID { get; set; }

	public string AddressingType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmAddressing> CrmAddressing { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public CrmAddressingType()
	{
		CrmAddressing = (ICollection<CrmAddressing>)new HashSet<CrmAddressing>();
	}
}
