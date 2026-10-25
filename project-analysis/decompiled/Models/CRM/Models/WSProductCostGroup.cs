using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductCostGroupMetadata))]
public class WSProductCostGroup
{
	public int ProductCostGroupID { get; set; }

	public string ProductCostGroupName { get; set; }

	public string ProductCostGroupDesc { get; set; }

	public int? OrderView { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost { get; set; }

	public virtual ICollection<WSProductCostGroup_Lang> WSProductCostGroup_Lang { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductCostGroup()
	{
		WSProductCost = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductCostGroup_Lang = (ICollection<WSProductCostGroup_Lang>)new HashSet<WSProductCostGroup_Lang>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
	}
}
