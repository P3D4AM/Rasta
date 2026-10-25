using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkedTypeMetadata))]
public class CrmLinkedType
{
	public int LinkedTypeID { get; set; }

	public short TypeOrder { get; set; }

	public string LinkTypeName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls { get; set; }

	public virtual ICollection<CrmLinkedType_Lang> CrmLinkedType_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmLinkedType()
	{
		CrmLinkedRolls = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmLinkedType_Lang = (ICollection<CrmLinkedType_Lang>)new HashSet<CrmLinkedType_Lang>();
		CrmLinkedUserPositions = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		CrmLinkedUsers = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
	}
}
