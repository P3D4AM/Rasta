using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsCommentsMetadata))]
public class CrmCmsComments
{
	public int CommentId { get; set; }

	public int ObjectTypeId { get; set; }

	public int ObjectId { get; set; }

	public int? ParentId { get; set; }

	public int? CrmCompanyId { get; set; }

	public string IPAddress { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string Mobile { get; set; }

	public string Tel { get; set; }

	public string Email { get; set; }

	public string Description { get; set; }

	public bool? IsVerified { get; set; }

	public int? VerifiedUserId { get; set; }

	public DateTime? VerifiedDateTime { get; set; }

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

	public virtual CrmCmsObjectTypes CrmCmsObjectTypes { get; set; }

	public virtual ICollection<CrmCmsComments_Lang> CrmCmsComments_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCmsComments()
	{
		CrmCmsComments_Lang = (ICollection<CrmCmsComments_Lang>)new HashSet<CrmCmsComments_Lang>();
	}
}
