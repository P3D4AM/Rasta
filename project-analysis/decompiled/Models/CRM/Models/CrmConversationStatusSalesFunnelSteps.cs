using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusSalesFunnelStepsMetadata))]
public class CrmConversationStatusSalesFunnelSteps
{
	public int SalesFunnelStepId { get; set; }

	public string SalesFunnelStepTitle { get; set; }

	public int? SalesFunnelStepStatusGroupId { get; set; }

	public string SalesFunnelStepStatusIDs { get; set; }

	public int? SalesFunnelStepOrder { get; set; }

	public string SalesFunnelStepColor { get; set; }

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

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual ICollection<CrmConversationStatusSalesFunnelSteps_Lang> CrmConversationStatusSalesFunnelSteps_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmConversationStatusSalesFunnelSteps()
	{
		CrmConversationStatusSalesFunnelSteps_Lang = (ICollection<CrmConversationStatusSalesFunnelSteps_Lang>)new HashSet<CrmConversationStatusSalesFunnelSteps_Lang>();
	}
}
