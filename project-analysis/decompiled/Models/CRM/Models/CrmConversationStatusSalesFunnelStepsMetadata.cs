using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmConversationStatusSalesFunnelStepsMetadata
{
	[Key]
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
}
