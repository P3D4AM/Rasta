using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetProductsMetadata))]
public class WSCostSheetProducts
{
	public int CostSheetProductId { get; set; }

	public string ctshPrdName { get; set; }

	public double ctshPrdQuantity { get; set; }

	public int? OrderView { get; set; }

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

	public int? ctshPrdGroupId { get; set; }

	public int? ctshPrdCmpProjectId { get; set; }

	public int? ctshPrdId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual ICollection<WSCostSheetProducts_Lang> WSCostSheetProducts_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSProductSecondGroup WSProductSecondGroup { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSCostSheetProducts()
	{
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheetProducts_Lang = (ICollection<WSCostSheetProducts_Lang>)new HashSet<WSCostSheetProducts_Lang>();
	}
}
