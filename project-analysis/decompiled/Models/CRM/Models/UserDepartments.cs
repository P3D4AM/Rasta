using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserDepartmentsMetadata))]
public class UserDepartments
{
	public int DepartmentID { get; set; }

	public string Department { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? DefaultTicketUserId { get; set; }

	public string TicketFooterText { get; set; }

	public int? LeaveVerificationWorkFlowId { get; set; }

	public int? MissionVerificationWorkFlowId { get; set; }

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<UserDepartments_Lang> UserDepartments_Lang { get; set; }

	public virtual ICollection<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers { get; set; }

	public virtual ICollection<CrmProjectTitleGroups> CrmProjectTitleGroups { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows1 { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public UserDepartments()
	{
		UserDepartments_Lang = (ICollection<UserDepartments_Lang>)new HashSet<UserDepartments_Lang>();
		UserDepartmentTicketReferUsers = (ICollection<UserDepartmentTicketReferUsers>)new HashSet<UserDepartmentTicketReferUsers>();
		CrmProjectTitleGroups = (ICollection<CrmProjectTitleGroups>)new HashSet<CrmProjectTitleGroups>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
	}
}
