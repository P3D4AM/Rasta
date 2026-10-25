using System;

namespace CRM.Models;

public class WSspSelectProductPriceGroupByPrdId_Result
{
	public int ProductPriceGroupID { get; set; }

	public string ProductPriceGroupName { get; set; }

	public string ProductPriceGroupDesc { get; set; }

	public bool? SHPDefaultPriceGroup { get; set; }

	public bool? SHPPriceGroupVisible { get; set; }

	public string LinkAccPrdPriceGroupIdStr { get; set; }

	public DateTime? LastPriceDocDateTime { get; set; }

	public string LastPriceJs { get; set; }
}
