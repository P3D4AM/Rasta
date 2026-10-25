using System.Collections.Generic;

namespace CRM.Models;

public class LkProductInfoViewModel
{
	public long RowNumber { get; set; }

	public int ProductId { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdDescription { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public bool? PrdInActive { get; set; }

	public int? PrdKind { get; set; }

	public double? PrdUnitIRate { get; set; }

	public string PrdModel { get; set; }

	public double? PrdWeight { get; set; }

	public double? PrdUnitIIRate { get; set; }

	public string SGName { get; set; }

	public string SGLinkAccGroupCode { get; set; }

	public string SGLinkAccGroupIdStr { get; set; }

	public string SGLinkAccGroupName { get; set; }

	public string SGLinkAccGroups { get; set; }

	public string Unit { get; set; }

	public string UnitLinkAccUnitIdStr { get; set; }

	public string UnitI { get; set; }

	public string UnitLinkAccUnitIdStrI { get; set; }

	public string UnitII { get; set; }

	public string UnitLinkAccUnitIdStrII { get; set; }

	public decimal Price { get; set; }

	public decimal Dicount { get; set; }

	public decimal DicountPercent { get; set; }

	public List<LkProductPriceInfoViewModel> PriceList { get; set; }

	public decimal Cost { get; set; }

	public string ListItemRecords { get; set; }
}
