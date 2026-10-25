using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetDyFieldGroupsMetadata))]
public class WSCostSheetDyFieldGroups
{
	public int CostSheetDyFieldGroupId { get; set; }

	public string ctshDyFieldGroupName { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSCostSheetDyFieldGroups_Lang> WSCostSheetDyFieldGroups_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSCostSheetDyFieldTitle> WSCostSheetDyFieldTitle { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSCostSheetDyFieldGroups()
	{
		WSCostSheetDyFieldGroups_Lang = (ICollection<WSCostSheetDyFieldGroups_Lang>)new HashSet<WSCostSheetDyFieldGroups_Lang>();
		WSCostSheetDyFieldTitle = (ICollection<WSCostSheetDyFieldTitle>)new HashSet<WSCostSheetDyFieldTitle>();
	}
}
