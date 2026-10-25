using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectTitleGroupsMetadata))]
public class CrmProjectTitleGroups
{
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

	public bool? ProjectTitleGroupAgreementActive { get; set; }

	public string ProjectTitleGroupAgreementDesc { get; set; }

	public string ProjectTitleGroupSubjectDefaultContext { get; set; }

	public bool? ProjectTitleGroupTicketCountCurrentWithStop { get; set; }

	public int? ProjectTitleGroupTicketAllowInCurrentCount { get; set; }

	public string ProjectTitleGroupColor { get; set; }

	public virtual ICollection<CrmProjectTitleGroups_Lang> CrmProjectTitleGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserDepartments UserDepartments { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProducts> WSProducts1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmProjectTitleGroups()
	{
		CrmProjectTitleGroups_Lang = (ICollection<CrmProjectTitleGroups_Lang>)new HashSet<CrmProjectTitleGroups_Lang>();
		CrmProjectTitles = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProducts1 = (ICollection<WSProducts>)new HashSet<WSProducts>();
	}
}
