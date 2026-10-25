using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysRollsMetadata))]
public class CrmsysRolls
{
	public int ID { get; set; }

	public string RollName { get; set; }

	public string Description { get; set; }

	public Guid? GUId { get; set; }

	public bool? LimitPreOrderDiscountActive { get; set; }

	public decimal? LimitPreOrderDiscountPercent { get; set; }

	public bool? LimitOrderDiscountActive { get; set; }

	public decimal? LimitOrderDiscountPercent { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroupPermission> CrmKnowledgeTankGroupPermission { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls1 { get; set; }

	public virtual ICollection<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public virtual ICollection<CrmsysRolls_Lang> CrmsysRolls_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms1 { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmsysRolls()
	{
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyFormWorkflowSteps = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
		CrmKnowledgeTankGroupPermission = (ICollection<CrmKnowledgeTankGroupPermission>)new HashSet<CrmKnowledgeTankGroupPermission>();
		CrmLinkedRolls = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmLinkedRolls1 = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmsysRollPermission = (ICollection<CrmsysRollPermission>)new HashSet<CrmsysRollPermission>();
		CrmsysRolls_Lang = (ICollection<CrmsysRolls_Lang>)new HashSet<CrmsysRolls_Lang>();
		UsersPermission = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
		CrmDyForms1 = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyFormWorkflowSteps1 = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
	}
}
