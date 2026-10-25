using System;

namespace CRM.Models;

public class KyanProductInfoViewModel
{
	public string ItemDescription { get; set; }

	public string itmBrcd { get; set; }

	public string itmCreateDate { get; set; }

	public int itmID { get; set; }

	public string itmName { get; set; }

	public decimal itmPrice { get; set; }

	public decimal itmQuantity { get; set; }

	public decimal itmRsGrpPrice { get; set; }

	public decimal itmRsGrpTempPrice { get; set; }

	public decimal itmTempPrice { get; set; }

	public int? POSDepartmentID { get; set; }

	public string POSDepartmentName { get; set; }

	public string[] serials { get; set; }

	public bool Taxable { get; set; }

	public decimal? UserPrice { get; set; }

	public DateTime itmCreateDate_Datetime { get; set; }

	public string itmCreateDate_Persian { get; set; }

	public long RowNumber { get; set; }

	public int ProductId { get; set; }
}
