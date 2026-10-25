using System;

namespace Mobile.Models;

public class MobspSelectProductPriceGroupByPrdId_Result
{
	public int ProductPriceGroupID { get; set; }

	public string ProductPriceGroupName { get; set; }

	public string ProductPriceGroupDesc { get; set; }

	public bool? SHPDefaultPriceGroup { get; set; }

	public bool? SHPPriceGroupVisible { get; set; }

	public string LinkAccPrdPriceGroupIdStr { get; set; }

	public DateTime? LastPriceDocDateTime { get; set; }
}
