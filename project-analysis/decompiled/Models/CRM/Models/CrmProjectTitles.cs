using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectTitlesMetadata))]
public class CrmProjectTitles
{
	public int ProjectTitleID { get; set; }

	public string ProjectTitle { get; set; }

	public int? ProjectTitleGroupId { get; set; }

	public int? ProjectTitleStatusGroupId { get; set; }

	public int? ProjectTitleGradeId { get; set; }

	public int? ProjectTitlePriorityId { get; set; }

	public string ProjectTitleDesc { get; set; }

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

	public bool? ActivePrjNumRWithTitle { get; set; }

	public int? PrjTitleGroupId { get; set; }

	public string PrjPostFix { get; set; }

	public int? PrjRemindDay { get; set; }

	public bool? PrjFOCmpCanSee { get; set; }

	public bool? PrjIsTicket { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmProjectGrade CrmProjectGrade { get; set; }

	public virtual CrmProjectGroups CrmProjectGroups { get; set; }

	public virtual CrmProjectPriority CrmProjectPriority { get; set; }

	public virtual CrmProjectTitleGroups CrmProjectTitleGroups { get; set; }

	public virtual ICollection<CrmProjectTitles_Lang> CrmProjectTitles_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProducts> WSProducts1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmProjectTitles()
	{
		CrmProjectTitles_Lang = (ICollection<CrmProjectTitles_Lang>)new HashSet<CrmProjectTitles_Lang>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProducts1 = (ICollection<WSProducts>)new HashSet<WSProducts>();
	}
}
