using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFundGroupsMetadata))]
public class CrmFundGroups
{
	public int FundGroupId { get; set; }

	public string GroupName { get; set; }

	public int ParentId { get; set; }

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

	public int? GroupVerificationWorkFlowId { get; set; }

	public virtual ICollection<CrmFund> CrmFund { get; set; }

	public virtual ICollection<CrmFundGroups_Lang> CrmFundGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmFundGroups()
	{
		CrmFund = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFundGroups_Lang = (ICollection<CrmFundGroups_Lang>)new HashSet<CrmFundGroups_Lang>();
	}
}
