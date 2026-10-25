using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductShpStockManageTypesMetadata
{
	[Key]
	public int ProductShpStockManageTypeId { get; set; }

	public string ProductShpStockManageType { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
