using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmProjectTitleGroupsMetadata
{
	[Key]
	public int ProjectTitleGroupId { get; set; }

	public string ProjectTitleGroup { get; set; }

	public string ProjectTitleGroupDesc { get; set; }

	public int? ProjectTitleGroupUserDepartmentId { get; set; }

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

	public virtual Users Users { get; set; }

	public virtual ICollection<CrmProjectTitleGroups_Lang> CrmProjectTitleGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserDepartments UserDepartments { get; set; }

	public virtual Users Users1 { get; set; }
}
