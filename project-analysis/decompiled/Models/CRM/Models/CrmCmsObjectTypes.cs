using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsObjectTypesMetadata))]
public class CrmCmsObjectTypes
{
	public int ObjectTypeId { get; set; }

	public string ObjectType { get; set; }

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

	public virtual ICollection<CrmCmsComments> CrmCmsComments { get; set; }

	public virtual ICollection<CrmCmsFiles> CrmCmsFiles { get; set; }

	public virtual ICollection<CrmCmsLikes> CrmCmsLikes { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsObjectTypes()
	{
		CrmCmsComments = (ICollection<CrmCmsComments>)new HashSet<CrmCmsComments>();
		CrmCmsFiles = (ICollection<CrmCmsFiles>)new HashSet<CrmCmsFiles>();
		CrmCmsLikes = (ICollection<CrmCmsLikes>)new HashSet<CrmCmsLikes>();
	}
}
