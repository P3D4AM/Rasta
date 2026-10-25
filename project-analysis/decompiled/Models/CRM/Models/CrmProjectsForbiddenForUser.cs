using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectsForbiddenForUserMetadata))]
public class CrmProjectsForbiddenForUser
{
	public int ProjectsForbiddenForUserID { get; set; }

	public int? CrmUserId { get; set; }

	public string ForbiddenProjectTitle { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? CId { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser_Lang> CrmProjectsForbiddenForUser_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmProjectsForbiddenForUser()
	{
		CrmProjectsForbiddenForUser_Lang = (ICollection<CrmProjectsForbiddenForUser_Lang>)new HashSet<CrmProjectsForbiddenForUser_Lang>();
	}
}
