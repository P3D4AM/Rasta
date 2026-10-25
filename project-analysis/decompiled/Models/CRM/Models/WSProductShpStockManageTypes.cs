using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductShpStockManageTypesMetadata))]
public class WSProductShpStockManageTypes
{
	public int ProductShpStockManageTypeId { get; set; }

	public string ProductShpStockManageType { get; set; }

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

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductShpStockManageTypes_Lang> WSProductShpStockManageTypes_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductShpStockManageTypes()
	{
		WSProductShpStockManageTypes_Lang = (ICollection<WSProductShpStockManageTypes_Lang>)new HashSet<WSProductShpStockManageTypes_Lang>();
	}
}
